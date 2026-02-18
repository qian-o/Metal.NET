namespace Metal.NET;

public class MTL4TimestampHeapEntry : IDisposable
{
    public MTL4TimestampHeapEntry(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4TimestampHeapEntry()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4TimestampHeapEntry value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4TimestampHeapEntry(nint value)
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

file class MTL4TimestampHeapEntrySelector
{
}
