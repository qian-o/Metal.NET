namespace Metal.NET;

public class MTL4FXTemporalDenoisedScaler(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4FXTemporalDenoisedScaler>
{
    public static new MTL4FXTemporalDenoisedScaler Null { get; } = new(0, false, false);

    public static new MTL4FXTemporalDenoisedScaler Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
