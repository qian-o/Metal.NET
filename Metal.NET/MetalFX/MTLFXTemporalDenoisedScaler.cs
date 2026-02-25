namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler(nint nativePtr, bool ownsReference = true) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownsReference), INativeObject<MTLFXTemporalDenoisedScaler>
{
    public static new MTLFXTemporalDenoisedScaler Create(nint nativePtr) => new(nativePtr);

    public static new MTLFXTemporalDenoisedScaler CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
