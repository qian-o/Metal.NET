namespace Metal.NET;

public readonly struct MTLIndirectComputeCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLIndirectComputeCommandEncoder value) => new(value.NativePtr);

    public MTLIndirectComputeCommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }
}

file static class MTLIndirectComputeCommandEncoderBindings
{
}
