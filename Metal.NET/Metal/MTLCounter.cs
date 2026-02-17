namespace Metal.NET;

public class MTLCounter : IDisposable
{
    public MTLCounter(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCounter()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Name => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSelector.Name));

    public static implicit operator nint(MTLCounter value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCounter(nint value)
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

file class MTLCounterSelector
{
    public static readonly Selector Name = Selector.Register("name");
}
