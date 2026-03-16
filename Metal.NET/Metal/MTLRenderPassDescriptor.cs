namespace Metal.NET;

/// <summary>A group of render targets that hold the results of a render pass.</summary>
public class MTLRenderPassDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPassDescriptor>
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

    #region Specifying the attachments for a rendering pass - Properties

    /// <summary>An array of state information for attachments that store color data.</summary>
    public MTLRenderPassColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.ColorAttachments);
    }

    /// <summary>State information for an attachment that stores depth data.</summary>
    public MTLRenderPassDepthAttachmentDescriptor DepthAttachment
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.DepthAttachment);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetDepthAttachment, value);
    }

    /// <summary>State information for an attachment that stores stencil data.</summary>
    public MTLRenderPassStencilAttachmentDescriptor StencilAttachment
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.StencilAttachment);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetStencilAttachment, value);
    }
    #endregion

    #region Specifying the visibility result buffer - Properties

    /// <summary>A buffer where the GPU writes visibility test results when fragments pass depth and stencil tests.</summary>
    public MTLBuffer VisibilityResultBuffer
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.VisibilityResultBuffer);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetVisibilityResultBuffer, value);
    }
    #endregion

    #region Layered rendering - Properties

    /// <summary>The number of active layers that all attachments need to have for layered rendering.</summary>
    public nuint RenderTargetArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetArrayLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetArrayLength, value);
    }

    /// <summary>The width, in pixels, to constrain the render target to.</summary>
    public nuint RenderTargetWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetWidth, value);
    }

    /// <summary>The height, in pixels, to constrain the render target to.</summary>
    public nuint RenderTargetHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.RenderTargetHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRenderTargetHeight, value);
    }
    #endregion

    #region Specifying tile shading parameters - Properties

    /// <summary>The per-sample size, in bytes, of the largest explicit imageblock layout in the render pass.</summary>
    public nuint ImageblockSampleLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.ImageblockSampleLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetImageblockSampleLength, value);
    }

    /// <summary>The per-tile size, in bytes, of the persistent threadgroup memory allocation.</summary>
    public nuint ThreadgroupMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.ThreadgroupMemoryLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetThreadgroupMemoryLength, value);
    }

    /// <summary>The tile width, in pixels.</summary>
    public nuint TileWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.TileWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetTileWidth, value);
    }

    /// <summary>The tile height, in pixels.</summary>
    public nuint TileHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.TileHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetTileHeight, value);
    }
    #endregion

    #region Specifying sample counts - Properties

    /// <summary>The raster sample count for the render pass when the render pass doesn’t have explicit attachments.</summary>
    public nuint DefaultRasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.DefaultRasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetDefaultRasterSampleCount, value);
    }
    #endregion

    #region Specifying a rasterization rate map - Properties

    /// <summary>The rasterization rate map to use when executing the render pass.</summary>
    public MTLRasterizationRateMap RasterizationRateMap
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.RasterizationRateMap);
        set => SetProperty(ref field, MTLRenderPassDescriptorBindings.SetRasterizationRateMap, value);
    }
    #endregion

    #region Specifying sample buffers for GPU counters - Properties

    /// <summary>The array of sample buffers that the render pass can access.</summary>
    public MTLRenderPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLRenderPassDescriptorBindings.SampleBufferAttachments);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>Specifies if the render pass should support color attachment mapping.</summary>
    public Bool8 SupportColorAttachmentMapping
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPassDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetSupportColorAttachmentMapping, value);
    }

    /// <summary>Specifies if Metal accumulates visibility results between render encoders or resets them.</summary>
    public MTLVisibilityResultType VisibilityResultType
    {
        get => (MTLVisibilityResultType)ObjectiveC.MsgSendLong(NativePtr, MTLRenderPassDescriptorBindings.VisibilityResultType);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetVisibilityResultType, (nint)value);
    }
    #endregion

    #region Using programmable sample positions - Methods

    /// <summary>Sets the programmable sample positions for a render pass.</summary>
    public unsafe void SetSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetSamplePositions, (nint)pPositions, (nuint)positions.Length);
        }
    }

    /// <summary>Returns the programmable sample positions set for a render pass.</summary>
    public unsafe nuint GetSamplePositions(MTLSamplePosition[] positions)
    {
        fixed (MTLSamplePosition* pPositions = positions)
        {
            return ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.GetSamplePositions, (nint)pPositions, (nuint)positions.Length);
        }
    }
    #endregion

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
