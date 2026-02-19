namespace Metal.NET;

public class MTLTileRenderPipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLTileRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.BinaryArchives);
        set => SetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.ColorAttachments);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.SetLabel, value);
    }

    public MTLLinkedFunctions? LinkedFunctions
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.LinkedFunctions);
        set => SetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.SetLinkedFunctions, value);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public NSArray? PreloadedLibraries
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.PreloadedLibraries);
        set => SetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.SetPreloadedLibraries, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLTileRenderPipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public bool SupportAddingBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorBindings.SupportAddingBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetSupportAddingBinaryFunctions, (Bool8)value);
    }

    public bool ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorBindings.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetThreadgroupSizeMatchesTileSize, (Bool8)value);
    }

    public MTLPipelineBufferDescriptorArray? TileBuffers
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.TileBuffers);
    }

    public MTLFunction? TileFunction
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.TileFunction);
        set => SetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.SetTileFunction, value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLTileRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector Label = "label";

    public static readonly Selector LinkedFunctions = "linkedFunctions";

    public static readonly Selector MaxCallStackDepth = "maxCallStackDepth";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector PreloadedLibraries = "preloadedLibraries";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLinkedFunctions = "setLinkedFunctions:";

    public static readonly Selector SetMaxCallStackDepth = "setMaxCallStackDepth:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetPreloadedLibraries = "setPreloadedLibraries:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector SetSupportAddingBinaryFunctions = "setSupportAddingBinaryFunctions:";

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = "setThreadgroupSizeMatchesTileSize:";

    public static readonly Selector SetTileFunction = "setTileFunction:";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector SupportAddingBinaryFunctions = "supportAddingBinaryFunctions";

    public static readonly Selector ThreadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";

    public static readonly Selector TileBuffers = "tileBuffers";

    public static readonly Selector TileFunction = "tileFunction";
}
