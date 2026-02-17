namespace Metal.NET;

public class MTL4TileRenderPipelineDescriptor : IDisposable
{
    public MTL4TileRenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4TileRenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4TileRenderPipelineDescriptor");

    public static MTL4TileRenderPipelineDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTL4TileRenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.Reset);
    }

    public void SetMaxTotalThreadsPerThreadgroup(uint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetRasterSampleCount(uint rasterSampleCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetRasterSampleCount, (nint)rasterSampleCount);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup, requiredThreadsPerThreadgroup);
    }

    public void SetStaticLinkingDescriptor(MTL4StaticLinkingDescriptor staticLinkingDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetStaticLinkingDescriptor, staticLinkingDescriptor.NativePtr);
    }

    public void SetSupportBinaryLinking(Bool8 supportBinaryLinking)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetSupportBinaryLinking, (nint)supportBinaryLinking.Value);
    }

    public void SetThreadgroupSizeMatchesTileSize(Bool8 threadgroupSizeMatchesTileSize)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetThreadgroupSizeMatchesTileSize, (nint)threadgroupSizeMatchesTileSize.Value);
    }

    public void SetTileFunctionDescriptor(MTL4FunctionDescriptor tileFunctionDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetTileFunctionDescriptor, tileFunctionDescriptor.NativePtr);
    }

}

file class MTL4TileRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector SetStaticLinkingDescriptor = Selector.Register("setStaticLinkingDescriptor:");

    public static readonly Selector SetSupportBinaryLinking = Selector.Register("setSupportBinaryLinking:");

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = Selector.Register("setThreadgroupSizeMatchesTileSize:");

    public static readonly Selector SetTileFunctionDescriptor = Selector.Register("setTileFunctionDescriptor:");
}
