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

    public void Encode(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.Encode, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorBindings
{
    public static readonly Selector Encode = "encodeToCommandBuffer:";
}
