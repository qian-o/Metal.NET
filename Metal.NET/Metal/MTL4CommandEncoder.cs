namespace Metal.NET;

public readonly struct MTL4CommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTL4CommandEncoder value) => new(value.NativePtr);

    public MTL4CommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandEncoderBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.SetLabel, value.NativePtr);
    }

    public MTL4CommandBuffer CommandBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandEncoderBindings.CommandBuffer));
    }

    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterQueueStages_BeforeStages_VisibilityOptions, (nuint)afterQueueStages, (nuint)beforeStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterStages(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterStages_BeforeQueueStages_VisibilityOptions, (nuint)afterStages, (nuint)beforeQueueStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterEncoderStages(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterEncoderStages_BeforeEncoderStages_VisibilityOptions, (nuint)afterEncoderStages, (nuint)beforeEncoderStages, (nuint)visibilityOptions);
    }

    public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.UpdateFence_AfterEncoderStages, fence.NativePtr, (nuint)afterEncoderStages);
    }

    public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandEncoderBindings.WaitForFence_BeforeEncoderStages, fence.NativePtr, (nuint)beforeEncoderStages);
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
    public static readonly Selector BarrierAfterEncoderStages_BeforeEncoderStages_VisibilityOptions = "barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:";

    public static readonly Selector BarrierAfterQueueStages_BeforeStages_VisibilityOptions = "barrierAfterQueueStages:beforeStages:visibilityOptions:";

    public static readonly Selector BarrierAfterStages_BeforeQueueStages_VisibilityOptions = "barrierAfterStages:beforeQueueStages:visibilityOptions:";

    public static readonly Selector CommandBuffer = "commandBuffer";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector UpdateFence_AfterEncoderStages = "updateFence:afterEncoderStages:";

    public static readonly Selector WaitForFence_BeforeEncoderStages = "waitForFence:beforeEncoderStages:";
}
