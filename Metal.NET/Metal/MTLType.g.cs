namespace Metal.NET;

file class MTLTypeSelector
{
}

public class MTLType : IDisposable
{
    public MTLType(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLType(nint value)
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
