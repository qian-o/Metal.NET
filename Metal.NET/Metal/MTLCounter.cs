namespace Metal.NET;

public class MTLCounter(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
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
