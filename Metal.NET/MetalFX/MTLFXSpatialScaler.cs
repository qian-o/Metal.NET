namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr) : MTLFXSpatialScalerBase(nativePtr), INativeObject<MTLFXSpatialScaler>
{
    public static new MTLFXSpatialScaler Create(nint nativePtr) => new(nativePtr);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
