namespace Metal.NET;

public partial class MTLRenderPassDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassDescriptor");

    public MTLRenderPassDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLRenderPassColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorSelector.ColorAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint DefaultRasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.DefaultRasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetDefaultRasterSampleCount, value);
    }

    public MTLRenderPassDepthAttachmentDescriptor? DepthAttachment
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorSelector.DepthAttachment);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetDepthAttachment, value?.NativePtr ?? 0);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.ImageblockSampleLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetImageblockSampleLength, value);
    }

    public MTLRasterizationRateMap? RasterizationRateMap
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorSelector.RasterizationRateMap);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRasterizationRateMap, value?.NativePtr ?? 0);
    }

    public nuint RenderTargetArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.RenderTargetArrayLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetArrayLength, value);
    }

    public nuint RenderTargetHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.RenderTargetHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetHeight, value);
    }

    public nuint RenderTargetWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.RenderTargetWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetRenderTargetWidth, value);
    }

    public MTLRenderPassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorSelector.SampleBufferAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLRenderPassStencilAttachmentDescriptor? StencilAttachment
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorSelector.StencilAttachment);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetStencilAttachment, value?.NativePtr ?? 0);
    }

    public bool SupportColorAttachmentMapping
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPassDescriptorSelector.SupportColorAttachmentMapping);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetSupportColorAttachmentMapping, (Bool8)value);
    }

    public nuint ThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.ThreadgroupMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetThreadgroupMemoryLength, value);
    }

    public nuint TileHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.TileHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetTileHeight, value);
    }

    public nuint TileWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.TileWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetTileWidth, value);
    }

    public MTLBuffer? VisibilityResultBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorSelector.VisibilityResultBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetVisibilityResultBuffer, value?.NativePtr ?? 0);
    }

    public MTLVisibilityResultType VisibilityResultType
    {
        get => (MTLVisibilityResultType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorSelector.VisibilityResultType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetVisibilityResultType, (nint)value);
    }

    public nuint GetSamplePositions(MTLSamplePosition positions, nuint count)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorSelector.GetSamplePositions, positions, count);
    }

    public static MTLRenderPassDescriptor? RenderPassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLRenderPassDescriptorSelector.RenderPassDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetSamplePositions(MTLSamplePosition positions, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorSelector.SetSamplePositions, positions, count);
    }
}

file static class MTLRenderPassDescriptorSelector
{
    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector DefaultRasterSampleCount = Selector.Register("defaultRasterSampleCount");

    public static readonly Selector DepthAttachment = Selector.Register("depthAttachment");

    public static readonly Selector GetSamplePositions = Selector.Register("getSamplePositions:count:");

    public static readonly Selector ImageblockSampleLength = Selector.Register("imageblockSampleLength");

    public static readonly Selector RasterizationRateMap = Selector.Register("rasterizationRateMap");

    public static readonly Selector RenderPassDescriptor = Selector.Register("renderPassDescriptor");

    public static readonly Selector RenderTargetArrayLength = Selector.Register("renderTargetArrayLength");

    public static readonly Selector RenderTargetHeight = Selector.Register("renderTargetHeight");

    public static readonly Selector RenderTargetWidth = Selector.Register("renderTargetWidth");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

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
