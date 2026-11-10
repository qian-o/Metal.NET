namespace Metal.NET;

public readonly struct MTLCounterSet(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLCounterSet value) => new(value.NativePtr);

    public MTLCounterSet Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCounterSetBindings.Name));
    }

    public NSArray<MTLCounter> Counters
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCounterSetBindings.Counters));
    }
}

file static class MTLCounterSetBindings
{
    public static readonly Selector Counters = "counters";

    public static readonly Selector Name = "name";
}
