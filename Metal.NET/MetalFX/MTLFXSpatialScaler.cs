namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr, bool ownsReference) : MTLFXSpatialScalerBase(nativePtr, ownsReference), INativeObject<MTLFXSpatialScaler>
{
    public static new MTLFXSpatialScaler Create(nint nativePtr) => new(nativePtr, true);

    public static new MTLFXSpatialScaler CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
