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

    public void Notify(MTLSharedEventListener listener, ulong value, MTLSharedEventNotificationBlock block)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSharedEventBindings.Notify, listener.NativePtr, value, block.NativePtr);
    }

    public MTLSharedEventHandle MakeSharedEventHandle()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLSharedEventBindings.MakeSharedEventHandle);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool Wait(ulong value, ulong milliseconds)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLSharedEventBindings.Wait, value, milliseconds);
    }
}

file static class MTLSharedEventBindings
{
    public static readonly Selector MakeSharedEventHandle = "newSharedEventHandle";

    public static readonly Selector Notify = "notifyListener:atValue:block:";

    public static readonly Selector SetSignaledValue = "setSignaledValue:";

    public static readonly Selector SignaledValue = "signaledValue";

    public static readonly Selector Wait = "waitUntilSignaledValue:timeoutMS:";
}
