namespace Metal.NET;

public class MTL4CommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandEncoder>
{
    #region INativeObject
    public static new MTL4CommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandEncoderBindings.Label);
        set => SetProperty(ref field, MTL4CommandEncoderBindings.SetLabel, value);
    }

    public MTL4CommandBuffer CommandBuffer
    {
        get => GetProperty(ref field, MTL4CommandEncoderBindings.CommandBuffer);
    }

    public void BarrierAfterQueueStagesBeforeStagesVisibilityOptions(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterQueueStages, (nuint)afterQueueStages, (nuint)beforeStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
    {
        BarrierAfterQueueStagesBeforeStagesVisibilityOptions(afterQueueStages, beforeStages, visibilityOptions);
    }

    public void BarrierAfterStagesBeforeQueueStagesVisibilityOptions(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterStages, (nuint)afterStages, (nuint)beforeQueueStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterStages(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
    {
        BarrierAfterStagesBeforeQueueStagesVisibilityOptions(afterStages, beforeQueueStages, visibilityOptions);
    }

    public void BarrierAfterEncoderStagesBeforeEncoderStagesVisibilityOptions(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterEncoderStages, (nuint)afterEncoderStages, (nuint)beforeEncoderStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterEncoderStages(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
    {
        BarrierAfterEncoderStagesBeforeEncoderStagesVisibilityOptions(afterEncoderStages, beforeEncoderStages, visibilityOptions);
    }

    public void UpdateFenceAfterEncoderStages(MTLFence fence, MTLStages afterEncoderStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.UpdateFence, fence.NativePtr, (nuint)afterEncoderStages);
    }

    public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
    {
        UpdateFenceAfterEncoderStages(fence, afterEncoderStages);
    }

    public void WaitForFenceBeforeEncoderStages(MTLFence fence, MTLStages beforeEncoderStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.WaitForFence, fence.NativePtr, (nuint)beforeEncoderStages);
    }

    public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
    {
        WaitForFenceBeforeEncoderStages(fence, beforeEncoderStages);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.PopDebugGroup);
    }

    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.EndEncoding);
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
