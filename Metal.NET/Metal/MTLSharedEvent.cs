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

    public nuint SignaledValue
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSharedEventSelector.SignaledValue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventSelector.SetSignaledValue, value);
    }

    public MTLSharedEventHandle NewSharedEventHandle()
    {
        MTLSharedEventHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventSelector.NewSharedEventHandle));

        return result;
    }

    public void NotifyListener(MTLSharedEventListener listener, nuint value, nint function)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventSelector.NotifyListenerValueFunction, listener.NativePtr, value, function);
    }

    public Bool8 WaitUntilSignaledValue(nuint value, nuint milliseconds)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSharedEventSelector.WaitUntilSignaledValueMilliseconds, value, milliseconds);

        return result;
    }

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
}

file class MTLSharedEventSelector
{
    public static readonly Selector SignaledValue = Selector.Register("signaledValue");

    public static readonly Selector SetSignaledValue = Selector.Register("setSignaledValue:");

    public static readonly Selector NewSharedEventHandle = Selector.Register("newSharedEventHandle");

    public static readonly Selector NotifyListenerValueFunction = Selector.Register("notifyListener:value:function:");

    public static readonly Selector WaitUntilSignaledValueMilliseconds = Selector.Register("waitUntilSignaledValue:milliseconds:");
}
