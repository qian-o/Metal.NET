namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler(nint nativePtr, bool owned) : MTLFXTemporalDenoisedScalerBase(nativePtr, owned)
{
    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
