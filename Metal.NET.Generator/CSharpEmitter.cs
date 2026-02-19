using System.Text;

namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-cpp definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// </summary>
class CSharpEmitter(string outputDir, GeneratorContext context, TypeMapper typeMapper)
{
    /// <summary>
    /// Hand-written classes to skip during generation.
    /// </summary>
    static readonly HashSet<string> SkipClasses = ["NSString", "NSError", "NSArray", "NSURL",
        "NSDictionary", "NSNotification", "NSNotificationCenter", "NSSet", "NSEnumerator",
        "NSObject", "NSProcessInfo", "NSBundle", "NSAutoreleasePool", "NSNumber", "NSValue",
        "NSDate"];

    #region Generation Entry Point

    public void GenerateAll()
    {
        foreach (var enumDef in context.Enums)
        {
            GenerateEnum(enumDef);
        }

        // Build known class names (both generated and hand-written)
        foreach (var classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            context.KnownClassNames.Add(prefix + classDef.Name);
        }
        context.KnownClassNames.UnionWith(["NSString", "NSError", "NSArray", "NSURL", "NativeObject"]);

        // Build a map of class name → property names for inheritance detection
        var classPropertyMap = new Dictionary<string, HashSet<string>>();
        foreach (var classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            string csClassName = prefix + classDef.Name;
            var propNames = classDef.Methods
                .Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget)
                .Select(m => TypeMapper.ToPascalCase(m.CppName))
                .ToHashSet();
            classPropertyMap[csClassName] = propNames;
        }

        // Build inherited property names by walking the inheritance chain
        HashSet<string> GetInheritedProperties(string csClassName)
        {
            var result = new HashSet<string>();
            if (!classPropertyMap.ContainsKey(csClassName)) return result;
            var classDef = context.Classes.First(c => TypeMapper.GetPrefix(c.CppNamespace) + c.Name == csClassName);
            var current = classDef.BaseClassName;
            while (current != null && context.KnownClassNames.Contains(current) && classPropertyMap.TryGetValue(current, out var parentProps))
            {
                result.UnionWith(parentProps);
                var parentDef = context.Classes.FirstOrDefault(c => TypeMapper.GetPrefix(c.CppNamespace) + c.Name == current);
                current = parentDef?.BaseClassName;
            }
            return result;
        }

        // Build lookup of free functions per target class
        var freeFuncsByClass = context.FreeFunctions
            .GroupBy(f => f.TargetClassName)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            string csClassName = prefix + classDef.Name;
            var inheritedProps = GetInheritedProperties(csClassName);
            freeFuncsByClass.TryGetValue(csClassName, out var classFuncs);
            GenerateClass(classDef, inheritedProps, classFuncs ?? []);
        }
    }

    #endregion

    #region Enum Generation

    void GenerateEnum(EnumDef enumDef)
    {
        string prefix = TypeMapper.GetPrefix(enumDef.CppNamespace);
        string csEnumName = prefix + enumDef.Name;
        string subdir = TypeMapper.GetOutputSubdir(enumDef.CppNamespace);
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        var sb = new StringBuilder();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        if (enumDef.IsFlags)
            sb.AppendLine("[Flags]");

        sb.AppendLine($"public enum {csEnumName} : {enumDef.BackingType}");
        sb.AppendLine("{");

        for (int i = 0; i < enumDef.Members.Count; i++)
        {
            var member = enumDef.Members[i];
            string comma = i < enumDef.Members.Count - 1 ? "," : "";
            if (i > 0) sb.AppendLine();
            sb.AppendLine($"    {member.Name} = {member.Value}{comma}");
        }

        sb.AppendLine("}");
        File.WriteAllText(Path.Combine(dir, $"{csEnumName}.cs"), sb.ToString());
        Console.WriteLine($"  Generated: {subdir}/{csEnumName}.cs");
    }

    #endregion

    #region Class Generation

    void GenerateClass(ClassDef classDef, HashSet<string> inheritedProperties, List<FreeFunctionDef> freeFunctions)
    {
        string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
        string csClassName = prefix + classDef.Name;

        if (SkipClasses.Contains(csClassName)) return;

        string subdir = TypeMapper.GetOutputSubdir(classDef.CppNamespace);
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        bool hasClassField = context.RegisteredClasses.Contains(csClassName);
        bool hasFreeFunctions = freeFunctions.Count > 0;

        // Filter out methods with unmapped array params, function pointer params, or unmappable types
        var validMethods = classDef.Methods
            .Where(m => !m.Parameters.Any(p => p.CppType == "ARRAY_PARAM"))
            .Where(m => !HasUnmergableArrayParam(m))
            .Where(m => !HasFunctionPointerParam(m))
            .Where(m => !HasUnmappableParam(m))
            .ToList();

        var hasZeroParamVersion = validMethods
            .Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget)
            .Select(m => m.CppName).ToHashSet();

        var (properties, methods) = CategorizeMembers(validMethods, classDef.CppNamespace);

        var selectors = new SortedDictionary<string, string>();
        var sb = new StringBuilder();

        if (hasFreeFunctions)
        {
            sb.AppendLine("using System.Runtime.InteropServices;");
            sb.AppendLine();
        }

        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        string baseClass = classDef.BaseClassName != null && context.KnownClassNames.Contains(classDef.BaseClassName)
            ? classDef.BaseClassName
            : "NativeObject";
        string partialKeyword = hasFreeFunctions ? "partial " : "";
        sb.AppendLine($"public {partialKeyword}class {csClassName}(nint nativePtr, bool retain) : {baseClass}(nativePtr, retain)");
        sb.AppendLine("{");

        bool hasPrecedingMember = false;
        if (hasClassField)
        {
            sb.AppendLine($"    public {csClassName}() : this(ObjectiveCRuntime.AllocInit({csClassName}Bindings.Class), false)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        // Properties (sorted alphabetically)
        foreach (var prop in properties)
        {
            int prevLen = sb.Length;
            if (hasPrecedingMember) sb.AppendLine();
            if (EmitProperty(sb, prop, csClassName, classDef.CppNamespace, selectors, inheritedProperties))
                hasPrecedingMember = true;
            else
                sb.Length = prevLen;
        }

        // Methods
        foreach (var method in methods)
        {
            if (hasPrecedingMember) sb.AppendLine();
            EmitMethod(sb, method, csClassName, classDef.CppNamespace, selectors, hasClassField, hasZeroParamVersion);
            hasPrecedingMember = true;
        }

        // Static free functions
        foreach (var func in freeFunctions)
        {
            if (hasPrecedingMember) sb.AppendLine();
            EmitFreeFunction(sb, func, classDef.CppNamespace);
            hasPrecedingMember = true;
        }

        sb.AppendLine("}");
        sb.AppendLine();

        // Bindings class
        sb.AppendLine($"file static class {csClassName}Bindings");
        sb.AppendLine("{");

        bool first = true;
        if (hasClassField)
        {
            sb.AppendLine($"    public static readonly nint Class = ObjectiveCRuntime.GetClass(\"{csClassName}\");");
            first = false;
        }

        foreach (var (name, objc) in selectors)
        {
            if (!first) sb.AppendLine();
            sb.AppendLine($"    public static readonly Selector {name} = \"{objc}\";");
            first = false;
        }
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(dir, $"{csClassName}.cs"), sb.ToString());
        Console.WriteLine($"  Generated: {subdir}/{csClassName}.cs");
    }

    #endregion

    #region Member Categorization

    (List<PropertyDef> Properties, List<MethodInfo> Methods) CategorizeMembers(
        List<MethodInfo> allMethods, string ns)
    {
        var properties = new List<PropertyDef>();
        var methods = new List<MethodInfo>();
        var used = new HashSet<MethodInfo>(ReferenceEqualityComparer.Instance);

        // Build setter map
        var setterMap = new Dictionary<string, MethodInfo>(StringComparer.Ordinal);
        foreach (var m in allMethods)
        {
            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3]) &&
                m.ReturnType == "void" && m.Parameters.Count == 1)
            {
                string propName = char.ToLower(m.CppName[3]) + (m.CppName.Length > 4 ? m.CppName[4..] : "");
                setterMap[propName] = m;
            }
        }

        // Find getters
        foreach (var m in allMethods)
        {
            if (m.ReturnType == "void") continue;
            if (m.Parameters.Count > 0) continue;
            if (m.UsesClassTarget) continue;
            if (used.Contains(m)) continue;
            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3])) continue;
            if (TypeMapper.IsOwnershipTransferMethod(m.CppName)) continue;

            MethodInfo? setter = null;
            if (setterMap.TryGetValue(m.CppName, out var s))
            {
                setter = s;
                used.Add(s);
            }

            properties.Add(new PropertyDef(m, setter));
            used.Add(m);
        }

        // Remaining become methods
        foreach (var m in allMethods)
        {
            if (used.Contains(m)) continue;
            methods.Add(m);
        }

        properties.Sort((a, b) => string.Compare(
            TypeMapper.ToPascalCase(a.Getter.CppName), TypeMapper.ToPascalCase(b.Getter.CppName), StringComparison.Ordinal));

        return (properties, methods);
    }

    #endregion

    #region Method Filtering

    static bool HasFunctionPointerParam(MethodInfo method)
    {
        return method.Parameters.Any(p =>
            p.CppType.Contains("Handler") || p.CppType.Contains("Block") ||
            p.CppType.Contains("function") || p.CppType.Contains("std::function") ||
            p.CppType.Contains("void(") || p.CppType.Contains("Function&") ||
            p.CppType.Contains("Function &"));
    }

    bool HasUnmappableParam(MethodInfo method)
    {
        foreach (var p in method.Parameters)
        {
            if (p.CppType.StartsWith("OBJ_ARRAY:") || p.CppType.StartsWith("PRIM_ARRAY:") || p.CppType.StartsWith("STRUCT_ARRAY:") || p.CppType == "ARRAY_PARAM") continue;
            if (TypeMapper.IsUnmappableCppType(p.CppType)) return true;
        }
        if (TypeMapper.IsUnmappableCppType(method.ReturnType)) return true;
        return false;
    }

    static bool HasUnmergableArrayParam(MethodInfo method)
    {
        var p = method.Parameters;
        for (int i = 0; i < p.Count; i++)
        {
            if (p[i].CppType.StartsWith("OBJ_ARRAY:") || p[i].CppType.StartsWith("PRIM_ARRAY:") || p[i].CppType.StartsWith("STRUCT_ARRAY:"))
            {
                bool nextIsCount = i + 1 < p.Count &&
                    p[i + 1].CppType is "NS::UInteger" &&
                    p[i + 1].Name is "count";
                if (!nextIsCount)
                    return true;
            }
        }
        return false;
    }

    #endregion

    #region Property Emission

    bool EmitProperty(StringBuilder sb, PropertyDef prop, string csClassName,
        string ns, SortedDictionary<string, string> selectors, HashSet<string> inheritedProperties)
    {
        var getter = prop.Getter;
        string csPropName = TypeMapper.ToPascalCase(getter.CppName);

        if (inheritedProperties.Contains(csPropName))
            return false;

        string csType = typeMapper.MapCppType(getter.ReturnType, ns);
        bool nullable = typeMapper.IsNullableType(csType);
        bool isEnum = typeMapper.IsEnumType(csType);
        bool isStruct = TypeMapper.StructTypes.Contains(csType);
        bool isBool = csType == "bool";

        // Register getter selector
        string selectorName = csPropName;
        string selectorObjC;
        if (getter.SelectorAccessor != null && context.SelectorMap.TryGetValue(getter.SelectorAccessor, out string? objcSel))
            selectorObjC = objcSel;
        else
            selectorObjC = getter.CppName;
        selectors.TryAdd(selectorName, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorName}";
        string target = "NativePtr";
        string typeStr = nullable ? $"{csType}?" : csType;

        // Resolve setter selector
        string? setSelName = null;
        if (prop.Setter != null)
        {
            setSelName = "Set" + csPropName;
            string setSelObjC;
            if (prop.Setter.SelectorAccessor != null && context.SelectorMap.TryGetValue(prop.Setter.SelectorAccessor, out string? setObjC))
                setSelObjC = setObjC;
            else
                setSelObjC = "set" + csPropName + ":";
            selectors.TryAdd(setSelName, setSelObjC);
        }

        if (nullable)
        {
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => GetProperty(ref field, {selectorRef});");
            if (prop.Setter != null)
                sb.AppendLine($"        set => SetProperty(ref field, {csClassName}Bindings.{setSelName}, value);");
            sb.AppendLine("    }");
        }
        else if (isEnum)
        {
            string msgSend = typeMapper.GetMsgSendForEnumGet(csType);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ({csType}){msgSend}({target}, {selectorRef});");
            if (prop.Setter != null)
            {
                string setCast = typeMapper.GetEnumSetCast(csType);
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, {setCast}value);");
            }
            sb.AppendLine("    }");
        }
        else if (isBool)
        {
            sb.AppendLine($"    public bool {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.MsgSendBool({target}, {selectorRef});");
            if (prop.Setter != null)
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, (Bool8)value);");
            sb.AppendLine("    }");
        }
        else if (isStruct)
        {
            string msgSend = TypeMapper.GetMsgSendForStruct(csType);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.{msgSend}({target}, {selectorRef});");
            if (prop.Setter != null)
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            sb.AppendLine("    }");
        }
        else
        {
            string msgSend = TypeMapper.GetMsgSendMethod(csType);
            string getCast = csType is "int" or "long" ? $"({csType})" : "";
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => {getCast}ObjectiveCRuntime.{msgSend}({target}, {selectorRef});");
            if (prop.Setter != null)
            {
                string setCast = csType switch { "int" => "(nint)", "long" => "(nint)", _ => "" };
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, {setCast}value);");
            }
            sb.AppendLine("    }");
        }

        return true;
    }

    #endregion

    #region Method Emission

    void EmitMethod(StringBuilder sb, MethodInfo method, string csClassName,
        string ns, SortedDictionary<string, string> selectors, bool hasClassField,
        HashSet<string> methodsWithZeroParamProperty)
    {
        string csMethodName;
        string selectorObjC;
        string cppName = method.CppName;

        if (method.SelectorAccessor != null)
        {
            if (context.SelectorMap.TryGetValue(method.SelectorAccessor, out string? objcSel))
                selectorObjC = objcSel;
            else
                selectorObjC = method.SelectorAccessor.Replace('_', ':');

            string selectorBaseName = selectorObjC.Contains(':')
                ? selectorObjC[..selectorObjC.IndexOf(':')]
                : selectorObjC;

            if (methodsWithZeroParamProperty.Contains(cppName) && method.Parameters.Count > 0)
                csMethodName = TypeMapper.ToPascalCase(selectorBaseName);
            else
                csMethodName = TypeMapper.ToPascalCase(cppName);
        }
        else
        {
            csMethodName = TypeMapper.ToPascalCase(cppName);
            int colonCount = method.Parameters.Count;
            selectorObjC = method.CppName + (colonCount > 0 ? new string(':', colonCount) : "");
        }

        bool isStaticClassMethod = method.IsStatic && method.UsesClassTarget;
        string target = isStaticClassMethod ? $"{csClassName}Bindings.Class" : "NativePtr";

        string selectorKey = TypeMapper.ToPascalCase(method.CppName);
        if (selectors.TryGetValue(selectorKey, out string? existingSelector) && existingSelector != selectorObjC)
        {
            selectorKey = TypeMapper.ToPascalCase(selectorObjC.Replace(":", " ").Trim()).Replace(" ", "");
        }
        selectors.TryAdd(selectorKey, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        string returnType = typeMapper.MapCppType(method.ReturnType, ns);
        bool nullable = typeMapper.IsNullableType(returnType);
        bool isEnum = typeMapper.IsEnumType(returnType);
        bool isStruct = TypeMapper.StructTypes.Contains(returnType);
        bool isBool = returnType == "bool";
        bool isVoid = returnType == "void";

        bool hasOutError = method.Parameters.Any(p => p.CppType.Contains("Error**"));
        bool needsRetain = nullable && !TypeMapper.IsOwnershipTransferMethod(cppName);

        // Build C# parameter list and call arguments
        var csParams = new List<string>();
        var callArgs = new List<string> { target, selectorRef };
        var arraySetupLines = new List<string>();
        var fixedStatements = new List<string>();
        bool needsUnsafeContext = false;

        for (int pi = 0; pi < method.Parameters.Count; pi++)
        {
            var param = method.Parameters[pi];
            if (param.CppType == "ARRAY_PARAM") continue;

            if (param.CppType.StartsWith("OBJ_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemCppType = param.CppType["OBJ_ARRAY:".Length..];
                string elemCsType = typeMapper.MapCppType(elemCppType + "*", ns);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].CppType is "NS::UInteger" &&
                    method.Parameters[pi + 1].Name is "count";

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                arraySetupLines.Add($"        nint* {ptrVar} = stackalloc nint[{csParamName}.Length];");
                arraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                arraySetupLines.Add($"        {{");
                arraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i].NativePtr;");
                arraySetupLines.Add($"        }}");

                callArgs.Add($"(nint){ptrVar}");

                if (nextIsCount)
                {
                    callArgs.Add($"(nuint){csParamName}.Length");
                    pi++;
                }
                continue;
            }

            if (param.CppType.StartsWith("PRIM_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemType = param.CppType["PRIM_ARRAY:".Length..];
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemType}[] {csParamName}");

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                arraySetupLines.Add($"        {elemType}* {ptrVar} = stackalloc {elemType}[{csParamName}.Length];");
                arraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                arraySetupLines.Add($"        {{");
                arraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i];");
                arraySetupLines.Add($"        }}");

                callArgs.Add($"(nint){ptrVar}");
                continue;
            }

            if (param.CppType.StartsWith("STRUCT_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemCppType = param.CppType["STRUCT_ARRAY:".Length..];
                string elemCsType = typeMapper.MapCppType(elemCppType, ns);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].CppType is "NS::UInteger" &&
                    method.Parameters[pi + 1].Name is "count";

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                fixedStatements.Add($"fixed ({elemCsType}* {ptrVar} = {csParamName})");

                callArgs.Add($"(nint){ptrVar}");

                if (nextIsCount)
                {
                    callArgs.Add($"(nuint){csParamName}.Length");
                    pi++;
                }
                continue;
            }

            string csParamType = typeMapper.MapCppType(param.CppType, ns);
            string paramName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

            if (param.CppType.Contains("Error**"))
            {
                csParams.Add("out NSError? error");
                callArgs.Add("out nint errorPtr");
                continue;
            }

            csParams.Add($"{csParamType} {paramName}");

            if (typeMapper.IsNullableType(csParamType))
                callArgs.Add($"{paramName}.NativePtr");
            else if (typeMapper.IsEnumType(csParamType))
                callArgs.Add($"{typeMapper.GetEnumSetCast(csParamType)}{paramName}");
            else if (csParamType == "bool")
                callArgs.Add($"(Bool8){paramName}");
            else if (csParamType is "uint" or "ulong")
                callArgs.Add($"(nuint){paramName}");
            else if (csParamType is "int" or "long")
                callArgs.Add($"(nint){paramName}");
            else
                callArgs.Add(paramName);
        }

        string paramStr = string.Join(", ", csParams);
        string argsStr = string.Join(", ", callArgs);
        string staticKw = isStaticClassMethod ? "static " : "";
        string unsafeKw = needsUnsafeContext ? "unsafe " : "";
        string csReturnType = isVoid ? "void" : nullable ? $"{returnType}?" : returnType;

        sb.AppendLine($"    public {staticKw}{unsafeKw}{csReturnType} {csMethodName}({paramStr})");
        sb.AppendLine("    {");

        foreach (var line in arraySetupLines)
            sb.AppendLine(line);
        if (arraySetupLines.Count > 0)
            sb.AppendLine();

        string indent = "        ";
        foreach (var fixedStmt in fixedStatements)
        {
            sb.AppendLine($"{indent}{fixedStmt}");
            sb.AppendLine($"{indent}{{");
            indent += "    ";
        }

        if (isVoid)
        {
            sb.AppendLine($"{indent}ObjectiveCRuntime.MsgSend({argsStr});");
            if (hasOutError)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}error = errorPtr is not 0 ? new(errorPtr, true) : null;");
            }
        }
        else if (nullable)
        {
            string retainFlag = needsRetain ? "true" : "false";
            if (hasOutError)
            {
                sb.AppendLine($"{indent}nint nativePtr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = errorPtr is not 0 ? new(errorPtr, true) : null;");
                sb.AppendLine();
                sb.AppendLine($"{indent}return nativePtr is not 0 ? new(nativePtr, {retainFlag}) : null;");
            }
            else
            {
                sb.AppendLine($"{indent}nint nativePtr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}return nativePtr is not 0 ? new(nativePtr, {retainFlag}) : null;");
            }
        }
        else if (isEnum)
        {
            string msgSend = typeMapper.GetMsgSendForEnumGet(returnType);
            if (hasOutError)
            {
                sb.AppendLine($"{indent}var result = ({returnType}){msgSend}({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = errorPtr is not 0 ? new(errorPtr, true) : null;");
                sb.AppendLine();
                sb.AppendLine($"{indent}return result;");
            }
            else
            {
                sb.AppendLine($"{indent}return ({returnType}){msgSend}({argsStr});");
            }
        }
        else if (isBool)
        {
            if (hasOutError)
            {
                sb.AppendLine($"{indent}var result = ObjectiveCRuntime.MsgSendBool({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = errorPtr is not 0 ? new(errorPtr, true) : null;");
                sb.AppendLine();
                sb.AppendLine($"{indent}return result;");
            }
            else
            {
                sb.AppendLine($"{indent}return ObjectiveCRuntime.MsgSendBool({argsStr});");
            }
        }
        else if (isStruct)
        {
            string msgSend = TypeMapper.GetMsgSendForStruct(returnType);
            if (hasOutError)
            {
                sb.AppendLine($"{indent}var result = ObjectiveCRuntime.{msgSend}({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = errorPtr is not 0 ? new(errorPtr, true) : null;");
                sb.AppendLine();
                sb.AppendLine($"{indent}return result;");
            }
            else
            {
                sb.AppendLine($"{indent}return ObjectiveCRuntime.{msgSend}({argsStr});");
            }
        }
        else
        {
            string msgSend = TypeMapper.GetMsgSendMethod(returnType);
            string retCast = returnType is "uint" or "ulong" or "int" or "long" ? $"({returnType})" : "";
            if (hasOutError)
            {
                sb.AppendLine($"{indent}var result = {retCast}ObjectiveCRuntime.{msgSend}({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = errorPtr is not 0 ? new(errorPtr, true) : null;");
                sb.AppendLine();
                sb.AppendLine($"{indent}return result;");
            }
            else
            {
                sb.AppendLine($"{indent}return {retCast}ObjectiveCRuntime.{msgSend}({argsStr});");
            }
        }

        // Close fixed blocks in reverse order
        for (int fi = fixedStatements.Count - 1; fi >= 0; fi--)
        {
            indent = "        " + new string(' ', fi * 4);
            sb.AppendLine($"{indent}}}");
        }

        sb.AppendLine("    }");
    }

    #endregion

    #region Free Function Emission

    void EmitFreeFunction(StringBuilder sb, FreeFunctionDef func, string cppNamespace)
    {
        string csReturnType = typeMapper.MapCppType(func.ReturnType, cppNamespace);
        bool nullable = typeMapper.IsNullableType(csReturnType);

        var pinvokeParams = new List<string>();
        foreach (var p in func.Parameters)
        {
            string csType = typeMapper.MapCppType(p.CppType, cppNamespace);
            if (typeMapper.IsNullableType(csType))
                pinvokeParams.Add($"nint {TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name))}");
            else
                pinvokeParams.Add($"{csType} {TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name))}");
        }

        string pinvokeReturnType = nullable ? "nint" : csReturnType;

        sb.AppendLine($"    [LibraryImport(\"{func.LibraryPath}\", EntryPoint = \"{func.CEntryPoint}\")]");
        sb.AppendLine($"    private static partial {pinvokeReturnType} {func.CEntryPoint}({string.Join(", ", pinvokeParams)});");
        sb.AppendLine();

        var wrapperParams = new List<string>();
        var callArgs = new List<string>();
        foreach (var p in func.Parameters)
        {
            string csType = typeMapper.MapCppType(p.CppType, cppNamespace);
            string csName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name));
            if (typeMapper.IsNullableType(csType))
            {
                wrapperParams.Add($"{csType} {csName}");
                callArgs.Add($"{csName}.NativePtr");
            }
            else
            {
                wrapperParams.Add($"{csType} {csName}");
                callArgs.Add(csName);
            }
        }

        string csFullReturnType = nullable ? $"{csReturnType}?" : csReturnType;
        string wrapperParamStr = string.Join(", ", wrapperParams);
        string callArgStr = string.Join(", ", callArgs);

        if (nullable)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.CppName}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine($"        return nativePtr is not 0 ? new(nativePtr, false) : null;");
            sb.AppendLine("    }");
        }
        else if (csReturnType == "void")
        {
            sb.AppendLine($"    public static void {func.CppName}({wrapperParamStr}) => {func.CEntryPoint}({callArgStr});");
        }
        else
        {
            sb.AppendLine($"    public static {csReturnType} {func.CppName}({wrapperParamStr}) => {func.CEntryPoint}({callArgStr});");
        }
    }

    #endregion
}
