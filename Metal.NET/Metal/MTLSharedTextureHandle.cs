namespace Metal.NET;

public readonly struct MTLSharedTextureHandle(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedTextureHandleBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedTextureHandleBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTLSharedTextureHandleBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");
}
