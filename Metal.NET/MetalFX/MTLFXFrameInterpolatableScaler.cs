namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static MTLFXFrameInterpolatableScaler Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
