namespace Metal.NET;

public partial class MTLCounterSet : NativeObject
{
    public MTLCounterSet(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? Counters
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetSelector.Counters);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLCounterSetSelector
{
    public static readonly Selector Counters = Selector.Register("counters");

    public static readonly Selector Name = Selector.Register("name");
}
