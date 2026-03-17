namespace Metal.NET;

public class MTLIndirectComputeCommand(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIndirectComputeCommand>
{
    #region INativeObject
    public static new MTLIndirectComputeCommand Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectComputeCommand New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void SetComputePipelineState(MTLComputePipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetComputePipelineState, pipelineState.NativePtr);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBuffer, buffer.NativePtr, offset, index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBufferoffsetattributeStrideatIndex, buffer.NativePtr, offset, stride, index);
    }

    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    public void SetBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetBarrier);
    }

    public void ClearBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ClearBarrier);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetImageblockWidth, width, height);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.Reset);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetThreadgroupMemoryLength, length, index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetStageInRegion, region);
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
