namespace Metal.NET;

public readonly struct MTLFXFrameInterpolatableScaler(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFXFrameInterpolatableScaler value) => new(value.NativePtr);

    public MTLFXFrameInterpolatableScaler Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }
}

file static class MTLFXFrameInterpolatableScalerBindings
{
}
