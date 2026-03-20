namespace Metal.NET;

public class MTLIOCommandQueue(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOCommandQueue>
{
    #region INativeObject
    public static new MTLIOCommandQueue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOCommandQueue New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLIOCommandQueueBindings.Label);
        set => SetProperty(ref field, MTLIOCommandQueueBindings.SetLabel, value);
    }

    public void EnqueueBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueBindings.EnqueueBarrier);
    }

    public MTLIOCommandBuffer MakeCommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOCommandQueueBindings.CommandBuffer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIOCommandBuffer MakeCommandBufferWithUnretainedReferences()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIOCommandQueueBindings.CommandBufferWithUnretainedReferences);

        return new(nativePtr, NativeObjectOwnership.Owned);
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
