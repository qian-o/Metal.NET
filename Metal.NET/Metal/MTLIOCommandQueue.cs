namespace Metal.NET;

public class MTLIOCommandQueue(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLIOCommandQueue>
{
    public static MTLIOCommandQueue Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLIOCommandQueue Null => new(0, false);

    public NSString Label
    {
        get => GetProperty(ref field, MTLIOCommandQueueBindings.Label);
        set => SetProperty(ref field, MTLIOCommandQueueBindings.SetLabel, value);
    }

    public MTLIOCommandBuffer CommandBuffer()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBuffer);

        return new(nativePtr, false);
    }

    public MTLIOCommandBuffer CommandBufferWithUnretainedReferences()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);

        return new(nativePtr, false);
    }

    public void EnqueueBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueBindings.EnqueueBarrier);
    }
}

file static class MTLIOCommandQueueBindings
{
    public static readonly Selector CommandBuffer = "commandBuffer";

    public static readonly Selector CommandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";

    public static readonly Selector EnqueueBarrier = "enqueueBarrier";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
