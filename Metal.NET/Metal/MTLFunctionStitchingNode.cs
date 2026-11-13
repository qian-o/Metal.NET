namespace Metal.NET;

public readonly struct MTLFunctionStitchingNode(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFunctionStitchingNode value) => new(value.NativePtr);

    public MTLFunctionStitchingNode Retain()
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

file static class MTLFunctionStitchingNodeBindings
{
}
