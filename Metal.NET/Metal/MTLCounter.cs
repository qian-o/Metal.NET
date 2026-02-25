namespace Metal.NET;

public class MTLCounter(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLCounter>
{
    public static MTLCounter Null { get; } = new(0, false);

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
