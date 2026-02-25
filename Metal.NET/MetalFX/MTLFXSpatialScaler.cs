namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXSpatialScalerBase(nativePtr, ownership), INativeObject<MTLFXSpatialScaler>
{
    public static new MTLFXSpatialScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXSpatialScaler Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
