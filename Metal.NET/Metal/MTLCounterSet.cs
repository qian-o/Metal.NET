namespace Metal.NET;

public class MTLCounterSet(nint nativePtr) : NativeObject(nativePtr)
{

    public NSArray? Counters
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetSelector.Counters));
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetSelector.Name));
    }
}

file static class MTLCounterSetSelector
{
    public static readonly Selector Counters = Selector.Register("counters");

    public static readonly Selector Name = Selector.Register("name");
}
