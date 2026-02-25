namespace Metal.NET;

public class MTLSharedEventHandle(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference)
{
    public NSString Label
    {
        get => GetProperty(ref field, MTLSharedEventHandleBindings.Label);
    }
}

file static class MTLSharedEventHandleBindings
{
    public static readonly Selector Label = "label";
}
