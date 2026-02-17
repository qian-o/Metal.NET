namespace Metal.NET;

file class MTLRenderPassDescriptorSelector
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
    public static readonly Selector RenderPassDescriptor = Selector.Register("renderPassDescriptor");
}

public class MTLRenderPassDescriptor : IDisposable
{
    public MTLRenderPassDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void SetDefaultRasterSampleCount(nuint defaultRasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetDefaultRasterSampleCount_, (nint)defaultRasterSampleCount);
    }

    public void SetDepthAttachment(MTLRenderPassDepthAttachmentDescriptor depthAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetDepthAttachment_, depthAttachment.NativePtr);
    }

    public void SetImageblockSampleLength(nuint imageblockSampleLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetImageblockSampleLength_, (nint)imageblockSampleLength);
    }

    public void SetRasterizationRateMap(MTLRasterizationRateMap rasterizationRateMap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRasterizationRateMap_, rasterizationRateMap.NativePtr);
    }

    public void SetRenderTargetArrayLength(nuint renderTargetArrayLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetArrayLength_, (nint)renderTargetArrayLength);
    }

    public void SetRenderTargetHeight(nuint renderTargetHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetHeight_, (nint)renderTargetHeight);
    }

    public void SetRenderTargetWidth(nuint renderTargetWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetWidth_, (nint)renderTargetWidth);
    }

    public void SetStencilAttachment(MTLRenderPassStencilAttachmentDescriptor stencilAttachment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetStencilAttachment_, stencilAttachment.NativePtr);
    }

    public void SetSupportColorAttachmentMapping(Bool8 supportColorAttachmentMapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetSupportColorAttachmentMapping_, (nint)supportColorAttachmentMapping.Value);
    }

    public void SetThreadgroupMemoryLength(nuint threadgroupMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetThreadgroupMemoryLength_, (nint)threadgroupMemoryLength);
    }

    public void SetTileHeight(nuint tileHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetTileHeight_, (nint)tileHeight);
    }

    public void SetTileWidth(nuint tileWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetTileWidth_, (nint)tileWidth);
    }

    public void SetVisibilityResultBuffer(MTLBuffer visibilityResultBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetVisibilityResultBuffer_, visibilityResultBuffer.NativePtr);
    }

    public void SetVisibilityResultType(MTLVisibilityResultType visibilityResultType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassDescriptorSelector.SetVisibilityResultType_, (nint)(uint)visibilityResultType);
    }

    public static MTLRenderPassDescriptor RenderPassDescriptor()
    {
        var result = new MTLRenderPassDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLRenderPassDescriptorSelector.RenderPassDescriptor));

        return result;
    }

}
