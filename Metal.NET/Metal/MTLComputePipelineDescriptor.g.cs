namespace Metal.NET;

public class MTLComputePipelineDescriptor : IDisposable
{
    public MTLComputePipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetBinaryArchives, binaryArchives.NativePtr);
    }

    public void SetComputeFunction(MTLFunction computeFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetComputeFunction, computeFunction.NativePtr);
    }

    public void SetInsertLibraries(NSArray insertLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetInsertLibraries, insertLibraries.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetLinkedFunctions(MTLLinkedFunctions linkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetLinkedFunctions, linkedFunctions.NativePtr);
    }

    public void SetMaxCallStackDepth(uint maxCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetMaxCallStackDepth, (nint)maxCallStackDepth);
    }

    public void SetMaxTotalThreadsPerThreadgroup(uint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetPreloadedLibraries(NSArray preloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetPreloadedLibraries, preloadedLibraries.NativePtr);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup, requiredThreadsPerThreadgroup);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetShaderValidation, (nint)(uint)shaderValidation);
    }

    public void SetStageInputDescriptor(MTLStageInputOutputDescriptor stageInputDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetStageInputDescriptor, stageInputDescriptor.NativePtr);
    }

    public void SetSupportAddingBinaryFunctions(Bool8 supportAddingBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetSupportAddingBinaryFunctions, (nint)supportAddingBinaryFunctions.Value);
    }

    public void SetSupportIndirectCommandBuffers(Bool8 supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)supportIndirectCommandBuffers.Value);
    }

    public void SetThreadGroupSizeIsMultipleOfThreadExecutionWidth(Bool8 threadGroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, (nint)threadGroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

}

file class MTLComputePipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetComputeFunction = Selector.Register("setComputeFunction:");
    public static readonly Selector SetInsertLibraries = Selector.Register("setInsertLibraries:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector SetLinkedFunctions = Selector.Register("setLinkedFunctions:");
    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");
    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");
    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");
    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");
    public static readonly Selector SetStageInputDescriptor = Selector.Register("setStageInputDescriptor:");
    public static readonly Selector SetSupportAddingBinaryFunctions = Selector.Register("setSupportAddingBinaryFunctions:");
    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");
    public static readonly Selector SetThreadGroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setThreadGroupSizeIsMultipleOfThreadExecutionWidth:");
}
