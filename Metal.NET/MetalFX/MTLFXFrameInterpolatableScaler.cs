namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static new MTLFXFrameInterpolatableScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXFrameInterpolatableScaler Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
