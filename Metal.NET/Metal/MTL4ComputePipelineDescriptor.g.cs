namespace Metal.NET;

public class MTL4ComputePipelineDescriptor : IDisposable
{
    public MTL4ComputePipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4ComputePipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4ComputePipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4ComputePipelineDescriptor(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.Reset);
    }

    public void SetComputeFunctionDescriptor(MTL4FunctionDescriptor computeFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetComputeFunctionDescriptor, computeFunctionDescriptor.NativePtr);
    }

    public void SetMaxTotalThreadsPerThreadgroup(uint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup, requiredThreadsPerThreadgroup);
    }

    public void SetStaticLinkingDescriptor(MTL4StaticLinkingDescriptor staticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetStaticLinkingDescriptor, staticLinkingDescriptor.NativePtr);
    }

    public void SetSupportBinaryLinking(Bool8 supportBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetSupportBinaryLinking, (nint)supportBinaryLinking.Value);
    }

    public void SetSupportIndirectCommandBuffers(MTL4IndirectCommandBufferSupportState supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)(uint)supportIndirectCommandBuffers);
    }

    public void SetThreadGroupSizeIsMultipleOfThreadExecutionWidth(Bool8 threadGroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, (nint)threadGroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

}

file class MTL4ComputePipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetComputeFunctionDescriptor = Selector.Register("setComputeFunctionDescriptor:");
    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");
    public static readonly Selector SetStaticLinkingDescriptor = Selector.Register("setStaticLinkingDescriptor:");
    public static readonly Selector SetSupportBinaryLinking = Selector.Register("setSupportBinaryLinking:");
    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");
    public static readonly Selector SetThreadGroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setThreadGroupSizeIsMultipleOfThreadExecutionWidth:");
}
