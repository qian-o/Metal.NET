namespace Metal.NET;

public class MTLComponentTransform : IDisposable
{
    public MTLComponentTransform(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLComponentTransform()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComponentTransform value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComponentTransform(nint value)
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

file class MTLComponentTransformSelector
{
}
