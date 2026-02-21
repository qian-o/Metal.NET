using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Maps C++ types to C# types, resolves MsgSend method variants,
/// and provides naming helpers (PascalCase, camelCase, reserved word escaping).
/// </summary>
partial class TypeMapper(GeneratorContext context)
{
    /// <summary>
    /// Struct types (returned by value, not nullable).
    /// </summary>
    public static readonly HashSet<string> StructTypes =
    [
        "NSRange", "MTLRegion", "MTLSize", "MTLOrigin", "MTLSamplePosition", "MTLViewport",
        "MTLScissorRect", "MTLClearColor", "CGSize", "MTLResourceID", "MTLSizeAndAlign",
        "MTLAccelerationStructureSizes", "MTLTextureSwizzleChannels",
        "MTLVertexAmplificationViewMapping", "MTL4BufferRange", "MTL4Origin", "MTL4Size",
        "MTL4Range", "MTLRange",
        "MTL4CopySparseBufferMappingOperation", "MTL4CopySparseTextureMappingOperation",
        "MTL4UpdateSparseBufferMappingOperation", "MTL4UpdateSparseTextureMappingOperation",
        "SimdFloat4x4"
    ];

    /// <summary>
    /// Known typos in metal-cpp headers (parameter name corrections).
    /// </summary>
    static readonly Dictionary<string, string> ParamNameCorrections = new()
    {
        ["frontFacingWindning"] = "frontFacingWinding"
    };

    /// <summary>
    /// C# reserved words.
    /// </summary>
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
            "dispatch_queue_t" => "nint",
            "dispatch_data_t" => "nint",
            "CGColorSpaceRef" => "nint",
            "CFTimeInterval" => "double",
            "CGSize" => "CGSize",
            "simd::float4x4" => "SimdFloat4x4",
            _ => null
        };
        if (simple != null)
        {
            return simple;
        }

        // Namespaced types
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

            string prefix = GetPrefix(defaultNs);
            return prefix + t;
        }

        return "nint";
    }

    public bool IsNullableType(string csType)
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

        if (t.Contains("Timestamp") && !t.Contains("TimestampGranularity"))
        {
            return true;
        }

        if (t.Contains("Autoreleased"))
        {
            return true;
        }

        if (t.Contains("NS::Bundle") || t.Contains("NS::Process") ||
            t.Contains("NS::Notification") || t.Contains("NS::Observer") ||
            t.Contains("NS::Dictionary") || t.Contains("NS::Object") ||
            t.Contains("NS::Data") || t.Contains("NS::Number") ||
            t.Contains("NS::Set") || t.Contains("NS::Enumerator") ||
            t.Contains("NS::Value") || t.Contains("NS::Date"))
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

    public static string GetMsgSendMethod(string csType) => csType switch
    {
        "nint" => "MsgSendPtr",
        "nuint" => "MsgSendNUInt",
        "uint" => "MsgSendUInt",
        "int" => "MsgSendPtr",
        "ulong" => "MsgSendULong",
        "long" => "MsgSendPtr",
        "float" => "MsgSendFloat",
        "double" => "MsgSendDouble",
        _ => "MsgSendPtr"
    };

    public string GetMsgSendForEnumGet(string csEnumType)
    {
        if (context.EnumBackingTypes.TryGetValue(csEnumType, out string? backing))
        {
            return backing switch
            {
                "int" => "ObjectiveCRuntime.MsgSendInt",
                "uint" => "ObjectiveCRuntime.MsgSendUInt",
                "long" => "ObjectiveCRuntime.MsgSendPtr",
                "ulong" => "ObjectiveCRuntime.MsgSendNUInt",
                _ => "ObjectiveCRuntime.MsgSendNUInt"
            };
        }
        return "ObjectiveCRuntime.MsgSendNUInt";
    }

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
