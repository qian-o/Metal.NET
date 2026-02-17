namespace Metal.NET;

public class MTLTileRenderPipelineDescriptor : IDisposable
{
    public MTLTileRenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLTileRenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.Reset);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetBinaryArchives, binaryArchives.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetLinkedFunctions(MTLLinkedFunctions linkedFunctions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetLinkedFunctions, linkedFunctions.NativePtr);
    }

    public void SetMaxCallStackDepth(uint maxCallStackDepth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetMaxCallStackDepth, (nint)maxCallStackDepth);
    }

    public void SetMaxTotalThreadsPerThreadgroup(uint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetPreloadedLibraries(NSArray preloadedLibraries)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetPreloadedLibraries, preloadedLibraries.NativePtr);
    }

    public void SetRasterSampleCount(uint rasterSampleCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetRasterSampleCount, (nint)rasterSampleCount);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup, requiredThreadsPerThreadgroup);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetShaderValidation, (nint)(uint)shaderValidation);
    }

    public void SetSupportAddingBinaryFunctions(Bool8 supportAddingBinaryFunctions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetSupportAddingBinaryFunctions, (nint)supportAddingBinaryFunctions.Value);
    }

    public void SetThreadgroupSizeMatchesTileSize(Bool8 threadgroupSizeMatchesTileSize)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetThreadgroupSizeMatchesTileSize, (nint)threadgroupSizeMatchesTileSize.Value);
    }

    public void SetTileFunction(MTLFunction tileFunction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetTileFunction, tileFunction.NativePtr);
    }

}

file class MTLTileRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetLinkedFunctions = Selector.Register("setLinkedFunctions:");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector SetSupportAddingBinaryFunctions = Selector.Register("setSupportAddingBinaryFunctions:");

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = Selector.Register("setThreadgroupSizeMatchesTileSize:");

    public static readonly Selector SetTileFunction = Selector.Register("setTileFunction:");
}
