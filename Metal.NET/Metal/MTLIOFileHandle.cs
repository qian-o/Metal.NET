namespace Metal.NET;

public partial class MTLIOFileHandle : NativeObject
{
    public MTLIOFileHandle(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOFileHandleSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOFileHandleSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLIOFileHandleSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
