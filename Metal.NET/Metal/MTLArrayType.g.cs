namespace Metal.NET;

public class MTLArrayType : IDisposable
{
    public MTLArrayType(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLArrayType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLArrayType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArrayType(nint value)
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

file class MTLArrayTypeSelector
{
}
