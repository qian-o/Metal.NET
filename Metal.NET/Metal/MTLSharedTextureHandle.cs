namespace Metal.NET;

public partial class MTLSharedTextureHandle : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedTextureHandle");

    public MTLSharedTextureHandle(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedTextureHandleSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedTextureHandleSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLSharedTextureHandleSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");
}
