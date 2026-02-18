namespace Metal.NET;

public class MTLIOCommandQueue(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLIOCommandBuffer? CommandBuffer
    {
        get => GetNullableObject<MTLIOCommandBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.CommandBuffer));
    }

    public MTLIOCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get => GetNullableObject<MTLIOCommandBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.CommandBufferWithUnretainedReferences));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.Label));
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
