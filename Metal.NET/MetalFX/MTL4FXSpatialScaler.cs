namespace Metal.NET;

public class MTL4FXSpatialScaler(nint nativePtr, bool ownsReference) : MTLFXSpatialScalerBase(nativePtr, ownsReference), INativeObject<MTL4FXSpatialScaler>
{
    public static new MTL4FXSpatialScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTL4FXSpatialScaler Null => Create(0, false);
    public static new MTL4FXSpatialScaler Empty => Null;

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
