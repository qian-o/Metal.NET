namespace Metal.NET;

public class MTL4FXTemporalScaler(nint nativePtr) : MTLFXTemporalScalerBase(nativePtr), INativeObject<MTL4FXTemporalScaler>
{
    public static new MTL4FXTemporalScaler Create(nint nativePtr) => new(nativePtr);

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
