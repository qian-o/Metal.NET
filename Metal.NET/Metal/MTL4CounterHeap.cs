namespace Metal.NET;

public readonly struct MTL4CounterHeap(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapBindings.Count);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapBindings.Type);
    }

    public void InvalidateCounterRange(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapBindings.InvalidateCounterRange, range);
    }
}

file static class MTL4CounterHeapBindings
{
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector InvalidateCounterRange = Selector.Register("invalidateCounterRange:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Type = Selector.Register("type");
}
