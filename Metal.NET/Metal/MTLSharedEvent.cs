namespace Metal.NET;

/// <summary>
/// A type that synchronizes memory operations to one or more resources across multiple CPUs, GPUs, and processes.
/// </summary>
public class MTLSharedEvent(nint nativePtr, NativeObjectOwnership ownership) : MTLEvent(nativePtr, ownership), INativeObject<MTLSharedEvent>
{
    #region INativeObject
    public static new MTLSharedEvent Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSharedEvent New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Synchronizing a shareable event - Properties

    /// <summary>
    /// The current signal value for the shareable event.
    /// </summary>
    public ulong SignaledValue
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLSharedEventBindings.SignaledValue);
        set => ObjectiveC.MsgSend(NativePtr, MTLSharedEventBindings.SetSignaledValue, value);
    }
    #endregion

    #region Synchronizing a shareable event - Methods

    /// <summary>
    /// Schedules a notification handler to be called after the shareable event’s signal value equals or exceeds a given value.
    /// </summary>
    public void NotifyListener(MTLSharedEventListener listener, ulong value, MTLSharedEventNotificationBlock block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSharedEventBindings.NotifyListener, listener.NativePtr, value, block.NativePtr);
    }
    #endregion

    #region Creating a shared event handle - Methods

    /// <summary>
    /// Creates a new shareable event handle.
    /// </summary>
    public MTLSharedEventHandle NewSharedEventHandle()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLSharedEventBindings.NewSharedEventHandle);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Instance Methods - Methods

    public bool WaitUntilSignaledValue(ulong value, ulong milliseconds)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLSharedEventBindings.WaitUntilSignaledValue, value, milliseconds);
    }
    #endregion
}

file static class MTLSharedEventBindings
{
    public static readonly Selector NewSharedEventHandle = "newSharedEventHandle";

    public static readonly Selector NotifyListener = "notifyListener:atValue:block:";

    public static readonly Selector SetSignaledValue = "setSignaledValue:";

    public static readonly Selector SignaledValue = "signaledValue";

    public static readonly Selector WaitUntilSignaledValue = "waitUntilSignaledValue:timeoutMS:";
}
