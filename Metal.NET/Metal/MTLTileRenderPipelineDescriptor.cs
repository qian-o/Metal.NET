namespace Metal.NET;

public class MTLTileRenderPipelineDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineDescriptor");

    public MTLTileRenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLTileRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLTileRenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray BinaryArchives
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetBinaryArchives, value.NativePtr);
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.ColorAttachments));

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetLabel, value.NativePtr);
    }

    public MTLLinkedFunctions LinkedFunctions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.LinkedFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetLinkedFunctions, value.NativePtr);
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

    public NSArray PreloadedLibraries
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.PreloadedLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetPreloadedLibraries, value.NativePtr);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetRasterSampleCount, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTileRenderPipelineDescriptorSelector.ShaderValidation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetShaderValidation, (uint)value);
    }

    public Bool8 SupportAddingBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorSelector.SupportAddingBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetSupportAddingBinaryFunctions, value);
    }

    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorSelector.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetThreadgroupSizeMatchesTileSize, value);
    }

    public MTLPipelineBufferDescriptorArray TileBuffers => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.TileBuffers));

    public MTLFunction TileFunction
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorSelector.TileFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.SetTileFunction, value.NativePtr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorSelector.Reset);
    }

    public static implicit operator nint(MTLTileRenderPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTileRenderPipelineDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLTileRenderPipelineDescriptorSelector
{
    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");

    public static readonly Selector SetLinkedFunctions = Selector.Register("setLinkedFunctions:");

    public static readonly Selector MaxCallStackDepth = Selector.Register("maxCallStackDepth");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector PreloadedLibraries = Selector.Register("preloadedLibraries");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector SupportAddingBinaryFunctions = Selector.Register("supportAddingBinaryFunctions");

    public static readonly Selector SetSupportAddingBinaryFunctions = Selector.Register("setSupportAddingBinaryFunctions:");

    public static readonly Selector ThreadgroupSizeMatchesTileSize = Selector.Register("threadgroupSizeMatchesTileSize");

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = Selector.Register("setThreadgroupSizeMatchesTileSize:");

    public static readonly Selector TileBuffers = Selector.Register("tileBuffers");

    public static readonly Selector TileFunction = Selector.Register("tileFunction");

    public static readonly Selector SetTileFunction = Selector.Register("setTileFunction:");

    public static readonly Selector Reset = Selector.Register("reset");
}
