namespace Metal.NET;

public readonly struct MTLIndirectComputeCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLIndirectComputeCommandEncoder value) => new(value.NativePtr);

    public MTLIndirectComputeCommandEncoder Retain()
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

file static class MTLIndirectComputeCommandEncoderBindings
{
}
