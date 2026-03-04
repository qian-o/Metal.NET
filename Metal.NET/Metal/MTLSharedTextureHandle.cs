namespace Metal.NET;

public class MTLSharedTextureHandle(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLSharedTextureHandle>
{
    #region INativeObject
    public static MTLSharedTextureHandle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLSharedTextureHandle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

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
