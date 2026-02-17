using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBufferBinding_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLBufferBinding
{
    public readonly nint NativePtr;

    public MTLBufferBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBufferBinding o) => o.NativePtr;
    public static implicit operator MTLBufferBinding(nint ptr) => new MTLBufferBinding(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
