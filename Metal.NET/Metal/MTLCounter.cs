namespace Metal.NET;

public class MTLCounter(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCounter>
{
    public static MTLCounter Create(nint nativePtr) => new(nativePtr);

    public static MTLCounter CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
