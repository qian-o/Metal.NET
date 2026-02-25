namespace Metal.NET;

public class MTLFXTemporalScaler(nint nativePtr, bool ownsReference = true) : MTLFXTemporalScalerBase(nativePtr, ownsReference), INativeObject<MTLFXTemporalScaler>
{
    public static new MTLFXTemporalScaler Create(nint nativePtr) => new(nativePtr);

    public static new MTLFXTemporalScaler CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
