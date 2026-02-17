using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPassStencilAttachmentDescriptor_Selectors
{
    internal static readonly Selector setClearStencil_ = Selector.Register("setClearStencil:");
    internal static readonly Selector setStencilResolveFilter_ = Selector.Register("setStencilResolveFilter:");
}

public class MTLRenderPassStencilAttachmentDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPassStencilAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPassStencilAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLRenderPassStencilAttachmentDescriptor(nint ptr) => new MTLRenderPassStencilAttachmentDescriptor(ptr);

    ~MTLRenderPassStencilAttachmentDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassStencilAttachmentDescriptor");

    public static MTLRenderPassStencilAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLRenderPassStencilAttachmentDescriptor(ptr);
    }

    public void SetClearStencil(uint clearStencil)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptor_Selectors.setClearStencil_, (nint)clearStencil);
    }

    public void SetStencilResolveFilter(MTLMultisampleStencilResolveFilter stencilResolveFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptor_Selectors.setStencilResolveFilter_, (nint)(uint)stencilResolveFilter);
    }

}
