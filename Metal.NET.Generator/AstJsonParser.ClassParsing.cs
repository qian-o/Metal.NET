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
            string getterName = SelectorToMethodName(getterSelector);
            string returnType = MapObjCTypeForModel(propObjcType);

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
            if (propertyNames.Contains(name))
            {
                continue;
            }

            if (SkipMethods.Contains(name))
            {
                continue;
            }

            string returnType = MapObjCTypeForModel(astMethod.ReturnType);

            // Skip unmappable return types
            if (IsUnmappableObjCType(astMethod.ReturnType))
            {
                continue;
            }

            // Skip methods that return NSArray (can only be used as properties)
            if (returnType.StartsWith("NSArray"))
            {
                continue;
            }

            // Parse parameters
            List<ParamDef> parameters = [];
            bool skipMethod = false;
            foreach (AstParam p in astMethod.Parameters)
            {
                if (IsUnmappableObjCType(p.Type))
                {
                    skipMethod = true;
                    break;
                }

                string paramType = MapObjCTypeForModel(p.Type);

                // Skip methods with NSArray/NSDictionary parameters (static class, can't be used as params)
                if (paramType.StartsWith("NSArray") || paramType.StartsWith("NSDictionary"))
                {
                    skipMethod = true;
                    break;
                }

                parameters.Add(new ParamDef(paramType, p.Name));
            }

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
            if (current.Type.StartsWith("OBJ_ARRAY:") ||
                current.Type.StartsWith("STRUCT_ARRAY:") ||
                current.Type.StartsWith("PRIM_ARRAY:"))
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
                parameters[i] = new ParamDef($"STRUCT_ARRAY:{elemType}", current.Name);
                parameters[i + 1] = new ParamDef("ARRAY_PARAM", next.Name);
            }
            else if (type.EndsWith('*') && TypeMapper.StructTypes.Contains(type.TrimEnd('*')))
            {
                parameters[i] = new ParamDef($"STRUCT_ARRAY:{type}", current.Name);
                parameters[i + 1] = new ParamDef("ARRAY_PARAM", next.Name);
            }
        }
    }

    #endregion
}
