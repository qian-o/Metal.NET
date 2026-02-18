namespace Metal.NET;

public class MTLCounterResultTimestamp : IDisposable
{
    public MTLCounterResultTimestamp(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLCounterResultTimestamp()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCounterResultTimestamp value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCounterResultTimestamp(nint value)
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

file class MTLCounterResultTimestampSelector
{
}
