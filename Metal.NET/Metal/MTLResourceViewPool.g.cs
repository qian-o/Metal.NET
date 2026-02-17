namespace Metal.NET;

file class MTLResourceViewPoolSelector
{
}

public class MTLResourceViewPool : IDisposable
{
    public MTLResourceViewPool(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLResourceViewPool()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResourceViewPool value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceViewPool(nint value)
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
