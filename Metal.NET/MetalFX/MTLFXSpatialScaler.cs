namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr, bool owned) : MTLFXSpatialScalerBase(nativePtr, owned)
{
    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
