namespace Metal.NET;

public class MTL4FXTemporalDenoisedScaler(nint nativePtr, bool ownsReference = true) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownsReference), INativeObject<MTL4FXTemporalDenoisedScaler>
{
    public static new MTL4FXTemporalDenoisedScaler Create(nint nativePtr) => new(nativePtr);

    public static new MTL4FXTemporalDenoisedScaler CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
