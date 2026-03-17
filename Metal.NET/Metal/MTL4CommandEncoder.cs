namespace Metal.NET;

/// <summary>
/// An encoder that writes GPU commands into a command buffer.
/// </summary>
public class MTL4CommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandEncoder>
{
    #region INativeObject
    public static new MTL4CommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// Returns the command buffer that is currently encoding commands.
    /// </summary>
    public MTL4CommandBuffer CommandBuffer
    {
        get => GetProperty(ref field, MTL4CommandEncoderBindings.CommandBuffer);
    }

    /// <summary>
    /// Provides an optional label to assign to the command encoder for debug purposes.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandEncoderBindings.Label);
        set => SetProperty(ref field, MTL4CommandEncoderBindings.SetLabel, value);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Encodes an intra-pass barrier.
    /// </summary>
    public void BarrierAfterEncoderStages(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterEncoderStages, (nuint)afterEncoderStages, (nuint)beforeEncoderStages, (nuint)visibilityOptions);
    }

    /// <summary>
    /// Declares that all command generation from this encoder is complete.
    /// </summary>
    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.EndEncoding);
    }

    /// <summary>
    /// Inserts a debug string into the frame data to aid debugging.
    /// </summary>
    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    /// <summary>
    /// Pops the latest debug group string from this encoder’s stack of debug groups.
    /// </summary>
    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.PopDebugGroup);
    }

    /// <summary>
    /// Pushes a string onto this encoder’s stack of debug groups.
    /// </summary>
    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    /// <summary>
    /// Encodes a command that instructs the GPU to update a fence after one or more stages, which can unblock other passes waiting for the fence.
    /// </summary>
    public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.UpdateFence, fence.NativePtr, (nuint)afterEncoderStages);
    }

    /// <summary>
    /// Encodes a command that instructs the GPU to pause before starting one or more stages of the pass until a pass updates a fence.
    /// </summary>
    public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.WaitForFence, fence.NativePtr, (nuint)beforeEncoderStages);
    }
    #endregion

    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterQueueStages, (nuint)afterQueueStages, (nuint)beforeStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterStages(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterStages, (nuint)afterStages, (nuint)beforeQueueStages, (nuint)visibilityOptions);
    }
}

file static class MTL4CommandEncoderBindings
{
    public static readonly Selector BarrierAfterEncoderStages = "barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:";

    public static readonly Selector BarrierAfterQueueStages = "barrierAfterQueueStages:beforeStages:visibilityOptions:";

    public static readonly Selector BarrierAfterStages = "barrierAfterStages:beforeQueueStages:visibilityOptions:";

    public static readonly Selector CommandBuffer = "commandBuffer";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector UpdateFence = "updateFence:afterEncoderStages:";

    public static readonly Selector WaitForFence = "waitForFence:beforeEncoderStages:";
}
