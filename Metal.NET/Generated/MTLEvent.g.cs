using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLEvent_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLEvent
{
    public readonly nint NativePtr;

    public MTLEvent(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLEvent o) => o.NativePtr;
    public static implicit operator MTLEvent(nint ptr) => new MTLEvent(ptr);

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLEvent_Selectors.setLabel_, label.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
