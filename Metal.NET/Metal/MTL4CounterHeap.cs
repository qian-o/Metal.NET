namespace Metal.NET;

public class MTL4CounterHeap : IDisposable
{
    public MTL4CounterHeap(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CounterHeap()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CounterHeap value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CounterHeap(nint value)
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

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapSelector.SetLabel, label.NativePtr);
    }

}

file class MTL4CounterHeapSelector
{
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
