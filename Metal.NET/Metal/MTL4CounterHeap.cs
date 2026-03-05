namespace Metal.NET;

public class MTL4CounterHeap(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CounterHeap>
{
    #region INativeObject
    public static new MTL4CounterHeap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CounterHeap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4CounterHeapBindings.Count);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CounterHeapBindings.Label);
        set => SetProperty(ref field, MTL4CounterHeapBindings.SetLabel, value);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveC.MsgSendLong(NativePtr, MTL4CounterHeapBindings.Type);
    }

    public void InvalidateCounterRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapBindings.InvalidateCounterRange, range);
    }

    public NSData ResolveCounterRange(NSRange range)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTL4CounterHeapBindings.ResolveCounterRange, range);

        return new(nativePtr, NativeObjectOwnership.Owned);
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
