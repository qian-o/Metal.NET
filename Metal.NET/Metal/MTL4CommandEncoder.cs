namespace Metal.NET;

public readonly struct MTL4CommandEncoder(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4CommandBuffer? CommandBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandEncoderBindings.CommandBuffer);
            return ptr is not 0 ? new MTL4CommandBuffer(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandEncoderBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderBindings.SetLabel, value?.NativePtr ?? 0);
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
