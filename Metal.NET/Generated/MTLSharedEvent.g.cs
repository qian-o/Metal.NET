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

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLSharedEvent
{
    public readonly nint NativePtr;

    public MTLSharedEvent(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLSharedEvent o) => o.NativePtr;
    public static implicit operator MTLSharedEvent(nint ptr) => new MTLSharedEvent(ptr);

    public MTLSharedEventHandle NewSharedEventHandle()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLSharedEvent_Selectors.newSharedEventHandle);
        return new MTLSharedEventHandle(__result);
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
        return (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLSharedEvent_Selectors.waitUntilSignaledValue_milliseconds_, (nint)value, (nint)milliseconds) != 0;
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
