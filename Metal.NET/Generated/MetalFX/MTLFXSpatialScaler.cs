namespace Metal.NET;

public partial class MTLFXSpatialScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXSpatialScalerBase(nativePtr, ownership), INativeObject<MTLFXSpatialScaler>
{
    #region INativeObject
    public static new MTLFXSpatialScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXSpatialScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void Encode(MTLCommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
