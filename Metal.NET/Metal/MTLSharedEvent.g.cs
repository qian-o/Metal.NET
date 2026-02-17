using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLSharedEvent_Selectors
{
    internal static readonly Selector newSharedEventHandle = Selector.Register("newSharedEventHandle");
    internal static readonly Selector notifyListener_value_function_ = Selector.Register("notifyListener:value:function:");
    internal static readonly Selector setSignaledValue_ = Selector.Register("setSignaledValue:");
    internal static readonly Selector waitUntilSignaledValue_milliseconds_ = Selector.Register("waitUntilSignaledValue:milliseconds:");
}

public class MTLSharedEvent : IDisposable
{
    public nint NativePtr { get; }

    public MTLSharedEvent(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLSharedEvent o) => o.NativePtr;
    public static implicit operator MTLSharedEvent(nint ptr) => new MTLSharedEvent(ptr);

    ~MTLSharedEvent() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public MTLSharedEventHandle NewSharedEventHandle()
    {
        var __r = new MTLSharedEventHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLSharedEvent_Selectors.newSharedEventHandle));
        return __r;
    }

    public void NotifyListener(MTLSharedEventListener listener, nuint value, nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSharedEvent_Selectors.notifyListener_value_function_, listener.NativePtr, (nint)value, function);
    }

    public void SetSignaledValue(nuint signaledValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSharedEvent_Selectors.setSignaledValue_, (nint)signaledValue);
    }

    public Bool8 WaitUntilSignaledValue(nuint value, nuint milliseconds)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLSharedEvent_Selectors.waitUntilSignaledValue_milliseconds_, (nint)value, (nint)milliseconds) != 0;
        return __r;
    }

}
