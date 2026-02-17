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

    public void ClearBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.ClearBarrier);
    }

    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.ConcurrentDispatchThreadgroupsThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.ConcurrentDispatchThreadsThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.Reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetBarrier);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetComputePipelineState, pipelineState.NativePtr);
    }

    public void SetImageblockWidth(uint width, uint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetImageblockWidthHeight, (nuint)width, (nuint)height);
    }

    public void SetKernelBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBufferOffsetStrideIndex, buffer.NativePtr, (nuint)offset, (nuint)stride, (nuint)index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetStageInRegion, region);
    }

    public void SetThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetThreadgroupMemoryLengthIndex, (nuint)length, (nuint)index);
    }

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

    public static readonly Selector SetStageInRegion = Selector.Register("setStageInRegion:");

    public static readonly Selector SetThreadgroupMemoryLengthIndex = Selector.Register("setThreadgroupMemoryLength:index:");
}
