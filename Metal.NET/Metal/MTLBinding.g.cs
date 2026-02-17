namespace Metal.NET;

file class MTLBindingSelector
{
}

public class MTLBinding : IDisposable
{
    public MTLBinding(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBinding(nint value)
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
