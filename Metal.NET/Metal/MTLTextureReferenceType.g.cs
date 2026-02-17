namespace Metal.NET;

public class MTLTextureReferenceType : IDisposable
{
    public MTLTextureReferenceType(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTextureReferenceType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTextureReferenceType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureReferenceType(nint value)
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

file class MTLTextureReferenceTypeSelector
{
}
