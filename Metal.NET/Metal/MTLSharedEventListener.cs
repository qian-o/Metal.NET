namespace Metal.NET;

public partial class MTLSharedEventListener : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public MTLSharedEventListener(nint nativePtr) : base(nativePtr)
    {
    }

    public nint DispatchQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventListenerSelector.DispatchQueue);
    }

    public static MTLSharedEventListener? SharedListener()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLSharedEventListenerSelector.SharedListener);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLSharedEventListenerSelector
{
    public static readonly Selector DispatchQueue = Selector.Register("dispatchQueue");

    public static readonly Selector SharedListener = Selector.Register("sharedListener");
}
