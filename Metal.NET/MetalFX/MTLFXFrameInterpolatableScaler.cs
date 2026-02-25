namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static MTLFXFrameInterpolatableScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLFXFrameInterpolatableScaler Null => new(0, false);
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
