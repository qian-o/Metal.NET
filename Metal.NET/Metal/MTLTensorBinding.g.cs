namespace Metal.NET;

file class MTLTensorBindingSelector
{
}

public class MTLTensorBinding : IDisposable
{
    public MTLTensorBinding(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLTensorBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTensorBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorBinding(nint value)
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
