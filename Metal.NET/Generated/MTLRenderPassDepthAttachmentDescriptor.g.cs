using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPassDepthAttachmentDescriptor_Selectors
{
    internal static readonly Selector setClearDepth_ = Selector.Register("setClearDepth:");
    internal static readonly Selector setDepthResolveFilter_ = Selector.Register("setDepthResolveFilter:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLRenderPassDepthAttachmentDescriptor
{
    public readonly nint NativePtr;

    public MTLRenderPassDepthAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPassDepthAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLRenderPassDepthAttachmentDescriptor(nint ptr) => new MTLRenderPassDepthAttachmentDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public static MTLRenderPassDepthAttachmentDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLRenderPassDepthAttachmentDescriptor(ptr);
    }

    public MTLRenderPassDepthAttachmentDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLRenderPassDepthAttachmentDescriptor(ptr);
    }

    public static MTLRenderPassDepthAttachmentDescriptor New()
    {
        return Alloc().Init();
    }

    public void SetClearDepth(double clearDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptor_Selectors.setClearDepth_, clearDepth);
    }

    public void SetDepthResolveFilter(MTLMultisampleDepthResolveFilter depthResolveFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptor_Selectors.setDepthResolveFilter_, (nint)(uint)depthResolveFilter);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
