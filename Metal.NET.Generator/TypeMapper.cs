namespace Metal.NET.Generator;

/// <summary>
/// Maps ObjC types to C# types, resolves MsgSend method variants,
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
        "MTLVertexAmplificationViewMapping", "MTL4BufferRange",
        "MTL4CopySparseBufferMappingOperation", "MTL4CopySparseTextureMappingOperation",
        "MTL4UpdateSparseBufferMappingOperation", "MTL4UpdateSparseTextureMappingOperation",
        "SimdFloat4x4",
        "MTLPackedFloat3", "MTLPackedFloatQuaternion", "MTLPackedFloat4x3",
        "MTLIndirectCommandBufferExecutionRange",
    ];

    /// <summary>Known typos in metal-ast.json parameter names (parameter name corrections).</summary>
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

    /// <summary>Returns the ObjC class-name prefix for the given namespace (e.g., "MTL" → "MTL").</summary>
    public static string GetPrefix(string ns) => ns switch
    {
        "MTL" => "MTL",
        "MTL4" => "MTL4",
        "NS" => "NS",
        "CA" => "CA",
        "MTLFX" => "MTLFX",
        "MTL4FX" => "MTL4FX",
        _ => ns
    };

    /// <summary>Returns the output subdirectory for a given namespace (e.g., "MTL" → "Metal").</summary>
    public static string GetOutputSubdir(string ns) => ns switch
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
    /// Maps an ObjC type string to a C# type name.
    /// Handles pointers, namespaced types (e.g., MTL::Device*), ObjC types (e.g., MTLDevice*),
    /// and special aliases.
    /// </summary>
    public static string MapType(string objcType)
    {
        string t = objcType.Trim();

        // Remove const, class keywords, ObjC annotations and nullability specifiers
        t = t.Replace("const ", "").Replace("class ", "")
             .Replace("NS_RETURNS_INNER_POINTER ", "")
             .Replace(" _Nonnull", "").Replace(" _Nullable", "")
             .Replace("_Nonnull ", "").Replace("_Nullable ", "")
             .Replace("_Nonnull", "").Replace("_Nullable", "")
             .Trim();

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
            "NSUInteger" when isPointer => "nint",
            "NSInteger" when isPointer => "nint",
            "NSUInteger" => "nuint",
            "NSInteger" => "nint",
            "uint32_t" => "uint",
            "int32_t" => "int",
            "uint8_t" => "byte",
            "int8_t" => "sbyte",
            "uint16_t" => "ushort",
            "int16_t" => "short",
            "uint64_t" or "std::uint64_t" => "ulong",
            "int64_t" or "std::int64_t" => "long",
            "long long" => "long",
            "unsigned long long" => "ulong",
            "unsigned int" => "uint",
            "unsigned long" => "nuint",
            "unsigned short" => "ushort",
            "unsigned char" => "byte",
            "short" => "short",
            "long" => "nint",
            "unichar" => "ushort",
            "OSType" => "uint",
            "NSStringEncoding" when isPointer => "nint",
            "NSStringEncoding" => "nuint",
            "NSErrorDomain" => "NSString",
            "NSErrorUserInfoKey" => "NSString",
            "NSURLResourceKey" => "NSString",
            "NSDecimal" => "nint",
            "Class" => "nint",
            "id" => "nint",
            "float" => "float",
            "double" => "double",
            "bool" or "BOOL" => "bool",
            "char" when isPointer => "nint",
            "char" => "sbyte",
            "IOSurfaceRef" => "nint",
            "dispatch_queue_t" => "DispatchQueue",
            "dispatch_data_t" => "DispatchData",
            "CGColorSpaceRef" => "CGColorSpace",
            "CFTimeInterval" => "double",
            "CGSize" => "CGSize",
            "CGFloat" => "double",
            "simd::float4x4" => "SimdFloat4x4",
            "SimdFloat4x4" => "SimdFloat4x4",
            "MTLGPUAddress" => "nuint",
            "MTLCoordinate2D" => "MTLSamplePosition",
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

            // ObjC types: the type name already has a prefix (e.g., MTLDevice, NSString)
            // Just return it as-is since it matches the C# class name
            return t;
        }

        return "nint";
    }

    /// <summary>
    /// Returns <see langword="true"/> if the C# type represents a <c>NativeObject</c> subclass
    /// (not a primitive, struct, or enum).
    /// </summary>
    public bool IsNativeObjectType(string csType) =>
        csType is not ("void" or "bool" or "nint" or "nuint" or "uint" or "int" or "ulong" or "long"
            or "float" or "double" or "byte" or "sbyte" or "short" or "ushort")
        && !StructTypes.Contains(csType)
        && !context.EnumBackingTypes.ContainsKey(csType);

    /// <summary>Returns <see langword="true"/> if <paramref name="csType"/> is a generated enum.</summary>
    public bool IsEnumType(string csType) => context.EnumBackingTypes.ContainsKey(csType);

    /// <summary>
    /// Returns <see langword="true"/> if the ObjC type cannot be mapped to a C# type
    /// (templates, references, const pointer qualifiers, or unsupported framework types).
    /// </summary>
    public static bool IsUnmappableType(string objcType) =>
        objcType.Contains('<') || objcType.Contains('>') ||
        objcType.Contains('&') ||
        (objcType.Contains("* const") && !objcType.Contains("**")) ||
        objcType.Contains("NS::Process") || objcType.Contains("NS::Observer") ||
        objcType.Contains("kern_return_t") || objcType.Contains("task_id_token_t");

    #endregion

    #region MsgSend Mapping

    /// <summary>
    /// Returns the MsgSend method group name for a given C# return type (e.g., "nint" → "MsgSendNInt").
    /// </summary>
    public static string GetMsgSendMethod(string csType) => csType switch
    {
        "nint" => "MsgSendNInt",
        "nuint" => "MsgSendNUInt",
        "uint" => "MsgSendUInt",
        "int" => "MsgSendInt",
        "ulong" => "MsgSendULong",
        "long" => "MsgSendLong",
        "float" => "MsgSendFloat",
        "double" => "MsgSendDouble",
        _ => "MsgSendNInt"
    };

    /// <summary>
    /// Returns <see langword="true"/> if a narrowing cast is needed from the MsgSend return type to <paramref name="csType"/>.
    /// </summary>
    public static bool NeedsNarrowCast(string csType) => csType is "sbyte" or "byte" or "short" or "ushort";

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
        _ => "MsgSendNInt"
    };

    #endregion

    #region Naming Helpers

    /// <summary>Converts the first character of <paramref name="name"/> to uppercase (PascalCase).</summary>
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

    /// <summary>Converts the first character of <paramref name="name"/> to lowercase (camelCase), applying known corrections.</summary>
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

    /// <summary>Prefixes <paramref name="name"/> with <c>@</c> if it collides with a C# reserved word.</summary>
    public static string EscapeReservedWord(string name) =>
        CSharpReservedWords.Contains(name) ? "@" + name : name;

    #endregion

    #region Generated Regex

    [GeneratedRegex(@"^(MTL4FX|MTL4|MTLFX|MTL|NS|CA|CG)\s*::\s*(.+)$")]
    private static partial Regex NamespaceTypeRegex();

    #endregion
}
