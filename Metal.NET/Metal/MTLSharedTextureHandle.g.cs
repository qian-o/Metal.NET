namespace Metal.NET;

file class MTLSharedTextureHandleSelector
{
}

public class MTLSharedTextureHandle : IDisposable
{
    public MTLSharedTextureHandle(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLSharedTextureHandle()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLSharedTextureHandle value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSharedTextureHandle(nint value)
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
