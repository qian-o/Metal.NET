namespace Metal.NET;

public readonly struct MTLCounter(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLCounter value) => new(value.NativePtr);

    public MTLCounter Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCounterBindings.Name));
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
