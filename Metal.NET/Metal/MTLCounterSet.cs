namespace Metal.NET;

public class MTLCounterSet(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public NSArray? Counters
    {
        get => GetProperty(ref field, MTLCounterSetBindings.Counters);
    }

    public NSString? Name
    {
        get => GetProperty(ref field, MTLCounterSetBindings.Name);
    }
}

file static class MTLCounterSetBindings
{
    public static readonly Selector Counters = "counters";

    public static readonly Selector Name = "name";
}
