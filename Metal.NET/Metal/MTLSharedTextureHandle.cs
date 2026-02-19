namespace Metal.NET;

public class MTLSharedTextureHandle(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty<MTLDevice>(ref field, MTLSharedTextureHandleBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLSharedTextureHandleBindings.Label);
    }
}

file static class MTLSharedTextureHandleBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";
}
