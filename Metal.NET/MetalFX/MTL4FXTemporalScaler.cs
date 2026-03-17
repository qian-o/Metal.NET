namespace Metal.NET;

public class MTL4FXTemporalScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXTemporalScalerBase(nativePtr, ownership), INativeObject<MTL4FXTemporalScaler>
{
    #region INativeObject
    public static new MTL4FXTemporalScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4FXTemporalScaler New(nint nativePtr, NativeObjectOwnership ownership)
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
        ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
    #endregion
}

file static class MTL4FXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
