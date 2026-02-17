namespace Metal.NET;

file class MTLTensorReferenceTypeSelector
{
}

public class MTLTensorReferenceType : IDisposable
{
    public MTLTensorReferenceType(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLTensorReferenceType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTensorReferenceType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorReferenceType(nint value)
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
