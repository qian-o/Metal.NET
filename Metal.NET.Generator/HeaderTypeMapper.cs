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
    public static string? ToCSharpType(string cppType)
    {
        // Trim whitespace, const, pointer markers
        var t = cppType.Trim();
        t = t.Replace("const ", "").Trim();

        // Strip C++ forward-declaration "class" keyword
        if (t.StartsWith("class "))
            t = t.Substring(6).Trim();

        // Detect pointer-to-array (e.g. "MTL::Buffer* buffers[]") — unsupported
        if (t.Contains("[]"))
            return null;

        // Check if original type was a pointer
        bool isPointer = t.Contains('*');
        t = t.TrimEnd('*', '&').Trim();

        // void* (pointer to raw data) maps to IntPtr, not void
        if (t == "void" && isPointer)
            return "IntPtr";

        // const char* → IntPtr (C string pointer)
        if (t == "char" && isPointer)
            return "IntPtr";

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
            // Plain C types
            case "int": return "int";
            case "unsigned int": return "uint";
            case "long": return "long";
            case "unsigned long": return "ulong";
            case "long long": return "long";
            case "unsigned long long": return "ulong";
            case "short": return "short";
            case "unsigned short": return "ushort";
            case "char": return "byte";
            case "unsigned char": return "byte";
            case "signed char": return "sbyte";
            case "unichar": return "ushort";
            case "UInteger": return "UIntPtr";
            case "Integer": return "IntPtr";

            // Foundation
            case "String": return "NSString";
            case "Error": return "NSError";
            case "Array": return "NSArray";
            case "Object": return "IntPtr";
            case "URL": return "IntPtr";
            case "Bundle": return "IntPtr";
            case "Dictionary": return "IntPtr";
            case "Number": return "IntPtr";
            case "Data":
            case "dispatch_data_t":
                return "IntPtr";

            // Opaque handle / platform types
            case "dispatch_queue_t": return "IntPtr";
            case "IOSurfaceRef": return "IntPtr";
            case "CGColorSpaceRef": return "IntPtr";
            case "task_id_token_t": return "IntPtr";

            // CFTimeInterval is a double
            case "CFTimeInterval": return "double";

            // Metal value structs
            case "Origin": return "MTLOrigin";
            case "Size": return "MTLSize";
            case "Region": return "MTLRegion";
            case "Viewport": return "MTLViewport";
            case "ScissorRect": return "MTLScissorRect";
            case "ClearColor": return "MTLClearColor";
            case "SamplePosition": return "MTLSamplePosition";
            case "Coordinate2D": return "MTLSamplePosition";
            case "CGSize": return "CGSize";

            // Metal small value types mapped to primitives
            case "GPUAddress": return "ulong";
            case "ResourceID": return "ulong";
            case "Range": return "IntPtr";

            default:
                // Skip callback/block/handler types — these can't be represented as simple types
                if (IsUnsupportedType(t))
                    return null;
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
    /// Types that we cannot represent in the bindings and should cause
    /// the method/property to be skipped entirely.
    /// </summary>
    public static bool IsUnsupportedType(string shortType)
    {
        // Callback / block / handler types
        if (shortType.EndsWith("Handler") || shortType.EndsWith("HandlerFunction")
            || shortType.EndsWith("Block") || shortType.EndsWith("NotificationFunction"))
            return true;
        // Autoreleased reflection pointer types — opaque in C#
        if (shortType.StartsWith("Autoreleased"))
            return true;
        // C++ value structs we haven't defined in the runtime yet
        // Strip any namespace prefix before checking
        var baseName = shortType;
        if (baseName.StartsWith("MTL4FX")) baseName = baseName.Substring(6);
        else if (baseName.StartsWith("MTLFX")) baseName = baseName.Substring(5);
        else if (baseName.StartsWith("MTL4")) baseName = baseName.Substring(4);
        else if (baseName.StartsWith("MTL")) baseName = baseName.Substring(3);
        if (s_unsupportedValueTypes.Contains(baseName))
            return true;
        // C++ template / complex types
        if (shortType.Contains("<") || shortType.Contains(">"))
            return true;
        return false;
    }

    private static readonly HashSet<string> s_unsupportedValueTypes = new HashSet<string>
    {
        "BufferRange", "AccelerationStructureSizes",
        "TextureSwizzleChannels", "VertexAmplificationViewMapping",
        "Timestamp", "float4x4", "Architecture",
        "IndirectCommandBufferSupportState",
        "CopySparseBufferMappingOperation", "CopySparseTextureMappingOperation",
        "UpdateSparseBufferMappingOperation", "UpdateSparseTextureMappingOperation",
    };

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
            || csType == "MTLSamplePosition" || csType == "CGSize"
            || csType == "MTLSizeAndAlign";
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

    /// <summary>
    /// C# reserved keywords that cannot be used as identifiers.
    /// </summary>
    public static bool IsCSharpKeyword(string name)
    {
        switch (name)
        {
            case "object": case "event": case "string": case "class": case "struct":
            case "enum": case "interface": case "delegate": case "namespace":
            case "abstract": case "base": case "bool": case "break": case "byte":
            case "case": case "catch": case "char": case "checked": case "const":
            case "continue": case "decimal": case "default": case "do": case "double":
            case "else": case "extern": case "false": case "finally": case "fixed":
            case "float": case "for": case "foreach": case "goto": case "if":
            case "implicit": case "in": case "int": case "internal": case "is":
            case "lock": case "long": case "new": case "null": case "operator":
            case "out": case "override": case "params": case "private": case "protected":
            case "public": case "readonly": case "ref": case "return": case "sbyte":
            case "sealed": case "short": case "sizeof": case "static":
            case "switch": case "this": case "throw": case "true": case "try":
            case "typeof": case "uint": case "ulong": case "unchecked": case "unsafe":
            case "ushort": case "using": case "virtual": case "void": case "volatile":
            case "while":
                return true;
            default:
                return false;
        }
    }

    private static string StripNamespace(string t)
    {
        // "MTL::Device" -> "Device", "NS::String" -> "String"
        // "MTL4::CommandBuffer" -> "MTL4CommandBuffer" (preserve MTL4 prefix)
        // "MTLFX::SpatialScaler" -> "MTLFXSpatialScaler" (preserve MTLFX prefix)
        var idx = t.LastIndexOf("::");
        if (idx >= 0)
        {
            var ns = t.Substring(0, idx);
            var name = t.Substring(idx + 2);
            // Preserve certain prefixes
            if (ns == "CA") return $"CA{name}";
            if (ns == "MTL4") return $"MTL4{name}";
            if (ns == "MTLFX") return $"MTLFX{name}";
            if (ns == "MTL4FX") return $"MTL4FX{name}";
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
        "Level", "Color", "Stage", "Granularity", "Stages",
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
