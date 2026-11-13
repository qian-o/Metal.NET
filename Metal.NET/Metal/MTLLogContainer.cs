namespace Metal.NET;

public readonly struct MTLLogContainer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLLogContainer value) => new(value.NativePtr);

    public MTLLogContainer Retain()
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

file static class MTLLogContainerBindings
{
}
