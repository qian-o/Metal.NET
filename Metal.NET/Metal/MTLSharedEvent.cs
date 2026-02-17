namespace Metal.NET;

public class MTLSharedEvent : IDisposable
{
    public MTLSharedEvent(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLSharedEvent()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLSharedEvent value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSharedEvent(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public nuint SignaledValue
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSharedEventSelector.SignaledValue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventSelector.SetSignaledValue, (nuint)value);
    }

    public MTLSharedEventHandle NewSharedEventHandle()
    {
        MTLSharedEventHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventSelector.NewSharedEventHandle));

        return result;
    }

    public void NotifyListener(MTLSharedEventListener listener, uint value, int function)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventSelector.NotifyListenerValueFunction, listener.NativePtr, (nuint)value, function);
    }

    public Bool8 WaitUntilSignaledValue(uint value, uint milliseconds)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSharedEventSelector.WaitUntilSignaledValueMilliseconds, (nuint)value, (nuint)milliseconds);

        return result;
    }

}

file class MTLSharedEventSelector
{
    public static readonly Selector SignaledValue = Selector.Register("signaledValue");

    public static readonly Selector SetSignaledValue = Selector.Register("setSignaledValue:");

    public static readonly Selector NewSharedEventHandle = Selector.Register("newSharedEventHandle");

    public static readonly Selector NotifyListenerValueFunction = Selector.Register("notifyListener:value:function:");

    public static readonly Selector WaitUntilSignaledValueMilliseconds = Selector.Register("waitUntilSignaledValue:milliseconds:");
}
