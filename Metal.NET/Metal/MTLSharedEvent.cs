namespace Metal.NET;

public class MTLSharedEvent(nint nativePtr) : MTLEvent(nativePtr)
{
    public nuint SignaledValue
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSharedEventSelector.SignaledValue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventSelector.SetSignaledValue, value);
    }

    public static implicit operator nint(MTLSharedEvent value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSharedEvent(nint value)
    {
        return new(value);
    }

    public MTLSharedEventHandle NewSharedEventHandle()
    {
        MTLSharedEventHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventSelector.NewSharedEventHandle));

        return result;
    }

    public Bool8 WaitUntilSignaledValue(nuint value, nuint milliseconds)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSharedEventSelector.WaitUntilSignaledValueTimeoutMS, value, milliseconds);

        return result;
    }
}

file class MTLSharedEventSelector
{
    public static readonly Selector SignaledValue = Selector.Register("signaledValue");

    public static readonly Selector SetSignaledValue = Selector.Register("setSignaledValue:");

    public static readonly Selector NewSharedEventHandle = Selector.Register("newSharedEventHandle");

    public static readonly Selector WaitUntilSignaledValueTimeoutMS = Selector.Register("waitUntilSignaledValue:timeoutMS:");
}
