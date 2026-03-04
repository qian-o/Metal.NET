namespace Metal.NET;

public class MTLSharedEventListener(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLSharedEventListener>
{
    #region INativeObject
    public static MTLSharedEventListener Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLSharedEventListener New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLSharedEventListener() : this(ObjectiveC.AllocInit(MTLSharedEventListenerBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public DispatchQueue DispatchQueue
    {
        get => GetProperty(ref field, MTLSharedEventListenerBindings.DispatchQueue);
    }

    public static MTLSharedEventListener SharedListener()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLSharedEventListenerBindings.Class, MTLSharedEventListenerBindings.SharedListener);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLSharedEventListenerBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLSharedEventListener");

    public static readonly Selector DispatchQueue = "dispatchQueue";

    public static readonly Selector SharedListener = "sharedListener";
}
