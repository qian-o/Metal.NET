namespace Metal.NET;

public class MTL4FXSpatialScaler(nint nativePtr, bool owned) : MTLFXSpatialScalerBase(nativePtr, owned)
{
    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
