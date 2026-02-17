namespace Metal.NET;

public class MTLFXSpatialScaler : IDisposable
{
    public MTLFXSpatialScaler(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerSelector.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }

}

file class MTLFXSpatialScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
