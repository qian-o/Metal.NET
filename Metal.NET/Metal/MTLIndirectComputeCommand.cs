namespace Metal.NET;

public partial class MTLIndirectComputeCommand : NativeObject
{
    public MTLIndirectComputeCommand(nint nativePtr) : base(nativePtr)
    {
    }

    public void ClearBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.ClearBarrier);
    }

    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.ConcurrentDispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.ConcurrentDispatchThreads, threadsPerGrid, threadsPerThreadgroup);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetImageblockWidth, width, height);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBuffer, buffer.NativePtr, offset, index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetKernelBuffer, buffer.NativePtr, offset, stride, index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetStageInRegion, region);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandSelector.SetThreadgroupMemoryLength, length, index);
    }
}

file static class MTLIndirectComputeCommandSelector
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");

    public static readonly Selector ConcurrentDispatchThreadgroups = Selector.Register("concurrentDispatchThreadgroups::");

    public static readonly Selector ConcurrentDispatchThreads = Selector.Register("concurrentDispatchThreads::");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetBarrier = Selector.Register("setBarrier");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:");

    public static readonly Selector SetImageblockWidth = Selector.Register("setImageblockWidth::");

    public static readonly Selector SetKernelBuffer = Selector.Register("setKernelBuffer:::");

    public static readonly Selector SetStageInRegion = Selector.Register("setStageInRegion:");

    public static readonly Selector SetThreadgroupMemoryLength = Selector.Register("setThreadgroupMemoryLength::");
}
