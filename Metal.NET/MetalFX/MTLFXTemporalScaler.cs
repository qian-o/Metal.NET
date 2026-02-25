namespace Metal.NET;

public class MTLFXTemporalScaler(nint nativePtr, bool ownsReference) : MTLFXTemporalScalerBase(nativePtr, ownsReference), INativeObject<MTLFXTemporalScaler>
{
    public static new MTLFXTemporalScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static new MTLFXTemporalScaler Null => new(0, false);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
