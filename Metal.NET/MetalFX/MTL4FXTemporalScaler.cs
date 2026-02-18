namespace Metal.NET;

public class MTL4FXTemporalScaler : IDisposable
{
    public MTL4FXTemporalScaler(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4FXTemporalScaler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalScalerSelector.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }

    public static implicit operator nint(MTL4FXTemporalScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FXTemporalScaler(nint value)
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

file class MTL4FXTemporalScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
