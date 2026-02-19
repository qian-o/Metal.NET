namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr) : MTLFXSpatialScalerBase(nativePtr)
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
