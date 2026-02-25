namespace Metal.NET;

public class MTLCounter(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCounter>
{
    public static MTLCounter Null => Create(0, false);
    public static MTLCounter Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
