using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Metal.NET.Generator;

/// <summary>
/// Deserializes metal-ast.json and populates a <see cref="GeneratorContext"/>
/// with enum, class, struct, free function, and block type alias definitions.
/// </summary>
partial class AstJsonParser
{
    /// <summary>Methods to skip during parsing (ObjC runtime methods handled by the framework).</summary>
    static readonly HashSet<string> SkipMethods = ["alloc", "init", "retain", "release", "autorelease", "copy", "retainCount"];

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
        "copyWithZone:", "mutableCopyWithZone:",
        "array", "arrayWithObject:", "arrayWithObjects:count:",
        "objectAtIndex:",
    ];

    /// <summary>Known inline block signatures mapped to delegate names.</summary>
    static readonly Dictionary<string, string> InlineBlockDelegateNames = new()
    {
        ["void * _Nonnull, NSUInteger"] = "MTLDeallocator",
        ["unichar * _Nonnull, NSUInteger"] = "MTLDeallocator",
    };

    /// <summary>Override parameter names for known inline block types.</summary>
    static readonly Dictionary<string, string[]> InlineBlockParamNames = new()
    {
        ["MTLDeallocator"] = ["pointer", "length"],
    };

    /// <summary>Known ObjC class names that support AllocInit (have a registered ObjC class).</summary>
    static readonly HashSet<string> AllocInitClasses =
    [
        "MTLTextureDescriptor", "MTLRenderPipelineDescriptor", "MTLComputePipelineDescriptor",
        "MTLRenderPassDescriptor", "MTLDepthStencilDescriptor", "MTLStencilDescriptor",
        "MTLSamplerDescriptor", "MTLCompileOptions", "MTLVertexDescriptor",
        "MTLRenderPipelineColorAttachmentDescriptor", "MTLTileRenderPipelineColorAttachmentDescriptor",
        "MTLTileRenderPipelineDescriptor", "MTLMeshRenderPipelineDescriptor",
        "MTLComputePassDescriptor", "MTLBlitPassDescriptor", "MTLRenderPassAttachmentDescriptor",
        "MTLRenderPassColorAttachmentDescriptor", "MTLRenderPassDepthAttachmentDescriptor",
        "MTLRenderPassStencilAttachmentDescriptor",
        "MTLFunctionDescriptor", "MTLIntersectionFunctionDescriptor",
        "MTLFunctionConstantValues", "MTLLinkedFunctions",
        "MTLBinaryArchiveDescriptor", "MTLCaptureDescriptor",
        "MTLResourceStatePassDescriptor", "MTLAccelerationStructurePassDescriptor",
        "MTLBlitPassSampleBufferAttachmentDescriptor", "MTLComputePassSampleBufferAttachmentDescriptor",
        "MTLRenderPassSampleBufferAttachmentDescriptor", "MTLResourceStatePassSampleBufferAttachmentDescriptor",
        "MTLAccelerationStructurePassSampleBufferAttachmentDescriptor",
        "MTLAccelerationStructureDescriptor", "MTLAccelerationStructureGeometryDescriptor",
        "MTLPrimitiveAccelerationStructureDescriptor",
        "MTLAccelerationStructureTriangleGeometryDescriptor",
        "MTLAccelerationStructureBoundingBoxGeometryDescriptor",
        "MTLAccelerationStructureMotionTriangleGeometryDescriptor",
        "MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor",
        "MTLAccelerationStructureCurveGeometryDescriptor",
        "MTLAccelerationStructureMotionCurveGeometryDescriptor",
        "MTLInstanceAccelerationStructureDescriptor",
        "MTLIndirectInstanceAccelerationStructureDescriptor",
        "MTLMotionKeyframeData",
        "MTLHeapDescriptor", "MTLCommandBufferDescriptor",
        "MTLIndirectCommandBufferDescriptor",
        "MTLVisibleFunctionTableDescriptor", "MTLIntersectionFunctionTableDescriptor",
        "MTLCounterSampleBufferDescriptor", "MTLResidencySetDescriptor",
        "MTLTextureViewDescriptor", "MTLIOCommandQueueDescriptor",
        "MTLLogStateDescriptor", "MTLRasterizationRateMapDescriptor",
        "MTLSharedEventListener", "MTLArgumentDescriptor",
        "MTLStageInputOutputDescriptor", "MTLAttributeDescriptor",
        "MTLBufferLayoutDescriptor", "MTLVertexAttributeDescriptor",
        "MTLVertexBufferLayoutDescriptor", "MTLPipelineBufferDescriptor",
        "MTLCommandQueueDescriptor", "MTLTensorDescriptor",
        "MTLRenderPipelineFunctionsDescriptor",
        "MTLStitchedLibraryDescriptor", "MTLRasterizationRateLayerDescriptor",
        "MTLResourceViewPoolDescriptor", "MTLTextureViewPool",
        "MTLCaptureManager",
        // MTL4 classes
        "MTL4CompilerDescriptor", "MTL4CompilerTaskOptions",
        "MTL4LibraryFunctionDescriptor", "MTL4SpecializedFunctionDescriptor",
        "MTL4StitchedFunctionDescriptor",
        "MTL4ComputePipelineDescriptor", "MTL4CounterHeapDescriptor",
        "MTL4ArgumentTableDescriptor",
        "MTL4LibraryDescriptor", "MTL4PipelineOptions",
        "MTL4PipelineDescriptor", "MTL4PipelineDataSetSerializerDescriptor",
        "MTL4StaticLinkingDescriptor", "MTL4PipelineStageDynamicLinkingDescriptor",
        "MTL4RenderPipelineDynamicLinkingDescriptor",
        "MTL4RenderPipelineColorAttachmentDescriptor",
        "MTL4RenderPipelineDescriptor", "MTL4RenderPassDescriptor",
        "MTL4CommandBufferOptions", "MTL4CommitOptions",
        "MTL4CommandQueueDescriptor", "MTL4CommandAllocatorDescriptor",
        "MTL4RenderPipelineBinaryFunctionsDescriptor",
        "MTL4AccelerationStructureDescriptor", "MTL4AccelerationStructureGeometryDescriptor",
        "MTL4PrimitiveAccelerationStructureDescriptor",
        "MTL4AccelerationStructureTriangleGeometryDescriptor",
        "MTL4AccelerationStructureBoundingBoxGeometryDescriptor",
        "MTL4AccelerationStructureMotionTriangleGeometryDescriptor",
        "MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor",
        "MTL4AccelerationStructureCurveGeometryDescriptor",
        "MTL4AccelerationStructureMotionCurveGeometryDescriptor",
        "MTL4InstanceAccelerationStructureDescriptor",
        "MTL4IndirectInstanceAccelerationStructureDescriptor",
        "MTL4BinaryFunctionDescriptor", "MTL4FunctionDescriptor",
        "MTL4MachineLearningPipelineDescriptor",
        "MTL4MeshRenderPipelineDescriptor",
        "MTL4TileRenderPipelineDescriptor",
        // MTLFX classes
        "MTLFXTemporalScalerDescriptor", "MTLFXTemporalDenoisedScalerDescriptor",
        "MTLFXSpatialScalerDescriptor", "MTLFXFrameInterpolatorDescriptor",
        // QuartzCore
        "CAMetalLayer",
    ];

    /// <summary>Protocols to skip (not relevant for generated bindings).</summary>
    static readonly HashSet<string> SkipProtocols =
    [
        "NSObject", "NSCopying", "NSMutableCopying", "NSSecureCoding", "NSFastEnumeration",
    ];

    /// <summary>Classes to skip (hand-written or not relevant).</summary>
    static readonly HashSet<string> SkipClasses =
    [
        "NSObject", "NSArray", "NSString", "NSError", "NSURL",
        "NSDictionary", "NSNumber", "NSValue", "NSData",
        "NSBundle", "NSProcessInfo", "NSAutoreleasePool",
        "NSDate", "NSNotification", "NSNotificationCenter",
        "NSSet", "NSEnumerator",
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
        ParseBlockTypedefs(ast, context);
        ParseProtocols(ast, context);
        ParseClasses(ast, context);
        ParseFreeFunctions(ast, context);

        return context;
    }

    #region Selector & Name Helpers

    /// <summary>
    /// Converts an ObjC selector to a C++ method name for the internal model.
    /// E.g., "newCommandQueueWithMaxCommandBufferCount:" → "newCommandQueueWithMaxCommandBufferCount"
    /// E.g., "setFoo:" → "setFoo"
    /// E.g., "foo" → "foo"
    /// </summary>
    static string SelectorToMethodName(string selector)
    {
        // Remove trailing colons and split on colons to get the base name
        if (!selector.Contains(':'))
        {
            return selector;
        }

        // For multi-part selectors like "foo:bar:baz:", use the first part as the method name
        int firstColon = selector.IndexOf(':');
        return selector[..firstColon];
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
    static string StripNullability(string objcType)
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

