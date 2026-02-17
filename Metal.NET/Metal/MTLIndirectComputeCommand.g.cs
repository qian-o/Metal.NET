namespace Metal.NET;

file class MTLIndirectComputeCommandSelector
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");
    public static readonly Selector ConcurrentDispatchThreadgroups_threadsPerThreadgroup_ = Selector.Register("concurrentDispatchThreadgroups:threadsPerThreadgroup:");
    public static readonly Selector ConcurrentDispatchThreads_threadsPerThreadgroup_ = Selector.Register("concurrentDispatchThreads:threadsPerThreadgroup:");
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetBarrier = Selector.Register("setBarrier");
    public static readonly Selector SetComputePipelineState_ = Selector.Register("setComputePipelineState:");
    public static readonly Selector SetImageblockWidth_height_ = Selector.Register("setImageblockWidth:height:");
    public static readonly Selector SetKernelBuffer_offset_index_ = Selector.Register("setKernelBuffer:offset:index:");
    public static readonly Selector SetKernelBuffer_offset_stride_index_ = Selector.Register("setKernelBuffer:offset:stride:index:");
    public static readonly Selector SetThreadgroupMemoryLength_index_ = Selector.Register("setThreadgroupMemoryLength:index:");
}

public class MTLIndirectComputeCommand : IDisposable
{
    public MTLIndirectComputeCommand(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIndirectComputeCommand()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIndirectComputeCommand value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectComputeCommand(nint value)
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

    public void ClearBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.ClearBarrier);
    }

    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.ConcurrentDispatchThreadgroups_threadsPerThreadgroup_, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.ConcurrentDispatchThreads_threadsPerThreadgroup_, threadsPerGrid, threadsPerThreadgroup);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.Reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetBarrier);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetComputePipelineState_, pipelineState.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetImageblockWidth_height_, (nint)width, (nint)height);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBuffer_offset_stride_index_, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

}
