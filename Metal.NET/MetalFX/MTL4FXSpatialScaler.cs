namespace Metal.NET;

public class MTL4FXSpatialScaler(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLFXSpatialScalerBase(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4FXSpatialScaler>
{
    public static new MTL4FXSpatialScaler Null { get; } = new(0, false, false);

    public static new MTL4FXSpatialScaler Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
