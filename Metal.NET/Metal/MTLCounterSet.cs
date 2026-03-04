namespace Metal.NET;

public class MTLCounterSet(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLCounterSet>
{
    #region INativeObject
    public static MTLCounterSet Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLCounterSet New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

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
