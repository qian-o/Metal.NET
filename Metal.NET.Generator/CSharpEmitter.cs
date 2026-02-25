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
    static readonly HashSet<string> SkipClasses =
    [
        "NSString",
        "NSError",
        "NSArray",
        "NSURL",
        "NSDictionary",
        "NSNotification",
        "NSNotificationCenter",
        "NSSet",
        "NSEnumerator",
        "NSObject",
        "NSProcessInfo",
        "NSBundle",
        "NSAutoreleasePool",
        "NSNumber",
        "NSValue",
        "NSDate"
    ];

    /// <summary>
    /// Maps (ClassName, MemberName) → element type for NSArray properties and methods,
    /// inferred from the Objective-C Metal API typed arrays.
    /// </summary>
    static readonly Dictionary<(string Class, string Member), string> NSArrayElementTypes = new()
    {
        // MTLDevice
        { ("MTLDevice", "CounterSets"), "MTLCounterSet" },
        { ("MTLDevice", "CopyAllDevices"), "MTLDevice" },
        { ("MTLDevice", "NewArgumentEncoder"), "MTLArgumentDescriptor" },
        // MTLCounterSet
        { ("MTLCounterSet", "Counters"), "MTLCounter" },
        // MTLLibrary
        { ("MTLLibrary", "FunctionNames"), "NSString" },
        // MTLFunction
        { ("MTLFunction", "StageInputAttributes"), "MTLAttribute" },
        { ("MTLFunction", "VertexAttributes"), "MTLVertexAttribute" },
        // MTLStructType
        { ("MTLStructType", "Members"), "MTLStructMember" },
        // MTLResidencySet
        { ("MTLResidencySet", "AllAllocations"), "MTLAllocation" },
        // MTLCommandBufferEncoderInfo
        { ("MTLCommandBufferEncoderInfo", "DebugSignposts"), "NSString" },
        // MTLInstanceAccelerationStructureDescriptor
        { ("MTLInstanceAccelerationStructureDescriptor", "InstancedAccelerationStructures"), "MTLAccelerationStructure" },
        // MTLFunctionStitchingGraph
        { ("MTLFunctionStitchingGraph", "Attributes"), "MTLFunctionStitchingAttribute" },
        { ("MTLFunctionStitchingGraph", "Nodes"), "MTLFunctionStitchingFunctionNode" },
        // MTLFunctionStitchingFunctionNode
        { ("MTLFunctionStitchingFunctionNode", "ControlDependencies"), "MTLFunctionStitchingFunctionNode" },
        // MTLStitchedLibraryDescriptor
        { ("MTLStitchedLibraryDescriptor", "FunctionGraphs"), "MTLFunctionStitchingGraph" },
        // MTL4CompilerTaskOptions
        { ("MTL4CompilerTaskOptions", "LookupArchives"), "MTL4Archive" },
        // MTLComputePipelineState
        { ("MTLComputePipelineState", "NewComputePipelineStateWithBinaryFunctions"), "MTL4BinaryFunction" },
        { ("MTLComputePipelineState", "NewComputePipelineState"), "MTLFunction" },
        // MTL4MachineLearningPipelineDescriptor
        { ("MTL4MachineLearningPipelineDescriptor", "SetInputDimensions"), "MTLTensorExtents" },
    };

    /// <summary>
    /// Maps a property name suffix to element type for NSArray properties.
    /// Applied when no exact (Class, Property) match is found.
    /// </summary>
    static readonly (string Suffix, string ElementType)[] NSArraySuffixRules =
    [
        ("BinaryArchives", "MTLBinaryArchive"),
        ("AdditionalBinaryFunctions", "MTLFunction"),
        ("BinaryLinkedFunctions", "MTL4BinaryFunction"),
        ("BinaryFunctions", "MTLFunction"),
        ("PrivateFunctions", "MTLFunction"),
        ("Functions", "MTLFunction"),
        ("PreloadedLibraries", "MTLDynamicLibrary"),
        ("InsertLibraries", "MTLDynamicLibrary"),
        ("Libraries", "MTLDynamicLibrary"),
        ("GeometryDescriptors", "MTLAccelerationStructureGeometryDescriptor"),
        ("PrivateFunctionDescriptors", "MTL4FunctionDescriptor"),
        ("FunctionDescriptors", "MTL4FunctionDescriptor"),
        ("VertexBuffers", "MTLMotionKeyframeData"),
        ("BoundingBoxBuffers", "MTLMotionKeyframeData"),
        ("ControlPointBuffers", "MTLMotionKeyframeData"),
        ("RadiusBuffers", "MTLMotionKeyframeData"),
        ("Bindings", "MTLBinding"),
        ("Arguments", "MTLArgument"),
    ];

    /// <summary>
    /// Tries to resolve the element type for an NSArray property.
    /// Returns null if no mapping is found.
    /// </summary>
    static string? TryResolveNSArrayElementType(string className, string propertyName)
    {
        if (NSArrayElementTypes.TryGetValue((className, propertyName), out string? elementType))
        {
            return elementType;
        }

        foreach ((string suffix, string elemType) in NSArraySuffixRules)
        {
            if (propertyName.EndsWith(suffix, StringComparison.Ordinal))
            {
                return elemType;
            }
        }

        return null;
    }

    #region Generation Entry Point

    public void GenerateAll()
    {
        foreach (EnumDef enumDef in context.Enums)
        {
            GenerateEnum(enumDef);
        }

        // Build known class names (both generated and hand-written)
        foreach (ClassDef classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            context.KnownClassNames.Add(prefix + classDef.Name);
        }
        context.KnownClassNames.UnionWith(["NSString", "NSError", "NSArray", "NSURL", "NativeObject"]);

        // Build a map of class name → property names for inheritance detection
        Dictionary<string, HashSet<string>> classPropertyMap = [];
        foreach (ClassDef classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            string csClassName = prefix + classDef.Name;
            classPropertyMap[csClassName] =
            [
                .. classDef.Methods.Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget && m.IsConst)
                                   .Select(m => TypeMapper.ToPascalCase(m.CppName))
            ];
        }

        // Build inherited property names by walking the inheritance chain
        HashSet<string> GetInheritedProperties(string csClassName)
        {
            HashSet<string> result = [];
            if (!classPropertyMap.ContainsKey(csClassName))
            {
                return result;
            }
            ClassDef classDef = context.Classes.First(c => TypeMapper.GetPrefix(c.CppNamespace) + c.Name == csClassName);
            string? current = classDef.BaseClassName;
            while (current != null && context.KnownClassNames.Contains(current) && classPropertyMap.TryGetValue(current, out HashSet<string>? parentProps))
            {
                result.UnionWith(parentProps);
                ClassDef? parentDef = context.Classes.FirstOrDefault(c => TypeMapper.GetPrefix(c.CppNamespace) + c.Name == current);
                current = parentDef?.BaseClassName;
            }
            return result;
        }

        // Build lookup of free functions per target class
        Dictionary<string, List<FreeFunctionDef>> freeFuncsByClass = context.FreeFunctions
            .GroupBy(f => f.TargetClassName)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (ClassDef classDef in context.Classes)
        {
            string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
            string csClassName = prefix + classDef.Name;
            HashSet<string> inheritedProps = GetInheritedProperties(csClassName);
            freeFuncsByClass.TryGetValue(csClassName, out List<FreeFunctionDef>? classFuncs);
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

        StringBuilder sb = new();
        sb.AppendLine("namespace Metal.NET;");
        sb.AppendLine();

        if (enumDef.IsFlags)
        {
            sb.AppendLine("[Flags]");
        }

        sb.AppendLine($"public enum {csEnumName} : {enumDef.BackingType}");
        sb.AppendLine("{");

        for (int i = 0; i < enumDef.Members.Count; i++)
        {
            EnumMember member = enumDef.Members[i];
            string comma = i < enumDef.Members.Count - 1 ? "," : "";
            if (i > 0)
            {
                sb.AppendLine();
            }
            sb.AppendLine($"    {member.Name} = {member.Value}{comma}");
        }

        sb.AppendLine("}");
        File.WriteAllText(Path.Combine(dir, $"{csEnumName}.cs"), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: {subdir}/{csEnumName}.cs");
    }

    #endregion

    #region Class Generation

    void GenerateClass(ClassDef classDef, HashSet<string> inheritedProperties, List<FreeFunctionDef> freeFunctions)
    {
        string prefix = TypeMapper.GetPrefix(classDef.CppNamespace);
        string csClassName = prefix + classDef.Name;

        if (SkipClasses.Contains(csClassName))
        {
            return;
        }

        string subdir = TypeMapper.GetOutputSubdir(classDef.CppNamespace);
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        bool hasClassField = context.RegisteredClasses.Contains(csClassName);
        bool hasFreeFunctions = freeFunctions.Count > 0;

        // Filter out methods with unmapped array params, function pointer params, or unmappable types
        List<MethodInfo> validMethods =
        [
            .. classDef.Methods.Where(m => !m.Parameters.Any(p => p.CppType == "ARRAY_PARAM")
                                           && !HasUnmergableArrayParam(m)
                                           && !HasFunctionPointerParam(m)
                                           && !HasUnmappableParam(m))
        ];

        HashSet<string> hasZeroParamVersion =
        [
            .. validMethods
                .Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget)
                .Select(m => m.CppName)
        ];

        (List<PropertyDef> properties, List<MethodInfo> methods) = CategorizeMembers(validMethods);

        SortedDictionary<string, string> selectors = [];
        StringBuilder sb = new();

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
        sb.AppendLine($"public {partialKeyword}class {csClassName}(nint nativePtr, bool ownsReference) : {baseClass}(nativePtr, ownsReference), INativeObject<{csClassName}>");
        sb.AppendLine("{");
        string newKeyword = baseClass != "NativeObject" ? "new " : "";
        sb.AppendLine($"    public static {newKeyword}{csClassName} Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);");
        sb.AppendLine($"    public static {newKeyword}{csClassName} Null => Create(0, false);");
        sb.AppendLine($"    public static {newKeyword}{csClassName} Empty => Null;");

        bool hasPrecedingMember = true;
        if (hasClassField)
        {
            sb.AppendLine();
            sb.AppendLine($"    public {csClassName}() : this(ObjectiveCRuntime.AllocInit({csClassName}Bindings.Class), true)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        // Properties (sorted alphabetically)
        foreach (PropertyDef prop in properties)
        {
            int prevLen = sb.Length;
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            if (EmitProperty(sb, prop, csClassName, classDef.CppNamespace, selectors, inheritedProperties))
            {
                hasPrecedingMember = true;
            }
            else
            {
                sb.Length = prevLen;
            }
        }

        // Indexer (objectAtIndexedSubscript: / setObject:atIndexedSubscript:)
        MethodInfo? indexerGetter = methods.FirstOrDefault(m =>
            m.SelectorAccessor is "objectAtIndexedSubscript_"
            || (m.CppName == "object" && m.Parameters.Count == 1 && m.ReturnType != "void"));
        MethodInfo? indexerSetter = methods.FirstOrDefault(m =>
            m.SelectorAccessor is "setObject_atIndexedSubscript_"
            || (m.CppName == "setObject" && m.Parameters.Count == 2 && m.ReturnType == "void"));

        if (indexerGetter != null)
        {
            const string getterSelectorObjC = "objectAtIndexedSubscript:";
            const string setterSelectorObjC = "setObject:atIndexedSubscript:";

            selectors.TryAdd("Object", getterSelectorObjC);

            string elemType = TypeMapper.MapCppType(indexerGetter.ReturnType, classDef.CppNamespace);
            string indexParam = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(indexerGetter.Parameters[0].Name));

            sb.AppendLine();
            sb.AppendLine($"    public {elemType} this[nuint {indexParam}]");
            sb.AppendLine("    {");
            sb.AppendLine("        get");
            sb.AppendLine("        {");
            sb.AppendLine($"            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, {csClassName}Bindings.Object, {indexParam});");
            sb.AppendLine();
            sb.AppendLine("            return new(nativePtr, false);");
            sb.AppendLine("        }");

            if (indexerSetter != null)
            {
                selectors.TryAdd("SetObject", setterSelectorObjC);

                sb.AppendLine("        set");
                sb.AppendLine("        {");
                sb.AppendLine($"            ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.SetObject, value.NativePtr, {indexParam});");
                sb.AppendLine("        }");
            }

            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        // Methods (skip indexer getter/setter already emitted above)
        foreach (MethodInfo method in methods)
        {
            if (method == indexerGetter || method == indexerSetter)
            {
                continue;
            }

            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitMethod(sb, method, csClassName, classDef.CppNamespace, selectors, hasZeroParamVersion);
            hasPrecedingMember = true;
        }

        // Static free functions
        foreach (FreeFunctionDef func in freeFunctions)
        {
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitFreeFunction(sb, func, classDef.CppNamespace, csClassName);
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

        foreach ((string name, string objc) in selectors)
        {
            if (!first)
            {
                sb.AppendLine();
            }
            sb.AppendLine($"    public static readonly Selector {name} = \"{objc}\";");
            first = false;
        }
        sb.AppendLine("}");

        File.WriteAllText(Path.Combine(dir, $"{csClassName}.cs"), sb.ToString(), new UTF8Encoding(true));
        Console.WriteLine($"  Generated: {subdir}/{csClassName}.cs");
    }

    #endregion

    #region Member Categorization

    static (List<PropertyDef> Properties, List<MethodInfo> Methods) CategorizeMembers(List<MethodInfo> allMethods)
    {
        List<PropertyDef> properties = [];
        List<MethodInfo> methods = [];
        HashSet<MethodInfo> used = new(ReferenceEqualityComparer.Instance);

        // Build setter map
        Dictionary<string, MethodInfo> setterMap = new(StringComparer.Ordinal);
        foreach (MethodInfo m in allMethods)
        {
            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3]) &&
                m.ReturnType == "void" && m.Parameters.Count == 1)
            {
                string propName = char.ToLower(m.CppName[3]) + (m.CppName.Length > 4 ? m.CppName[4..] : "");
                setterMap[propName] = m;
            }
        }

        // Find getters
        foreach (MethodInfo m in allMethods)
        {
            if (m.ReturnType == "void")
            {
                continue;
            }

            if (m.Parameters.Count > 0)
            {
                continue;
            }

            if (m.UsesClassTarget)
            {
                continue;
            }

            if (used.Contains(m))
            {
                continue;
            }

            if (m.CppName.StartsWith("set") && m.CppName.Length > 3 && char.IsUpper(m.CppName[3]))
            {
                continue;
            }

            if (TypeMapper.IsOwnershipTransferMethod(m.CppName))
            {
                continue;
            }

            if (!m.IsConst)
            {
                continue;
            }

            MethodInfo? setter = null;
            if (setterMap.TryGetValue(m.CppName, out MethodInfo? s))
            {
                setter = s;
                used.Add(s);
            }

            properties.Add(new PropertyDef(m, setter));
            used.Add(m);
        }

        // Remaining become methods
        foreach (MethodInfo m in allMethods)
        {
            if (used.Contains(m))
            {
                continue;
            }

            methods.Add(m);
        }

        properties.Sort((a, b) => string.CompareOrdinal(TypeMapper.ToPascalCase(a.Getter.CppName), TypeMapper.ToPascalCase(b.Getter.CppName)));

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

    static bool HasUnmappableParam(MethodInfo method)
    {
        foreach (ParamDef p in method.Parameters)
        {
            if (p.CppType.StartsWith("OBJ_ARRAY:") ||
                p.CppType.StartsWith("PRIM_ARRAY:") ||
                p.CppType.StartsWith("STRUCT_ARRAY:") ||
                p.CppType == "ARRAY_PARAM")
            {
                continue;
            }
            if (TypeMapper.IsUnmappableCppType(p.CppType))
            {
                return true;
            }
        }

        return TypeMapper.IsUnmappableCppType(method.ReturnType);
    }

    static bool HasUnmergableArrayParam(MethodInfo method)
    {
        List<ParamDef> p = method.Parameters;
        for (int i = 0; i < p.Count; i++)
        {
            if (p[i].CppType.StartsWith("OBJ_ARRAY:") ||
                p[i].CppType.StartsWith("PRIM_ARRAY:") ||
                p[i].CppType.StartsWith("STRUCT_ARRAY:"))
            {
                bool nextIsCount = i + 1 < p.Count &&
                    p[i + 1].CppType is "NS::UInteger" &&
                    p[i + 1].Name is "count";
                if (!nextIsCount)
                {
                    return true;
                }
            }
        }
        return false;
    }

    #endregion

    #region Property Emission

    bool EmitProperty(StringBuilder sb, PropertyDef prop, string csClassName, string ns, SortedDictionary<string, string> selectors, HashSet<string> inheritedProperties)
    {
        MethodInfo getter = prop.Getter;
        string csPropName = TypeMapper.ToPascalCase(getter.CppName);

        if (inheritedProperties.Contains(csPropName))
        {
            return false;
        }

        string csType = TypeMapper.MapCppType(getter.ReturnType, ns);

        // Resolve NSArray element type for typed arrays
        string? nsArrayElemType = null;
        if (csType == "NSArray")
        {
            nsArrayElemType = TryResolveNSArrayElementType(csClassName, csPropName);
        }

        bool isNSArray = nsArrayElemType != null;
        bool nullable = !isNSArray && typeMapper.IsNativeObjectType(csType);
        bool isEnum = typeMapper.IsEnumType(csType);
        bool isStruct = TypeMapper.StructTypes.Contains(csType);
        bool isBool = csType == "bool";

        // Register getter selector
        string selectorName = csPropName;
        string selectorObjC;
        if (getter.SelectorAccessor != null && context.SelectorMap.TryGetValue(getter.SelectorAccessor, out string? objcSel))
        {
            selectorObjC = objcSel;
        }
        else
        {
            selectorObjC = getter.CppName;
        }
        selectors.TryAdd(selectorName, selectorObjC);

        const string Target = "NativePtr";

        string selectorRef = $"{csClassName}Bindings.{selectorName}";
        string typeStr = csType;

        // Resolve setter selector
        string? setSelName = null;
        if (prop.Setter != null)
        {
            setSelName = "Set" + csPropName;
            string setSelObjC;
            if (prop.Setter.SelectorAccessor != null && context.SelectorMap.TryGetValue(prop.Setter.SelectorAccessor, out string? setObjC))
            {
                setSelObjC = setObjC;
            }
            else
            {
                setSelObjC = "set" + csPropName + ":";
            }
            selectors.TryAdd(setSelName, setSelObjC);
        }

        if (isNSArray)
        {
            sb.AppendLine($"    public {nsArrayElemType}[] {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => GetArrayProperty<{nsArrayElemType}>({selectorRef});");
            if (prop.Setter != null)
            {
                sb.AppendLine($"        set => SetArrayProperty({csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (nullable)
        {
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => GetProperty(ref field, {selectorRef});");
            if (prop.Setter != null)
            {
                sb.AppendLine($"        set => SetProperty(ref field, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (isEnum)
        {
            string msgSend = typeMapper.GetMsgSendForEnumGet(csType);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ({csType}){msgSend}({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                string setCast = typeMapper.GetEnumSetCast(csType);
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, {setCast}value);");
            }
            sb.AppendLine("    }");
        }
        else if (isBool)
        {
            sb.AppendLine($"    public Bool8 {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.MsgSendBool({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else if (isStruct)
        {
            string msgSend = TypeMapper.GetMsgSendForStruct(csType);
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => ObjectiveCRuntime.{msgSend}({Target}, {selectorRef});");
            if (prop.Setter != null)
            {
                sb.AppendLine($"        set => ObjectiveCRuntime.MsgSend(NativePtr, {csClassName}Bindings.{setSelName}, value);");
            }
            sb.AppendLine("    }");
        }
        else
        {
            string msgSend = TypeMapper.GetMsgSendMethod(csType);
            string getCast = csType is "int" or "long" ? $"({csType})" : "";
            sb.AppendLine($"    public {typeStr} {csPropName}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => {getCast}ObjectiveCRuntime.{msgSend}({Target}, {selectorRef});");
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

    void EmitMethod(StringBuilder sb, MethodInfo method, string csClassName, string ns, SortedDictionary<string, string> selectors, HashSet<string> hasZeroParamVersion)
    {
        string csMethodName;
        string selectorObjC;
        string cppName = method.CppName;

        if (method.SelectorAccessor != null)
        {
            if (context.SelectorMap.TryGetValue(method.SelectorAccessor, out string? objcSel))
            {
                selectorObjC = objcSel;
            }
            else
            {
                selectorObjC = method.SelectorAccessor.Replace('_', ':');
            }

            string selectorBaseName = selectorObjC.Contains(':')
                ? selectorObjC[..selectorObjC.IndexOf(':')]
                : selectorObjC;

            if (hasZeroParamVersion.Contains(cppName) && method.Parameters.Count > 0)
            {
                csMethodName = TypeMapper.ToPascalCase(selectorBaseName);
            }
            else
            {
                csMethodName = TypeMapper.ToPascalCase(cppName);
            }
        }
        else
        {
            csMethodName = TypeMapper.ToPascalCase(cppName);
            int colonCount = method.Parameters.Count;
            selectorObjC = method.CppName + (colonCount > 0 ? new string(':', colonCount) : "");
        }

        bool isStaticClassMethod = method.IsStatic && method.UsesClassTarget;
        string target = isStaticClassMethod ? $"{csClassName}Bindings.Class" : "NativePtr";

        string selectorKey;
        if (hasZeroParamVersion.Contains(method.CppName) && method.Parameters.Count > 0)
        {
            selectorKey = TypeMapper.ToPascalCase(selectorObjC.Replace(":", " ").Trim()).Replace(" ", "");
        }
        else
        {
            selectorKey = TypeMapper.ToPascalCase(method.CppName);
        }
        if (selectors.TryGetValue(selectorKey, out string? existingSelector) && existingSelector != selectorObjC)
        {
            selectorKey = TypeMapper.ToPascalCase(selectorObjC.Replace(":", " ").Trim()).Replace(" ", "");
        }
        selectors.TryAdd(selectorKey, selectorObjC);

        string selectorRef = $"{csClassName}Bindings.{selectorKey}";

        string returnType = TypeMapper.MapCppType(method.ReturnType, ns);

        // Resolve NSArray element type for array returns
        string? returnArrayElemType = null;
        if (returnType == "NSArray")
        {
            returnArrayElemType = TryResolveNSArrayElementType(csClassName, csMethodName);
        }
        bool returnsArray = returnArrayElemType != null;

        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(returnType);
        bool isEnum = typeMapper.IsEnumType(returnType);
        bool isStruct = TypeMapper.StructTypes.Contains(returnType);
        bool isBool = returnType == "bool";
        bool isVoid = returnType == "void";

        bool hasOutError = method.Parameters.Any(p => p.CppType.Contains("Error**"));

        // Per Objective-C memory management conventions, only methods whose selector
        // begins with alloc, new, copy, or mutableCopy return a +1 retained reference.
        // All other methods (including objectAtIndexedSubscript:, objectAtIndex:, etc.)
        // return borrowed references.
        bool ownsReturn = selectorObjC.StartsWith("alloc", StringComparison.Ordinal)
            || selectorObjC.StartsWith("new", StringComparison.Ordinal)
            || selectorObjC.StartsWith("copy", StringComparison.Ordinal)
            || selectorObjC.StartsWith("mutableCopy", StringComparison.Ordinal);
        string ownsReturnStr = ownsReturn ? "true" : "false";

        // Build C# parameter list and call arguments
        List<string> csParams = [];
        List<string> callArgs = [target, selectorRef];
        List<string> arraySetupLines = [];
        List<string> fixedStatements = [];
        List<string> nsArrayReleaseVars = [];
        bool needsUnsafeContext = false;

        for (int pi = 0; pi < method.Parameters.Count; pi++)
        {
            ParamDef param = method.Parameters[pi];
            if (param.CppType == "ARRAY_PARAM")
            {
                continue;
            }

            if (param.CppType.StartsWith("OBJ_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemCppType = param.CppType["OBJ_ARRAY:".Length..];
                string elemCsType = TypeMapper.MapCppType(elemCppType + "*", ns);
                string csParamName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

                csParams.Add($"{elemCsType}[] {csParamName}");

                bool nextIsCount = pi + 1 < method.Parameters.Count &&
                    method.Parameters[pi + 1].CppType is "NS::UInteger" &&
                    method.Parameters[pi + 1].Name is "count";

                string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                arraySetupLines.Add($"        nint* {ptrVar} = stackalloc nint[{csParamName}.Length];");
                arraySetupLines.Add($"        for (int i = 0; i < {csParamName}.Length; i++)");
                arraySetupLines.Add("        {");
                arraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i].NativePtr;");
                arraySetupLines.Add("        }");

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
                arraySetupLines.Add("        {");
                arraySetupLines.Add($"            {ptrVar}[i] = {csParamName}[i];");
                arraySetupLines.Add("        }");

                callArgs.Add($"(nint){ptrVar}");
                continue;
            }

            if (param.CppType.StartsWith("STRUCT_ARRAY:"))
            {
                needsUnsafeContext = true;
                string elemCppType = param.CppType["STRUCT_ARRAY:".Length..];
                string elemCsType = TypeMapper.MapCppType(elemCppType, ns);
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

            string csParamType = TypeMapper.MapCppType(param.CppType, ns);
            string paramName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(param.Name));

            if (param.CppType.Contains("Error**"))
            {
                csParams.Add("out NSError error");
                callArgs.Add("out nint errorPtr");
                continue;
            }

            if (param.CppType.Contains("Timestamp*") && !param.CppType.Contains("TimestampGranularity"))
            {
                csParams.Add($"out ulong {paramName}");
                callArgs.Add($"out {paramName}");
                continue;
            }

            csParams.Add($"{csParamType} {paramName}");

            if (csParamType == "NSArray")
            {
                // Resolve the element type for this NSArray parameter
                string? paramArrayElemType = TryResolveNSArrayElementType(csClassName, csMethodName);
                if (paramArrayElemType != null)
                {
                    // Replace the param we just added with T[] version
                    csParams[^1] = $"{paramArrayElemType}[] {paramName}";
                    string ptrVar = $"p{TypeMapper.ToPascalCase(param.Name)}";
                    arraySetupLines.Add($"        nint {ptrVar} = NSArray.FromArray({paramName});");
                    callArgs.Add(ptrVar);
                    nsArrayReleaseVars.Add(ptrVar);
                }
                else
                {
                    callArgs.Add($"{paramName}");
                }
            }
            else if (typeMapper.IsNativeObjectType(csParamType))
            {
                callArgs.Add($"{paramName}.NativePtr");
            }
            else if (typeMapper.IsEnumType(csParamType))
            {
                callArgs.Add($"{typeMapper.GetEnumSetCast(csParamType)}{paramName}");
            }
            else if (csParamType == "bool")
            {
                callArgs.Add($"(Bool8){paramName}");
            }
            else if (csParamType is "uint" or "ulong")
            {
                callArgs.Add($"(nuint){paramName}");
            }
            else if (csParamType is "int" or "long")
            {
                callArgs.Add($"(nint){paramName}");
            }
            else
            {
                callArgs.Add(paramName);
            }
        }

        string paramStr = string.Join(", ", csParams);
        string argsStr = string.Join(", ", callArgs);
        string staticKw = isStaticClassMethod ? "static " : "";
        string unsafeKw = needsUnsafeContext ? "unsafe " : "";
        string csReturnType = returnsArray ? $"{returnArrayElemType}[]" : (isVoid ? "void" : returnType);

        sb.AppendLine($"    public {staticKw}{unsafeKw}{csReturnType} {csMethodName}({paramStr})");
        sb.AppendLine("    {");

        foreach (string line in arraySetupLines)
        {
            sb.AppendLine(line);
        }

        if (arraySetupLines.Count > 0)
        {
            sb.AppendLine();
        }

        string indent = "        ";
        foreach (string fixedStmt in fixedStatements)
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
                sb.AppendLine($"{indent}error = new(errorPtr, false);");
            }
            foreach (string rv in nsArrayReleaseVars)
            {
                sb.AppendLine();
                sb.AppendLine($"{indent}ObjectiveCRuntime.Release({rv});");
            }
        }
        else if (returnsArray)
        {
            if (hasOutError)
            {
                sb.AppendLine($"{indent}nint nativePtr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, false);");
                foreach (string rv in nsArrayReleaseVars)
                {
                    sb.AppendLine();
                    sb.AppendLine($"{indent}ObjectiveCRuntime.Release({rv});");
                }
                sb.AppendLine();
                if (ownsReturn)
                {
                    sb.AppendLine($"{indent}{returnArrayElemType}[] result = NSArray.ToArray<{returnArrayElemType}>(nativePtr);");
                    sb.AppendLine();
                    sb.AppendLine($"{indent}ObjectiveCRuntime.Release(nativePtr);");
                    sb.AppendLine();
                    sb.AppendLine($"{indent}return result;");
                }
                else
                {
                    sb.AppendLine($"{indent}return NSArray.ToArray<{returnArrayElemType}>(nativePtr);");
                }
            }
            else
            {
                sb.AppendLine($"{indent}nint nativePtr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                foreach (string rv in nsArrayReleaseVars)
                {
                    sb.AppendLine();
                    sb.AppendLine($"{indent}ObjectiveCRuntime.Release({rv});");
                }
                sb.AppendLine();
                if (ownsReturn)
                {
                    sb.AppendLine($"{indent}{returnArrayElemType}[] result = NSArray.ToArray<{returnArrayElemType}>(nativePtr);");
                    sb.AppendLine();
                    sb.AppendLine($"{indent}ObjectiveCRuntime.Release(nativePtr);");
                    sb.AppendLine();
                    sb.AppendLine($"{indent}return result;");
                }
                else
                {
                    sb.AppendLine($"{indent}return NSArray.ToArray<{returnArrayElemType}>(nativePtr);");
                }
            }
        }
        else if (nullable)
        {
            if (hasOutError)
            {
                sb.AppendLine($"{indent}nint nativePtr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, false);");
                foreach (string rv in nsArrayReleaseVars)
                {
                    sb.AppendLine();
                    sb.AppendLine($"{indent}ObjectiveCRuntime.Release({rv});");
                }
                sb.AppendLine();
                sb.AppendLine($"{indent}return new(nativePtr, {ownsReturnStr});");
            }
            else
            {
                sb.AppendLine($"{indent}nint nativePtr = ObjectiveCRuntime.MsgSendPtr({argsStr});");
                foreach (string rv in nsArrayReleaseVars)
                {
                    sb.AppendLine();
                    sb.AppendLine($"{indent}ObjectiveCRuntime.Release({rv});");
                }
                sb.AppendLine();
                sb.AppendLine($"{indent}return new(nativePtr, {ownsReturnStr});");
            }
        }
        else if (isEnum)
        {
            string msgSend = typeMapper.GetMsgSendForEnumGet(returnType);
            if (hasOutError)
            {
                sb.AppendLine($"{indent}{returnType} result = ({returnType}){msgSend}({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, false);");
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
                sb.AppendLine($"{indent}bool result = ObjectiveCRuntime.MsgSendBool({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, false);");
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
                sb.AppendLine($"{indent}{returnType} result = ObjectiveCRuntime.{msgSend}({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, false);");
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
            string retCast = returnType is "int" or "long" ? $"({returnType})" : "";
            if (hasOutError)
            {
                sb.AppendLine($"{indent}{csReturnType} result = {retCast}ObjectiveCRuntime.{msgSend}({argsStr});");
                sb.AppendLine();
                sb.AppendLine($"{indent}error = new(errorPtr, false);");
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

    void EmitFreeFunction(StringBuilder sb, FreeFunctionDef func, string cppNamespace, string csClassName)
    {
        string csReturnType = TypeMapper.MapCppType(func.ReturnType, cppNamespace);

        // Resolve NSArray element type for array returns
        string? returnArrayElemType = null;
        if (csReturnType == "NSArray")
        {
            returnArrayElemType = TryResolveNSArrayElementType(csClassName, func.CppName);
        }
        bool returnsArray = returnArrayElemType != null;
        bool nullable = !returnsArray && typeMapper.IsNativeObjectType(csReturnType);

        List<string> pinvokeParams = [];
        foreach (ParamDef p in func.Parameters)
        {
            string csType = TypeMapper.MapCppType(p.CppType, cppNamespace);
            if (typeMapper.IsNativeObjectType(csType))
            {
                pinvokeParams.Add($"nint {TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name))}");
            }
            else
            {
                pinvokeParams.Add($"{csType} {TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name))}");
            }
        }

        string pinvokeReturnType = (nullable || returnsArray) ? "nint" : csReturnType;

        sb.AppendLine($"    [LibraryImport(\"{func.LibraryPath}\", EntryPoint = \"{func.CEntryPoint}\")]");
        sb.AppendLine($"    private static partial {pinvokeReturnType} {func.CEntryPoint}({string.Join(", ", pinvokeParams)});");
        sb.AppendLine();

        List<string> wrapperParams = [];
        List<string> callArgs = [];
        foreach (ParamDef p in func.Parameters)
        {
            string csType = TypeMapper.MapCppType(p.CppType, cppNamespace);
            string csName = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(p.Name));
            if (typeMapper.IsNativeObjectType(csType))
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

        string csFullReturnType = returnsArray ? $"{returnArrayElemType}[]" : csReturnType;
        string wrapperParamStr = string.Join(", ", wrapperParams);
        string callArgStr = string.Join(", ", callArgs);

        if (returnsArray)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.CppName}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine($"        {returnArrayElemType}[] result = NSArray.ToArray<{returnArrayElemType}>(nativePtr);");
            sb.AppendLine();
            sb.AppendLine("        ObjectiveCRuntime.Release(nativePtr);");
            sb.AppendLine();
            sb.AppendLine("        return result;");
            sb.AppendLine("    }");
        }
        else if (nullable)
        {
            sb.AppendLine($"    public static {csFullReturnType} {func.CppName}({wrapperParamStr})");
            sb.AppendLine("    {");
            sb.AppendLine($"        nint nativePtr = {func.CEntryPoint}({callArgStr});");
            sb.AppendLine();
            sb.AppendLine("        return new(nativePtr, true);");
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
