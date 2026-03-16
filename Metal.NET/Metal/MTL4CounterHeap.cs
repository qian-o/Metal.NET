namespace Metal.NET;

/// <summary>Represents an opaque, driver-controlled section of memory that can store GPU counter data.</summary>
public class MTL4CounterHeap(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CounterHeap>
{
    #region INativeObject
    public static new MTL4CounterHeap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CounterHeap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>Queries the number of entries in the heap.</summary>
    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4CounterHeapBindings.Count);
    }

    /// <summary>Assigns a label for later inspection or visualization.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4CounterHeapBindings.Label);
        set => SetProperty(ref field, MTL4CounterHeapBindings.SetLabel, value);
    }

    /// <summary>Queries the type of the heap.</summary>
    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveC.MsgSendLong(NativePtr, MTL4CounterHeapBindings.Type);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Invalidates a range of entries in this counter heap.</summary>
    public void InvalidateCounterRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapBindings.InvalidateCounterRange, range);
    }

    /// <summary>Resolves heap data on the CPU timeline.</summary>
    public NSData ResolveCounterRange(NSRange range)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CounterHeapBindings.ResolveCounterRange, range);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
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
