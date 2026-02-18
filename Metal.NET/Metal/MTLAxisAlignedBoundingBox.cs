namespace Metal.NET;

public class MTLAxisAlignedBoundingBox : IDisposable
{
    public MTLAxisAlignedBoundingBox(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLAxisAlignedBoundingBox()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAxisAlignedBoundingBox value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAxisAlignedBoundingBox(nint value)
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

file class MTLAxisAlignedBoundingBoxSelector
{
}
