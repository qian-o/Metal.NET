namespace Metal.NET;

public class MTLSharedTextureHandle(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference)
{
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLSharedTextureHandleBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLSharedTextureHandleBindings.Label);
    }
}

file static class MTLSharedTextureHandleBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";
}
