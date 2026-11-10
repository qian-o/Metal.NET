namespace Metal.NET;

public readonly struct MTL4TileRenderPipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTL4PipelineDescriptor(MTL4TileRenderPipelineDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4TileRenderPipelineDescriptor value) => new(value.NativePtr);

    public MTL4TileRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4TileRenderPipelineDescriptorBindings.Class))
    {
    }

    public MTL4TileRenderPipelineDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4FunctionDescriptor TileFunctionDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.TileFunctionDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetTileFunctionDescriptor, value.NativePtr);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.ColorAttachments));
    }

    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorBindings.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetThreadgroupSizeMatchesTileSize, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTL4TileRenderPipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTL4StaticLinkingDescriptor StaticLinkingDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.StaticLinkingDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetStaticLinkingDescriptor, value.NativePtr);
    }

    public Bool8 SupportBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SupportBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetSupportBinaryLinking, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4PipelineOptions Options
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.Options));
        set => ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetOptions, value.NativePtr);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTL4TileRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4TileRenderPipelineDescriptor");

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector Options = "options";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetOptions = "setOptions:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";

    public static readonly Selector SetStaticLinkingDescriptor = "setStaticLinkingDescriptor:";

    public static readonly Selector SetSupportBinaryLinking = "setSupportBinaryLinking:";

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = "setThreadgroupSizeMatchesTileSize:";

    public static readonly Selector SetTileFunctionDescriptor = "setTileFunctionDescriptor:";

    public static readonly Selector StaticLinkingDescriptor = "staticLinkingDescriptor";

    public static readonly Selector SupportBinaryLinking = "supportBinaryLinking";

    public static readonly Selector ThreadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";

    public static readonly Selector TileFunctionDescriptor = "tileFunctionDescriptor";
}
