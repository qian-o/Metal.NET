namespace Metal.NET;

public class MTLIndirectComputeCommand(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLIndirectComputeCommand>
{
    public static MTLIndirectComputeCommand Null { get; } = new(0, false);

    public static MTLIndirectComputeCommand Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public void ClearBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ClearBarrier);
    }

    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.Reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetBarrier);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetComputePipelineState, pipelineState.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetImageblockWidth, width, height);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBuffer, buffer.NativePtr, offset, index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBufferoffsetattributeStrideatIndex, buffer.NativePtr, offset, stride, index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetStageInRegion, region);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetThreadgroupMemoryLength, length, index);
    }
}

file static class MTLIndirectComputeCommandBindings
{
    public static readonly Selector ClearBarrier = "clearBarrier";

    public static readonly Selector ConcurrentDispatchThreadgroups = "concurrentDispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector ConcurrentDispatchThreads = "concurrentDispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBarrier = "setBarrier";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidth = "setImageblockWidth:height:";

    public static readonly Selector SetKernelBuffer = "setKernelBuffer:offset:atIndex:";

    public static readonly Selector SetKernelBufferoffsetattributeStrideatIndex = "setKernelBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetStageInRegion = "setStageInRegion:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:atIndex:";
}
