using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPackedFloat4x3_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLPackedFloat4x3
{
    public readonly nint NativePtr;

    public MTLPackedFloat4x3(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPackedFloat4x3 o) => o.NativePtr;
    public static implicit operator MTLPackedFloat4x3(nint ptr) => new MTLPackedFloat4x3(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
