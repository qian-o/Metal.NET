namespace Metal.NET;

file class MTLFunctionStitchingAttributeSelector
{
}

public class MTLFunctionStitchingAttribute : IDisposable
{
    public MTLFunctionStitchingAttribute(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFunctionStitchingAttribute()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionStitchingAttribute value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingAttribute(nint value)
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
