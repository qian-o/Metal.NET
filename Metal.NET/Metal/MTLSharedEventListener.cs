namespace Metal.NET;

public class MTLSharedEventListener(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLSharedEventListener() : this(ObjectiveCRuntime.AllocInit(MTLSharedEventListenerBindings.Class), true)
    {
    }

    public nint DispatchQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventListenerBindings.DispatchQueue);
    }

    public static MTLSharedEventListener? SharedListener()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLSharedEventListenerBindings.Class, MTLSharedEventListenerBindings.SharedListener);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }
}

file static class MTLSharedEventListenerBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public static readonly Selector DispatchQueue = "dispatchQueue";

    public static readonly Selector SharedListener = "sharedListener";
}
