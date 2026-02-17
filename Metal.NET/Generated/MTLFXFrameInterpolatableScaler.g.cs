using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXFrameInterpolatableScaler_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFXFrameInterpolatableScaler
{
    public readonly nint NativePtr;

    public MTLFXFrameInterpolatableScaler(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXFrameInterpolatableScaler o) => o.NativePtr;
    public static implicit operator MTLFXFrameInterpolatableScaler(nint ptr) => new MTLFXFrameInterpolatableScaler(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
