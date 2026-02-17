namespace Metal.NET;

file class MTLFXTemporalScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer_ = Selector.Register("encodeToCommandBuffer:");
}

public class MTLFXTemporalScaler : IDisposable
{
    public MTLFXTemporalScaler(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFXTemporalScaler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXTemporalScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalScaler(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerSelector.EncodeToCommandBuffer_, pCommandBuffer.NativePtr);
    }

}
