namespace Metal.NET;

public readonly struct MTLCounterSet(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public NSArray? Counters
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetBindings.Counters);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTLCounterSetBindings
{
    public static readonly Selector Counters = Selector.Register("counters");

    public static readonly Selector Name = Selector.Register("name");
}
