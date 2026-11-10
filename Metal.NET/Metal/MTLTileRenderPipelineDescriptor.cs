namespace Metal.NET;

public readonly struct MTLTileRenderPipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLTileRenderPipelineDescriptor value) => new(value.NativePtr);

    public MTLTileRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTLTileRenderPipelineDescriptorBindings.Class))
    {
    }

    public MTLTileRenderPipelineDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLFunction TileFunction
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.TileFunction));
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetTileFunction, value.NativePtr);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.ColorAttachments));
    }

    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorBindings.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetThreadgroupSizeMatchesTileSize, value);
    }

    public MTLPipelineBufferDescriptorArray TileBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.TileBuffers));
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public NSArray<MTLBinaryArchive> BinaryArchives
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.BinaryArchives));
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetBinaryArchives, value.NativePtr);
    }

    public NSArray<MTLDynamicLibrary> PreloadedLibraries
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.PreloadedLibraries));
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetPreloadedLibraries, value.NativePtr);
    }

    public MTLLinkedFunctions LinkedFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.LinkedFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetLinkedFunctions, value.NativePtr);
    }

    public Bool8 SupportAddingBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorBindings.SupportAddingBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetSupportAddingBinaryFunctions, value);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLTileRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLTileRenderPipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLTileRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTileRenderPipelineDescriptor");

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
