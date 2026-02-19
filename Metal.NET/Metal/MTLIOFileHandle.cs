namespace Metal.NET;

public class MTLIOFileHandle(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public NSString? Label
    {
        get => GetProperty(ref field, MTLIOFileHandleBindings.Label);
        set => SetProperty(ref field, MTLIOFileHandleBindings.SetLabel, value);
    }
}

file static class MTLIOFileHandleBindings
{
    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
