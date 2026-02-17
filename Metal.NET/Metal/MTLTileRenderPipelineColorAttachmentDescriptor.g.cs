using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTileRenderPipelineColorAttachmentDescriptor_Selectors
{
    internal static readonly Selector setPixelFormat_ = Selector.Register("setPixelFormat:");
}

public class MTLTileRenderPipelineColorAttachmentDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLTileRenderPipelineColorAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTileRenderPipelineColorAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLTileRenderPipelineColorAttachmentDescriptor(nint ptr) => new MTLTileRenderPipelineColorAttachmentDescriptor(ptr);

    ~MTLTileRenderPipelineColorAttachmentDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptor");

    public static MTLTileRenderPipelineColorAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLTileRenderPipelineColorAttachmentDescriptor(ptr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptor_Selectors.setPixelFormat_, (nint)(uint)pixelFormat);
    }

}
