namespace Metal.NET;

public class MTLSharedEvent(nint nativePtr, NativeObjectOwnership ownership) : MTLEvent(nativePtr, ownership), INativeObject<MTLSharedEvent>
{
    #region INativeObject
    public static new MTLSharedEvent Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSharedEvent New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public ulong SignaledValue
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLSharedEventBindings.SignaledValue);
        set => ObjectiveC.MsgSend(NativePtr, MTLSharedEventBindings.SetSignaledValue, value);
    }

    public MTLSharedEventHandle NewSharedEventHandle()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLSharedEventBindings.NewSharedEventHandle);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void NotifyListener(MTLSharedEventListener listener, ulong value, MTLSharedEventNotificationBlock block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSharedEventBindings.NotifyListener, listener.NativePtr, (nuint)value, block);
    }

    public bool WaitUntilSignaledValue(ulong value, ulong milliseconds)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLSharedEventBindings.WaitUntilSignaledValue, (nuint)value, (nuint)milliseconds);
    }
}

file static class MTLSharedEventBindings
{
    public static readonly Selector NewSharedEventHandle = "newSharedEventHandle";

    public static readonly Selector NotifyListener = "notifyListener:atValue:block:";

    public static readonly Selector SetSignaledValue = "setSignaledValue:";

    public static readonly Selector SignaledValue = "signaledValue";

    public static readonly Selector WaitUntilSignaledValue = "waitUntilSignaledValue:timeoutMS:";
}
