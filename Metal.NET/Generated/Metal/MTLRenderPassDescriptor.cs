namespace Metal.NET;

public partial class MTLRenderPassDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPassDescriptor>
{
    #region INativeObject
    public static new MTLRenderPassDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPassDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPassDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLRenderPassColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.ColorAttachments);
    }

    public MTLRenderPassDepthAttachmentDescriptor DepthAttachment
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.DepthAttachment);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetDepthAttachment, value);
    }

    public MTLRenderPassStencilAttachmentDescriptor StencilAttachment
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.StencilAttachment);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetStencilAttachment, value);
    }

    public MTLBuffer VisibilityResultBuffer
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.VisibilityResultBuffer);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetVisibilityResultBuffer, value);
    }

    public nuint RenderTargetArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetArrayLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetArrayLength, value);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.ImageblockSampleLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetImageblockSampleLength, value);
    }

    public nuint ThreadgroupMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.ThreadgroupMemoryLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetThreadgroupMemoryLength, value);
    }

    public nuint TileWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.TileWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetTileWidth, value);
    }

    public nuint TileHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.TileHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetTileHeight, value);
    }

    public nuint DefaultRasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.DefaultRasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetDefaultRasterSampleCount, value);
    }

    public nuint RenderTargetWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetWidth, value);
    }

    public nuint RenderTargetHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetHeight, value);
    }

    public MTLRasterizationRateMap RasterizationRateMap
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.RasterizationRateMap);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetRasterizationRateMap, value);
    }

    public MTLRenderPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.SampleBufferAttachments);
    }

    public MTLVisibilityResultType VisibilityResultType
    {
        get => (MTLVisibilityResultType)ObjectiveC.MsgSendLong(NativePtr, MTLRenderPassDescriptorBindings.VisibilityResultType);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetVisibilityResultType, (nint)value);
    }

    public Bool8 SupportColorAttachmentMapping
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPassDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetSupportColorAttachmentMapping, value);
    }

    public unsafe void SetSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetSamplePositions_Count, (nint)pPositions, (nuint)positions.Length);
        }
    }

    public unsafe nuint GetSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            return ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.GetSamplePositions_Count, (nint)pPositions, (nuint)positions.Length);
        }
    }

    public static MTLRenderPassDescriptor RenderPassDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLRenderPassDescriptorBindings.Class, MTLRenderPassDescriptorBindings.RenderPassDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLRenderPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassDescriptor");

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector DefaultRasterSampleCount = "defaultRasterSampleCount";

    public static readonly Selector DepthAttachment = "depthAttachment";

    public static readonly Selector GetSamplePositions_Count = "getSamplePositions:count:";

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

    public static readonly Selector SetSamplePositions_Count = "setSamplePositions:count:";

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
