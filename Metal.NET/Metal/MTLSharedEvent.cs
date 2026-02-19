namespace Metal.NET;

public class MTLSharedEvent(nint nativePtr) : MTLEvent(nativePtr)
{
    public MTLSharedEventHandle? NewSharedEventHandle
    {
        get => GetProperty(ref field, MTLSharedEventBindings.NewSharedEventHandle);
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
    public static readonly Selector NewSharedEventHandle = "newSharedEventHandle";

    public static readonly Selector SetSignaledValue = "setSignaledValue:";

    public static readonly Selector SignaledValue = "signaledValue";

    public static readonly Selector WaitUntilSignaledValue = "waitUntilSignaledValue:timeoutMS:";
}
