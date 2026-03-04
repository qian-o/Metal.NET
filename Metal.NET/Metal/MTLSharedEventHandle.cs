namespace Metal.NET;

public class MTLSharedEventHandle(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLSharedEventHandle>
{
    #region INativeObject
    public static MTLSharedEventHandle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLSharedEventHandle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLSharedEventHandleBindings.Label);
    }
}

file static class MTLSharedEventHandleBindings
{
    public static readonly Selector Label = "label";
}
