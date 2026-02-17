namespace Metal.NET;

public class MTLVertexAttribute : IDisposable
{
    public MTLVertexAttribute(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLVertexAttribute()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLVertexAttribute value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexAttribute(nint value)
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

file class MTLVertexAttributeSelector
{
}
