using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCounterSampleBuffer_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLCounterSampleBuffer
{
    public readonly nint NativePtr;

    public MTLCounterSampleBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCounterSampleBuffer o) => o.NativePtr;
    public static implicit operator MTLCounterSampleBuffer(nint ptr) => new MTLCounterSampleBuffer(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
