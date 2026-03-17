namespace Metal.NET;

/// <summary>
/// A listener for shareable event notifications.
/// </summary>
public class MTLSharedEventListener(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLSharedEventListener>
{
    #region INativeObject
    public static new MTLSharedEventListener Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSharedEventListener New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLSharedEventListener() : this(ObjectiveC.AllocInit(MTLSharedEventListenerBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Getting the dispatch queue - Properties

    /// <summary>
    /// The dispatch queue used to dispatch any notifications.
    /// </summary>
    public DispatchQueue DispatchQueue
    {
        get => GetProperty(ref field, MTLSharedEventListenerBindings.DispatchQueue);
    }
    #endregion

    #region Type Methods - Methods

    public static MTLSharedEventListener SharedListener()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLSharedEventListenerBindings.Class, MTLSharedEventListenerBindings.SharedListener);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTLSharedEventListenerBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLSharedEventListener");

    public static readonly Selector DispatchQueue = "dispatchQueue";

    public static readonly Selector SharedListener = "sharedListener";
}
