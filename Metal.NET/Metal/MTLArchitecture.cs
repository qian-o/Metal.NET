namespace Metal.NET;

public readonly struct MTLArchitecture(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLArchitecture value) => new(value.NativePtr);

    public MTLArchitecture Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLArchitectureBindings.Name));
    }
}

file static class MTLArchitectureBindings
{
    public static readonly Selector Name = "name";
}
