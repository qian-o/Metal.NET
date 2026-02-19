namespace Metal.NET;

public class MTLRenderPassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassDescriptorBindings.Class))
    {
    }

    public MTLRenderPassColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorBindings.ColorAttachments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLRenderPassColorAttachmentDescriptorArray(ptr);
            }

            return field;
        }
    }

    public nuint DefaultRasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.DefaultRasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetDefaultRasterSampleCount, value);
    }

    public MTLRenderPassDepthAttachmentDescriptor? DepthAttachment
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorBindings.DepthAttachment);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLRenderPassDepthAttachmentDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetDepthAttachment, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.ImageblockSampleLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetImageblockSampleLength, value);
    }

    public MTLRasterizationRateMap? RasterizationRateMap
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorBindings.RasterizationRateMap);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLRasterizationRateMap(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetRasterizationRateMap, value?.NativePtr ?? 0);
            field = value;
        }
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

    public MTLRenderPassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorBindings.SampleBufferAttachments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLRenderPassSampleBufferAttachmentDescriptorArray(ptr);
            }

            return field;
        }
    }

    public MTLRenderPassStencilAttachmentDescriptor? StencilAttachment
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorBindings.StencilAttachment);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLRenderPassStencilAttachmentDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetStencilAttachment, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public bool SupportColorAttachmentMapping
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPassDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetSupportColorAttachmentMapping, (Bool8)value);
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

    public MTLBuffer? VisibilityResultBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorBindings.VisibilityResultBuffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBuffer(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetVisibilityResultBuffer, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLVisibilityResultType VisibilityResultType
    {
        get => (MTLVisibilityResultType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassDescriptorBindings.VisibilityResultType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetVisibilityResultType, (nint)value);
    }

    public nuint GetSamplePositions(MTLSamplePosition positions, nuint count)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDescriptorBindings.GetSamplePositions, positions, count);
    }

    public static MTLRenderPassDescriptor? RenderPassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLRenderPassDescriptorBindings.Class, MTLRenderPassDescriptorBindings.RenderPassDescriptor);
        return ptr is not 0 ? new MTLRenderPassDescriptor(ptr) : null;
    }

    public void SetSamplePositions(MTLSamplePosition positions, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDescriptorBindings.SetSamplePositions, positions, count);
    }
}

file static class MTLRenderPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassDescriptor");

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
