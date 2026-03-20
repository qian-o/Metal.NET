namespace Metal.NET;

public partial class MTLFXFrameInterpolatableScaler(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXFrameInterpolatableScaler>
{
    #region INativeObject
    public static new MTLFXFrameInterpolatableScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXFrameInterpolatableScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
