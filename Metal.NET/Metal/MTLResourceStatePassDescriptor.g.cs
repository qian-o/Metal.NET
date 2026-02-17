using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResourceStatePassDescriptor_Selectors
{
    internal static readonly Selector resourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");
}

public class MTLResourceStatePassDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLResourceStatePassDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResourceStatePassDescriptor o) => o.NativePtr;
    public static implicit operator MTLResourceStatePassDescriptor(nint ptr) => new MTLResourceStatePassDescriptor(ptr);

    ~MTLResourceStatePassDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        var __r = new MTLResourceStatePassDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLResourceStatePassDescriptor_Selectors.resourceStatePassDescriptor));
        return __r;
    }

}
