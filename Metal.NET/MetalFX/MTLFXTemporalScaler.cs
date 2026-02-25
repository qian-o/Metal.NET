namespace Metal.NET;

public class MTLFXTemporalScaler(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : MTLFXTemporalScalerBase(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFXTemporalScaler>
{
    public static new MTLFXTemporalScaler Null { get; } = new(0, false);

    public static new MTLFXTemporalScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
