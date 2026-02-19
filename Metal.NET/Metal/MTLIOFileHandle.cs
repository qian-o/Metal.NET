namespace Metal.NET;

public readonly struct MTLIOFileHandle(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOFileHandleBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOFileHandleBindings.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLIOFileHandleBindings
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
