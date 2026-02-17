using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLComputePipelineReflection_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLComputePipelineReflection
{
    public readonly nint NativePtr;

    public MTLComputePipelineReflection(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLComputePipelineReflection o) => o.NativePtr;
    public static implicit operator MTLComputePipelineReflection(nint ptr) => new MTLComputePipelineReflection(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
