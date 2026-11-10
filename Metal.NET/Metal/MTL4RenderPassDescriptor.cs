namespace Metal.NET;

public readonly struct MTL4RenderPassDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4RenderPassDescriptor value) => new(value.NativePtr);

    public MTL4RenderPassDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPassDescriptorBindings.Class))
    {
    }

    public MTL4RenderPassDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLRenderPassColorAttachmentDescriptorArray ColorAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPassDescriptorBindings.ColorAttachments));
    }

    public MTLRenderPassDepthAttachmentDescriptor DepthAttachment
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPassDescriptorBindings.DepthAttachment));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetDepthAttachment, value.NativePtr);
    }

    public MTLRenderPassStencilAttachmentDescriptor StencilAttachment
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPassDescriptorBindings.StencilAttachment));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetStencilAttachment, value.NativePtr);
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPassDescriptorBindings.RasterizationRateMap));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetRasterizationRateMap, value.NativePtr);
    }

    public MTLBuffer VisibilityResultBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPassDescriptorBindings.VisibilityResultBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetVisibilityResultBuffer, value.NativePtr);
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

    public unsafe void SetSamplePositions(ReadOnlySpan<MTLSamplePosition> positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4RenderPassDescriptorBindings.SetSamplePositions_Count, (nint)pPositions, (nuint)positions.Length);
        }
    }

    public unsafe nuint GetSamplePositions(ReadOnlySpan<MTLSamplePosition> positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            return ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPassDescriptorBindings.GetSamplePositions_Count, (nint)pPositions, (nuint)positions.Length);
        }
    }
}

file static class MTL4RenderPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4RenderPassDescriptor");

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector DefaultRasterSampleCount = "defaultRasterSampleCount";

    public static readonly Selector DepthAttachment = "depthAttachment";

    public static readonly Selector GetSamplePositions_Count = "getSamplePositions:count:";

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
