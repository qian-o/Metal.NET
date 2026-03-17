namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr, NativeObjectOwnership ownership) : MTLFXFrameInterpolatorBase(nativePtr, ownership), INativeObject<MTLFXFrameInterpolator>
{
    #region INativeObject
    public static new MTLFXFrameInterpolator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXFrameInterpolator New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Encode this frame interpolator’s work into a command buffer.
    /// </summary>
    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
    #endregion
}

file static class MTLFXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
