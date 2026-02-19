namespace Metal.NET;

public class MTL4FXTemporalScaler(nint nativePtr, bool owned) : MTLFXTemporalScalerBase(nativePtr, owned)
{
    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
