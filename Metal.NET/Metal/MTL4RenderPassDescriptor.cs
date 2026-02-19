namespace Metal.NET;

public readonly struct MTL4RenderPassDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4RenderPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPassDescriptorBindings.Class))
    {
    }

    public MTLRenderPassColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorBindings.ColorAttachments);
            return ptr is not 0 ? new MTLRenderPassColorAttachmentDescriptorArray(ptr) : default;
        }
    }

    public nuint DefaultRasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.DefaultRasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetDefaultRasterSampleCount, value);
    }

    public MTLRenderPassDepthAttachmentDescriptor? DepthAttachment
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorBindings.DepthAttachment);
            return ptr is not 0 ? new MTLRenderPassDepthAttachmentDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetDepthAttachment, value?.NativePtr ?? 0);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.ImageblockSampleLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetImageblockSampleLength, value);
    }

    public MTLRasterizationRateMap? RasterizationRateMap
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorBindings.RasterizationRateMap);
            return ptr is not 0 ? new MTLRasterizationRateMap(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetRasterizationRateMap, value?.NativePtr ?? 0);
    }

    public nuint RenderTargetArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.RenderTargetArrayLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetRenderTargetArrayLength, value);
    }

    public nuint RenderTargetHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.RenderTargetHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetRenderTargetHeight, value);
    }

    public nuint RenderTargetWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.RenderTargetWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetRenderTargetWidth, value);
    }

    public MTLRenderPassStencilAttachmentDescriptor? StencilAttachment
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorBindings.StencilAttachment);
            return ptr is not 0 ? new MTLRenderPassStencilAttachmentDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetStencilAttachment, value?.NativePtr ?? 0);
    }

    public bool SupportColorAttachmentMapping
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPassDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetSupportColorAttachmentMapping, (Bool8)value);
    }

    public nuint ThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.ThreadgroupMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetThreadgroupMemoryLength, value);
    }

    public nuint TileHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.TileHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetTileHeight, value);
    }

    public nuint TileWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.TileWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetTileWidth, value);
    }

    public MTLBuffer? VisibilityResultBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorBindings.VisibilityResultBuffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetVisibilityResultBuffer, value?.NativePtr ?? 0);
    }

    public MTLVisibilityResultType VisibilityResultType
    {
        get => (MTLVisibilityResultType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorBindings.VisibilityResultType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetVisibilityResultType, (nint)value);
    }

    public nuint GetSamplePositions(MTLSamplePosition positions, nuint count)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.GetSamplePositions, positions, count);
    }

    public void SetSamplePositions(MTLSamplePosition positions, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetSamplePositions, positions, count);
    }
}

file static class MTL4RenderPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPassDescriptor");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector DefaultRasterSampleCount = Selector.Register("defaultRasterSampleCount");

    public static readonly Selector DepthAttachment = Selector.Register("depthAttachment");

    public static readonly Selector GetSamplePositions = Selector.Register("getSamplePositions:count:");

    public static readonly Selector ImageblockSampleLength = Selector.Register("imageblockSampleLength");

    public static readonly Selector RasterizationRateMap = Selector.Register("rasterizationRateMap");

    public static readonly Selector RenderTargetArrayLength = Selector.Register("renderTargetArrayLength");

    public static readonly Selector RenderTargetHeight = Selector.Register("renderTargetHeight");

    public static readonly Selector RenderTargetWidth = Selector.Register("renderTargetWidth");

    public static readonly Selector SetDefaultRasterSampleCount = Selector.Register("setDefaultRasterSampleCount:");

    public static readonly Selector SetDepthAttachment = Selector.Register("setDepthAttachment:");

    public static readonly Selector SetImageblockSampleLength = Selector.Register("setImageblockSampleLength:");

    public static readonly Selector SetRasterizationRateMap = Selector.Register("setRasterizationRateMap:");

    public static readonly Selector SetRenderTargetArrayLength = Selector.Register("setRenderTargetArrayLength:");

    public static readonly Selector SetRenderTargetHeight = Selector.Register("setRenderTargetHeight:");

    public static readonly Selector SetRenderTargetWidth = Selector.Register("setRenderTargetWidth:");

    public static readonly Selector SetSamplePositions = Selector.Register("setSamplePositions:count:");

    public static readonly Selector SetStencilAttachment = Selector.Register("setStencilAttachment:");

    public static readonly Selector SetSupportColorAttachmentMapping = Selector.Register("setSupportColorAttachmentMapping:");

    public static readonly Selector SetThreadgroupMemoryLength = Selector.Register("setThreadgroupMemoryLength:");

    public static readonly Selector SetTileHeight = Selector.Register("setTileHeight:");

    public static readonly Selector SetTileWidth = Selector.Register("setTileWidth:");

    public static readonly Selector SetVisibilityResultBuffer = Selector.Register("setVisibilityResultBuffer:");

    public static readonly Selector SetVisibilityResultType = Selector.Register("setVisibilityResultType:");

    public static readonly Selector StencilAttachment = Selector.Register("stencilAttachment");

    public static readonly Selector SupportColorAttachmentMapping = Selector.Register("supportColorAttachmentMapping");

    public static readonly Selector ThreadgroupMemoryLength = Selector.Register("threadgroupMemoryLength");

    public static readonly Selector TileHeight = Selector.Register("tileHeight");

    public static readonly Selector TileWidth = Selector.Register("tileWidth");

    public static readonly Selector VisibilityResultBuffer = Selector.Register("visibilityResultBuffer");

    public static readonly Selector VisibilityResultType = Selector.Register("visibilityResultType");
}
