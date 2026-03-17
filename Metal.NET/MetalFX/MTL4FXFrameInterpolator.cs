namespace Metal.NET;

public class MTL4FXFrameInterpolator(nint nativePtr, NativeObjectOwnership ownership) : MTLFXFrameInterpolatorBase(nativePtr, ownership), INativeObject<MTL4FXFrameInterpolator>
{
    #region INativeObject
    public static new MTL4FXFrameInterpolator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4FXFrameInterpolator New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Encode this frame interpolator’s work into a command buffer.
    /// </summary>
    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
    #endregion
}

file static class MTL4FXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
