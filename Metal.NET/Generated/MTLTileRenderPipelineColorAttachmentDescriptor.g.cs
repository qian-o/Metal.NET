using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTileRenderPipelineColorAttachmentDescriptor_Selectors
{
    internal static readonly Selector setPixelFormat_ = Selector.Register("setPixelFormat:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLTileRenderPipelineColorAttachmentDescriptor
{
    public readonly nint NativePtr;

    public MTLTileRenderPipelineColorAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTileRenderPipelineColorAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLTileRenderPipelineColorAttachmentDescriptor(nint ptr) => new MTLTileRenderPipelineColorAttachmentDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptor");

    public static MTLTileRenderPipelineColorAttachmentDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLTileRenderPipelineColorAttachmentDescriptor(ptr);
    }

    public MTLTileRenderPipelineColorAttachmentDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLTileRenderPipelineColorAttachmentDescriptor(ptr);
    }

    public static MTLTileRenderPipelineColorAttachmentDescriptor New()
    {
        return Alloc().Init();
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptor_Selectors.setPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
