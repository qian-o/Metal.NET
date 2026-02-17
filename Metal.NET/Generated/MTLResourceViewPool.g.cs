using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResourceViewPool_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLResourceViewPool
{
    public readonly nint NativePtr;

    public MTLResourceViewPool(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResourceViewPool o) => o.NativePtr;
    public static implicit operator MTLResourceViewPool(nint ptr) => new MTLResourceViewPool(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
