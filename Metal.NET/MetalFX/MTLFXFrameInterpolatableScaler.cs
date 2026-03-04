namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLFXFrameInterpolatableScaler>
{
    #region INativeObject
    public static MTLFXFrameInterpolatableScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFXFrameInterpolatableScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
