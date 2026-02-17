namespace Metal.NET;

file class MTLCounterSelector
{
}

public class MTLCounter : IDisposable
{
    public MTLCounter(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLCounter()
    {
        Release();
    }

    public nint NativePtr { get; }

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
