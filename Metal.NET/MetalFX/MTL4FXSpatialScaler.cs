namespace Metal.NET;

public class MTL4FXSpatialScaler(nint nativePtr, bool ownsReference) : MTLFXSpatialScalerBase(nativePtr, ownsReference), INativeObject<MTL4FXSpatialScaler>
{
    public static new MTL4FXSpatialScaler Create(nint nativePtr) => new(nativePtr, true);

    public static new MTL4FXSpatialScaler CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
