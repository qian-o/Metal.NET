namespace Metal.NET;

public class MTL4FXTemporalScaler(nint nativePtr) : MTLFXTemporalScalerBase(nativePtr)
{

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalScalerSelector.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
