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
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBuffer_Offset_AttributeStride_AtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreadgroups_ThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreads_ThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
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
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetImageblockWidth_Height, width, height);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.Reset);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetThreadgroupMemoryLength_AtIndex, length, index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetStageInRegion, region);
    }
}

file static class MTLIndirectComputeCommandBindings
{
    public static readonly Selector ClearBarrier = "clearBarrier";

    public static readonly Selector ConcurrentDispatchThreadgroups_ThreadsPerThreadgroup = "concurrentDispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector ConcurrentDispatchThreads_ThreadsPerThreadgroup = "concurrentDispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBarrier = "setBarrier";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidth_Height = "setImageblockWidth:height:";

    public static readonly Selector SetKernelBuffer_Offset_AtIndex = "setKernelBuffer:offset:atIndex:";

    public static readonly Selector SetKernelBuffer_Offset_AttributeStride_AtIndex = "setKernelBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetStageInRegion = "setStageInRegion:";

    public static readonly Selector SetThreadgroupMemoryLength_AtIndex = "setThreadgroupMemoryLength:atIndex:";
}
