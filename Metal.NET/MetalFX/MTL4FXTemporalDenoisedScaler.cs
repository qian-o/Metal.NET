namespace Metal.NET;

public class MTL4FXTemporalDenoisedScaler : IDisposable
{
    public MTL4FXTemporalDenoisedScaler(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4FXTemporalDenoisedScaler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }

    public static implicit operator nint(MTL4FXTemporalDenoisedScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FXTemporalDenoisedScaler(nint value)
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

file class MTL4FXTemporalDenoisedScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
