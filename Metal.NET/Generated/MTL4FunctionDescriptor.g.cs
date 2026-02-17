using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4FunctionDescriptor_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4FunctionDescriptor
{
    public readonly nint NativePtr;

    public MTL4FunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4FunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTL4FunctionDescriptor(nint ptr) => new MTL4FunctionDescriptor(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
