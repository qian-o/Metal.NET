namespace Metal.NET;

public class MTLSharedEventListener(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLSharedEventListener>
{
    public static MTLSharedEventListener Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLSharedEventListener Null => Create(0, false);
    public static MTLSharedEventListener Empty => Null;

    public MTLSharedEventListener() : this(ObjectiveCRuntime.AllocInit(MTLSharedEventListenerBindings.Class), true)
    {
    }

    public nint DispatchQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventListenerBindings.DispatchQueue);
    }

    public static MTLSharedEventListener SharedListener()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLSharedEventListenerBindings.Class, MTLSharedEventListenerBindings.SharedListener);

        return new(nativePtr, false);
    }
}

file static class MTLSharedEventListenerBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public static readonly Selector DispatchQueue = "dispatchQueue";

    public static readonly Selector SharedListener = "sharedListener";
}
