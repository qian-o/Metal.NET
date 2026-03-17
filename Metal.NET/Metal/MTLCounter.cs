namespace Metal.NET;

public class MTLCounter(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCounter>
{
    #region INativeObject
    public static new MTLCounter Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCounter New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
