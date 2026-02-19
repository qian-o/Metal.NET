namespace Metal.NET;

public class MTLSharedEventHandle(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
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
