namespace Metal.NET;

public class MTLAttribute : IDisposable
{
    public MTLAttribute(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAttribute()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAttribute value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAttribute(nint value)
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

file class MTLAttributeSelector
{
}
