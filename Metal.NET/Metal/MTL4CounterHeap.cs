namespace Metal.NET;

public partial class MTL4CounterHeap : NativeObject
{
    public MTL4CounterHeap(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapSelector.Count);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapSelector.Type);
    }

    public void InvalidateCounterRange(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapSelector.InvalidateCounterRange, range);
    }
}

file static class MTL4CounterHeapSelector
{
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector InvalidateCounterRange = Selector.Register("invalidateCounterRange:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Type = Selector.Register("type");
}
