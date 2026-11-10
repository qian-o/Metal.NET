namespace Metal.NET;

public readonly struct MTLLogContainer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLLogContainer value) => new(value.NativePtr);

    public MTLLogContainer Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }
}

file static class MTLLogContainerBindings
{
}
