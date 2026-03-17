namespace Metal.NET;

/// <summary>
/// An individual counter a GPU device lists within one of its counter sets.
/// </summary>
public class MTLCounter(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCounter>
{
    #region INativeObject
    public static new MTLCounter Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCounter New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying a counter - Properties

    /// <summary>
    /// The name of a GPU’s counter instance.
    /// </summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }
    #endregion
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
