using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTextureReferenceType_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLTextureReferenceType
{
    public readonly nint NativePtr;

    public MTLTextureReferenceType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTextureReferenceType o) => o.NativePtr;
    public static implicit operator MTLTextureReferenceType(nint ptr) => new MTLTextureReferenceType(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
