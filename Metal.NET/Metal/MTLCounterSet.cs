namespace Metal.NET;

/// <summary>A collection of individual counters a GPU device supports for a counter set.</summary>
public class MTLCounterSet(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCounterSet>
{
    #region INativeObject
    public static new MTLCounterSet Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCounterSet New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying a counter set - Properties

    /// <summary>The name of the GPU’s counter set instance.</summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterSetBindings.Name);
    }
    #endregion

    #region Checking which counters a GPU supports - Properties

    /// <summary>An array of the counter instances a GPU device supports.</summary>
    public MTLCounter[] Counters
    {
        get => GetArrayProperty<MTLCounter>(MTLCounterSetBindings.Counters);
    }
    #endregion
}

file static class MTLCounterSetBindings
{
    public static readonly Selector Counters = "counters";

    public static readonly Selector Name = "name";
}
