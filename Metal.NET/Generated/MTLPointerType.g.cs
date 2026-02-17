using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPointerType_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLPointerType
{
    public readonly nint NativePtr;

    public MTLPointerType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPointerType o) => o.NativePtr;
    public static implicit operator MTLPointerType(nint ptr) => new MTLPointerType(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
