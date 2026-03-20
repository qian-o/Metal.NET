namespace Metal.NET.Generator;

partial class AstJsonParser
{
    #region Type Mapping Helpers

    /// <summary>
    /// Maps an ObjC type string to the internal model representation that
    /// <see cref="TypeMapper.MapType"/> can subsequently resolve to a final C# type.
    /// Handles <c>id&lt;Protocol&gt;</c>, <c>NSArray</c>/<c>NSDictionary</c> generics,
    /// block handler types, inline blocks, and standard ObjC → C++ style type names.
    /// </summary>
    static string MapObjCTypeForModel(string objcType)
    {
        string t = StripNullability(objcType).Trim();

        // T *const * → OBJ_ARRAY:T (C-style array of object pointers)
        if (t.Contains("*const") && t.EndsWith('*'))
        {
            string elem = t.Replace("*const", "").TrimEnd('*', ' ').Trim();
            return $"{ParamDef.ObjArray}{elem}";
        }

        // id<Protocol> const * → OBJ_ARRAY:Protocol (pointer to array of protocol objects)
        Match idConstPtrMatch = IdProtocolConstPointerRegex().Match(t);
        if (idConstPtrMatch.Success)
        {
            return $"{ParamDef.ObjArray}{idConstPtrMatch.Groups[1].Value}";
        }

        // id<Protocol> → Protocol*
        Match idMatch = IdProtocolRegex().Match(t);
        if (idMatch.Success)
        {
            return idMatch.Groups[1].Value + "*";
        }

        // NSArray<...> / NSDictionary<...> → pointer form (element type resolved by emitter)
        if (t is "NSArray" || t.StartsWith("NSArray<") || t.StartsWith("NSArray *"))
        {
            return "NSArray*";
        }

        if (t is "NSDictionary" || t.StartsWith("NSDictionary<") || t.StartsWith("NSDictionary *"))
        {
            return "NSDictionary*";
        }

        if (t is "NSSet" || t.StartsWith("NSSet<") || t.StartsWith("NSSet *"))
        {
            return "NSSet*";
        }

        // Well-known exact-match types → switch expression
        string? exactMatch = t switch
        {
            "id" => "NSObject*",
            "BOOL" => "bool",
            "instancetype" => "void*",
            "NSUInteger" => "NS::UInteger",
            "NSInteger" => "NS::Integer",
            "CGColorSpaceRef" => "CGColorSpaceRef",
            "IOSurfaceRef" => "IOSurfaceRef",
            "CFTimeInterval" => "CFTimeInterval",
            "CGSize" => "CGSize",
            "dispatch_queue_t" => "dispatch_queue_t",
            "dispatch_data_t" => "dispatch_data_t",
            "CGFloat" => "double",
            "size_t" => "NS::UInteger",
            "simd_float4x4" => "SimdFloat4x4",
            "MTLGPUAddress" => "NS::UInteger",
            "MTLCoordinate2D" => "MTL::Coordinate2D*",
            "const char *" or "char *" => "char*",
            "unichar" => "ushort",
            "NSStringEncoding" => "NSStringEncoding",
            "NSComparisonResult" => "NSComparisonResult",
            "NSStringCompareOptions" => "NSStringCompareOptions",
            "const void *" or "void *" => "nint",
            "const unichar *" or "unichar *" => "nint",
            _ => null
        };
        if (exactMatch is not null)
        {
            return exactMatch;
        }

        // Block handler types (named typedefs like MTLCommandBufferHandler)
        if ((t.Contains("Handler") || t.Contains("Block")) &&
            !t.Contains('*') && !t.Contains('<') && !t.Contains('('))
        {
            return t;
        }

        // Inline block: void (^ _Nullable)(...) or void (^)(...)
        if (t.Contains("(^"))
        {
            Match inlineBlockMatch = InlineBlockTypeRegex().Match(t);
            if (inlineBlockMatch.Success &&
                InlineBlockDelegateNames.TryGetValue(inlineBlockMatch.Groups[1].Value.Trim(), out string? delegateName))
            {
                return $"{ParamDef.InlineBlock}{delegateName}";
            }
            return $"{ParamDef.InlineBlock}UNKNOWN_BLOCK";
        }

        // C primitive types — pass through as-is
        if (t is "uint32_t" or "int32_t" or "uint8_t" or "int8_t" or "uint16_t" or "int16_t"
                or "uint64_t" or "int64_t" or "float" or "double" or "void"
                or "kern_return_t" or "task_id_token_t")
        {
            return t;
        }

        // NSError ** → Error**
        if (t.Contains("NSError") && t.Count(c => c == '*') >= 2)
        {
            return "NS::Error**";
        }

        // Pointer types: MTLFoo * → BaseName* (optionally with const)
        if (t.EndsWith('*'))
        {
            string baseName = t.TrimEnd('*', ' ').Trim();
            if (baseName.StartsWith("const "))
            {
                baseName = baseName["const ".Length..].Trim();
                if (InferNamespaceFromName(baseName) is not "")
                {
                    return "const " + baseName + "*";
                }
            }
            return baseName + "*";
        }

        // Non-pointer ObjC types (enum values, struct values) — return as-is
        return t;
    }

    /// <summary>
    /// Extracts the element type from an ObjC <c>NSArray&lt;...&gt;</c> type string.
    /// Returns a model type string (e.g., "MTLFunctionStitchingNode*") or <see langword="null"/>
    /// if the element type cannot be resolved.
    /// </summary>
    static string? ExtractNSArrayElementType(string objcType)
    {
        string t = StripNullability(objcType).Trim();

        // Match NSArray<ElementType *> or NSArray<id<Protocol>>
        int start = t.IndexOf('<');
        int end = t.LastIndexOf('>');
        if (start < 0 || end <= start)
        {
            return null;
        }

        string inner = t[(start + 1)..end].Trim();

        // id<Protocol> → Protocol*
        if (inner.StartsWith("id<") && inner.EndsWith(">"))
        {
            string protocol = inner[3..^1];
            if (protocol.Contains("ObjectType") || protocol.Contains("KeyType"))
            {
                return null;
            }

            // Skipped protocols (e.g., NSCopying) → treat as NSObject
            if (SkipProtocols.Contains(protocol))
            {
                return "NSObject*";
            }

            return protocol + "*";
        }

        // ElementType * → ElementType*
        if (inner.EndsWith(" *") || inner.EndsWith("*"))
        {
            string elem = inner.TrimEnd(' ', '*').Trim();
            if (elem.Contains("ObjectType") || elem.Contains("KeyType"))
            {
                return null;
            }

            return elem + "*";
        }

        return null;
    }

    /// <summary>Exact-match ObjC types that cannot be mapped to C#.</summary>
    static readonly HashSet<string> UnmappableExactTypes =
    [
        "IMP", "SEL", "FourCharCode", "id *", "NSStringEncodingConversionOptions"
    ];

    /// <summary>Substring patterns that mark an ObjC type as unmappable.</summary>
    static readonly string[] UnmappablePatterns =
    [
        "NS::Process", "NS::Observer", "NSProcess", "NSObserver",
        "ObjectType", "KeyType", "NS_RETURNS_INNER_POINTER",
        "NSStringEncoding *", "NSCoder", "MTLIOCompressionContext", "va_list",
        "NSDate", "NSLocale", "NSCharacterSet", "NSStringTransform",
        "NSRangePointer", "NSURLBookmark", "NSURLHandle", "NSURLResourceKey",
        "NSDataWritingOptions", "NSDataSearchOptions", "NSDataReadingOptions",
        "NSDataBase64", "NSDataCompressionAlgorithm", "NSDecimal",
        "NSLinguistic", "NSEnumerator", "NSErrorDomain",
    ];

    /// <summary>
    /// Returns <see langword="true"/> if an ObjC type from the AST cannot be mapped to C#
    /// and the containing method/property should be skipped.
    /// </summary>
    static bool IsUnmappableObjCType(string objcType)
    {
        string t = StripNullability(objcType).Trim();

        if (UnmappableExactTypes.Contains(t))
        {
            return true;
        }

        // Structural exclusions: complex pointer patterns
        if ((t.Contains("*const ") && !t.EndsWith('*'))
            || (t.Contains("const") && t.Contains("* _Nonnull *") && !t.EndsWith('*')))
        {
            return true;
        }

        foreach (string pattern in UnmappablePatterns)
        {
            if (t.Contains(pattern))
            {
                return true;
            }
        }

        return false;
    }

    #endregion
}
