namespace Metal.NET;

public class MTL4CommandEncoder(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTL4CommandBuffer? CommandBuffer
    {
        get => GetProperty(ref field, MTL4CommandEncoderBindings.CommandBuffer);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTL4CommandEncoderBindings.Label);
        set => SetProperty(ref field, MTL4CommandEncoderBindings.SetLabel, value);
    }

    public void BarrierAfterEncoderStages(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterEncoderStages, (nuint)afterEncoderStages, (nuint)beforeEncoderStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterQueueStages, (nuint)afterQueueStages, (nuint)beforeStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterStages(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.BarrierAfterStages, (nuint)afterStages, (nuint)beforeQueueStages, (nuint)visibilityOptions);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.EndEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.UpdateFence, fence.NativePtr, (nuint)afterEncoderStages);
    }

    public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.WaitForFence, fence.NativePtr, (nuint)beforeEncoderStages);
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
