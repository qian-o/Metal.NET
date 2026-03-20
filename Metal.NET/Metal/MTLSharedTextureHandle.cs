namespace Metal.NET;

public partial class MTLSharedTextureHandle(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLSharedTextureHandle>
{
    #region INativeObject
    public static new MTLSharedTextureHandle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSharedTextureHandle New(nint nativePtr, NativeObjectOwnership ownership)
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
