namespace Metal.NET;

public class MTL4CounterHeap(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapBindings.Count);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTL4CounterHeapBindings.Label);
        set => SetProperty(ref field, MTL4CounterHeapBindings.SetLabel, value);
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
    public static readonly Selector Count = "count";

    public static readonly Selector InvalidateCounterRange = "invalidateCounterRange:";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector Type = "type";
}
