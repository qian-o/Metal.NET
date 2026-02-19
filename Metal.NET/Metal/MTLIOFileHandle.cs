namespace Metal.NET;

public class MTLIOFileHandle(nint nativePtr) : NativeObject(nativePtr)
{
    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLIOFileHandleBindings.Label);
        set => SetProperty(ref field, MTLIOFileHandleBindings.SetLabel, value);
    }
}

file static class MTLIOFileHandleBindings
{
    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
