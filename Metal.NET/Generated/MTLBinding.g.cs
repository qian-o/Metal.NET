using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBinding_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLBinding
{
    public readonly nint NativePtr;

    public MTLBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBinding o) => o.NativePtr;
    public static implicit operator MTLBinding(nint ptr) => new MTLBinding(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
