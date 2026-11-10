namespace Metal.NET;

public readonly struct MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFunctionStitchingAttribute(MTLFunctionStitchingAttributeAlwaysInline value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLFunctionStitchingAttributeAlwaysInline value) => new(value.NativePtr);

    public MTLFunctionStitchingAttributeAlwaysInline Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }
}

file static class MTLFunctionStitchingAttributeAlwaysInlineBindings
{
}
