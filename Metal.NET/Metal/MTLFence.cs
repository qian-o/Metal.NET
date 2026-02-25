namespace Metal.NET;

public class MTLFence(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFence>
{
    public static MTLFence Create(nint nativePtr) => new(nativePtr, true);

    public static MTLFence CreateBorrowed(nint nativePtr) => new(nativePtr, false);

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
