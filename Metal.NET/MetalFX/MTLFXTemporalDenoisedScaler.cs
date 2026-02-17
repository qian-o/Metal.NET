namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler : IDisposable
{
    public MTLFXTemporalDenoisedScaler(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLFXTemporalDenoisedScaler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }

    public static implicit operator nint(MTLFXTemporalDenoisedScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalDenoisedScaler(nint value)
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

file class MTLFXTemporalDenoisedScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
