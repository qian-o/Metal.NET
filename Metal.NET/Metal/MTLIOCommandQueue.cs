namespace Metal.NET;

public class MTLIOCommandQueue : IDisposable
{
    public MTLIOCommandQueue(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLIOCommandQueue()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLIOCommandBuffer CommandBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.CommandBuffer));
    }

    public MTLIOCommandBuffer CommandBufferWithUnretainedReferences
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.CommandBufferWithUnretainedReferences));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueSelector.SetLabel, value.NativePtr);
    }

    public void EnqueueBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueSelector.EnqueueBarrier);
    }

    public static implicit operator nint(MTLIOCommandQueue value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOCommandQueue(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLIOCommandQueueSelector
{
    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector CommandBufferWithUnretainedReferences = Selector.Register("commandBufferWithUnretainedReferences");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector EnqueueBarrier = Selector.Register("enqueueBarrier");
}
