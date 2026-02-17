using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPackedFloatQuaternion_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLPackedFloatQuaternion
{
    public readonly nint NativePtr;

    public MTLPackedFloatQuaternion(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPackedFloatQuaternion o) => o.NativePtr;
    public static implicit operator MTLPackedFloatQuaternion(nint ptr) => new MTLPackedFloatQuaternion(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
