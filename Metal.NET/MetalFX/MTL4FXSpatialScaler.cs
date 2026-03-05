namespace Metal.NET;

public class MTL4FXSpatialScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXSpatialScalerBase(nativePtr, ownership), INativeObject<MTL4FXSpatialScaler>
{
    #region INativeObject
    public static new MTL4FXSpatialScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4FXSpatialScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
