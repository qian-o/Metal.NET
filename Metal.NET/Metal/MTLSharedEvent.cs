namespace Metal.NET;

public class MTLSharedEvent(nint nativePtr, bool retain) : MTLEvent(nativePtr, retain)
{
    public ulong SignaledValue
    {
        get => ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSharedEventBindings.SignaledValue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventBindings.SetSignaledValue, value);
    }

    public MTLSharedEventHandle? NewSharedEventHandle()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventBindings.NewSharedEventHandle);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public bool WaitUntilSignaledValue(ulong value, ulong milliseconds)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSharedEventBindings.WaitUntilSignaledValue, (nuint)value, (nuint)milliseconds);
    }
}

file static class MTLSharedEventBindings
{
    public static readonly Selector NewSharedEventHandle = "newSharedEventHandle";

    public static readonly Selector SetSignaledValue = "setSignaledValue:";

    public static readonly Selector SignaledValue = "signaledValue";

    public static readonly Selector WaitUntilSignaledValue = "waitUntilSignaledValue:timeoutMS:";
}
