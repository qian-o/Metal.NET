using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAllocation_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLAllocation
{
    public readonly nint NativePtr;

    public MTLAllocation(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAllocation o) => o.NativePtr;
    public static implicit operator MTLAllocation(nint ptr) => new MTLAllocation(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
