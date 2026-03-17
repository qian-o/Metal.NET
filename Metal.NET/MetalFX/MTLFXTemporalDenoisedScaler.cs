namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownership), INativeObject<MTLFXTemporalDenoisedScaler>
{
    #region INativeObject
    public static new MTLFXTemporalDenoisedScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalDenoisedScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Encode this scaler denoiser’s work into a command buffer.
    /// </summary>
    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
    #endregion
}

file static class MTLFXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
