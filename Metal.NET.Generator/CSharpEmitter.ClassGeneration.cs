namespace Metal.NET.Generator;

partial class CSharpEmitter
{
    #region Class Generation

    /// <summary>
    /// Generates a single C# class file: constructor, properties, methods, indexer,
    /// free-function wrappers, and the companion <c>Bindings</c> selector-lookup class.
    /// </summary>
    void GenerateClass(ClassDef classDef, HashSet<string> inheritedProperties, HashSet<string> knownDelegateNames, List<FreeFunctionDef> freeFunctions)
    {
        string csClassName = classDef.FullCsName;

        if (AstJsonParser.SkipClasses.Contains(csClassName))
        {
            return;
        }

        string subdir = TypeMapper.GetOutputSubdir(classDef.Namespace);
        string dir = Path.Combine(outputDir, subdir);
        Directory.CreateDirectory(dir);

        bool hasFreeFunctions = freeFunctions.Count > 0;

        List<MethodInfo> validMethods =
        [
            .. classDef.Methods.Where(m => !m.IsInit
                                            && !HasUnmergableArrayParam(m)
                                            && !HasFunctionPointerParam(m, knownDelegateNames)
                                            && !HasUnmappableParam(m)
                                            && !m.ReturnType.Contains("UNKNOWN_BLOCK"))
        ];

        List<MethodInfo> initMethods =
        [
            .. classDef.Methods.Where(m => m.IsInit
                                            && !HasFunctionPointerParam(m, knownDelegateNames)
                                            && !HasUnmappableParam(m))
        ];

        bool hasClassField = classDef.HasAllocInit
            || validMethods.Any(m => m.IsStatic && m.UsesClassTarget);

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
        string partialKeyword = "partial ";

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
        if (classDef.HasAllocInit)
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

        // === Instance methods ===
        HashSet<string> emittedMethodSignatures = [];
        foreach (MethodInfo method in nonIndexerMethods.Where(m => !(m.IsStatic && m.UsesClassTarget)))
        {
            string csName = TypeMapper.ToPascalCase(method.Name);
            string methodSig = csName + "(" + string.Join(",", method.Parameters
                .Where(p => p.Type != "ARRAY_PARAM")
                .Select(p => TypeMapper.MapType(p.Type))) + ")";
            if (!emittedMethodSignatures.Add(methodSig))
            {
                continue;
            }

            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitMethod(sb, method, csClassName, selectors, knownDelegateNames);
            hasPrecedingMember = true;
        }

        // === Static methods ===
        foreach (MethodInfo method in nonIndexerMethods.Where(m => m.IsStatic && m.UsesClassTarget))
        {
            string csName = TypeMapper.ToPascalCase(method.Name);
            string methodSig = csName + "(" + string.Join(",", method.Parameters
                .Where(p => p.Type != "ARRAY_PARAM")
                .Select(p => TypeMapper.MapType(p.Type))) + ")";
            if (!emittedMethodSignatures.Add(methodSig))
            {
                continue;
            }

            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitMethod(sb, method, csClassName, selectors, knownDelegateNames);
            hasPrecedingMember = true;
        }

        // === Init static factory methods ===
        HashSet<string> emittedInitSignatures = [];
        foreach (MethodInfo initMethod in initMethods)
        {
            // Deduplicate by method name + parameter types
            string selectorKey = BuildMethodNameFromSelector(initMethod.Selector!);
            string csMethodName = TypeMapper.ToPascalCase(selectorKey);
            string sig = csMethodName + "(" + string.Join(",", initMethod.Parameters
                .Where(p => p.Type != "ARRAY_PARAM")
                .Select(p => p.Type.Contains("Error**") ? "out NSError"
                    : p.Type.StartsWith("NSARRAY_PARAM:") ? TypeMapper.MapType(p.Type["NSARRAY_PARAM:".Length..]) + "[]"
                    : TypeMapper.MapType(p.Type))) + ")";
            if (!emittedInitSignatures.Add(sig))
            {
                continue;
            }

            if (hasPrecedingMember)
            {
                sb.AppendLine();
            }

            EmitInitStaticMethod(sb, initMethod, csClassName, selectors);
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

        File.WriteAllText(Path.Combine(dir, $"{csClassName}.cs"), sb.ToString(), Utf8Bom);
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
    /// Only methods flagged as <see cref="MethodInfo.IsPropertyAccessor"/> (parsed from the
    /// JSON <c>properties</c> array) are promoted to C# properties.
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

        Dictionary<string, MethodInfo> setterMap = new(StringComparer.OrdinalIgnoreCase);
#pragma warning restore IDE0028
        foreach (MethodInfo m in allMethods)
        {
            if (m.IsPropertyAccessor &&
                m.Name.StartsWith("set") && m.Name.Length > 3 && char.IsUpper(m.Name[3]) &&
                m.ReturnType == "void" && m.Parameters.Count == 1)
            {
                setterMap[GetPropertyName(m)] = m;
            }
        }

        foreach (MethodInfo m in allMethods)
        {
            if (!m.IsPropertyAccessor)
            {
                continue;
            }

            if (m.ReturnType == "void")
            {
                continue;
            }

            if (m.Parameters.Count > 0)
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
    static bool HasFunctionPointerParam(MethodInfo method, HashSet<string> knownDelegateNames)
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
                return !knownDelegateNames.Contains(csType);
            }

            return p.Type.Contains("function") || p.Type.Contains("void(");
        });
    }

    /// <summary>Returns <see langword="true"/> if the parameter type is a known block handler typedef.</summary>
    static bool IsBlockHandlerType(string type, HashSet<string> knownDelegateNames)
    {
        if (type.Contains("Handler") || type.Contains("Block"))
        {
            string csType = TypeMapper.MapType(type);
            return knownDelegateNames.Contains(csType);
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
                p.Type.StartsWith("NSARRAY_PARAM:") ||
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
    /// next parameter is <b>not</b> a matching <c>count</c> parameter and the method
    /// does not use a range-terminator or preceding count pattern.
    /// </summary>
    static bool HasUnmergableArrayParam(MethodInfo method)
    {
        List<ParamDef> p = method.Parameters;

        // If the last parameter is NSRange, treat all arrays as valid (bulk-set with range).
        bool hasRangeTerminator = p.Count > 0 && p[^1].Type is "NSRange";

        for (int i = 0; i < p.Count; i++)
        {
            if (p[i].Type.StartsWith("OBJ_ARRAY:") ||
                p[i].Type.StartsWith("PRIM_ARRAY:") ||
                p[i].Type.StartsWith("STRUCT_ARRAY:"))
            {
                bool nextIsCount = i + 1 < p.Count &&
                    p[i + 1] is { Type: "NS::UInteger" or "ARRAY_PARAM", Name: "count" };

                // Also accept when a preceding NS::UInteger supplies the count (e.g., layerCount before layers).
                bool prevIsCount = i > 0 && p[i - 1].Type is "NS::UInteger";

                if (!nextIsCount && !hasRangeTerminator && !prevIsCount)
                {
                    return true;
                }
            }
        }
        return false;
    }

    #endregion
}
