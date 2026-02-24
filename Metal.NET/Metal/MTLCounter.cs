namespace Metal.NET;

public class MTLCounter(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLCounter>
{
    public static MTLCounter Create(nint nativePtr) => new(nativePtr);

    public NSString Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
