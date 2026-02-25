namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static MTLFXFrameInterpolatableScaler Create(nint nativePtr) => new(nativePtr);

    public static MTLFXFrameInterpolatableScaler CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
