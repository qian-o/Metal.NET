using System.Text;

namespace Metal.NET.Generator;

/// <summary>
/// Emits C# source files from parsed metal-ast.json definitions.
/// Generates enum types, NativeObject-based classes with properties/methods, and P/Invoke free functions.
/// Also auto-generates Common/ObjectiveC.cs with all required MsgSend overloads.
/// </summary>
partial class CSharpEmitter
{
    #region Class Generation

    /// <summary>
    /// Generates a single C# class file: constructor, properties, methods, indexer,
    /// free-function wrappers, and the companion <c>Bindings</c> selector-lookup class.
    /// </summary>
    void GenerateClass(ClassDef classDef, HashSet<string> inheritedProperties, List<FreeFunctionDef> freeFunctions)
    {
        string prefix = TypeMapper.GetPrefix(classDef.Namespace);
        string csClassName = prefix + classDef.Name;

        if (SkipClasses.Contains(csClassName))
        {
            return;
        }

        string subdir = TypeMapper.GetOutputSubdir(classDef.Namespace);
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        bool hasClassField = classDef.HasAllocInit;
        bool hasFreeFunctions = freeFunctions.Count > 0;

        List<MethodInfo> validMethods =
        [
            .. classDef.Methods.Where(m => !m.Parameters.Any(p => p.Type == "ARRAY_PARAM")
                                            && !HasUnmergableArrayParam(m)
                                            && !HasFunctionPointerParam(m)
                                            && !HasUnmappableParam(m))
        ];

        HashSet<string> hasZeroParamVersion =
        [
            .. validMethods
                .Where(m => m.Parameters.Count == 0 && m.ReturnType != "void" && !m.UsesClassTarget)
                .Select(m => m.Name)
        ];

        (List<PropertyDef> properties, List<MethodInfo> methods) = CategorizeMembers(validMethods);

        // Detect indexer
        MethodInfo? indexerGetter = methods.FirstOrDefault(m =>
            m.Selector is "objectAtIndexedSubscript:"
            || (m.Name == "object" && m.Parameters.Count == 1 && m.ReturnType != "void"));
        MethodInfo? indexerSetter = methods.FirstOrDefault(m =>
            m.Selector is "setObject:atIndexedSubscript:"
            || (m.Name == "setObject" && m.Parameters.Count == 2 && m.ReturnType == "void"));

        List<MethodInfo> nonIndexerMethods = [.. methods
            .Where(m => m != indexerGetter && m != indexerSetter)];

        Dictionary<MethodInfo, string> simplifiedNames = ComputeSimplifiedMethodNames(nonIndexerMethods, properties);

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
            : "NSObject";
        string partialKeyword = hasFreeFunctions ? "partial " : "";

        // Class-level [Obsolete] from AST
        if (classDef.Deprecated)
        {
            sb.AppendLine(classDef.DeprecationMessage is { } dm
                ? $"[Obsolete(\"{dm}\")]"
                : "[Obsolete]");
        }

        sb.AppendLine($"public {partialKeyword}class {csClassName}(nint nativePtr, NativeObjectOwnership ownership) : {baseClass}(nativePtr, ownership), INativeObject<{csClassName}>");
        sb.AppendLine("{");
        string newKeyword = baseClass is not "NativeObject" ? "new " : "";
        sb.AppendLine("    #region INativeObject");
        sb.AppendLine($"    public static {newKeyword}{csClassName} Null {{ get; }} = new(0, NativeObjectOwnership.Borrowed);");
        sb.AppendLine();
        sb.AppendLine($"    public static {newKeyword}{csClassName} New(nint nativePtr, NativeObjectOwnership ownership)");
        sb.AppendLine("    {");
        sb.AppendLine("        return new(nativePtr, ownership);");
        sb.AppendLine("    }");
        sb.AppendLine("    #endregion");

        bool hasPrecedingMember = true;

        // Constructor
        if (hasClassField)
        {
            sb.AppendLine();
            sb.AppendLine($"    public {csClassName}() : this(ObjectiveC.AllocInit({csClassName}Bindings.Class), NativeObjectOwnership.Managed)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        // === Properties (in JSON order, no grouping) ===
        foreach (PropertyDef prop in properties)
        {
            int prevLen = sb.Length;
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            if (EmitProperty(sb, prop, csClassName, selectors, inheritedProperties))
            {
                hasPrecedingMember = true;
            }
            else
            {
                sb.Length = prevLen;
            }
        }

        // === Indexer ===
        if (indexerGetter != null)
        {
            const string getterSelectorObjC = "objectAtIndexedSubscript:";
            const string setterSelectorObjC = "setObject:atIndexedSubscript:";

            selectors.TryAdd("Object", getterSelectorObjC);

            string elemType = TypeMapper.MapType(indexerGetter.ReturnType);
            string indexParam = TypeMapper.EscapeReservedWord(TypeMapper.ToCamelCase(indexerGetter.Parameters[0].Name));

            sb.AppendLine();
            sb.AppendLine($"    public {elemType} this[nuint {indexParam}]");
            sb.AppendLine("    {");
            sb.AppendLine("        get");
            sb.AppendLine("        {");
            sb.AppendLine($"            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, {csClassName}Bindings.Object, {indexParam});");
            sb.AppendLine();
            sb.AppendLine("            return new(nativePtr, NativeObjectOwnership.Borrowed);");
            sb.AppendLine("        }");
            RecordMsgSend("MsgSendNInt", "nuint");

            if (indexerSetter != null)
            {
                selectors.TryAdd("SetObject", setterSelectorObjC);

                sb.AppendLine("        set");
                sb.AppendLine("        {");
                sb.AppendLine($"            ObjectiveC.MsgSend(NativePtr, {csClassName}Bindings.SetObject, value.NativePtr, {indexParam});");
                sb.AppendLine("        }");
                RecordMsgSend("MsgSend", "nint", "nuint");
            }

            sb.AppendLine("    }");
            hasPrecedingMember = true;
        }

        // === Methods (in JSON order, no grouping) ===
        foreach (MethodInfo method in nonIndexerMethods)
        {
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitMethod(sb, method, csClassName, selectors, hasZeroParamVersion, simplifiedNames);
            hasPrecedingMember = true;
        }

        // === Free functions ===
        foreach (FreeFunctionDef func in freeFunctions)
        {
            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitFreeFunction(sb, func, csClassName);
            hasPrecedingMember = true;
        }

        sb.AppendLine("}");
        sb.AppendLine();

        sb.AppendLine($"file static class {csClassName}Bindings");
        sb.AppendLine("{");

        bool first = true;
        if (hasClassField)
        {
            sb.AppendLine($"    public static readonly nint Class = ObjectiveC.GetClass(\"{csClassName}\");");
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

    /// <summary>
    /// Derives the ObjC property name from a method's name.
    /// Strips <c>set</c> then <c>is</c> prefixes sequentially so that setters and boolean
    /// getters always resolve to the same canonical name:
    /// <list type="bullet">
    ///   <item><c>setXxx</c> → <c>xxx</c> (regular setter)</item>
    ///   <item><c>isXxx</c>  → <c>xxx</c> (boolean getter)</item>
    ///   <item><c>setIsXxx</c> → <c>isXxx</c> → <c>xxx</c> (boolean setter, chained)</item>
    ///   <item>everything else → returned as-is</item>
    /// </list>
    /// </summary>
    static string GetPropertyName(MethodInfo m)
    {
        string name = m.Name;

        // Strip trailing underscore (e.g., setFoo_ → setFoo).
        if (name.EndsWith('_'))
        {
            name = name[..^1];
        }

        // Setter: setXxx → xxx
        if (name.Length > 3 && name.StartsWith("set") && char.IsUpper(name[3]))
        {
            name = char.ToLower(name[3]) + name[4..];
        }

        // Boolean getter: isXxx → xxx
        if (name.Length > 2 && name.StartsWith("is") && char.IsUpper(name[2]))
        {
            name = char.ToLower(name[2]) + name[3..];
        }

        return name;
    }

    /// <summary>
    /// Separates methods into properties (getter/setter pairs) and remaining methods.
    /// A method is treated as a property getter if it has no parameters, returns non-void,
    /// is const, is not static, and is not an ownership-transfer method (new/alloc/copy/init).
    /// Getter-setter pairing uses <see cref="GetPropertyName"/> to derive the ObjC property
    /// name from each method's name, so all naming conventions (including
    /// boolean <c>isXxx</c> getters paired with <c>setXxx:</c> setters) are handled uniformly.
    /// </summary>
    static (List<PropertyDef> Properties, List<MethodInfo> Methods) CategorizeMembers(List<MethodInfo> allMethods)
    {
        List<PropertyDef> properties = [];
        List<MethodInfo> methods = [];
#pragma warning disable IDE0028 // Collection initialization can be simplified (requires custom comparer)
        HashSet<MethodInfo> used = new(ReferenceEqualityComparer.Instance);

        Dictionary<string, MethodInfo> setterMap = new(StringComparer.Ordinal);
#pragma warning restore IDE0028
        foreach (MethodInfo m in allMethods)
        {
            if (m.Name.StartsWith("set") && m.Name.Length > 3 && char.IsUpper(m.Name[3]) &&
                m.ReturnType == "void" && m.Parameters.Count == 1)
            {
                setterMap[GetPropertyName(m)] = m;
            }
        }

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

            if (m.Name.StartsWith("set") && m.Name.Length > 3 && char.IsUpper(m.Name[3]))
            {
                continue;
            }

            if (TypeMapper.IsOwnershipTransferMethod(m.Name))
            {
                continue;
            }

            if (!m.IsConst)
            {
                continue;
            }

            MethodInfo? setter = null;
            if (setterMap.TryGetValue(GetPropertyName(m), out MethodInfo? s))
            {
                setter = s;
                used.Add(s);
            }

            properties.Add(new PropertyDef(m, setter));
            used.Add(m);
        }

        foreach (MethodInfo m in allMethods)
        {
            if (used.Contains(m))
            {
                continue;
            }

            methods.Add(m);
        }

        return (properties, methods);
    }

    #endregion

    #region Method Filtering

    /// <summary>
    /// Returns <see langword="true"/> if the method has <c>std::function</c> or unknown function
    /// pointer params. Block handler params (<c>Handler</c>/<c>Block</c> types and <c>INLINE_BLOCK:</c>
    /// markers) are <b>not</b> considered function pointers.
    /// </summary>
    bool HasFunctionPointerParam(MethodInfo method)
    {
        return method.Parameters.Any(p =>
        {
            if (p.Type.StartsWith("INLINE_BLOCK:"))
            {
                string delegateName = p.Type["INLINE_BLOCK:".Length..];
                return delegateName == "UNKNOWN_BLOCK";
            }

            if (p.Type.Contains("std::function") || p.Type.Contains("Function&") || p.Type.Contains("Function &"))
            {
                return true;
            }

            if (p.Type.Contains("Handler") || p.Type.Contains("Block"))
            {
                string csType = TypeMapper.MapType(p.Type);
                return !context.BlockTypeAliases.Any(b => b.CsDelegateName == csType);
            }

            return p.Type.Contains("function") || p.Type.Contains("void(");
        });
    }

    /// <summary>Returns <see langword="true"/> if the parameter type is a known block handler typedef.</summary>
    bool IsBlockHandlerType(string type)
    {
        if (type.Contains("Handler") || type.Contains("Block"))
        {
            string csType = TypeMapper.MapType(type);
            return context.BlockTypeAliases.Any(b => b.CsDelegateName == csType);
        }

        return false;
    }

    /// <summary>
    /// Returns <see langword="true"/> if any parameter's type is unmappable (excluding
    /// special prefixed types and block handler types which are handled separately).
    /// </summary>
    static bool HasUnmappableParam(MethodInfo method)
    {
        foreach (ParamDef p in method.Parameters)
        {
            if (p.Type.StartsWith("OBJ_ARRAY:") ||
                p.Type.StartsWith("PRIM_ARRAY:") ||
                p.Type.StartsWith("STRUCT_ARRAY:") ||
                p.Type.StartsWith("INLINE_BLOCK:") ||
                p.Type == "ARRAY_PARAM")
            {
                continue;
            }

            if (p.Type.Contains("Handler") || p.Type.Contains("Block") ||
                p.Type.Contains("Function&") || p.Type.Contains("Function &") ||
                p.Type.Contains("std::function"))
            {
                continue;
            }

            if (TypeMapper.IsUnmappableType(p.Type))
            {
                return true;
            }
        }

        return TypeMapper.IsUnmappableType(method.ReturnType);
    }

    /// <summary>
    /// Returns <see langword="true"/> if the method has an array parameter whose
    /// next parameter is <b>not</b> a matching <c>count</c> parameter.
    /// </summary>
    static bool HasUnmergableArrayParam(MethodInfo method)
    {
        List<ParamDef> p = method.Parameters;
        for (int i = 0; i < p.Count; i++)
        {
            if (p[i].Type.StartsWith("OBJ_ARRAY:") ||
                p[i].Type.StartsWith("PRIM_ARRAY:") ||
                p[i].Type.StartsWith("STRUCT_ARRAY:"))
            {
                bool nextIsCount = i + 1 < p.Count &&
                    p[i + 1].Type is "NS::UInteger" &&
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
}
