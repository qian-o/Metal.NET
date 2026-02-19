namespace Metal.NET;

public readonly struct MTLSharedEventHandle(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventHandleBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTLSharedEventHandleBindings
{
    public static readonly Selector Label = Selector.Register("label");
}
