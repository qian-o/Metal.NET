namespace Metal.NET;

public class MTLCounterSet(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCounterSet>
{
    public static MTLCounterSet Create(nint nativePtr) => new(nativePtr, true);

    public static MTLCounterSet CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public NSArray Counters
    {
        get => GetProperty(ref field, MTLCounterSetBindings.Counters);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterSetBindings.Name);
    }
}

file static class MTLCounterSetBindings
{
    public static readonly Selector Counters = "counters";

    public static readonly Selector Name = "name";
}
