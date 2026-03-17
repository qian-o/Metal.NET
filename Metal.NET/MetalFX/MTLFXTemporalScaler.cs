namespace Metal.NET;

/// <summary>
/// An upscaling effect that generates a higher resolution texture in a render pass by analyzing multiple input textures over time.
/// </summary>
public class MTLFXTemporalScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXTemporalScalerBase(nativePtr, ownership), INativeObject<MTLFXTemporalScaler>
{
    #region INativeObject
    public static new MTLFXTemporalScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Encoding a temporal scaling effect - Methods

    /// <summary>
    /// Adds the temporal scaling command to a render pass’s command buffer.
    /// </summary>
    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
    #endregion
}

file static class MTLFXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
