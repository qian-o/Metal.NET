namespace Metal.NET;

public class MTL4RenderPassDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4RenderPassDescriptor>
{
    #region INativeObject
    public static new MTL4RenderPassDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderPassDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4RenderPassDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPassDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLRenderPassColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTL4RenderPassDescriptorBindings.ColorAttachments);
    }

    public MTLRenderPassDepthAttachmentDescriptor DepthAttachment
    {
        get => GetProperty(ref field, MTL4RenderPassDescriptorBindings.DepthAttachment);
        set => SetProperty(ref field, MTL4RenderPassDescriptorBindings.SetDepthAttachment, value);
    }

    public MTLRenderPassStencilAttachmentDescriptor StencilAttachment
    {
        get => GetProperty(ref field, MTL4RenderPassDescriptorBindings.StencilAttachment);
        set => SetProperty(ref field, MTL4RenderPassDescriptorBindings.SetStencilAttachment, value);
    }

    public nuint RenderTargetArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.RenderTargetArrayLength);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetRenderTargetArrayLength, value);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.ImageblockSampleLength);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetImageblockSampleLength, value);
    }

    public nuint ThreadgroupMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.ThreadgroupMemoryLength);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetThreadgroupMemoryLength, value);
    }

    public nuint TileWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.TileWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetTileWidth, value);
    }

    public nuint TileHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.TileHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetTileHeight, value);
    }

    public nuint DefaultRasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.DefaultRasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetDefaultRasterSampleCount, value);
    }

    public nuint RenderTargetWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.RenderTargetWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetRenderTargetWidth, value);
    }

    public nuint RenderTargetHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.RenderTargetHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetRenderTargetHeight, value);
    }

    public MTLRasterizationRateMap RasterizationRateMap
    {
        get => GetProperty(ref field, MTL4RenderPassDescriptorBindings.RasterizationRateMap);
        set => SetProperty(ref field, MTL4RenderPassDescriptorBindings.SetRasterizationRateMap, value);
    }

    public MTLBuffer VisibilityResultBuffer
    {
        get => GetProperty(ref field, MTL4RenderPassDescriptorBindings.VisibilityResultBuffer);
        set => SetProperty(ref field, MTL4RenderPassDescriptorBindings.SetVisibilityResultBuffer, value);
    }

    public MTLVisibilityResultType VisibilityResultType
    {
        get => (MTLVisibilityResultType)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPassDescriptorBindings.VisibilityResultType);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetVisibilityResultType, (nint)value);
    }

    public Bool8 SupportColorAttachmentMapping
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4RenderPassDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetSupportColorAttachmentMapping, value);
    }

    public unsafe void SetSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetSamplePositions, (nint)pPositions, (nuint)positions.Length);
        }
    }

    public unsafe nuint GetSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            return ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.GetSamplePositions, (nint)pPositions, (nuint)positions.Length);
        }
    }
}

file static class MTL4RenderPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4RenderPassDescriptor");

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector DefaultRasterSampleCount = "defaultRasterSampleCount";

    public static readonly Selector DepthAttachment = "depthAttachment";

    public static readonly Selector GetSamplePositions = "getSamplePositions:count:";

    public static readonly Selector ImageblockSampleLength = "imageblockSampleLength";

    public static readonly Selector RasterizationRateMap = "rasterizationRateMap";

    public static readonly Selector RenderTargetArrayLength = "renderTargetArrayLength";

    public static readonly Selector RenderTargetHeight = "renderTargetHeight";

    public static readonly Selector RenderTargetWidth = "renderTargetWidth";

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
