namespace Metal.NET.Generator;

/// <summary>
/// Deserializes metal-ast.json and populates a <see cref="GeneratorContext"/>
/// with enum, class, struct, free function, and block type alias definitions.
/// </summary>
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

            if (cls.Framework is null or "CoreFoundation" or "CoreGraphics")
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
        if (!isProtocol && !string.IsNullOrEmpty(ast.Super) && ast.Super != "NSObject")
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

            string getterSelector = prop.Getter ?? prop.Name;
            string getterName = SelectorToMethodName(getterSelector);
            string returnType = MapObjCTypeForModel(propObjcType);

            // Getter
            propertySelectors.Add(getterSelector);
            methods.Add(new MethodInfo
            {
                Name = getterName,
                ReturnType = returnType,
                IsStatic = false,
                IsConst = true,
                Parameters = [],
                UsesClassTarget = false,
                Selector = getterSelector,
                DeprecationMessage = prop.Deprecated ? prop.DeprecationMessage : null,
            });

            // Setter (if not readonly)
            if (!prop.Readonly)
            {
                string setterSelector = prop.Setter ?? $"set{char.ToUpper(prop.Name[0])}{prop.Name[1..]}:";
                string setName = $"set{char.ToUpper(getterName[0])}{getterName[1..]}";
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
            string name = SelectorToMethodName(selector);

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
}
