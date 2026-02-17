using System.Collections.Generic;
using System.Linq;

namespace Metal.NET.Generator;

/// <summary>
/// Maps metal-cpp C++ types to C# types.
/// Ported from Metal.NET.HeaderParser for direct use in the source generator.
/// </summary>
internal static class HeaderTypeMapper
{
    /// <summary>
    /// Convert a metal-cpp C++ type string to the corresponding C# type
    /// for our binding definitions.
    /// </summary>
    public static string ToCSharpType(string cppType)
    {
        // Trim whitespace, const, pointer markers
        var t = cppType.Trim();
        t = t.Replace("const ", "").Trim();
        t = t.TrimEnd('*', '&').Trim();

        // Remove namespace prefixes
        t = StripNamespace(t);

        switch (t)
        {
            // Primitive types
            case "void": return "void";
            case "bool": return "Bool8";
            case "float": return "float";
            case "double": return "double";
            case "uint8_t": return "byte";
            case "uint16_t": return "ushort";
            case "uint32_t": return "uint";
            case "uint64_t": return "ulong";
            case "int8_t": return "sbyte";
            case "int16_t": return "short";
            case "int32_t": return "int";
            case "int64_t": return "long";
            case "UInteger": return "UIntPtr";
            case "Integer": return "IntPtr";

            // Foundation
            case "String": return "NSString";
            case "Error": return "NSError";
            case "Array": return "NSArray";
            case "URL": return "IntPtr";
            case "Data":
            case "dispatch_data_t":
                return "IntPtr";

            // Metal value structs
            case "Origin": return "MTLOrigin";
            case "Size": return "MTLSize";
            case "Region": return "MTLRegion";
            case "Viewport": return "MTLViewport";
            case "ScissorRect": return "MTLScissorRect";
            case "ClearColor": return "MTLClearColor";
            case "SamplePosition": return "MTLSamplePosition";
            case "CGSize": return "CGSize";

            default:
                // Metal enum types
                if (IsKnownEnumType(t))
                    return t.StartsWith("MTL") ? t : $"MTL{t}";
                // Metal ObjC types — prefix with MTL if not already
                if (t.StartsWith("MTL") || t.StartsWith("CA") || t.StartsWith("NS"))
                    return t;
                return $"MTL{t}";
        }
    }

    /// <summary>
    /// Whether the original C++ type was a pointer (i.e., an ObjC object wrapper).
    /// </summary>
    public static bool IsPointerType(string cppType)
    {
        return cppType.Trim().EndsWith("*");
    }

    /// <summary>
    /// Determines if a type (after namespace stripping) is a known Metal enum.
    /// </summary>
    public static bool IsKnownEnumType(string shortType)
    {
        return s_knownEnumSuffixes.Any(suffix => shortType.EndsWith(suffix))
            || s_knownEnumNames.Contains(shortType);
    }

    /// <summary>
    /// Whether the C# type is a value struct (passed by value, not via NativePtr).
    /// </summary>
    public static bool IsValueStruct(string csType)
    {
        return csType == "MTLOrigin" || csType == "MTLSize" || csType == "MTLRegion"
            || csType == "MTLViewport" || csType == "MTLScissorRect" || csType == "MTLClearColor"
            || csType == "MTLSamplePosition" || csType == "CGSize";
    }

    /// <summary>
    /// Whether the C# type is a primitive (not an ObjC wrapper struct).
    /// </summary>
    public static bool IsPrimitive(string csType)
    {
        return csType == "void" || csType == "bool" || csType == "Bool8"
            || csType == "float" || csType == "double"
            || csType == "byte" || csType == "sbyte" || csType == "short" || csType == "ushort"
            || csType == "uint" || csType == "ulong"
            || csType == "int" || csType == "long"
            || csType == "IntPtr" || csType == "UIntPtr" || csType == "nint" || csType == "nuint";
    }

    private static string StripNamespace(string t)
    {
        // "MTL::Device" -> "Device", "NS::String" -> "String"
        var idx = t.LastIndexOf("::");
        if (idx >= 0)
        {
            var ns = t.Substring(0, idx);
            var name = t.Substring(idx + 2);
            // Preserve certain prefixes
            if (ns == "CA") return $"CA{name}";
            return name;
        }
        return t;
    }

    private static readonly HashSet<string> s_knownEnumSuffixes = new HashSet<string>
    {
        "Format", "Action", "Mode", "Type", "Function", "Operation",
        "Factor", "Mask", "Options", "Filter", "Usage", "Version",
        "Status", "Winding", "Rate", "Step", "Family", "Set",
        "Mutability", "DataType", "Access", "Hazard", "Policy",
        "Level", "Color", "Stage",
    };

    private static readonly HashSet<string> s_knownEnumNames = new HashSet<string>
    {
        "PixelFormat", "PrimitiveType", "IndexType", "CullMode",
        "Winding", "TriangleFillMode", "CompareFunction", "StencilOperation",
        "BlendFactor", "BlendOperation", "ColorWriteMask", "VertexFormat",
        "VertexStepFunction", "SamplerMinMagFilter", "SamplerMipFilter",
        "SamplerAddressMode", "SamplerBorderColor", "ResourceOptions",
        "CPUCacheMode", "StorageMode", "TextureUsage", "TextureType",
        "FunctionType", "LanguageVersion", "CommandBufferStatus",
        "LoadAction", "StoreAction", "PurgeableState", "GPUFamily",
        "FeatureSet", "DepthClipMode", "DispatchType",
        "MultisampleDepthResolveFilter", "MultisampleStencilResolveFilter",
        "PrimitiveTopologyClass", "TessellationPartitionMode",
        "TessellationFactorStepFunction", "TessellationControlPointIndexType",
        "TessellationFactorFormat",
    };
}
