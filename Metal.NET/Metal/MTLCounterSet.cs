namespace Metal.NET;

public class MTLCounterSet : IDisposable
{
    public MTLCounterSet(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCounterSet()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray Counters => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetSelector.Counters));

    public NSString Name => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetSelector.Name));

    public static implicit operator nint(MTLCounterSet value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCounterSet(nint value)
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

file class MTLCounterSetSelector
{
    public static readonly Selector Counters = Selector.Register("counters");

    public static readonly Selector Name = Selector.Register("name");
}
