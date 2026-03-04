namespace Metal.NET;

public class MTLIOCommandQueue(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLIOCommandQueue>
{
    #region INativeObject
    public static MTLIOCommandQueue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLIOCommandQueue New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLIOCommandQueueBindings.Label);
        set => SetProperty(ref field, MTLIOCommandQueueBindings.SetLabel, value);
    }

    public MTLIOCommandBuffer CommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBuffer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOCommandBuffer CommandBufferWithUnretainedReferences()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void EnqueueBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueBindings.EnqueueBarrier);
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
