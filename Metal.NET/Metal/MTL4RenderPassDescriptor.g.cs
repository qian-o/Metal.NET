namespace Metal.NET;

public class MTL4RenderPassDescriptor : IDisposable
{
    public MTL4RenderPassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetDefaultRasterSampleCount(uint defaultRasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetDefaultRasterSampleCount, (nint)defaultRasterSampleCount);
    }

    public void SetDepthAttachment(MTLRenderPassDepthAttachmentDescriptor depthAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetDepthAttachment, depthAttachment.NativePtr);
    }

    public void SetImageblockSampleLength(uint imageblockSampleLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetImageblockSampleLength, (nint)imageblockSampleLength);
    }

    public void SetRasterizationRateMap(MTLRasterizationRateMap rasterizationRateMap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRasterizationRateMap, rasterizationRateMap.NativePtr);
    }

    public void SetRenderTargetArrayLength(uint renderTargetArrayLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetArrayLength, (nint)renderTargetArrayLength);
    }

    public void SetRenderTargetHeight(uint renderTargetHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetHeight, (nint)renderTargetHeight);
    }

    public void SetRenderTargetWidth(uint renderTargetWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetWidth, (nint)renderTargetWidth);
    }

    public void SetStencilAttachment(MTLRenderPassStencilAttachmentDescriptor stencilAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetStencilAttachment, stencilAttachment.NativePtr);
    }

    public void SetSupportColorAttachmentMapping(Bool8 supportColorAttachmentMapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetSupportColorAttachmentMapping, (nint)supportColorAttachmentMapping.Value);
    }

    public void SetThreadgroupMemoryLength(uint threadgroupMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetThreadgroupMemoryLength, (nint)threadgroupMemoryLength);
    }

    public void SetTileHeight(uint tileHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetTileHeight, (nint)tileHeight);
    }

    public void SetTileWidth(uint tileWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetTileWidth, (nint)tileWidth);
    }

    public void SetVisibilityResultBuffer(MTLBuffer visibilityResultBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetVisibilityResultBuffer, visibilityResultBuffer.NativePtr);
    }

    public void SetVisibilityResultType(MTLVisibilityResultType visibilityResultType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetVisibilityResultType, (nint)(uint)visibilityResultType);
    }

}

file class MTL4RenderPassDescriptorSelector
{
    public static readonly Selector SetDefaultRasterSampleCount = Selector.Register("setDefaultRasterSampleCount:");
    public static readonly Selector SetDepthAttachment = Selector.Register("setDepthAttachment:");
    public static readonly Selector SetImageblockSampleLength = Selector.Register("setImageblockSampleLength:");
    public static readonly Selector SetRasterizationRateMap = Selector.Register("setRasterizationRateMap:");
    public static readonly Selector SetRenderTargetArrayLength = Selector.Register("setRenderTargetArrayLength:");
    public static readonly Selector SetRenderTargetHeight = Selector.Register("setRenderTargetHeight:");
    public static readonly Selector SetRenderTargetWidth = Selector.Register("setRenderTargetWidth:");
    public static readonly Selector SetStencilAttachment = Selector.Register("setStencilAttachment:");
    public static readonly Selector SetSupportColorAttachmentMapping = Selector.Register("setSupportColorAttachmentMapping:");
    public static readonly Selector SetThreadgroupMemoryLength = Selector.Register("setThreadgroupMemoryLength:");
    public static readonly Selector SetTileHeight = Selector.Register("setTileHeight:");
    public static readonly Selector SetTileWidth = Selector.Register("setTileWidth:");
    public static readonly Selector SetVisibilityResultBuffer = Selector.Register("setVisibilityResultBuffer:");
    public static readonly Selector SetVisibilityResultType = Selector.Register("setVisibilityResultType:");
}
