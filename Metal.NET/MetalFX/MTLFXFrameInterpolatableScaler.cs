namespace Metal.NET;

public class MTLFXFrameInterpolatableScaler(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLFXFrameInterpolatableScaler>
{
    public static MTLFXFrameInterpolatableScaler Create(nint nativePtr) => new(nativePtr);
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
