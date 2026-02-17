using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPassDepthAttachmentDescriptor_Selectors
{
    internal static readonly Selector setClearDepth_ = Selector.Register("setClearDepth:");
    internal static readonly Selector setDepthResolveFilter_ = Selector.Register("setDepthResolveFilter:");
}

public class MTLRenderPassDepthAttachmentDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPassDepthAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPassDepthAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLRenderPassDepthAttachmentDescriptor(nint ptr) => new MTLRenderPassDepthAttachmentDescriptor(ptr);

    ~MTLRenderPassDepthAttachmentDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public static MTLRenderPassDepthAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLRenderPassDepthAttachmentDescriptor(ptr);
    }

    public void SetClearDepth(double clearDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptor_Selectors.setClearDepth_, clearDepth);
    }

    public void SetDepthResolveFilter(MTLMultisampleDepthResolveFilter depthResolveFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptor_Selectors.setDepthResolveFilter_, (nint)(uint)depthResolveFilter);
    }

}
