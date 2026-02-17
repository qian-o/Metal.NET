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
}
