using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTextureBinding_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLTextureBinding
{
    public readonly nint NativePtr;

    public MTLTextureBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTextureBinding o) => o.NativePtr;
    public static implicit operator MTLTextureBinding(nint ptr) => new MTLTextureBinding(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
