using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBinaryArchiveDescriptor_Selectors
{
    internal static readonly Selector setUrl_ = Selector.Register("setUrl:");
}

public class MTLBinaryArchiveDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLBinaryArchiveDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBinaryArchiveDescriptor o) => o.NativePtr;
    public static implicit operator MTLBinaryArchiveDescriptor(nint ptr) => new MTLBinaryArchiveDescriptor(ptr);

    ~MTLBinaryArchiveDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLBinaryArchiveDescriptor");

    public static MTLBinaryArchiveDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLBinaryArchiveDescriptor(ptr);
    }

    public void SetUrl(NSURL url)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBinaryArchiveDescriptor_Selectors.setUrl_, url.NativePtr);
    }

}
