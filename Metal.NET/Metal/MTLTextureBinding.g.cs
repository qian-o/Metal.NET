namespace Metal.NET;

public class MTLTextureBinding : IDisposable
{
    public MTLTextureBinding(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTextureBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTextureBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureBinding(nint value)
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

file class MTLTextureBindingSelector
{
}
