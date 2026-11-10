namespace Metal.NET;

public readonly struct MTLFXFrameInterpolatableScaler(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLFXFrameInterpolatableScaler value) => new(value.NativePtr);

    public MTLFXFrameInterpolatableScaler Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
