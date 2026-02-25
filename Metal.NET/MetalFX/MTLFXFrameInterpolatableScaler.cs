namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static MTLFXFrameInterpolatableScaler Create(nint nativePtr) => new(nativePtr, true);

    public static MTLFXFrameInterpolatableScaler CreateBorrowed(nint nativePtr) => new(nativePtr, false);
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
