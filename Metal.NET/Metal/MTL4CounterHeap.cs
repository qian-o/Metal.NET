namespace Metal.NET;

public class MTL4CounterHeap(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4CounterHeap>
{
    public static MTL4CounterHeap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CounterHeap Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapBindings.Count);
    }

    public NSString Label
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
