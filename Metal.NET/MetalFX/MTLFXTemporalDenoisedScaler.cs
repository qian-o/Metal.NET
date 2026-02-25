namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFXTemporalDenoisedScaler>
{
    public static new MTLFXTemporalDenoisedScaler Null { get; } = new(0, false, false);

    public static new MTLFXTemporalDenoisedScaler Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
