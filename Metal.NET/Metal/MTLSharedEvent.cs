namespace Metal.NET;

public readonly struct MTLSharedEvent(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLSharedEventHandle? NewSharedEventHandle
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventBindings.NewSharedEventHandle);
            return ptr is not 0 ? new MTLSharedEventHandle(ptr) : default;
        }
    }

    public nuint SignaledValue
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSharedEventBindings.SignaledValue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventBindings.SetSignaledValue, value);
    }

    public bool WaitUntilSignaledValue(nuint value, nuint milliseconds)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSharedEventBindings.WaitUntilSignaledValue, value, milliseconds);
    }
}

file static class MTLSharedEventBindings
{
    public static readonly Selector NewSharedEventHandle = Selector.Register("newSharedEventHandle");

    public static readonly Selector SetSignaledValue = Selector.Register("setSignaledValue:");

    public static readonly Selector SignaledValue = Selector.Register("signaledValue");

    public static readonly Selector WaitUntilSignaledValue = Selector.Register("waitUntilSignaledValue:timeoutMS:");
}
