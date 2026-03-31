namespace Metal.NET;

public class MTLCounterSet(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCounterSet>
{
    #region INativeObject
    public static new MTLCounterSet Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCounterSet New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterSetBindings.Name);
    }

    public NSArray<MTLCounter> Counters
    {
        get => GetProperty(ref field, MTLCounterSetBindings.Counters);
    }
}

file static class MTLCounterSetBindings
{
    public static readonly Selector Counters = "counters";

    public static readonly Selector Name = "name";
}
