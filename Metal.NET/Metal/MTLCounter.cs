namespace Metal.NET;

public class MTLCounter(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCounter>
{
    public static MTLCounter Create(nint nativePtr) => new(nativePtr, true);

    public static MTLCounter CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
