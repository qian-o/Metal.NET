namespace Metal.NET;

file class MTL4FunctionDescriptorSelector
{
}

public class MTL4FunctionDescriptor : IDisposable
{
    public MTL4FunctionDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4FunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4FunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FunctionDescriptor(nint value)
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
