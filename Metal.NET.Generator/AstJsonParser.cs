namespace Metal.NET.Generator;

/// <summary>
/// Deserializes metal-ast.json and populates a <see cref="GeneratorContext"/>
/// with enum, class, struct, free function, and block type alias definitions.
/// </summary>
partial class AstJsonParser
{
    /// <summary>Methods to skip during parsing (ObjC runtime methods handled by the framework).</summary>
    static readonly HashSet<string> SkipMethods = ["alloc", "init", "retain", "release", "autorelease", "retainCount"];

    /// <summary>Selectors to skip entirely (not relevant for generated bindings).</summary>
    static readonly HashSet<string> SkipSelectors =
    [
        "isEqual:", "hash", "superclass", "class", "self", "zone", "performSelector:",
        "performSelector:withObject:", "performSelector:withObject:withObject:",
        "isProxy", "isKindOfClass:", "isMemberOfClass:", "conformsToProtocol:",
        "respondsToSelector:", "retain", "release", "autorelease", "retainCount",
        "description", "debugDescription", "dealloc", "finalize",
        "observationInfo", "setObservationInfo:", "classForCoder",
        "replacementObjectForCoder:", "awakeAfterUsingCoder:",
        "observeValueForKeyPath:ofObject:change:context:",
        "encodeWithCoder:", "initWithCoder:",
        "supportsSecureCoding", "countByEnumeratingWithState:objects:count:",
        "copy", "copyWithZone:", "mutableCopyWithZone:",
        "array", "arrayWithObject:", "arrayWithObjects:count:",
        "objectAtIndex:",
    ];

    /// <summary>Known inline block signatures mapped to delegate names. Populated
    /// by <see cref="ParseInlineBlocks"/> (auto-discovered entries).</summary>
    static readonly Dictionary<string, string> InlineBlockDelegateNames = [];

    /// <summary>Known ObjC class names that support AllocInit (have a registered ObjC class).</summary>
    static readonly HashSet<string> AllocInitClasses =
    [
        // Order follows the SDK class declarations in metal-ast.json.
        "MTLTensorAuxiliaryPlaneDescriptor", "MTLTensorAuxiliaryPlaneDescriptorMap", "MTLTensorDescriptor",
        "MTLTensorBufferAttachments", "MTLTextureDescriptor", "MTLTextureViewDescriptor", "MTLFunctionConstantValues",
        "MTLFunctionDescriptor", "MTLIntersectionFunctionDescriptor", "MTLCompileOptions",
        "MTLCounterSampleBufferDescriptor", "MTL4LibraryDescriptor", "MTL4FunctionDescriptor",
        "MTL4RenderPipelineDescriptor", "MTL4ComputePipelineDescriptor", "MTL4PipelineDescriptor",
        "MTL4MachineLearningPipelineDescriptor", "MTL4BinaryFunctionDescriptor",
        "MTL4PipelineStageDynamicLinkingDescriptor", "MTL4RenderPipelineDynamicLinkingDescriptor",
        "MTL4CompilerDescriptor", "MTL4CompilerTaskOptions", "MTL4CounterHeapDescriptor",
        "MTLRasterizationRateLayerDescriptor", "MTLRasterizationRateMapDescriptor", "MTLTileRenderPipelineDescriptor",
        "MTLMeshRenderPipelineDescriptor", "MTLSamplerDescriptor", "MTLRenderPipelineColorAttachmentDescriptor",
        "MTLDepthStencilDescriptor", "MTLRenderPipelineDescriptor", "MTLRenderPassDescriptor",
        "MTLComputePassDescriptor", "MTLBlitPassDescriptor", "MTLComputePipelineDescriptor",
        "MTLCommandQueueDescriptor", "MTLHeapDescriptor", "MTLIndirectCommandBufferDescriptor",
        "MTLBinaryArchiveDescriptor", "MTLAccelerationStructureDescriptor", "MTLVisibleFunctionTableDescriptor",
        "MTLIntersectionFunctionTableDescriptor", "MTLStitchedLibraryDescriptor", "MTLLogStateDescriptor",
        "MTLResidencySetDescriptor", "MTL4CommandQueueDescriptor", "MTL4CommandAllocatorDescriptor",
        "MTL4ArgumentTableDescriptor", "MTLResourceViewPoolDescriptor", "MTL4PipelineDataSetSerializerDescriptor",
        "MTLIOCommandQueueDescriptor", "MTLArgumentDescriptor", "MTLResourceStatePassSampleBufferAttachmentDescriptor",
        "MTLResourceStatePassDescriptor", "MTLRenderPassAttachmentDescriptor", "MTLRenderPassColorAttachmentDescriptor",
        "MTLRenderPassDepthAttachmentDescriptor", "MTLRenderPassStencilAttachmentDescriptor",
        "MTLRenderPassSampleBufferAttachmentDescriptor", "MTLBlitPassSampleBufferAttachmentDescriptor",
        "MTLAccelerationStructurePassDescriptor", "MTLCommandBufferDescriptor",
        "MTLComputePassSampleBufferAttachmentDescriptor", "MTLStencilDescriptor", "MTLVertexBufferLayoutDescriptor",
        "MTLVertexAttributeDescriptor", "MTLVertexDescriptor", "MTLBufferLayoutDescriptor", "MTLAttributeDescriptor",
        "MTLStageInputOutputDescriptor", "MTLPipelineBufferDescriptor", "MTLLinkedFunctions",
        "MTLRenderPipelineFunctionsDescriptor", "MTL4RenderPipelineBinaryFunctionsDescriptor",
        "MTLTileRenderPipelineColorAttachmentDescriptor", "MTLAccelerationStructureGeometryDescriptor",
        "MTLPrimitiveAccelerationStructureDescriptor", "MTLAccelerationStructureTriangleGeometryDescriptor",
        "MTLAccelerationStructureBoundingBoxGeometryDescriptor", "MTLMotionKeyframeData",
        "MTLAccelerationStructureMotionTriangleGeometryDescriptor",
        "MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor",
        "MTLAccelerationStructureCurveGeometryDescriptor", "MTLAccelerationStructureMotionCurveGeometryDescriptor",
        "MTLInstanceAccelerationStructureDescriptor", "MTLIndirectInstanceAccelerationStructureDescriptor",
        "MTL4RenderPassDescriptor", "MTL4CommandBufferOptions", "MTLSharedEventListener", "MTL4CommitOptions",
        "MTLCaptureDescriptor", "MTLCaptureManager", "MTLAccelerationStructurePassSampleBufferAttachmentDescriptor",
        "MTL4AccelerationStructureDescriptor", "MTL4AccelerationStructureGeometryDescriptor",
        "MTL4PrimitiveAccelerationStructureDescriptor", "MTL4AccelerationStructureTriangleGeometryDescriptor",
        "MTL4AccelerationStructureBoundingBoxGeometryDescriptor",
        "MTL4AccelerationStructureMotionTriangleGeometryDescriptor",
        "MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor",
        "MTL4AccelerationStructureCurveGeometryDescriptor", "MTL4AccelerationStructureMotionCurveGeometryDescriptor",
        "MTL4InstanceAccelerationStructureDescriptor", "MTL4IndirectInstanceAccelerationStructureDescriptor",
        "MTL4LibraryFunctionDescriptor", "MTL4SpecializedFunctionDescriptor", "MTL4StitchedFunctionDescriptor",
        "MTL4PipelineOptions", "MTL4StaticLinkingDescriptor", "MTL4RenderPipelineColorAttachmentDescriptor",
        "MTL4TileRenderPipelineDescriptor", "MTL4MeshRenderPipelineDescriptor", "MTLFXTemporalScalerDescriptor",
        "MTLFXTemporalDenoisedScalerDescriptor", "MTLFXSpatialScalerDescriptor", "MTLFXFrameInterpolatorDescriptor",
        // Existing entries without class declarations in metal-ast.json.
        "MTLTextureViewPool", "CAMetalLayer",
    ];

    /// <summary>Protocols to skip (not relevant for generated bindings).</summary>
    static readonly HashSet<string> SkipProtocols =
    [
        "NSObject", "NSCopying", "NSMutableCopying", "NSSecureCoding", "NSFastEnumeration",
    ];

    /// <summary>Classes to skip (hand-written or not relevant). Shared with <see cref="CSharpEmitter"/>.</summary>
    internal static readonly HashSet<string> SkipClasses =
    [
        "NSObject", "NSArray",
        "NSValue", "NSProcessInfo", "NSAutoreleasePool",
        "NSDate", "NSNotification", "NSNotificationCenter",
        "NSEnumerator",
    ];

    /// <summary>Structs to skip during parsing.</summary>
    static readonly HashSet<string> SkipStructParseNames = ["CGSize"];

    public static GeneratorContext Parse(string astJsonPath)
    {
        GeneratorContext context = new();

        byte[] bytes = File.ReadAllBytes(astJsonPath);
        int offset = bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF ? 3 : 0;

        AstRoot ast = JsonSerializer.Deserialize<AstRoot>(bytes.AsSpan(offset))
            ?? throw new InvalidOperationException("Failed to deserialize metal-ast.json");

        ParseEnums(ast, context);
        ParseStructs(ast, context);

        // Auto-populate StructTypes from parsed definitions so DetectArrayParamPairs
        // and the emitter can recognise all struct types without manual maintenance.
        foreach (StructDef s in context.Structs)
        {
            TypeMapper.StructTypes.Add(TypeMapper.GetPrefix(s.Namespace) + s.Name);
        }

        ParseBlockTypedefs(ast, context);
        ParseInlineBlocks(ast, context);
        ParseProtocols(ast, context);
        ParseClasses(ast, context);
        ParseFreeFunctions(ast, context);

        return context;
    }

    #region Selector & Name Helpers

    /// <summary>
    /// Extracts the base name from an ObjC selector (the part before the first colon).
    /// Used for property getter/setter name derivation during parsing.
    /// </summary>
    static string SelectorToMethodName(string selector)
    {
        int firstColon = selector.IndexOf(':');
        return firstColon < 0 ? selector : selector[..firstColon];
    }

    /// <summary>
    /// Infers a logical namespace prefix from an ObjC name by matching the longest
    /// known prefix (e.g., "MTL4FXFoo" → "MTL4FX", "MTLDevice" → "MTL").
    /// Returns an empty string if no known prefix matches.
    /// </summary>
    static string InferNamespaceFromName(string name) => name switch
    {
        _ when name.StartsWith("MTL4FX") => "MTL4FX",
        _ when name.StartsWith("MTLFX") => "MTLFX",
        _ when name.StartsWith("MTL4") => "MTL4",
        _ when name.StartsWith("MTL") => "MTL",
        _ when name.StartsWith("NS") => "NS",
        _ when name.StartsWith("CA") => "CA",
        _ when name.StartsWith("CG") => "CG",
        _ => ""
    };

    /// <summary>Maps a framework name to its logical namespace prefix.</summary>
    static string FrameworkToNamespace(string framework) => framework switch
    {
        "Metal" => "MTL",
        "MetalFX" => "MTLFX",
        "Foundation" => "NS",
        "QuartzCore" => "CA",
        _ => "MTL"
    };

    /// <summary>Strips nullability and API availability annotations from ObjC type strings.</summary>
    internal static string StripNullability(string objcType)
    {
        string result = NullabilityRegex().Replace(objcType, "");
        result = ApiAvailabilityRegex().Replace(result, "");
        return result.Trim();
    }

    #endregion

    #region Generated Regex

    [GeneratedRegex(@"\b(?:_Nonnull|_Nullable|_Nullable_result|__nonnull|__nullable|_Null_unspecified|__null_unspecified)\b")]
    private static partial Regex NullabilityRegex();

    [GeneratedRegex(@"\bAPI_(?:UN)?AVAILABLE\b(?:\([^)]*\))?")]
    private static partial Regex ApiAvailabilityRegex();

    [GeneratedRegex(@"^id<(\w+)>\s*const\s*\*$")]
    private static partial Regex IdProtocolConstPointerRegex();

    [GeneratedRegex(@"^id<(\w+)>$")]
    private static partial Regex IdProtocolRegex();

    [GeneratedRegex(@"void\s*\(\^\s*(?:_Nullable)?\s*\)\s*\(([^)]*)\)")]
    private static partial Regex InlineBlockTypeRegex();

    [GeneratedRegex(@"^void\s*\(\^\)\s*\(([^)]*)\)$")]
    private static partial Regex BlockSignatureRegex();

    [GeneratedRegex(@"^(.+?)\[(\d+)\]$")]
    private static partial Regex ArrayFieldRegex();

    #endregion
}

