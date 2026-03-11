using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Maps C++ types to C# types, resolves MsgSend method variants,
/// and provides naming helpers (PascalCase, camelCase, reserved word escaping).
/// </summary>
partial class TypeMapper(GeneratorContext context)
{
    /// <summary>Struct types returned by value (not nullable, not reference types).</summary>
    public static readonly HashSet<string> StructTypes =
    [
        "NSRange", "MTLRegion", "MTLSize", "MTLOrigin", "MTLSamplePosition", "MTLViewport",
        "MTLScissorRect", "MTLClearColor", "CGSize", "MTLResourceID", "MTLSizeAndAlign",
        "MTLAccelerationStructureSizes", "MTLTextureSwizzleChannels",
        "MTLVertexAmplificationViewMapping", "MTL4BufferRange", "MTLRange",
        "MTL4CopySparseBufferMappingOperation", "MTL4CopySparseTextureMappingOperation",
        "MTL4UpdateSparseBufferMappingOperation", "MTL4UpdateSparseTextureMappingOperation",
        "SimdFloat4x4"
    ];

    /// <summary>Known typos in metal-cpp headers (parameter name corrections).</summary>
    static readonly Dictionary<string, string> ParamNameCorrections = new()
    {
        ["frontFacingWindning"] = "frontFacingWinding"
    };

    /// <summary>C# reserved words that need @ prefix when used as identifiers.</summary>
    static readonly HashSet<string> CSharpReservedWords =
    [
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
        "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
        "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
        "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock",
        "long", "namespace", "new", "null", "object", "operator", "out", "override", "params",
        "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
        "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true",
        "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual",
        "void", "volatile", "while"
    ];

    #region Namespace Mapping

    public static string GetPrefix(string cppNamespace) => cppNamespace switch
    {
        "MTL" => "MTL",
        "MTL4" => "MTL4",
        "NS" => "NS",
        "CA" => "CA",
        "MTLFX" => "MTLFX",
        "MTL4FX" => "MTL4FX",
        _ => cppNamespace
    };

    public static string GetOutputSubdir(string cppNamespace) => cppNamespace switch
    {
        "MTL" or "MTL4" => "Metal",
        "NS" => "Foundation",
        "CA" => "QuartzCore",
        "MTLFX" or "MTL4FX" => "MetalFX",
        _ => "Metal"
    };

    #endregion

    #region Type Mapping

    /// <summary>
    /// Maps a C++ type string to a C# type name.
    /// Handles pointers, namespaced types (e.g., MTL::Device*), and special aliases.
    /// </summary>
    public static string MapCppType(string cppType, string defaultNs)
    {
        string t = cppType.Trim();

        // Remove const and class keywords
        t = t.Replace("const ", "").Replace("class ", "").Trim();

        bool isPointer = t.EndsWith('*');
        bool isDoublePointer = t.EndsWith("**");

        if (isDoublePointer)
        {
            t = t[..^2].Trim();
        }
        else if (isPointer)
        {
            t = t[..^1].Trim();
        }

        if (t == "void" && isPointer)
        {
            return "nint";
        }

        if (t == "void")
        {
            return "void";
        }

        string? simple = t switch
        {
            "NS::UInteger" when isPointer => "nint",
            "NS::Integer" when isPointer => "nint",
            "NS::UInteger" => "nuint",
            "NS::Integer" => "nint",
            "uint32_t" => "uint",
            "int32_t" => "int",
            "uint8_t" => "byte",
            "int8_t" => "sbyte",
            "uint16_t" => "ushort",
            "int16_t" => "short",
            "uint64_t" or "std::uint64_t" => "ulong",
            "int64_t" or "std::int64_t" => "long",
            "float" => "float",
            "double" => "double",
            "bool" => "bool",
            "char" when isPointer => "nint",
            "IOSurfaceRef" => "nint",
            "dispatch_queue_t" => "DispatchQueue",
            "dispatch_data_t" => "DispatchData",
            "CGColorSpaceRef" => "CGColorSpace",
            "CFTimeInterval" => "double",
            "CGSize" => "CGSize",
            "simd::float4x4" => "SimdFloat4x4",
            _ => null
        };
        if (simple != null)
        {
            return simple;
        }

        // Namespaced types (e.g., MTL::Device, NS::String)
        Match nsMatch = NamespaceTypeRegex().Match(t);
        if (nsMatch.Success)
        {
            string typeNs = nsMatch.Groups[1].Value;
            string typeName = nsMatch.Groups[2].Value.Trim();

            if (typeName == "GPUAddress")
            {
                return "nuint";
            }

            if (typeName == "Coordinate2D")
            {
                return "MTLSamplePosition";
            }

            if (typeName == "Timestamp")
            {
                return "ulong";
            }

            if (typeNs == "NS" && typeName == "Object")
            {
                return "NSObject";
            }

            string prefix = GetPrefix(typeNs);
            return prefix + typeName;
        }

        // Unqualified type in same namespace
        if (!t.Contains("::"))
        {
            if (t == "GPUAddress")
            {
                return "nuint";
            }

            if (t == "Coordinate2D")
            {
                return "MTLSamplePosition";
            }

            if (t == "Timestamp")
            {
                return "ulong";
            }

            // NS basic types used without namespace qualifier inside NS namespace
            if (t == "UInteger")
            {
                return isPointer ? "nint" : "nuint";
            }

            if (t == "Integer")
            {
                return "nint";
            }

            string prefix = GetPrefix(defaultNs);
            return prefix + t;
        }

        return "nint";
    }

    /// <summary>
    /// Returns true if the C# type represents a NativeObject subclass (not a primitive, struct, or enum).
    /// </summary>
    public bool IsNativeObjectType(string csType)
    {
        if (csType is "void" or "bool" or "nint" or "nuint" or "uint" or "int" or "ulong" or "long" or "float" or "double"
            or "byte" or "sbyte" or "short" or "ushort")
        {
            return false;
        }

        if (StructTypes.Contains(csType))
        {
            return false;
        }

        if (context.EnumBackingTypes.ContainsKey(csType))
        {
            return false;
        }

        return true;
    }

    public bool IsEnumType(string csType) => context.EnumBackingTypes.ContainsKey(csType);

    /// <summary>
    /// Returns true if the C++ type cannot be mapped to a C# type (templates, references, etc.).
    /// </summary>
    public static bool IsUnmappableCppType(string cppType)
    {
        string t = cppType;

        if (t.Contains('<') || t.Contains('>'))
        {
            return true;
        }

        if (t.Contains('&'))
        {
            return true;
        }

        if (t.Contains("* const") && !t.Contains("**"))
        {
            return true;
        }

        if (t.Contains("Autoreleased"))
        {
            return true;
        }

        if (t.Contains("NS::Process") ||
            t.Contains("NS::Observer"))
        {
            return true;
        }

        if (t.Contains("kern_return_t") || t.Contains("task_id_token_t"))
        {
            return true;
        }

        return false;
    }

    #endregion

    #region MsgSend Mapping

    /// <summary>
    /// Returns the MsgSend method group name for a given C# return type (e.g., "nint" → "MsgSendPtr").
    /// </summary>
    public static string GetMsgSendMethod(string csType) => csType switch
    {
        "nint" => "MsgSendPtr",
        "nuint" => "MsgSendNUInt",
        "uint" => "MsgSendUInt",
        "int" => "MsgSendInt",
        "ulong" => "MsgSendULong",
        "long" => "MsgSendLong",
        "float" => "MsgSendFloat",
        "double" => "MsgSendDouble",
        _ => "MsgSendPtr"
    };

    /// <summary>
    /// Returns the MsgSend call expression for reading an enum property, based on its backing type.
    /// </summary>
    public string GetMsgSendForEnumGet(string csEnumType)
    {
        if (context.EnumBackingTypes.TryGetValue(csEnumType, out string? backing))
        {
            return backing switch
            {
                "int" => "ObjectiveC.MsgSendInt",
                "uint" => "ObjectiveC.MsgSendUInt",
                "long" => "ObjectiveC.MsgSendLong",
                "ulong" => "ObjectiveC.MsgSendULong",
                _ => "ObjectiveC.MsgSendNUInt"
            };
        }
        return "ObjectiveC.MsgSendNUInt";
    }

    /// <summary>
    /// Returns the cast expression for setting an enum property value (e.g., "(nuint)").
    /// </summary>
    public string GetEnumSetCast(string csEnumType)
    {
        if (context.EnumBackingTypes.TryGetValue(csEnumType, out string? backing))
        {
            return backing switch
            {
                "int" => "(int)",
                "uint" => "(uint)",
                "long" => "(nint)",
                "ulong" => "(nuint)",
                _ => "(nuint)"
            };
        }
        return "(nuint)";
    }

    /// <summary>
    /// Returns the specialized MsgSend method for a struct return type (e.g., "MTLSize" → "MsgSendMTLSize").
    /// </summary>
    public static string GetMsgSendForStruct(string csType) => csType switch
    {
        "MTLSize" => "MsgSendMTLSize",
        "MTLSizeAndAlign" => "MsgSendMTLSizeAndAlign",
        "MTLResourceID" => "MsgSendMTLResourceID",
        "MTLClearColor" => "MsgSendMTLClearColor",
        "MTLAccelerationStructureSizes" => "MsgSendMTLAccelerationStructureSizes",
        "MTLTextureSwizzleChannels" => "MsgSendMTLTextureSwizzleChannels",
        "MTLSamplePosition" => "MsgSendMTLSamplePosition",
        "MTL4BufferRange" => "MsgSendMTL4BufferRange",
        "NSRange" => "MsgSendNSRange",
        "CGSize" => "MsgSendCGSize",
        "SimdFloat4x4" => "MsgSendSimdFloat4x4",
        _ => "MsgSendPtr"
    };

    #endregion

    #region Ownership

    /// <summary>
    /// Returns true if the method name implies an ownership transfer per ObjC naming conventions
    /// (new*, alloc*, copy*, mutableCopy*, init*). Callers receive owned references from these methods.
    /// </summary>
    public static bool IsOwnershipTransferMethod(string cppName)
    {
        if (cppName.StartsWith("new") && (cppName.Length == 3 || char.IsUpper(cppName[3])))
        {
            return true;
        }

        if (cppName.StartsWith("alloc") && (cppName.Length == 5 || char.IsUpper(cppName[5])))
        {
            return true;
        }

        if (cppName.StartsWith("copy") && (cppName.Length == 4 || char.IsUpper(cppName[4])))
        {
            return true;
        }

        if (cppName.StartsWith("mutableCopy") && (cppName.Length == 11 || char.IsUpper(cppName[11])))
        {
            return true;
        }

        if (cppName.StartsWith("init") && (cppName.Length == 4 || char.IsUpper(cppName[4])))
        {
            return true;
        }

        return false;
    }

    #endregion

    #region Naming Helpers

    public static string ToPascalCase(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }

        if (name.Length == 1)
        {
            return char.ToUpper(name[0]).ToString();
        }

        return char.ToUpper(name[0]) + name[1..];
    }

    public static string ToCamelCase(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }

        if (ParamNameCorrections.TryGetValue(name, out string? corrected))
        {
            name = corrected;
        }

        if (name.Length == 1)
        {
            return char.ToLower(name[0]).ToString();
        }

        return char.ToLower(name[0]) + name[1..];
    }

    public static string EscapeReservedWord(string name) =>
        CSharpReservedWords.Contains(name) ? "@" + name : name;

    #endregion

    #region Generated Regex

    [GeneratedRegex(@"^(MTL4FX|MTL4|MTLFX|MTL|NS|CA|CG)\s*::\s*(.+)$")]
    private static partial Regex NamespaceTypeRegex();

    #endregion
}
