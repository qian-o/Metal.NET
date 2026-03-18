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

    public void Encode(MTLCommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBindings.Encode, commandBuffer.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorBindings
{
    public static readonly Selector Encode = "encodeToCommandBuffer:";
}
