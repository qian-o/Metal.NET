namespace Metal.NET;

public class MTLFXTemporalScaler(nint nativePtr) : MTLFXTemporalScalerBase(nativePtr), INativeObject<MTLFXTemporalScaler>
{
    public static new MTLFXTemporalScaler Create(nint nativePtr) => new(nativePtr);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
