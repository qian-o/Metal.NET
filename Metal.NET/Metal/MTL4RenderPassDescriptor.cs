namespace Metal.NET;

public partial class MTL4RenderPassDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPassDescriptor");

    public MTL4RenderPassDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLRenderPassColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorSelector.ColorAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint DefaultRasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.DefaultRasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetDefaultRasterSampleCount, value);
    }

    public MTLRenderPassDepthAttachmentDescriptor? DepthAttachment
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorSelector.DepthAttachment);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetDepthAttachment, value?.NativePtr ?? 0);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.ImageblockSampleLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetImageblockSampleLength, value);
    }

    public MTLRasterizationRateMap? RasterizationRateMap
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorSelector.RasterizationRateMap);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRasterizationRateMap, value?.NativePtr ?? 0);
    }

    public nuint RenderTargetArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.RenderTargetArrayLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetArrayLength, value);
    }

    public nuint RenderTargetHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.RenderTargetHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetHeight, value);
    }

    public nuint RenderTargetWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.RenderTargetWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetRenderTargetWidth, value);
    }

    public MTLRenderPassStencilAttachmentDescriptor? StencilAttachment
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorSelector.StencilAttachment);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetStencilAttachment, value?.NativePtr ?? 0);
    }

    public bool SupportColorAttachmentMapping
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPassDescriptorSelector.SupportColorAttachmentMapping);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetSupportColorAttachmentMapping, (Bool8)value);
    }

    public nuint ThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.ThreadgroupMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetThreadgroupMemoryLength, value);
    }

    public nuint TileHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.TileHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetTileHeight, value);
    }

    public nuint TileWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.TileWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetTileWidth, value);
    }

    public MTLBuffer? VisibilityResultBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorSelector.VisibilityResultBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetVisibilityResultBuffer, value?.NativePtr ?? 0);
    }

    public MTLVisibilityResultType VisibilityResultType
    {
        get => (MTLVisibilityResultType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPassDescriptorSelector.VisibilityResultType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetVisibilityResultType, (nint)value);
    }

    public nuint GetSamplePositions(MTLSamplePosition positions, nuint count)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorSelector.GetSamplePositions, positions, count);
    }

    public void SetSamplePositions(MTLSamplePosition positions, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPassDescriptorSelector.SetSamplePositions, positions, count);
    }
}

file static class MTL4RenderPassDescriptorSelector
{
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
