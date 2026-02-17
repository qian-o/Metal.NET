namespace Metal.NET;

file class MTLIOScratchBufferSelector
{
}

public class MTLIOScratchBuffer : IDisposable
{
    public MTLIOScratchBuffer(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIOScratchBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIOScratchBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOScratchBuffer(nint value)
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
