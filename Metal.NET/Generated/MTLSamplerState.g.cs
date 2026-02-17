using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLSamplerState_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLSamplerState
{
    public readonly nint NativePtr;

    public MTLSamplerState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLSamplerState o) => o.NativePtr;
    public static implicit operator MTLSamplerState(nint ptr) => new MTLSamplerState(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
