namespace Metal.NET;

public class MTLSharedEventListener(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLSharedEventListener>
{
    public static MTLSharedEventListener Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLSharedEventListener Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLSharedEventListener() : this(ObjectiveCRuntime.AllocInit(MTLSharedEventListenerBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nint DispatchQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventListenerBindings.DispatchQueue);
    }

    public static MTLSharedEventListener SharedListener()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLSharedEventListenerBindings.Class, MTLSharedEventListenerBindings.SharedListener);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLSharedEventListenerBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public static readonly Selector DispatchQueue = "dispatchQueue";

    public static readonly Selector SharedListener = "sharedListener";
}
