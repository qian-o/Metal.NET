namespace Metal.NET;

file class MTLSharedEventSelector
{
    public static readonly Selector NewSharedEventHandle = Selector.Register("newSharedEventHandle");
    public static readonly Selector NotifyListener_value_function_ = Selector.Register("notifyListener:value:function:");
    public static readonly Selector SetSignaledValue_ = Selector.Register("setSignaledValue:");
    public static readonly Selector WaitUntilSignaledValue_milliseconds_ = Selector.Register("waitUntilSignaledValue:milliseconds:");
}

public class MTLSharedEvent : IDisposable
{
    public MTLSharedEvent(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void NotifyListener(MTLSharedEventListener listener, nuint value, nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSharedEventSelector.NotifyListener_value_function_, listener.NativePtr, (nint)value, function);
    }

    public void SetSignaledValue(nuint signaledValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSharedEventSelector.SetSignaledValue_, (nint)signaledValue);
    }

    public Bool8 WaitUntilSignaledValue(nuint value, nuint milliseconds)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLSharedEventSelector.WaitUntilSignaledValue_milliseconds_, (nint)value, (nint)milliseconds) is not 0;

        return result;
    }

}
