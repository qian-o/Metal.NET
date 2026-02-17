using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLThreadgroupBinding_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLThreadgroupBinding
{
    public readonly nint NativePtr;

    public MTLThreadgroupBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLThreadgroupBinding o) => o.NativePtr;
    public static implicit operator MTLThreadgroupBinding(nint ptr) => new MTLThreadgroupBinding(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
