namespace Metal.NET.Generator;

/// <summary>
/// Deserializes metal-ast.json and populates a <see cref="GeneratorContext"/>
/// with enum, class, struct, free function, and block type alias definitions.
/// </summary>
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

        // id<Protocol> const * → OBJ_ARRAY:Protocol (pointer to array of protocol objects)
        Match idConstPtrMatch = IdProtocolConstPointerRegex().Match(t);
        if (idConstPtrMatch.Success)
        {
            return $"OBJ_ARRAY:{idConstPtrMatch.Groups[1].Value}";
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
                return $"INLINE_BLOCK:{delegateName}";
            }
            return "INLINE_BLOCK:UNKNOWN_BLOCK";
        }

        // C primitive types — pass through as-is
        if (t is "uint32_t" or "int32_t" or "uint8_t" or "int8_t" or "uint16_t" or "int16_t"
                or "uint64_t" or "int64_t" or "float" or "double" or "void")
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
    /// Returns <see langword="true"/> if an ObjC type from the AST cannot be mapped to C#
    /// and the containing method/property should be skipped.
    /// </summary>
    static bool IsUnmappableObjCType(string objcType)
    {
        string t = StripNullability(objcType).Trim();

        // Exact-match unmappable types
        if (t is "Class" or "IMP" or "SEL" or "FourCharCode" or "id *")
        {
            return true;
        }

        // Pattern-based exclusions
        return t.StartsWith("NSSet<")
            || t.Contains("NS::Process") || t.Contains("NS::Observer")
            || t.Contains("NSProcess") || t.Contains("NSObserver")
            || t.Contains("kern_return_t") || t.Contains("task_id_token_t")
            || t.Contains("ObjectType")
            || t.Contains("NS_RETURNS_INNER_POINTER")
            || t.Contains("NSStringEncoding")
            || t.Contains("*const ") || (t.Contains("const") && t.Contains("* _Nonnull *"))
            || t.Contains("unichar")
            || t.Contains("CAEDRMetadata")
            || t.Contains("NSCoder")
            || t.Contains("MTLIOCompressionContext");
    }

    #endregion
}
