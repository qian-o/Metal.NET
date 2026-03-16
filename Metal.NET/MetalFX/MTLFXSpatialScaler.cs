namespace Metal.NET;

/// <summary>An upscaling effect that generates a higher resolution texture in a render pass by spatially analyzing an input texture.</summary>
public class MTLFXSpatialScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXSpatialScalerBase(nativePtr, ownership), INativeObject<MTLFXSpatialScaler>
{
    #region INativeObject
    public static new MTLFXSpatialScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXSpatialScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Encoding a spatial scaler - Methods

    /// <summary>Adds the spatial scaler to a render pass’s command buffer.</summary>
    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
    #endregion
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
