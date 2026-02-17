namespace Metal.NET.HeaderParser;

/// <summary>
/// Maps metal-cpp C++ types to C# types used in our JSON definitions.
/// </summary>
public static class TypeMapper
{
    /// <summary>
    /// Convert a metal-cpp C++ type string to the corresponding C# type
    /// for our JSON definition format.
    /// </summary>
    public static string ToCSharpType(string cppType)
    {
        // Trim whitespace, const, pointer markers
        var t = cppType.Trim();
        t = t.Replace("const ", "").Trim();
        t = t.TrimEnd('*', '&').Trim();

        // Remove namespace prefixes
        t = StripNamespace(t);

        return t switch
        {
            // Primitive types
            "void" => "void",
            "bool" => "Bool8",
            "float" => "float",
            "double" => "double",
            "uint8_t" => "byte",
            "uint16_t" => "ushort",
            "uint32_t" => "uint",
            "uint64_t" => "ulong",
            "int8_t" => "sbyte",
            "int16_t" => "short",
            "int32_t" => "int",
            "int64_t" => "long",
            "UInteger" => "UIntPtr",
            "Integer" => "IntPtr",

            // Foundation
            "String" => "NSString",
            "Error" => "NSError",
            "Array" => "NSArray",
            "URL" => "IntPtr",
            "Data" or "dispatch_data_t" => "IntPtr",

            // Metal enum types (already parsed as enums — we use uint for properties,
            // but the enum name for method parameters)
            _ when IsKnownEnumType(t) => t.StartsWith("MTL") ? t : $"MTL{t}",

            // Metal value structs
            "Origin" => "MTLOrigin",
            "Size" => "MTLSize",
            "Region" => "MTLRegion",
            "Viewport" => "MTLViewport",
            "ScissorRect" => "MTLScissorRect",
            "ClearColor" => "MTLClearColor",
            "SamplePosition" => "MTLSamplePosition",
            "CGSize" => "CGSize",

            // Metal ObjC types — prefix with MTL if not already
            _ => t.StartsWith("MTL") || t.StartsWith("CA") || t.StartsWith("NS") ? t : $"MTL{t}",
        };
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
        return csType is "MTLOrigin" or "MTLSize" or "MTLRegion" or "MTLViewport"
            or "MTLScissorRect" or "MTLClearColor" or "MTLSamplePosition" or "CGSize";
    }

    /// <summary>
    /// Whether the C# type is a primitive (not an ObjC wrapper struct).
    /// </summary>
    public static bool IsPrimitive(string csType)
    {
        return csType is "void" or "bool" or "Bool8" or "float" or "double"
            or "byte" or "sbyte" or "short" or "ushort" or "uint" or "ulong"
            or "int" or "long" or "IntPtr" or "UIntPtr" or "nint" or "nuint";
    }

    private static string StripNamespace(string t)
    {
        // "MTL::Device" -> "Device", "NS::String" -> "String"
        var idx = t.LastIndexOf("::", StringComparison.Ordinal);
        if (idx >= 0)
        {
            var ns = t[..idx];
            var name = t[(idx + 2)..];
            // Preserve certain prefixes
            if (ns is "CA") return $"CA{name}";
            return name;
        }
        return t;
    }

    private static readonly HashSet<string> s_knownEnumSuffixes =
    [
        "Format", "Action", "Mode", "Type", "Function", "Operation",
        "Factor", "Mask", "Options", "Filter", "Usage", "Version",
        "Status", "Winding", "Rate", "Step", "Family", "Set",
        "Mutability", "DataType", "Access", "Hazard", "Policy",
        "Level", "Color", "Stage",
    ];

    private static readonly HashSet<string> s_knownEnumNames =
    [
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
    ];
}
