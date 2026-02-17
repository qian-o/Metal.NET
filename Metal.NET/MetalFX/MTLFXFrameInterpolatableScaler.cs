namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler : IDisposable
{
    public MTLFXFrameInterpolatableScaler(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFXFrameInterpolatableScaler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXFrameInterpolatableScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXFrameInterpolatableScaler(nint value)
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

file class MTLFXFrameInterpolatableScalerSelector
{
}
