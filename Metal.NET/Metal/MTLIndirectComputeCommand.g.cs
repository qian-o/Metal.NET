namespace Metal.NET;

public class MTLIndirectComputeCommand : IDisposable
{
    public MTLIndirectComputeCommand(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.ConcurrentDispatchThreadgroupsThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.ConcurrentDispatchThreadsThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetComputePipelineState, pipelineState.NativePtr);
    }

    public void SetImageblockWidth(uint width, uint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetImageblockWidthHeight, (nint)width, (nint)height);
    }

    public void SetKernelBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBufferOffsetStrideIndex, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommandSelector.SetThreadgroupMemoryLengthIndex, (nint)length, (nint)index);
    }

}

file class MTLIndirectComputeCommandSelector
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");
    public static readonly Selector ConcurrentDispatchThreadgroupsThreadsPerThreadgroup = Selector.Register("concurrentDispatchThreadgroups:threadsPerThreadgroup:");
    public static readonly Selector ConcurrentDispatchThreadsThreadsPerThreadgroup = Selector.Register("concurrentDispatchThreads:threadsPerThreadgroup:");
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetBarrier = Selector.Register("setBarrier");
    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:");
    public static readonly Selector SetImageblockWidthHeight = Selector.Register("setImageblockWidth:height:");
    public static readonly Selector SetKernelBufferOffsetIndex = Selector.Register("setKernelBuffer:offset:index:");
    public static readonly Selector SetKernelBufferOffsetStrideIndex = Selector.Register("setKernelBuffer:offset:stride:index:");
    public static readonly Selector SetThreadgroupMemoryLengthIndex = Selector.Register("setThreadgroupMemoryLength:index:");
}
