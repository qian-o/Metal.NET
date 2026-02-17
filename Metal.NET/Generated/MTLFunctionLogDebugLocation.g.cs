using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionLogDebugLocation_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFunctionLogDebugLocation
{
    public readonly nint NativePtr;

    public MTLFunctionLogDebugLocation(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionLogDebugLocation o) => o.NativePtr;
    public static implicit operator MTLFunctionLogDebugLocation(nint ptr) => new MTLFunctionLogDebugLocation(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
