namespace Metal.NET;

public class MTL4FXTemporalScaler(nint nativePtr) : MTLFXTemporalScalerBase(nativePtr)
{
    public static implicit operator nint(MTL4FXTemporalScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FXTemporalScaler(nint value)
    {
        return new(value);
    }

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file class MTL4FXTemporalScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
