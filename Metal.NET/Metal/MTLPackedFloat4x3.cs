namespace Metal.NET;

public class MTLPackedFloat4x3 : IDisposable
{
    public MTLPackedFloat4x3(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLPackedFloat4x3()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLPackedFloat4x3 value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPackedFloat4x3(nint value)
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

file class MTLPackedFloat4x3Selector
{
}
