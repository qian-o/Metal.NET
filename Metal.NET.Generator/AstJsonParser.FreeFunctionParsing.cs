namespace Metal.NET.Generator;

partial class AstJsonParser
{
    #region Free Function Parsing

    static void ParseFreeFunctions(AstRoot ast, GeneratorContext context)
    {
        foreach (AstFunction func in ast.Functions)
        {
            if (func.Framework is null)
            {
                continue;
            }

            string returnType = MapObjCTypeForModel(func.ReturnType);
            if (IsUnmappableObjCType(func.ReturnType))
            {
                continue;
            }

            // Skip C header static-inline struct constructor helpers (e.g., MTLOriginMake, MTLRegionMake2D).
            // They are NS_INLINE in the SDK headers and have no exported symbols in Metal.framework,
            // and the generated C# structs already provide constructors.
            if (TypeMapper.StructTypes.Contains(TypeMapper.MapType(returnType)))
            {
                continue;
            }

            // Determine correct prefix: try longest prefixes first (MTL4FX, MTL4, MTLFX, MTL, NS, CA)
            string funcNs = InferNamespaceFromName(func.Name);
            string prefix = funcNs != "" ? TypeMapper.GetPrefix(funcNs) : "";

            string name = func.Name.StartsWith(prefix) && prefix.Length > 0
                ? func.Name[prefix.Length..]
                : func.Name;

            // Determine target class name from function name
            string targetClassName = DeriveTargetClassName(prefix);

            // For NSArray-returning free functions, extract the element type from AST generics
            if (returnType.StartsWith("NSArray"))
            {
                string? elemType = ExtractNSArrayElementType(func.ReturnType);
                if (elemType == null)
                {
                    continue;
                }

                context.NSArrayReturnTypes.TryAdd((targetClassName, name), TypeMapper.MapType(elemType));
            }

            string ns = funcNs != "" ? funcNs : FrameworkToNamespace(func.Framework);

            List<ParamDef> parameters = [];
            bool skip = false;
            foreach (AstParam p in func.Parameters)
            {
                if (IsUnmappableObjCType(p.Type))
                {
                    skip = true;
                    break;
                }

                string paramType = MapObjCTypeForModel(p.Type);

                // Skip functions with NSArray/NSDictionary parameters
                if (paramType.StartsWith("NSArray") || paramType.StartsWith("NSDictionary"))
                {
                    skip = true;
                    break;
                }

                parameters.Add(new ParamDef(paramType, p.Name));
            }
            if (skip)
            {
                continue;
            }

            string libraryPath = FrameworkToLibraryPath(func.Framework);

            context.FreeFunctions.Add(new FreeFunctionDef(
                func.Name, returnType, name, parameters,
                libraryPath, ns, targetClassName));
        }
    }

    /// <summary>Derives the target C# class name for a free function based on its prefix.</summary>
    static string DeriveTargetClassName(string prefix) =>
        // e.g., MTLCopyAllDevices → MTLDevice, MTLCreateSystemDefaultDevice → MTLDevice
        prefix + "Device";

    /// <summary>Maps a framework name to the native library path on macOS.</summary>
    static string FrameworkToLibraryPath(string framework)
        => $"/System/Library/Frameworks/{framework}.framework/{framework}";

    #endregion
}
