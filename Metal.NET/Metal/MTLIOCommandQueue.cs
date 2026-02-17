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

    public void EnqueueBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueSelector.EnqueueBarrier);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueSelector.SetLabel, label.NativePtr);
    }

}

file class MTLIOCommandQueueSelector
{
    public static readonly Selector EnqueueBarrier = Selector.Register("enqueueBarrier");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
