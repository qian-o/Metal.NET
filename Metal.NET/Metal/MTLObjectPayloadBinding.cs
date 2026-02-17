namespace Metal.NET;

public class MTLObjectPayloadBinding : IDisposable
{
    public MTLObjectPayloadBinding(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLObjectPayloadBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLObjectPayloadBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLObjectPayloadBinding(nint value)
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

file class MTLObjectPayloadBindingSelector
{
}
