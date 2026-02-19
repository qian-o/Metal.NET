namespace Metal.NET;

public readonly struct MTLSharedEventListener(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLSharedEventListener() : this(ObjectiveCRuntime.AllocInit(MTLSharedEventListenerBindings.Class))
    {
    }

    public nint DispatchQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventListenerBindings.DispatchQueue);
    }

    public static MTLSharedEventListener? SharedListener()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLSharedEventListenerBindings.Class, MTLSharedEventListenerBindings.SharedListener);
        return ptr is not 0 ? new MTLSharedEventListener(ptr) : default;
    }
}

file static class MTLSharedEventListenerBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public static readonly Selector DispatchQueue = Selector.Register("dispatchQueue");

    public static readonly Selector SharedListener = Selector.Register("sharedListener");
}
