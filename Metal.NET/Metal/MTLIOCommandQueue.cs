namespace Metal.NET;

public class MTLIOCommandQueue(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLIOCommandBuffer? CommandBuffer
    {
        get => GetProperty(ref field, MTLIOCommandQueueBindings.CommandBuffer);
    }

    public MTLIOCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get => GetProperty(ref field, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLIOCommandQueueBindings.Label);
        set => SetProperty(ref field, MTLIOCommandQueueBindings.SetLabel, value);
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
