namespace Metal.NET;

public class MTL4FXTemporalDenoisedScaler(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4FXTemporalDenoisedScaler>
{
    public static new MTL4FXTemporalDenoisedScaler Null { get; } = new(0, false);

    public static new MTL4FXTemporalDenoisedScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
