using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLArrayType_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLArrayType
{
    public readonly nint NativePtr;

    public MTLArrayType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLArrayType o) => o.NativePtr;
    public static implicit operator MTLArrayType(nint ptr) => new MTLArrayType(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
