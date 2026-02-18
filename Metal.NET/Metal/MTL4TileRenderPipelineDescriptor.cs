namespace Metal.NET;

public partial class MTL4TileRenderPipelineDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4TileRenderPipelineDescriptor");

    public MTL4TileRenderPipelineDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorSelector.ColorAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorSelector.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetRasterSampleCount, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4TileRenderPipelineDescriptorSelector.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTL4StaticLinkingDescriptor? StaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorSelector.StaticLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public bool SupportBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SupportBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetSupportBinaryLinking, (Bool8)value);
    }

    public bool ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorSelector.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetThreadgroupSizeMatchesTileSize, (Bool8)value);
    }

    public MTL4FunctionDescriptor? TileFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorSelector.TileFunctionDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetTileFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.Reset);
    }
}

file static class MTL4TileRenderPipelineDescriptorSelector
{
    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector SetStaticLinkingDescriptor = Selector.Register("setStaticLinkingDescriptor:");

    public static readonly Selector SetSupportBinaryLinking = Selector.Register("setSupportBinaryLinking:");

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = Selector.Register("setThreadgroupSizeMatchesTileSize:");

    public static readonly Selector SetTileFunctionDescriptor = Selector.Register("setTileFunctionDescriptor:");

    public static readonly Selector StaticLinkingDescriptor = Selector.Register("staticLinkingDescriptor");

    public static readonly Selector SupportBinaryLinking = Selector.Register("supportBinaryLinking");

    public static readonly Selector ThreadgroupSizeMatchesTileSize = Selector.Register("threadgroupSizeMatchesTileSize");

    public static readonly Selector TileFunctionDescriptor = Selector.Register("tileFunctionDescriptor");
}
