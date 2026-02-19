namespace Metal.NET;

public class MTLSharedEventHandle(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public NSString? Label
    {
        get => GetProperty(ref field, MTLSharedEventHandleBindings.Label);
    }
}

file static class MTLSharedEventHandleBindings
{
    public static readonly Selector Label = "label";
}
