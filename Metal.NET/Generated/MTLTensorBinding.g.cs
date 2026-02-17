using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTensorBinding_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLTensorBinding
{
    public readonly nint NativePtr;

    public MTLTensorBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTensorBinding o) => o.NativePtr;
    public static implicit operator MTLTensorBinding(nint ptr) => new MTLTensorBinding(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
