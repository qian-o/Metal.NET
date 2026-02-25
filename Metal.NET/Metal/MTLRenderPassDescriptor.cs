namespace Metal.NET;

public class MTLRenderPassDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRenderPassDescriptor>
{
    public static MTLRenderPassDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLRenderPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassDescriptorBindings.Class), true)
    {
    }

    public MTLRenderPassColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.ColorAttachments);
    }

    public nuint DefaultRasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.DefaultRasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetDefaultRasterSampleCount, value);
    }

    public MTLRenderPassDepthAttachmentDescriptor DepthAttachment
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.DepthAttachment);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetDepthAttachment, value);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.ImageblockSampleLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetImageblockSampleLength, value);
    }

    public MTLRasterizationRateMap RasterizationRateMap
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.RasterizationRateMap);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetRasterizationRateMap, value);
    }

    public nuint RenderTargetArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetArrayLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetArrayLength, value);
    }

    public nuint RenderTargetHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetHeight, value);
    }

    public nuint RenderTargetWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetWidth, value);
    }

    public MTLRenderPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.SampleBufferAttachments);
    }

    public MTLRenderPassStencilAttachmentDescriptor StencilAttachment
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.StencilAttachment);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetStencilAttachment, value);
    }

    public Bool8 SupportColorAttachmentMapping
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPassDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetSupportColorAttachmentMapping, value);
    }

    public nuint ThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.ThreadgroupMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetThreadgroupMemoryLength, value);
    }

    public nuint TileHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.TileHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetTileHeight, value);
    }

    public nuint TileWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.TileWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetTileWidth, value);
    }

    public MTLBuffer VisibilityResultBuffer
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.VisibilityResultBuffer);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetVisibilityResultBuffer, value);
    }

    public MTLVisibilityResultType VisibilityResultType
    {
        get => (MTLVisibilityResultType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorBindings.VisibilityResultType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetVisibilityResultType, (nint)value);
    }

    public unsafe nuint GetSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.GetSamplePositions, (nint)pPositions, (nuint)positions.Length);
        }
    }

    public static MTLRenderPassDescriptor RenderPassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLRenderPassDescriptorBindings.Class, MTLRenderPassDescriptorBindings.RenderPassDescriptor);

        return new(nativePtr, true);
    }

    public unsafe void SetSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetSamplePositions, (nint)pPositions, (nuint)positions.Length);
        }
    }
}

file static class MTLRenderPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassDescriptor");

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector DefaultRasterSampleCount = "defaultRasterSampleCount";

    public static readonly Selector DepthAttachment = "depthAttachment";

    public static readonly Selector GetSamplePositions = "getSamplePositions:count:";

    public static readonly Selector ImageblockSampleLength = "imageblockSampleLength";

    public static readonly Selector RasterizationRateMap = "rasterizationRateMap";

    public static readonly Selector RenderPassDescriptor = "renderPassDescriptor";

    public static readonly Selector RenderTargetArrayLength = "renderTargetArrayLength";

    public static readonly Selector RenderTargetHeight = "renderTargetHeight";

    public static readonly Selector RenderTargetWidth = "renderTargetWidth";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";

    public static readonly Selector SetDefaultRasterSampleCount = "setDefaultRasterSampleCount:";

    public static readonly Selector SetDepthAttachment = "setDepthAttachment:";

    public static readonly Selector SetImageblockSampleLength = "setImageblockSampleLength:";

    public static readonly Selector SetRasterizationRateMap = "setRasterizationRateMap:";

    public static readonly Selector SetRenderTargetArrayLength = "setRenderTargetArrayLength:";

    public static readonly Selector SetRenderTargetHeight = "setRenderTargetHeight:";

    public static readonly Selector SetRenderTargetWidth = "setRenderTargetWidth:";

    public static readonly Selector SetSamplePositions = "setSamplePositions:count:";

    public static readonly Selector SetStencilAttachment = "setStencilAttachment:";

    public static readonly Selector SetSupportColorAttachmentMapping = "setSupportColorAttachmentMapping:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:";

    public static readonly Selector SetTileHeight = "setTileHeight:";

    public static readonly Selector SetTileWidth = "setTileWidth:";

    public static readonly Selector SetVisibilityResultBuffer = "setVisibilityResultBuffer:";

    public static readonly Selector SetVisibilityResultType = "setVisibilityResultType:";

    public static readonly Selector StencilAttachment = "stencilAttachment";

    public static readonly Selector SupportColorAttachmentMapping = "supportColorAttachmentMapping";

    public static readonly Selector ThreadgroupMemoryLength = "threadgroupMemoryLength";

    public static readonly Selector TileHeight = "tileHeight";

    public static readonly Selector TileWidth = "tileWidth";

    public static readonly Selector VisibilityResultBuffer = "visibilityResultBuffer";

    public static readonly Selector VisibilityResultType = "visibilityResultType";
}
