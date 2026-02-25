namespace Metal.NET;

public class MTLIOFileHandle(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLIOFileHandle>
{
    public static MTLIOFileHandle Create(nint nativePtr) => new(nativePtr);

    public static MTLIOFileHandle CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

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
