namespace Metal.NET;

public class MTLIOFileHandle(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLIOFileHandle>
{
    public static MTLIOFileHandle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLIOFileHandle Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

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
