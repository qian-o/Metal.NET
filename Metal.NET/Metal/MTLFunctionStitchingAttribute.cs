namespace Metal.NET;

public readonly struct MTLFunctionStitchingAttribute(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFunctionStitchingAttribute value) => new(value.NativePtr);

    public MTLFunctionStitchingAttribute Retain()
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

file static class MTLFunctionStitchingAttributeBindings
{
}
