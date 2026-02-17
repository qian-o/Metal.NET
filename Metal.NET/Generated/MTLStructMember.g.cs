using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLStructMember_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLStructMember
{
    public readonly nint NativePtr;

    public MTLStructMember(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLStructMember o) => o.NativePtr;
    public static implicit operator MTLStructMember(nint ptr) => new MTLStructMember(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
