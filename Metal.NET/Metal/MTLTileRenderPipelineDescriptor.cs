namespace Metal.NET;

public readonly struct MTLTileRenderPipelineDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLTileRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTileRenderPipelineDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorBindings.BinaryArchives);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLTileRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorBindings.ColorAttachments);
            return ptr is not 0 ? new MTLTileRenderPipelineColorAttachmentDescriptorArray(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? LinkedFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorBindings.LinkedFunctions);
            return ptr is not 0 ? new MTLLinkedFunctions(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetLinkedFunctions, value?.NativePtr ?? 0);
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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorBindings.PreloadedLibraries);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetPreloadedLibraries, value?.NativePtr ?? 0);
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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorBindings.TileBuffers);
            return ptr is not 0 ? new MTLPipelineBufferDescriptorArray(ptr) : default;
        }
    }

    public MTLFunction? TileFunction
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTileRenderPipelineDescriptorBindings.TileFunction);
            return ptr is not 0 ? new MTLFunction(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetTileFunction, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLTileRenderPipelineDescriptorBindings
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
