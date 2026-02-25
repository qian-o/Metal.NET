namespace Metal.NET;

public class MTL4FXTemporalScaler(nint nativePtr, bool ownsReference) : MTLFXTemporalScalerBase(nativePtr, ownsReference), INativeObject<MTL4FXTemporalScaler>
{
    public static new MTL4FXTemporalScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static new MTL4FXTemporalScaler Null => new(0, false);

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
