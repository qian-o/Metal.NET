namespace Metal.NET;

public class MTLEvent(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLEvent>
{
    #region INativeObject
    public static MTLEvent Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLEvent New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLEventBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLEventBindings.Label);
        set => SetProperty(ref field, MTLEventBindings.SetLabel, value);
    }
}

file static class MTLEventBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
