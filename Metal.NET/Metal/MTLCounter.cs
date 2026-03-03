namespace Metal.NET;

public class MTLCounter(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLCounter>
{
    public static new MTLCounter Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCounter Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
