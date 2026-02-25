namespace Metal.NET;

public class MTLCounterSet(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLCounterSet>
{
    public static MTLCounterSet Null { get; } = new(0, false);

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
