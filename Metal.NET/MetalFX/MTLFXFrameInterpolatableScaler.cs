namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static MTLFXFrameInterpolatableScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLFXFrameInterpolatableScaler Null => Create(0, false);
    public static MTLFXFrameInterpolatableScaler Empty => Null;
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
