namespace Metal.NET.Generator;

partial class AstJsonParser
{
    #region Protocol & Class Parsing

    static void ParseProtocols(AstRoot ast, GeneratorContext context)
    {
        foreach (AstClass proto in ast.Protocols)
        {
            if (SkipProtocols.Contains(proto.Name) || SkipClasses.Contains(proto.Name))
            {
                continue;
            }

            if (proto.Framework is null or "CoreFoundation" or "CoreGraphics")
            {
                continue;
            }

            ParseClassOrProtocol(proto, context, isProtocol: true);
        }
    }

    static void ParseClasses(AstRoot ast, GeneratorContext context)
    {
        // Build a set of names already parsed from protocols to avoid overwriting
        HashSet<string> protocolNames = new(context.Classes.Select(c => c.FullCsName));

        foreach (AstClass cls in ast.Classes)
        {
            if (SkipClasses.Contains(cls.Name))
            {
                continue;
            }

            if (cls.Framework is null or "CoreGraphics")
            {
                continue;
            }

            // Skip empty class stubs when a protocol with the same name was already parsed
            if (protocolNames.Contains(cls.Name))
            {
                continue;
            }

            ParseClassOrProtocol(cls, context, isProtocol: false);
        }
    }

    static void ParseClassOrProtocol(AstClass ast, GeneratorContext context, bool isProtocol)
    {
        string ns = InferNamespaceFromName(ast.Name);
        string prefix = TypeMapper.GetPrefix(ns);

        string bareName = ast.Name.StartsWith(prefix) ? ast.Name[prefix.Length..] : ast.Name;

        // Determine base class
        string? csBaseClassName = null;
        if (!isProtocol && !string.IsNullOrEmpty(ast.Super) && ast.Super != "NSObject"
            && !SkipClasses.Contains(ast.Super))
        {
            csBaseClassName = ast.Super;
        }
        else if (ast.Protocols.Count > 0)
        {
            // For protocols (and classes whose super is NSObject), use the first
            // conforming protocol as the base class.
            string? parentProto = ast.Protocols.FirstOrDefault(p => p != "NSObject" && !SkipProtocols.Contains(p));
            if (parentProto != null)
            {
                csBaseClassName = parentProto;
            }
        }

        // Check if class supports AllocInit
        bool hasAllocInit = AllocInitClasses.Contains(ast.Name);

        // Parse methods from the AST (both explicit methods and property accessors)
        List<MethodInfo> methods = [];

        // Track selectors emitted from properties to avoid duplicates from explicit methods
        HashSet<string> propertySelectors = [];
        HashSet<string> propertyNames = new(StringComparer.OrdinalIgnoreCase);

        // Build a lookup from method name → ObjC selector for parameterless methods.
        // Properties may lack an explicit getter field; in that case the real ObjC
        // selector lives only in the methods array (e.g. name "url" → selector "URL").
        Dictionary<string, string> methodSelectorByName = [];
        foreach (AstMethod m in ast.Methods)
        {
            if (m.Parameters.Count == 0 && !string.IsNullOrEmpty(m.Selector))
            {
                methodSelectorByName.TryAdd(m.Name, m.Selector);
            }
        }

        // Parse properties → generate getter and optional setter methods
        foreach (AstProperty prop in ast.Properties)
        {
            if (SkipSelectors.Contains(prop.Name) || SkipSelectors.Contains(prop.Getter ?? prop.Name))
            {
                continue;
            }

            // Skip unmappable types
            string propObjcType = prop.Type;
            if (IsUnmappableObjCType(propObjcType))
            {
                continue;
            }

            // Resolve getter selector: explicit getter → method selector → property name
            string getterSelector = prop.Getter
                ?? methodSelectorByName.GetValueOrDefault(prop.Name)
                ?? prop.Name;
            // Use the AST property name for the C# name (e.g. "gpuStartTime" → "GpuStartTime"),
            // not the selector (which may differ in casing, e.g. "GPUStartTime").
            string getterName = prop.Name;
            string returnType = MapObjCTypeForModel(propObjcType);

            // For NSArray properties, register element type extracted from AST generics
            if (returnType.StartsWith("NSArray"))
            {
                string? elemType = ExtractNSArrayElementType(propObjcType);
                if (elemType != null)
                {
                    string csElemType = TypeMapper.MapType(elemType);
                    string csPropName = TypeMapper.ToPascalCase(getterName);
                    context.NSArrayReturnTypes.TryAdd((ast.Name, csPropName), csElemType);
                }
            }

            // Getter
            propertySelectors.Add(getterSelector);
            propertyNames.Add(getterName);
            methods.Add(new MethodInfo
            {
                Name = getterName,
                ReturnType = returnType,
                IsStatic = false,
                IsConst = true,
                Parameters = [],
                UsesClassTarget = false,
                Selector = getterSelector,
                IsPropertyAccessor = true,
                DeprecationMessage = prop.Deprecated ? prop.DeprecationMessage : null,
            });

            // Setter (if not readonly)
            if (!prop.Readonly)
            {
                // ObjC convention: for "is"-prefixed boolean properties, the setter
                // drops the "is" prefix (e.g., isDepthReversed → setDepthReversed:).
                string setterBaseName = prop.Name;
                if (setterBaseName.Length > 2 && setterBaseName.StartsWith("is") && char.IsUpper(setterBaseName[2]))
                {
                    setterBaseName = char.ToLower(setterBaseName[2]) + setterBaseName[3..];
                }

                string setterSelector = prop.Setter ?? $"set{char.ToUpper(setterBaseName[0])}{setterBaseName[1..]}:";
                string setName = $"set{char.ToUpper(setterBaseName[0])}{setterBaseName[1..]}";
                string paramName = getterName;

                // Map the parameter type
                string paramType = returnType;

                propertySelectors.Add(setterSelector);
                methods.Add(new MethodInfo
                {
                    Name = setName,
                    ReturnType = "void",
                    IsStatic = false,
                    IsConst = false,
                    Parameters = [new ParamDef(paramType, paramName)],
                    UsesClassTarget = false,
                    Selector = setterSelector,
                    IsPropertyAccessor = true,
                    DeprecationMessage = prop.Deprecated ? prop.DeprecationMessage : null,
                });
            }
        }

        // Parse explicit methods
        foreach (AstMethod astMethod in ast.Methods)
        {
            if (SkipSelectors.Contains(astMethod.Selector))
            {
                continue;
            }

            // Skip methods that duplicate property selectors
            if (propertySelectors.Contains(astMethod.Selector))
            {
                continue;
            }

            string selector = astMethod.Selector;
            string name = !string.IsNullOrEmpty(astMethod.Name)
                ? astMethod.Name
                : SelectorToMethodName(selector);

            // Skip methods whose name clashes with a property (e.g., GPUStartTime vs gpuStartTime)
            // But allow overloads that have parameters (different selector, e.g., sparseTileSizeInBytesForSparsePageSize:)
            if (propertyNames.Contains(name) && astMethod.Parameters.Count == 0)
            {
                continue;
            }

            // Disambiguate: method with params whose name clashes with a property → prefix with "Get"
            if (propertyNames.Contains(name) && astMethod.Parameters.Count > 0)
            {
                name = "get" + name[0..1].ToUpperInvariant() + name[1..];
            }

            if (SkipMethods.Contains(name))
            {
                continue;
            }

            // Skip init methods with parameters — handled separately as constructors
            if (astMethod.Selector.StartsWith("init") && !astMethod.IsClassMethod && astMethod.Parameters.Count > 0)
            {
                continue;
            }

            string returnType = MapObjCTypeForModel(astMethod.ReturnType);

            // Skip unmappable return types
            if (IsUnmappableObjCType(astMethod.ReturnType))
            {
                continue;
            }

            // For NSArray-returning methods, try to extract the element type from AST generics.
            // If resolved, register it in the context so the emitter can look it up.
            if (returnType.StartsWith("NSArray"))
            {
                string? elemType = ExtractNSArrayElementType(astMethod.ReturnType);
                if (elemType == null)
                {
                    continue;
                }

                string csElemType = TypeMapper.MapType(elemType);
                string csMethodName = TypeMapper.ToPascalCase(name);
                context.NSArrayReturnTypes.TryAdd((ast.Name, csMethodName), csElemType);
            }

            // Parse parameters
            var (parameters, skipMethod) = ParseMethodParameters(astMethod.Parameters, skipUnresolvedCollections: true);

            if (skipMethod)
            {
                continue;
            }

            // Post-process: detect (pointer, count) array patterns and re-tag types
            DetectArrayParamPairs(parameters);

            bool usesClassTarget = astMethod.IsClassMethod;

            methods.Add(new MethodInfo
            {
                Name = name,
                ReturnType = returnType,
                IsStatic = astMethod.IsClassMethod,
                IsConst = !astMethod.IsClassMethod && returnType != "void",
                Parameters = parameters,
                UsesClassTarget = usesClassTarget,
                Selector = selector,
                DeprecationMessage = astMethod.Deprecated ? astMethod.DeprecationMessage : null,
            });
        }

        // Parse init methods (parameterized constructors)
        foreach (AstMethod astMethod in ast.Methods)
        {
            // Only instance methods whose selector starts with "init" and have parameters
            if (astMethod.IsClassMethod || !astMethod.Selector.StartsWith("init") || astMethod.Parameters.Count == 0)
            {
                continue;
            }

            // Skip selectors already explicitly excluded (e.g., initWithCoder:)
            if (SkipSelectors.Contains(astMethod.Selector))
            {
                continue;
            }

            // Parse parameters — skip if any are unmappable
            var (parameters, skipMethod) = ParseMethodParameters(astMethod.Parameters, skipUnresolvedCollections: false);

            if (skipMethod)
            {
                continue;
            }

            // Post-process array param pairs
            DetectArrayParamPairs(parameters);

            string initName = astMethod.Name != "init"
                ? astMethod.Name
                : SelectorToMethodName(astMethod.Selector);

            methods.Add(new MethodInfo
            {
                Name = initName,
                ReturnType = "instancetype",
                IsStatic = false,
                IsConst = false,
                Parameters = parameters,
                UsesClassTarget = false,
                Selector = astMethod.Selector,
                IsInit = true,
                DeprecationMessage = astMethod.Deprecated ? astMethod.DeprecationMessage : null,
            });
        }

        // If class has init methods, it needs AllocInit capability (Class field)
        if (methods.Any(m => m.IsInit))
        {
            hasAllocInit = true;
        }

        context.Classes.Add(new ClassDef
        {
            Namespace = ns,
            Name = bareName,
            BaseClassName = csBaseClassName,
            Methods = methods,
            HasAllocInit = hasAllocInit,
            Deprecated = ast.Deprecated,
            DeprecationMessage = ast.Deprecated ? ast.DeprecationMessage : null,
        });
    }

    #endregion

    #region Parameter Parsing

    /// <summary>
    /// Parses ObjC AST parameters into <see cref="ParamDef"/> list, resolving NSArray/NSSet generics.
    /// When <paramref name="skipUnresolvedCollections"/> is <see langword="true"/>, methods with
    /// unresolved <c>NSArray*</c> or <c>NSDictionary*</c> params are skipped (explicit methods);
    /// init methods pass <see langword="false"/> since they allow raw collection params.
    /// </summary>
    static (List<ParamDef> Parameters, bool Skip) ParseMethodParameters(List<AstParam> astParams, bool skipUnresolvedCollections)
    {
        List<ParamDef> parameters = [];
        foreach (AstParam p in astParams)
        {
            if (IsUnmappableObjCType(p.Type))
            {
                return ([], true);
            }

            string paramType = MapObjCTypeForModel(p.Type);

            // For NSArray params, try to extract generic element type for typed array support
            if (paramType == "NSArray*")
            {
                string? elemType = ExtractNSArrayElementType(p.Type);
                if (elemType != null)
                {
                    paramType = $"{ParamDef.NsArrayParam}{elemType}";
                }
            }

            // For NSSet params, try to extract generic element type for typed array support
            if (paramType == "NSSet*")
            {
                string? elemType = ExtractNSArrayElementType(p.Type);
                if (elemType != null)
                {
                    paramType = $"{ParamDef.NsSetParam}{elemType}";
                }
            }

            // Skip methods with unresolved NSArray/NSDictionary parameters
            if (skipUnresolvedCollections && paramType is "NSArray*" or "NSDictionary*")
            {
                return ([], true);
            }

            parameters.Add(new ParamDef(paramType, p.Name));
        }
        return (parameters, false);
    }

    #endregion

    #region Array Parameter Detection

    /// <summary>
    /// Detects <c>(pointer, count)</c> parameter pairs and re-tags the pointer parameter
    /// as <c>STRUCT_ARRAY:ElementType</c> and the count parameter as <c>ARRAY_PARAM</c>.
    /// Handles <c>const StructType*</c> and non-const <c>StructType*</c> patterns
    /// followed by an <c>NS::UInteger</c> parameter named <c>count</c>.
    /// <para>
    /// <c>OBJ_ARRAY:</c> patterns are already detected during type mapping for
    /// <c>id&lt;Protocol&gt; const *</c> types; this method handles struct/primitive pointer arrays.
    /// </para>
    /// </summary>
    static void DetectArrayParamPairs(List<ParamDef> parameters)
    {
        for (int i = 0; i < parameters.Count - 1; i++)
        {
            ParamDef current = parameters[i];
            ParamDef next = parameters[i + 1];

            // Already tagged as an array by type mapping
            if (current.Type.StartsWith(ParamDef.ObjArray) ||
                current.Type.StartsWith(ParamDef.StructArray) ||
                current.Type.StartsWith(ParamDef.PrimArray))
            {
                continue;
            }

            // Next param must be count
            if (next.Type is not "NS::UInteger" || next.Name is not "count")
            {
                continue;
            }

            // Check for struct pointer: "const StructType*" or "StructType*"
            string type = current.Type;
            if (type.StartsWith("const ") && type.EndsWith('*'))
            {
                string elemType = type["const ".Length..];
                parameters[i] = new ParamDef($"{ParamDef.StructArray}{elemType}", current.Name);
                parameters[i + 1] = new ParamDef(ParamDef.ArrayParam, next.Name);
            }
            else if (type.EndsWith('*') && TypeMapper.StructTypes.Contains(type.TrimEnd('*')))
            {
                parameters[i] = new ParamDef($"{ParamDef.StructArray}{type}", current.Name);
                parameters[i + 1] = new ParamDef(ParamDef.ArrayParam, next.Name);
            }
        }

        // Range-terminated arrays: if the last parameter is NSRange, tag untagged
        // pointer parameters as PRIM_ARRAY so the emitter can marshal them correctly.
        // E.g., setVertexBuffers:offsets:withRange: has (OBJ_ARRAY:MTLBuffer, const NSUInteger*, NSRange).
        if (parameters.Count >= 2 && parameters[^1].Type is "NSRange")
        {
            for (int i = 0; i < parameters.Count - 1; i++)
            {
                ParamDef current = parameters[i];

                // Already tagged
                if (current.Type.StartsWith(ParamDef.ObjArray) ||
                    current.Type.StartsWith(ParamDef.StructArray) ||
                    current.Type.StartsWith(ParamDef.PrimArray))
                {
                    continue;
                }

                string type = current.Type;

                // const X* → PRIM_ARRAY:csType
                if (type.StartsWith("const ") && type.EndsWith('*'))
                {
                    string elemModel = type["const ".Length..].TrimEnd('*').Trim();
                    string csElem = MapPrimElemType(elemModel);
                    parameters[i] = new ParamDef($"{ParamDef.PrimArray}{csElem}", current.Name);
                }
                // X* where X is a C primitive → PRIM_ARRAY:csType
                else if (type.EndsWith('*'))
                {
                    string elemModel = type.TrimEnd('*').Trim();
                    if (PrimElemTypes.ContainsKey(elemModel))
                    {
                        parameters[i] = new ParamDef($"{ParamDef.PrimArray}{MapPrimElemType(elemModel)}", current.Name);
                    }
                }
            }
        }
    }

    /// <summary>Known model-type → C# type mappings for primitive array elements.</summary>
    static readonly Dictionary<string, string> PrimElemTypes = new(StringComparer.Ordinal)
    {
        ["NSUInteger"] = "nuint",
        ["NS::UInteger"] = "nuint",
        ["NSInteger"] = "nint",
        ["NS::Integer"] = "nint",
        ["float"] = "float",
        ["double"] = "double",
        ["uint32_t"] = "uint",
        ["int32_t"] = "int",
        ["uint64_t"] = "ulong",
        ["int64_t"] = "long",
        ["uint16_t"] = "ushort",
        ["int16_t"] = "short",
        ["uint8_t"] = "byte",
        ["int8_t"] = "sbyte",
    };

    /// <summary>Maps a model element type to a C# primitive type for PRIM_ARRAY tagging.</summary>
    static string MapPrimElemType(string modelElemType) =>
        PrimElemTypes.TryGetValue(modelElemType, out string? csType) ? csType : modelElemType;

    #endregion
}
