namespace Metal.NET;

public class MTLSharedEvent(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLSharedEventHandle? NewSharedEventHandle
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventBindings.NewSharedEventHandle);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLSharedEventHandle(ptr);
            }

            return field;
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
