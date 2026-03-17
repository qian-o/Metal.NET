namespace Metal.NET;

/// <summary>
/// An upscaling effect that generates a higher resolution texture in a render pass by spatially analyzing an input texture.
/// </summary>
public class MTL4FXSpatialScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXSpatialScalerBase(nativePtr, ownership), INativeObject<MTL4FXSpatialScaler>
{
    #region INativeObject
    public static new MTL4FXSpatialScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4FXSpatialScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Encode this spatial scaler work into a command buffer.
    /// </summary>
    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
    #endregion
}

file static class MTL4FXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
