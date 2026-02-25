namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr, bool ownsReference) : MTLFXSpatialScalerBase(nativePtr, ownsReference), INativeObject<MTLFXSpatialScaler>
{
    public static new MTLFXSpatialScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTLFXSpatialScaler Null => Create(0, false);
    public static new MTLFXSpatialScaler Empty => Null;

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
