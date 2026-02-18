namespace Metal.NET;

public class MTLLogState : IDisposable
{
    public MTLLogState(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLLogState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLLogState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLogState(nint value)
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

file class MTLLogStateSelector
{
}
