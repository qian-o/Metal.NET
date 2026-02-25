namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler(nint nativePtr, bool ownsReference) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownsReference), INativeObject<MTLFXTemporalDenoisedScaler>
{
    public static new MTLFXTemporalDenoisedScaler Create(nint nativePtr) => new(nativePtr, true);

    public static new MTLFXTemporalDenoisedScaler CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
