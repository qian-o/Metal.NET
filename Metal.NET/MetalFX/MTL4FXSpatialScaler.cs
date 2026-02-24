namespace Metal.NET;

public class MTL4FXSpatialScaler(nint nativePtr) : MTLFXSpatialScalerBase(nativePtr), INativeObject<MTL4FXSpatialScaler>
{
    public static new MTL4FXSpatialScaler Create(nint nativePtr) => new(nativePtr);

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
