namespace Metal.NET;

public class MTL4CommandEncoder(nint nativePtr) : NativeObject(nativePtr)
{

    public MTL4CommandBuffer? CommandBuffer
    {
        get => GetNullableObject<MTL4CommandBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandEncoderSelector.CommandBuffer));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandEncoderSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public void BarrierAfterEncoderStages(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterEncoderStages, (nuint)afterEncoderStages, (nuint)beforeEncoderStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterQueueStages, (nuint)afterQueueStages, (nuint)beforeStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterStages(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterStages, (nuint)afterStages, (nuint)beforeQueueStages, (nuint)visibilityOptions);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.EndEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.InsertDebugSignpost, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.PushDebugGroup, @string.NativePtr);
    }

    public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.UpdateFence, fence.NativePtr, (nuint)afterEncoderStages);
    }

    public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.WaitForFence, fence.NativePtr, (nuint)beforeEncoderStages);
    }
}

file static class MTL4CommandEncoderSelector
{
    public static readonly Selector BarrierAfterEncoderStages = Selector.Register("barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:");

    public static readonly Selector BarrierAfterQueueStages = Selector.Register("barrierAfterQueueStages:beforeStages:visibilityOptions:");

    public static readonly Selector BarrierAfterStages = Selector.Register("barrierAfterStages:beforeQueueStages:visibilityOptions:");

    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector EndEncoding = Selector.Register("endEncoding");

    public static readonly Selector InsertDebugSignpost = Selector.Register("insertDebugSignpost:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:afterEncoderStages:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:beforeEncoderStages:");
}
