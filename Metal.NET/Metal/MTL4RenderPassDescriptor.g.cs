using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4RenderPassDescriptor_Selectors
{
    internal static readonly Selector setDefaultRasterSampleCount_ = Selector.Register("setDefaultRasterSampleCount:");
    internal static readonly Selector setDepthAttachment_ = Selector.Register("setDepthAttachment:");
    internal static readonly Selector setImageblockSampleLength_ = Selector.Register("setImageblockSampleLength:");
    internal static readonly Selector setRasterizationRateMap_ = Selector.Register("setRasterizationRateMap:");
    internal static readonly Selector setRenderTargetArrayLength_ = Selector.Register("setRenderTargetArrayLength:");
    internal static readonly Selector setRenderTargetHeight_ = Selector.Register("setRenderTargetHeight:");
    internal static readonly Selector setRenderTargetWidth_ = Selector.Register("setRenderTargetWidth:");
    internal static readonly Selector setStencilAttachment_ = Selector.Register("setStencilAttachment:");
    internal static readonly Selector setSupportColorAttachmentMapping_ = Selector.Register("setSupportColorAttachmentMapping:");
    internal static readonly Selector setThreadgroupMemoryLength_ = Selector.Register("setThreadgroupMemoryLength:");
    internal static readonly Selector setTileHeight_ = Selector.Register("setTileHeight:");
    internal static readonly Selector setTileWidth_ = Selector.Register("setTileWidth:");
    internal static readonly Selector setVisibilityResultBuffer_ = Selector.Register("setVisibilityResultBuffer:");
    internal static readonly Selector setVisibilityResultType_ = Selector.Register("setVisibilityResultType:");
}

public class MTL4RenderPassDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4RenderPassDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4RenderPassDescriptor o) => o.NativePtr;
    public static implicit operator MTL4RenderPassDescriptor(nint ptr) => new MTL4RenderPassDescriptor(ptr);

    ~MTL4RenderPassDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4RenderPassDescriptor");

    public static MTL4RenderPassDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTL4RenderPassDescriptor(ptr);
    }

    public void SetDefaultRasterSampleCount(nuint defaultRasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setDefaultRasterSampleCount_, (nint)defaultRasterSampleCount);
    }

    public void SetDepthAttachment(MTLRenderPassDepthAttachmentDescriptor depthAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setDepthAttachment_, depthAttachment.NativePtr);
    }

    public void SetImageblockSampleLength(nuint imageblockSampleLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setImageblockSampleLength_, (nint)imageblockSampleLength);
    }

    public void SetRasterizationRateMap(MTLRasterizationRateMap rasterizationRateMap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setRasterizationRateMap_, rasterizationRateMap.NativePtr);
    }

    public void SetRenderTargetArrayLength(nuint renderTargetArrayLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setRenderTargetArrayLength_, (nint)renderTargetArrayLength);
    }

    public void SetRenderTargetHeight(nuint renderTargetHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setRenderTargetHeight_, (nint)renderTargetHeight);
    }

    public void SetRenderTargetWidth(nuint renderTargetWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setRenderTargetWidth_, (nint)renderTargetWidth);
    }

    public void SetStencilAttachment(MTLRenderPassStencilAttachmentDescriptor stencilAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setStencilAttachment_, stencilAttachment.NativePtr);
    }

    public void SetSupportColorAttachmentMapping(Bool8 supportColorAttachmentMapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setSupportColorAttachmentMapping_, (nint)supportColorAttachmentMapping.Value);
    }

    public void SetThreadgroupMemoryLength(nuint threadgroupMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setThreadgroupMemoryLength_, (nint)threadgroupMemoryLength);
    }

    public void SetTileHeight(nuint tileHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setTileHeight_, (nint)tileHeight);
    }

    public void SetTileWidth(nuint tileWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setTileWidth_, (nint)tileWidth);
    }

    public void SetVisibilityResultBuffer(MTLBuffer visibilityResultBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setVisibilityResultBuffer_, visibilityResultBuffer.NativePtr);
    }

    public void SetVisibilityResultType(MTLVisibilityResultType visibilityResultType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptor_Selectors.setVisibilityResultType_, (nint)(uint)visibilityResultType);
    }

}
