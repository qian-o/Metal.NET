using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPassColorAttachmentDescriptor_Selectors
{
    internal static readonly Selector setClearColor_ = Selector.Register("setClearColor:");
}

public class MTLRenderPassColorAttachmentDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPassColorAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPassColorAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLRenderPassColorAttachmentDescriptor(nint ptr) => new MTLRenderPassColorAttachmentDescriptor(ptr);

    ~MTLRenderPassColorAttachmentDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public static MTLRenderPassColorAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLRenderPassColorAttachmentDescriptor(ptr);
    }

    public void SetClearColor(MTLClearColor clearColor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassColorAttachmentDescriptor_Selectors.setClearColor_, clearColor);
    }

}
