namespace Metal.NET;

file class MTL4RenderPassDescriptorSelector
{
    public static readonly Selector SetDefaultRasterSampleCount_ = Selector.Register("setDefaultRasterSampleCount:");
    public static readonly Selector SetDepthAttachment_ = Selector.Register("setDepthAttachment:");
    public static readonly Selector SetImageblockSampleLength_ = Selector.Register("setImageblockSampleLength:");
    public static readonly Selector SetRasterizationRateMap_ = Selector.Register("setRasterizationRateMap:");
    public static readonly Selector SetRenderTargetArrayLength_ = Selector.Register("setRenderTargetArrayLength:");
    public static readonly Selector SetRenderTargetHeight_ = Selector.Register("setRenderTargetHeight:");
    public static readonly Selector SetRenderTargetWidth_ = Selector.Register("setRenderTargetWidth:");
    public static readonly Selector SetStencilAttachment_ = Selector.Register("setStencilAttachment:");
    public static readonly Selector SetSupportColorAttachmentMapping_ = Selector.Register("setSupportColorAttachmentMapping:");
    public static readonly Selector SetThreadgroupMemoryLength_ = Selector.Register("setThreadgroupMemoryLength:");
    public static readonly Selector SetTileHeight_ = Selector.Register("setTileHeight:");
    public static readonly Selector SetTileWidth_ = Selector.Register("setTileWidth:");
    public static readonly Selector SetVisibilityResultBuffer_ = Selector.Register("setVisibilityResultBuffer:");
    public static readonly Selector SetVisibilityResultType_ = Selector.Register("setVisibilityResultType:");
}

public class MTL4RenderPassDescriptor : IDisposable
{
    public MTL4RenderPassDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4RenderPassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4RenderPassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4RenderPassDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetDefaultRasterSampleCount_, (nint)defaultRasterSampleCount);
    }

    public void SetDepthAttachment(MTLRenderPassDepthAttachmentDescriptor depthAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetDepthAttachment_, depthAttachment.NativePtr);
    }

    public void SetImageblockSampleLength(nuint imageblockSampleLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetImageblockSampleLength_, (nint)imageblockSampleLength);
    }

    public void SetRasterizationRateMap(MTLRasterizationRateMap rasterizationRateMap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRasterizationRateMap_, rasterizationRateMap.NativePtr);
    }

    public void SetRenderTargetArrayLength(nuint renderTargetArrayLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetArrayLength_, (nint)renderTargetArrayLength);
    }

    public void SetRenderTargetHeight(nuint renderTargetHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetHeight_, (nint)renderTargetHeight);
    }

    public void SetRenderTargetWidth(nuint renderTargetWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetWidth_, (nint)renderTargetWidth);
    }

    public void SetStencilAttachment(MTLRenderPassStencilAttachmentDescriptor stencilAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetStencilAttachment_, stencilAttachment.NativePtr);
    }

    public void SetSupportColorAttachmentMapping(Bool8 supportColorAttachmentMapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetSupportColorAttachmentMapping_, (nint)supportColorAttachmentMapping.Value);
    }

    public void SetThreadgroupMemoryLength(nuint threadgroupMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetThreadgroupMemoryLength_, (nint)threadgroupMemoryLength);
    }

    public void SetTileHeight(nuint tileHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetTileHeight_, (nint)tileHeight);
    }

    public void SetTileWidth(nuint tileWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetTileWidth_, (nint)tileWidth);
    }

    public void SetVisibilityResultBuffer(MTLBuffer visibilityResultBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetVisibilityResultBuffer_, visibilityResultBuffer.NativePtr);
    }

    public void SetVisibilityResultType(MTLVisibilityResultType visibilityResultType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetVisibilityResultType_, (nint)(uint)visibilityResultType);
    }

}
