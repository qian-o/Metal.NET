namespace Metal.NET;

public class MTLIOFileHandle(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOFileHandle>
{
    #region INativeObject
    public static new MTLIOFileHandle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOFileHandle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLIOFileHandleBindings.Label);
        set => SetProperty(ref field, MTLIOFileHandleBindings.SetLabel, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLIOFileHandleBindings.Label);
        set => SetProperty(ref field, MTLIOFileHandleBindings.SetLabel, value);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOFileHandleBindings.SetLabel, label.NativePtr);
    }
}

file static class MTLIOFileHandleBindings
{
    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
