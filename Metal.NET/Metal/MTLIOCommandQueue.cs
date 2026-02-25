namespace Metal.NET;

public class MTLIOCommandQueue(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLIOCommandQueue>
{
    public static MTLIOCommandQueue Create(nint nativePtr) => new(nativePtr);

    public static MTLIOCommandQueue CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public NSString Label
    {
        get => GetProperty(ref field, MTLIOCommandQueueBindings.Label);
        set => SetProperty(ref field, MTLIOCommandQueueBindings.SetLabel, value);
    }

    public MTLIOCommandBuffer CommandBuffer()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBuffer);

        return new(nativePtr);
    }

    public MTLIOCommandBuffer CommandBufferWithUnretainedReferences()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);

        return new(nativePtr);
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
