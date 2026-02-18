namespace Metal.NET;

public class MTLIndirectComputeCommand : IDisposable
{
    public MTLIndirectComputeCommand(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
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

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetImageblockWidthHeight, width, height);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetStageInRegion, region);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetThreadgroupMemoryLengthAtIndex, length, index);
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

    public static readonly Selector SetKernelBufferOffsetAttributeStrideAtIndex = Selector.Register("setKernelBuffer:offset:attributeStride:atIndex:");

    public static readonly Selector SetStageInRegion = Selector.Register("setStageInRegion:");

    public static readonly Selector SetThreadgroupMemoryLengthAtIndex = Selector.Register("setThreadgroupMemoryLength:atIndex:");
}
