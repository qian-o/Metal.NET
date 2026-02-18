namespace Metal.NET;

public partial class MTLIOCommandQueue : NativeObject
{
    public MTLIOCommandQueue(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLIOCommandBuffer? CommandBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.CommandBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLIOCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.CommandBufferWithUnretainedReferences);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public void EnqueueBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueSelector.EnqueueBarrier);
    }
}

file static class MTLIOCommandQueueSelector
{
    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector CommandBufferWithUnretainedReferences = Selector.Register("commandBufferWithUnretainedReferences");

    public static readonly Selector EnqueueBarrier = Selector.Register("enqueueBarrier");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
