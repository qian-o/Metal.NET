namespace Metal.NET;

/// <summary>
/// A compute command in an indirect command buffer.
/// </summary>
public class MTLIndirectComputeCommand(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIndirectComputeCommand>
{
    #region INativeObject
    public static new MTLIndirectComputeCommand Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectComputeCommand New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Setting a command’s arguments - Methods

    /// <summary>
    /// Sets the command’s compute pipeline state.
    /// </summary>
    public void SetComputePipelineState(MTLComputePipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetComputePipelineState, pipelineState.NativePtr);
    }

    /// <summary>
    /// Sets the size, in pixels, of the imageblock.
    /// </summary>
    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetImageblockWidth, width, height);
    }

    /// <summary>
    /// Sets a buffer for the compute function.
    /// </summary>
    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBuffer, buffer.NativePtr, offset, index);
    }

    /// <summary>
    /// Sets a buffer for the compute function.
    /// </summary>
    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBufferoffsetattributeStrideatIndex, buffer.NativePtr, offset, stride, index);
    }

    /// <summary>
    /// Sets the size of a block of threadgroup memory.
    /// </summary>
    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetThreadgroupMemoryLength, length, index);
    }

    /// <summary>
    /// Sets the region of the stage-in attributes to apply to the compute kernel.
    /// </summary>
    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetStageInRegion, region);
    }
    #endregion

    #region Synchronizing command execution - Methods

    /// <summary>
    /// Adds a barrier to ensure that commands executed prior to this command are complete before this command executes.
    /// </summary>
    public void SetBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetBarrier);
    }

    /// <summary>
    /// Removes any barrier set on the command.
    /// </summary>
    public void ClearBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ClearBarrier);
    }
    #endregion

    #region Encoding a compute command - Methods

    /// <summary>
    /// Encodes a compute command using a grid aligned to threadgroup boundaries.
    /// </summary>
    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    /// <summary>
    /// Encodes a compute command using an arbitrarily sized grid.
    /// </summary>
    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }
    #endregion

    #region Resetting a command - Methods

    /// <summary>
    /// Resets the command to its default state.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.Reset);
    }
    #endregion
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
