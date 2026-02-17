using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPassColorAttachmentDescriptor_Selectors
{
    internal static readonly Selector setClearColor_ = Selector.Register("setClearColor:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLRenderPassColorAttachmentDescriptor
{
    public readonly nint NativePtr;

    public MTLRenderPassColorAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPassColorAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLRenderPassColorAttachmentDescriptor(nint ptr) => new MTLRenderPassColorAttachmentDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public static MTLRenderPassColorAttachmentDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLRenderPassColorAttachmentDescriptor(ptr);
    }

    public MTLRenderPassColorAttachmentDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLRenderPassColorAttachmentDescriptor(ptr);
    }

    public static MTLRenderPassColorAttachmentDescriptor New()
    {
        return Alloc().Init();
    }

    public void SetClearColor(MTLClearColor clearColor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassColorAttachmentDescriptor_Selectors.setClearColor_, clearColor);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
