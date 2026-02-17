using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLObjectPayloadBinding_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLObjectPayloadBinding
{
    public readonly nint NativePtr;

    public MTLObjectPayloadBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLObjectPayloadBinding o) => o.NativePtr;
    public static implicit operator MTLObjectPayloadBinding(nint ptr) => new MTLObjectPayloadBinding(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
