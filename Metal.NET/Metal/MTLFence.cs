namespace Metal.NET;

public class MTLFence(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLFence>
{
    public static MTLFence Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFence Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFenceBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLFenceBindings.Label);
        set => SetProperty(ref field, MTLFenceBindings.SetLabel, value);
    }
}

file static class MTLFenceBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
