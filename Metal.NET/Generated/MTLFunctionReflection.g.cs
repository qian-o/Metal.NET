using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionReflection_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFunctionReflection
{
    public readonly nint NativePtr;

    public MTLFunctionReflection(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionReflection o) => o.NativePtr;
    public static implicit operator MTLFunctionReflection(nint ptr) => new MTLFunctionReflection(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
