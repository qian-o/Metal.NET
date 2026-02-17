namespace Metal.NET;

public class MTLPointerType : IDisposable
{
    public MTLPointerType(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLPointerType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLPointerType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPointerType(nint value)
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

file class MTLPointerTypeSelector
{
}
