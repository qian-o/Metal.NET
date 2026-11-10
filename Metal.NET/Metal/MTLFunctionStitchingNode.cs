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

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }
}

file static class MTLFunctionStitchingNodeBindings
{
}
