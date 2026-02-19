namespace Metal.NET;

public readonly struct MTLIOCommandQueue(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLIOCommandBuffer? CommandBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBuffer);
            return ptr is not 0 ? new MTLIOCommandBuffer(ptr) : default;
        }
    }

    public MTLIOCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);
            return ptr is not 0 ? new MTLIOCommandBuffer(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public void EnqueueBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueBindings.EnqueueBarrier);
    }
}

file static class MTLIOCommandQueueBindings
{
    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector CommandBufferWithUnretainedReferences = Selector.Register("commandBufferWithUnretainedReferences");

    public static readonly Selector EnqueueBarrier = Selector.Register("enqueueBarrier");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
