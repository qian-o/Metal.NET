namespace Metal.NET;

public class MTLFence(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty<MTLDevice>(ref field, MTLFenceBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLFenceBindings.Label);
        set => SetProperty(ref field, MTLFenceBindings.SetLabel, value);
    }
}

file static class MTLFenceBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
