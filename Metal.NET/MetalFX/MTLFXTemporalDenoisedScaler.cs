namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler(nint nativePtr, bool ownsReference) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownsReference), INativeObject<MTLFXTemporalDenoisedScaler>
{
    public static new MTLFXTemporalDenoisedScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTLFXTemporalDenoisedScaler Null => Create(0, false);
    public static new MTLFXTemporalDenoisedScaler Empty => Null;

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
