namespace Metal.NET;

file class MTLFXSpatialScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer_ = Selector.Register("encodeToCommandBuffer:");
}

public class MTLFXSpatialScaler : IDisposable
{
    public MTLFXSpatialScaler(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFXSpatialScaler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXSpatialScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXSpatialScaler(nint value)
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

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerSelector.EncodeToCommandBuffer_, pCommandBuffer.NativePtr);
    }

}
