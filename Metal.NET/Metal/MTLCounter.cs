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

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
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
