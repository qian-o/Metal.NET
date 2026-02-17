using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLType_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLType
{
    public readonly nint NativePtr;

    public MTLType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLType o) => o.NativePtr;
    public static implicit operator MTLType(nint ptr) => new MTLType(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
