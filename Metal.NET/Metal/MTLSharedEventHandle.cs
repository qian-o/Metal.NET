namespace Metal.NET;

public class MTLSharedEventHandle(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership)
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
