namespace Metal.NET;

public class MTLBufferBinding : IDisposable
{
    public MTLBufferBinding(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLBufferBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBufferBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBufferBinding(nint value)
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

file class MTLBufferBindingSelector
{
}
