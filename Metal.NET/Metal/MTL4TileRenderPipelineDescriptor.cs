namespace Metal.NET;

public class MTL4TileRenderPipelineDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4TileRenderPipelineDescriptor");

    public MTL4TileRenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTL4TileRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4TileRenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorSelector.ColorAttachments));
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

    public MTL4StaticLinkingDescriptor StaticLinkingDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorSelector.StaticLinkingDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetStaticLinkingDescriptor, value.NativePtr);
    }

    public Bool8 SupportBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SupportBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetSupportBinaryLinking, value);
    }

    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorSelector.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetThreadgroupSizeMatchesTileSize, value);
    }

    public MTL4FunctionDescriptor TileFunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4TileRenderPipelineDescriptorSelector.TileFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetTileFunctionDescriptor, value.NativePtr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.Reset);
    }

    public static implicit operator nint(MTL4TileRenderPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4TileRenderPipelineDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTL4TileRenderPipelineDescriptorSelector
{
    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector StaticLinkingDescriptor = Selector.Register("staticLinkingDescriptor");

    public static readonly Selector SetStaticLinkingDescriptor = Selector.Register("setStaticLinkingDescriptor:");

    public static readonly Selector SupportBinaryLinking = Selector.Register("supportBinaryLinking");

    public static readonly Selector SetSupportBinaryLinking = Selector.Register("setSupportBinaryLinking:");

    public static readonly Selector ThreadgroupSizeMatchesTileSize = Selector.Register("threadgroupSizeMatchesTileSize");

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = Selector.Register("setThreadgroupSizeMatchesTileSize:");

    public static readonly Selector TileFunctionDescriptor = Selector.Register("tileFunctionDescriptor");

    public static readonly Selector SetTileFunctionDescriptor = Selector.Register("setTileFunctionDescriptor:");

    public static readonly Selector Reset = Selector.Register("reset");
}
