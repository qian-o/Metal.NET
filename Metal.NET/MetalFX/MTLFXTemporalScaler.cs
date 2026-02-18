namespace Metal.NET;

public class MTLFXTemporalScaler(nint nativePtr) : MTLFXTemporalScalerBase(nativePtr)
{
    public static implicit operator nint(MTLFXTemporalScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalScaler(nint value)
    {
        return new(value);
    }

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file class MTLFXTemporalScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
