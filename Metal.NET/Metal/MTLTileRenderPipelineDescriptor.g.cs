namespace Metal.NET;

file class MTLTileRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetBinaryArchives_ = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetLinkedFunctions_ = Selector.Register("setLinkedFunctions:");
    public static readonly Selector SetMaxCallStackDepth_ = Selector.Register("setMaxCallStackDepth:");
    public static readonly Selector SetMaxTotalThreadsPerThreadgroup_ = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    public static readonly Selector SetPreloadedLibraries_ = Selector.Register("setPreloadedLibraries:");
    public static readonly Selector SetRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    public static readonly Selector SetRequiredThreadsPerThreadgroup_ = Selector.Register("setRequiredThreadsPerThreadgroup:");
    public static readonly Selector SetShaderValidation_ = Selector.Register("setShaderValidation:");
    public static readonly Selector SetSupportAddingBinaryFunctions_ = Selector.Register("setSupportAddingBinaryFunctions:");
    public static readonly Selector SetThreadgroupSizeMatchesTileSize_ = Selector.Register("setThreadgroupSizeMatchesTileSize:");
    public static readonly Selector SetTileFunction_ = Selector.Register("setTileFunction:");
}

public class MTLTileRenderPipelineDescriptor : IDisposable
{
    public MTLTileRenderPipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLTileRenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTileRenderPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTileRenderPipelineDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineDescriptor");

    public static MTLTileRenderPipelineDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLTileRenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.Reset);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetLinkedFunctions(MTLLinkedFunctions linkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetLinkedFunctions_, linkedFunctions.NativePtr);
    }

    public void SetMaxCallStackDepth(nuint maxCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetMaxCallStackDepth_, (nint)maxCallStackDepth);
    }

    public void SetMaxTotalThreadsPerThreadgroup(nuint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup_, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetPreloadedLibraries(NSArray preloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetPreloadedLibraries_, preloadedLibraries.NativePtr);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup_, requiredThreadsPerThreadgroup);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetShaderValidation_, (nint)(uint)shaderValidation);
    }

    public void SetSupportAddingBinaryFunctions(Bool8 supportAddingBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetSupportAddingBinaryFunctions_, (nint)supportAddingBinaryFunctions.Value);
    }

    public void SetThreadgroupSizeMatchesTileSize(Bool8 threadgroupSizeMatchesTileSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetThreadgroupSizeMatchesTileSize_, (nint)threadgroupSizeMatchesTileSize.Value);
    }

    public void SetTileFunction(MTLFunction tileFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetTileFunction_, tileFunction.NativePtr);
    }

}
