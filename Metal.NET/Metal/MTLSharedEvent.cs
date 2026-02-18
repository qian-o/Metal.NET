namespace Metal.NET;

public partial class MTLSharedEvent : NativeObject
{
    public MTLSharedEvent(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLSharedEventHandle? NewSharedEventHandle
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventSelector.NewSharedEventHandle);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint SignaledValue
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSharedEventSelector.SignaledValue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventSelector.SetSignaledValue, value);
    }

    public bool WaitUntilSignaledValue(nuint value, nuint milliseconds)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSharedEventSelector.WaitUntilSignaledValue, value, milliseconds);
    }
}

file static class MTLSharedEventSelector
{
    public static readonly Selector NewSharedEventHandle = Selector.Register("newSharedEventHandle");

    public static readonly Selector SetSignaledValue = Selector.Register("setSignaledValue:");

    public static readonly Selector SignaledValue = Selector.Register("signaledValue");

    public static readonly Selector WaitUntilSignaledValue = Selector.Register("waitUntilSignaledValue:timeoutMS:");
}
