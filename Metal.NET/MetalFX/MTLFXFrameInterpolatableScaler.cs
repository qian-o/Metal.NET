namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static MTLFXFrameInterpolatableScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFXFrameInterpolatableScaler Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
