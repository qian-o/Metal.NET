using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLogState_Selectors
{
    internal static readonly Selector addLogHandler_ = Selector.Register("addLogHandler:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLLogState
{
    public readonly nint NativePtr;

    public MTLLogState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLogState o) => o.NativePtr;
    public static implicit operator MTLLogState(nint ptr) => new MTLLogState(ptr);

    public void AddLogHandler(nint handler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogState_Selectors.addLogHandler_, handler);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
