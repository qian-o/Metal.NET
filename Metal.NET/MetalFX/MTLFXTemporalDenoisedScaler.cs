namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler(nint nativePtr) : MTLFXTemporalDenoisedScalerBase(nativePtr)
{
    public static implicit operator nint(MTLFXTemporalDenoisedScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalDenoisedScaler(nint value)
    {
        return new(value);
    }

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file class MTLFXTemporalDenoisedScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
