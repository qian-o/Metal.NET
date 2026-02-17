using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResourceStatePassDescriptor_Selectors
{
    internal static readonly Selector resourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLResourceStatePassDescriptor
{
    public readonly nint NativePtr;

    public MTLResourceStatePassDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResourceStatePassDescriptor o) => o.NativePtr;
    public static implicit operator MTLResourceStatePassDescriptor(nint ptr) => new MTLResourceStatePassDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLResourceStatePassDescriptor_Selectors.resourceStatePassDescriptor);
        return new MTLResourceStatePassDescriptor(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
