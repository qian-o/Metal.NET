namespace Metal.NET;

public class MTL4FXTemporalDenoisedScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownership), INativeObject<MTL4FXTemporalDenoisedScaler>
{
    #region INativeObject
    public static new MTL4FXTemporalDenoisedScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4FXTemporalDenoisedScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Encode this scaler denoiser’s work into a command buffer.</summary>
    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
    #endregion
}

file static class MTL4FXTemporalDenoisedScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
