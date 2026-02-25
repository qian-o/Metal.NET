namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr, bool ownsReference = true) : MTLFXSpatialScalerBase(nativePtr, ownsReference), INativeObject<MTLFXSpatialScaler>
{
    public static new MTLFXSpatialScaler Create(nint nativePtr) => new(nativePtr);

    public static new MTLFXSpatialScaler CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
