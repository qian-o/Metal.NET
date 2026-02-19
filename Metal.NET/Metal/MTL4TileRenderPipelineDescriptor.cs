namespace Metal.NET;

public readonly struct MTL4TileRenderPipelineDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4TileRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4TileRenderPipelineDescriptorBindings.Class))
    {
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorBindings.ColorAttachments);
            return ptr is not 0 ? new MTLTileRenderPipelineColorAttachmentDescriptorArray(ptr) : default;
        }
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4TileRenderPipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTL4StaticLinkingDescriptor? StaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorBindings.StaticLinkingDescriptor);
            return ptr is not 0 ? new MTL4StaticLinkingDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public bool SupportBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SupportBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetSupportBinaryLinking, (Bool8)value);
    }

    public bool ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorBindings.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetThreadgroupSizeMatchesTileSize, (Bool8)value);
    }

    public MTL4FunctionDescriptor? TileFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorBindings.TileFunctionDescriptor);
            return ptr is not 0 ? new MTL4FunctionDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetTileFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTL4TileRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4TileRenderPipelineDescriptor");

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
