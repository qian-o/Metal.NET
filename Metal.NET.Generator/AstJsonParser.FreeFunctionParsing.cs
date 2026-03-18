namespace Metal.NET.Generator;

/// <summary>
/// Deserializes metal-ast.json and populates a <see cref="GeneratorContext"/>
/// with enum, class, struct, free function, and block type alias definitions.
/// </summary>
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

            // Skip free functions returning NSArray (static class, can't be returned)
            if (returnType.StartsWith("NSArray"))
            {
                continue;
            }

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

            // Determine correct prefix: try longest prefixes first (MTL4FX, MTL4, MTLFX, MTL, NS, CA)
            string funcNs = InferNamespaceFromName(func.Name);
            string prefix = funcNs != "" ? TypeMapper.GetPrefix(funcNs) : "";

            string name = func.Name.StartsWith(prefix) && prefix.Length > 0
                ? func.Name[prefix.Length..]
                : func.Name;

            // Determine target class name from function name
            string targetClassName = DeriveTargetClassName(prefix);

            string ns = funcNs != "" ? funcNs : FrameworkToNamespace(func.Framework);

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
    static string FrameworkToLibraryPath(string framework) => framework switch
    {
        "Metal" => "/System/Library/Frameworks/Metal.framework/Metal",
        "MetalFX" => "/System/Library/Frameworks/MetalFX.framework/MetalFX",
        "Foundation" => "/System/Library/Frameworks/Foundation.framework/Foundation",
        "QuartzCore" => "/System/Library/Frameworks/QuartzCore.framework/QuartzCore",
        _ => "/System/Library/Frameworks/Metal.framework/Metal"
    };

    #endregion
}
