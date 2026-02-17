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

    public MTLSharedEventHandle NewSharedEventHandle()
    {
        var result = new MTLSharedEventHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLSharedEventSelector.NewSharedEventHandle));

        return result;
    }

    public void NotifyListener(MTLSharedEventListener listener, uint value, int function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSharedEventSelector.NotifyListenerValueFunction, listener.NativePtr, (nint)value, function);
    }

    public void SetSignaledValue(uint signaledValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSharedEventSelector.SetSignaledValue, (nint)signaledValue);
    }

    public Bool8 WaitUntilSignaledValue(uint value, uint milliseconds)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLSharedEventSelector.WaitUntilSignaledValueMilliseconds, (nint)value, (nint)milliseconds) is not 0;

        return result;
    }

}

file class MTLSharedEventSelector
{
    public static readonly Selector NewSharedEventHandle = Selector.Register("newSharedEventHandle");
    public static readonly Selector NotifyListenerValueFunction = Selector.Register("notifyListener:value:function:");
    public static readonly Selector SetSignaledValue = Selector.Register("setSignaledValue:");
    public static readonly Selector WaitUntilSignaledValueMilliseconds = Selector.Register("waitUntilSignaledValue:milliseconds:");
}
