namespace Metal.NET;

file class MTL4TileRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetMaxTotalThreadsPerThreadgroup_ = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    public static readonly Selector SetRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    public static readonly Selector SetRequiredThreadsPerThreadgroup_ = Selector.Register("setRequiredThreadsPerThreadgroup:");
    public static readonly Selector SetStaticLinkingDescriptor_ = Selector.Register("setStaticLinkingDescriptor:");
    public static readonly Selector SetSupportBinaryLinking_ = Selector.Register("setSupportBinaryLinking:");
    public static readonly Selector SetThreadgroupSizeMatchesTileSize_ = Selector.Register("setThreadgroupSizeMatchesTileSize:");
    public static readonly Selector SetTileFunctionDescriptor_ = Selector.Register("setTileFunctionDescriptor:");
}

public class MTL4TileRenderPipelineDescriptor : IDisposable
{
    public MTL4TileRenderPipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTL4TileRenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.Reset);
    }

    public void SetMaxTotalThreadsPerThreadgroup(nuint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup_, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup_, requiredThreadsPerThreadgroup);
    }

    public void SetStaticLinkingDescriptor(MTL4StaticLinkingDescriptor staticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetStaticLinkingDescriptor_, staticLinkingDescriptor.NativePtr);
    }

    public void SetSupportBinaryLinking(Bool8 supportBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetSupportBinaryLinking_, (nint)supportBinaryLinking.Value);
    }

    public void SetThreadgroupSizeMatchesTileSize(Bool8 threadgroupSizeMatchesTileSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetThreadgroupSizeMatchesTileSize_, (nint)threadgroupSizeMatchesTileSize.Value);
    }

    public void SetTileFunctionDescriptor(MTL4FunctionDescriptor tileFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptorSelector.SetTileFunctionDescriptor_, tileFunctionDescriptor.NativePtr);
    }

}
