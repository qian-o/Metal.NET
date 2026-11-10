namespace Metal.NET;

public readonly struct MTL4CounterHeap(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTL4CounterHeap value) => new(value.NativePtr);

    public MTL4CounterHeap Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CounterHeapBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapBindings.SetLabel, value.NativePtr);
    }

    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4CounterHeapBindings.Count);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveC.MsgSendLong(NativePtr, MTL4CounterHeapBindings.Type);
    }

    public NSData ResolveCounterRange(NSRange range)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CounterHeapBindings.ResolveCounterRange, range);

        return new(nativePtr);
    }

    public void InvalidateCounterRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapBindings.InvalidateCounterRange, range);
    }
}

file static class MTL4CounterHeapBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector InvalidateCounterRange = "invalidateCounterRange:";

    public static readonly Selector Label = "label";

    public static readonly Selector ResolveCounterRange = "resolveCounterRange:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Type = "type";
}
