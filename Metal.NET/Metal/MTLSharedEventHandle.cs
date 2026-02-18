namespace Metal.NET;

public partial class MTLSharedEventHandle : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventHandle");

    public MTLSharedEventHandle(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventHandleSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLSharedEventHandleSelector
{
    public static readonly Selector Label = Selector.Register("label");
}
