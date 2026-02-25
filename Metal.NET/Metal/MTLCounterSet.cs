namespace Metal.NET;

public class MTLCounterSet(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCounterSet>
{
    public static MTLCounterSet Null => Create(0, false);
    public static MTLCounterSet Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLCounter[] Counters
    {
        get => GetArrayProperty<MTLCounter>(MTLCounterSetBindings.Counters);
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
