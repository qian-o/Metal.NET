namespace Metal.NET;

public readonly struct MTLIndirectRenderCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLIndirectRenderCommandEncoder value) => new(value.NativePtr);

    public MTLIndirectRenderCommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }
}

file static class MTLIndirectRenderCommandEncoderBindings
{
}
