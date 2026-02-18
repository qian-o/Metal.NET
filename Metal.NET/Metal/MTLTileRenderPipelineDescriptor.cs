namespace Metal.NET;

public class MTLTileRenderPipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLTileRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineDescriptorSelector.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get => GetNullableObject<MTLTileRenderPipelineColorAttachmentDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.ColorAttachments));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? LinkedFunctions
    {
        get => GetNullableObject<MTLLinkedFunctions>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.LinkedFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetLinkedFunctions, value?.NativePtr ?? 0);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorSelector.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetMaxCallStackDepth, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorSelector.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public NSArray? PreloadedLibraries
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.PreloadedLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetPreloadedLibraries, value?.NativePtr ?? 0);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetRasterSampleCount, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLTileRenderPipelineDescriptorSelector.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetShaderValidation, (nint)value);
    }

    public bool SupportAddingBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorSelector.SupportAddingBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetSupportAddingBinaryFunctions, (Bool8)value);
    }

    public bool ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorSelector.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetThreadgroupSizeMatchesTileSize, (Bool8)value);
    }

    public MTLPipelineBufferDescriptorArray? TileBuffers
    {
        get => GetNullableObject<MTLPipelineBufferDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.TileBuffers));
    }

    public MTLFunction? TileFunction
    {
        get => GetNullableObject<MTLFunction>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.TileFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetTileFunction, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.Reset);
    }
}

file static class MTLTileRenderPipelineDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineDescriptor");

    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");

    public static readonly Selector MaxCallStackDepth = Selector.Register("maxCallStackDepth");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector PreloadedLibraries = Selector.Register("preloadedLibraries");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetLinkedFunctions = Selector.Register("setLinkedFunctions:");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector SetSupportAddingBinaryFunctions = Selector.Register("setSupportAddingBinaryFunctions:");

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = Selector.Register("setThreadgroupSizeMatchesTileSize:");

    public static readonly Selector SetTileFunction = Selector.Register("setTileFunction:");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector SupportAddingBinaryFunctions = Selector.Register("supportAddingBinaryFunctions");

    public static readonly Selector ThreadgroupSizeMatchesTileSize = Selector.Register("threadgroupSizeMatchesTileSize");

    public static readonly Selector TileBuffers = Selector.Register("tileBuffers");

    public static readonly Selector TileFunction = Selector.Register("tileFunction");
}
