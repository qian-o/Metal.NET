namespace Metal.NET;

file class MTLCommandBufferEncoderInfoSelector
{
}

public class MTLCommandBufferEncoderInfo : IDisposable
{
    public MTLCommandBufferEncoderInfo(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLCommandBufferEncoderInfo()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCommandBufferEncoderInfo value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandBufferEncoderInfo(nint value)
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
