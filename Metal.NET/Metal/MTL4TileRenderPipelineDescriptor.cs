namespace Metal.NET;

public class MTL4TileRenderPipelineDescriptor(nint nativePtr) : MTL4PipelineDescriptor(nativePtr)
{
    public MTL4TileRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4TileRenderPipelineDescriptorBindings.Class))
    {
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get => GetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.ColorAttachments);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4TileRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4TileRenderPipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTL4StaticLinkingDescriptor? StaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.StaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.SetStaticLinkingDescriptor, value);
    }

    public bool SupportBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SupportBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetSupportBinaryLinking, (Bool8)value);
    }

    public bool ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4TileRenderPipelineDescriptorBindings.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.SetThreadgroupSizeMatchesTileSize, (Bool8)value);
    }

    public MTL4FunctionDescriptor? TileFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.TileFunctionDescriptor);
        set => SetProperty(ref field, MTL4TileRenderPipelineDescriptorBindings.SetTileFunctionDescriptor, value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4TileRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTL4TileRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4TileRenderPipelineDescriptor");

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

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
