namespace Metal.NET;

file class MTLComputePipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetBinaryArchives_ = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetComputeFunction_ = Selector.Register("setComputeFunction:");
    public static readonly Selector SetInsertLibraries_ = Selector.Register("setInsertLibraries:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetLinkedFunctions_ = Selector.Register("setLinkedFunctions:");
    public static readonly Selector SetMaxCallStackDepth_ = Selector.Register("setMaxCallStackDepth:");
    public static readonly Selector SetMaxTotalThreadsPerThreadgroup_ = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    public static readonly Selector SetPreloadedLibraries_ = Selector.Register("setPreloadedLibraries:");
    public static readonly Selector SetRequiredThreadsPerThreadgroup_ = Selector.Register("setRequiredThreadsPerThreadgroup:");
    public static readonly Selector SetShaderValidation_ = Selector.Register("setShaderValidation:");
    public static readonly Selector SetStageInputDescriptor_ = Selector.Register("setStageInputDescriptor:");
    public static readonly Selector SetSupportAddingBinaryFunctions_ = Selector.Register("setSupportAddingBinaryFunctions:");
    public static readonly Selector SetSupportIndirectCommandBuffers_ = Selector.Register("setSupportIndirectCommandBuffers:");
    public static readonly Selector SetThreadGroupSizeIsMultipleOfThreadExecutionWidth_ = Selector.Register("setThreadGroupSizeIsMultipleOfThreadExecutionWidth:");
}

public class MTLComputePipelineDescriptor : IDisposable
{
    public MTLComputePipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLComputePipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputePipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePipelineDescriptor(nint value)
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

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.Reset);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetComputeFunction(MTLFunction computeFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetComputeFunction_, computeFunction.NativePtr);
    }

    public void SetInsertLibraries(NSArray insertLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetInsertLibraries_, insertLibraries.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetLinkedFunctions(MTLLinkedFunctions linkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetLinkedFunctions_, linkedFunctions.NativePtr);
    }

    public void SetMaxCallStackDepth(nuint maxCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetMaxCallStackDepth_, (nint)maxCallStackDepth);
    }

    public void SetMaxTotalThreadsPerThreadgroup(nuint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup_, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetPreloadedLibraries(NSArray preloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetPreloadedLibraries_, preloadedLibraries.NativePtr);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup_, requiredThreadsPerThreadgroup);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetShaderValidation_, (nint)(uint)shaderValidation);
    }

    public void SetStageInputDescriptor(MTLStageInputOutputDescriptor stageInputDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetStageInputDescriptor_, stageInputDescriptor.NativePtr);
    }

    public void SetSupportAddingBinaryFunctions(Bool8 supportAddingBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetSupportAddingBinaryFunctions_, (nint)supportAddingBinaryFunctions.Value);
    }

    public void SetSupportIndirectCommandBuffers(Bool8 supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetSupportIndirectCommandBuffers_, (nint)supportIndirectCommandBuffers.Value);
    }

    public void SetThreadGroupSizeIsMultipleOfThreadExecutionWidth(Bool8 threadGroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth_, (nint)threadGroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

}
