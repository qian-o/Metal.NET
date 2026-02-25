namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static MTLFXFrameInterpolatableScaler Null { get; } = new(0, false);

    public static MTLFXFrameInterpolatableScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
