namespace Metal.NET;

file class MTLPackedFloat3Selector
{
}

public class MTLPackedFloat3 : IDisposable
{
    public MTLPackedFloat3(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLPackedFloat3()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLPackedFloat3 value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPackedFloat3(nint value)
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
