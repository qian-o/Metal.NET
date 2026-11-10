namespace Metal.NET;

public readonly struct MTLIOCommandQueue(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLIOCommandQueue value) => new(value.NativePtr);

    public MTLIOCommandQueue Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIOCommandQueueBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueBindings.SetLabel, value.NativePtr);
    }

    public void EnqueueBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueBindings.EnqueueBarrier);
    }

    public MTLIOCommandBuffer MakeCommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOCommandQueueBindings.CommandBuffer);

        return new(nativePtr);
    }

    public MTLIOCommandBuffer MakeCommandBufferWithUnretainedReferences()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);

        return new(nativePtr);
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
