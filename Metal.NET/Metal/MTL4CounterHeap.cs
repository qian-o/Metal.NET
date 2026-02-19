namespace Metal.NET;

public class MTL4CounterHeap(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapBindings.Count);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
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
