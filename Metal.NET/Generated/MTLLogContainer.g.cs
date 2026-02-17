using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLogContainer_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLLogContainer
{
    public readonly nint NativePtr;

    public MTLLogContainer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLogContainer o) => o.NativePtr;
    public static implicit operator MTLLogContainer(nint ptr) => new MTLLogContainer(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
