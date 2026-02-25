namespace Metal.NET;

public class MTLIOFileHandle(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLIOFileHandle>
{
    public static MTLIOFileHandle Null => Create(0, false);
    public static MTLIOFileHandle Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public NSString Label
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
