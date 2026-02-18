namespace Metal.NET;

public class MTLSharedEventListener(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLSharedEventListener() : this(ObjectiveCRuntime.AllocInit(MTLSharedEventListenerSelector.Class))
    {
    }

    public nint DispatchQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventListenerSelector.DispatchQueue);
    }

    public static MTLSharedEventListener? SharedListener()
    {
        return GetNullableObject<MTLSharedEventListener>(ObjectiveCRuntime.MsgSendPtr(MTLSharedEventListenerSelector.Class, MTLSharedEventListenerSelector.SharedListener));
    }
}

file static class MTLSharedEventListenerSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public static readonly Selector DispatchQueue = Selector.Register("dispatchQueue");

    public static readonly Selector SharedListener = Selector.Register("sharedListener");
}
