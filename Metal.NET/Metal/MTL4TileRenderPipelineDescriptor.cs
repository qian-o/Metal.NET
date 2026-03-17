namespace Metal.NET;

/// <summary>
/// Groups together properties you use to create a tile render pipeline state object.
/// </summary>
public class MTL4TileRenderPipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4PipelineDescriptor(nativePtr, ownership), INativeObject<MTL4TileRenderPipelineDescriptor>
{
    #region INativeObject
    public static new MTL4TileRenderPipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4TileRenderPipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4TileRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4TileRenderPipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Access an array of descriptors that configure the properties of each color attachment in the tile render pipeline.
    /// </summary>
    public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.ColorAttachments);
    }

    /// <summary>
    /// Sets the maximum number of threads that the GPU can execute simultaneously within a single threadgroup in the tile render pipeline.
    /// </summary>
    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    /// <summary>
    /// Configures the number of samples per pixel used for multisampling.
    /// </summary>
    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    /// <summary>
    /// Sets the required number of threads per threadgroup for tile dispatches.
    /// </summary>
    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTL4TileRenderPipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    /// <summary>
    /// Configures an object that contains information about functions to link to the tile render pipeline when Metal builds it.
    /// </summary>
    public MTL4StaticLinkingDescriptor StaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.StaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.SetStaticLinkingDescriptor, value);
    }

    /// <summary>
    /// Indicates whether the pipeline supports linking binary functions.
    /// </summary>
    public Bool8 SupportBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SupportBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetSupportBinaryLinking, value);
    }

    /// <summary>
    /// Indicating whether the size of the threadgroup matches the size of a tile in the render pipeline.
    /// </summary>
    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorBindings.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetThreadgroupSizeMatchesTileSize, value);
    }

    /// <summary>
    /// Configures the tile function that the render pipeline executes for each tile in the tile shader stage.
    /// </summary>
    public MTL4FunctionDescriptor TileFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.TileFunctionDescriptor);
        set => SetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.SetTileFunctionDescriptor, value);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Resets the descriptor to the default state.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.Reset);
    }
    #endregion
}

file static class MTL4TileRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4TileRenderPipelineDescriptor");

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";

    public static readonly Selector SetStaticLinkingDescriptor = "setStaticLinkingDescriptor:";

    public static readonly Selector SetSupportBinaryLinking = "setSupportBinaryLinking:";

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = "setThreadgroupSizeMatchesTileSize:";

    public static readonly Selector SetTileFunctionDescriptor = "setTileFunctionDescriptor:";

    public static readonly Selector StaticLinkingDescriptor = "staticLinkingDescriptor";

    public static readonly Selector SupportBinaryLinking = "supportBinaryLinking";

    public static readonly Selector ThreadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";

    public static readonly Selector TileFunctionDescriptor = "tileFunctionDescriptor";
}
