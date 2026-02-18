namespace Metal.NET;

public class MTL4FXTemporalDenoisedScaler(nint nativePtr) : MTLFXTemporalDenoisedScalerBase(nativePtr)
{
    public static implicit operator nint(MTL4FXTemporalDenoisedScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FXTemporalDenoisedScaler(nint value)
    {
        return new(value);
    }

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file class MTL4FXTemporalDenoisedScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
