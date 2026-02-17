namespace Metal.NET;

public class MTLRenderPassDescriptor : IDisposable
{
    public MTLRenderPassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassDescriptor");

    public static MTLRenderPassDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLRenderPassDescriptor(ptr);
    }

    public void SetDefaultRasterSampleCount(uint defaultRasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetDefaultRasterSampleCount, (nint)defaultRasterSampleCount);
    }

    public void SetDepthAttachment(MTLRenderPassDepthAttachmentDescriptor depthAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetDepthAttachment, depthAttachment.NativePtr);
    }

    public void SetImageblockSampleLength(uint imageblockSampleLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetImageblockSampleLength, (nint)imageblockSampleLength);
    }

    public void SetRasterizationRateMap(MTLRasterizationRateMap rasterizationRateMap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRasterizationRateMap, rasterizationRateMap.NativePtr);
    }

    public void SetRenderTargetArrayLength(uint renderTargetArrayLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetArrayLength, (nint)renderTargetArrayLength);
    }

    public void SetRenderTargetHeight(uint renderTargetHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetHeight, (nint)renderTargetHeight);
    }

    public void SetRenderTargetWidth(uint renderTargetWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetWidth, (nint)renderTargetWidth);
    }

    public void SetStencilAttachment(MTLRenderPassStencilAttachmentDescriptor stencilAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetStencilAttachment, stencilAttachment.NativePtr);
    }

    public void SetSupportColorAttachmentMapping(Bool8 supportColorAttachmentMapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetSupportColorAttachmentMapping, (nint)supportColorAttachmentMapping.Value);
    }

    public void SetThreadgroupMemoryLength(uint threadgroupMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetThreadgroupMemoryLength, (nint)threadgroupMemoryLength);
    }

    public void SetTileHeight(uint tileHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetTileHeight, (nint)tileHeight);
    }

    public void SetTileWidth(uint tileWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetTileWidth, (nint)tileWidth);
    }

    public void SetVisibilityResultBuffer(MTLBuffer visibilityResultBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetVisibilityResultBuffer, visibilityResultBuffer.NativePtr);
    }

    public void SetVisibilityResultType(MTLVisibilityResultType visibilityResultType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetVisibilityResultType, (nint)(uint)visibilityResultType);
    }

    public static MTLRenderPassDescriptor RenderPassDescriptor()
    {
        var result = new MTLRenderPassDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLRenderPassDescriptorSelector.RenderPassDescriptor));

        return result;
    }

}

file class MTLRenderPassDescriptorSelector
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
    public static readonly Selector RenderPassDescriptor = Selector.Register("renderPassDescriptor");
}
