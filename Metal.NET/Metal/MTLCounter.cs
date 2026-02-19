namespace Metal.NET;

public class MTLCounter(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public NSString? Name
    {
        get => GetProperty(ref field, MTLCounterBindings.Name);
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = "name";
}
