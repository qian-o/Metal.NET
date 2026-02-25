namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLFXSpatialScalerBase(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFXSpatialScaler>
{
    public static new MTLFXSpatialScaler Null { get; } = new(0, false, false);

    public static new MTLFXSpatialScaler Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
