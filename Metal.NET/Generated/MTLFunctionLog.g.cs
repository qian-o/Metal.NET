using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionLog_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFunctionLog
{
    public readonly nint NativePtr;

    public MTLFunctionLog(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionLog o) => o.NativePtr;
    public static implicit operator MTLFunctionLog(nint ptr) => new MTLFunctionLog(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
