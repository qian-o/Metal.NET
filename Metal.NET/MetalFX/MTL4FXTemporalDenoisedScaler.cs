namespace Metal.NET;

public class MTL4FXTemporalDenoisedScaler(nint nativePtr) : MTLFXTemporalDenoisedScalerBase(nativePtr)
{

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalDenoisedScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
