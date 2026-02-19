namespace Metal.NET;

public readonly struct MTLRenderPipelineState(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLRenderPipelineStateBindings.GpuResourceID);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ImageblockSampleLength);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadgroupsPerMeshGrid);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerMeshThreadgroup);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerObjectThreadgroup);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    public nuint MeshThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MeshThreadExecutionWidth);
    }

    public MTL4PipelineDescriptor? NewRenderPipelineDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineDescriptor);
            return ptr is not 0 ? new MTL4PipelineDescriptor(ptr) : default;
        }
    }

    public nuint ObjectThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ObjectThreadExecutionWidth);
    }

    public MTLRenderPipelineReflection? Reflection
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.Reflection);
            return ptr is not 0 ? new MTLRenderPipelineReflection(ptr) : default;
        }
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerMeshThreadgroup);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerObjectThreadgroup);
    }

    public MTLSize RequiredThreadsPerTileThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerTileThreadgroup);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.ShaderValidation);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineStateBindings.SupportIndirectCommandBuffers);
    }

    public bool ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineStateBindings.ThreadgroupSizeMatchesTileSize);
    }

    public MTLFunctionHandle? FunctionHandle(NSString name, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.FunctionHandle, name.NativePtr, (nuint)stage);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : default;
    }

    public MTLFunctionHandle? FunctionHandle(MTL4BinaryFunction function, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.FunctionHandle, function.NativePtr, (nuint)stage);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : default;
    }

    public MTLFunctionHandle? FunctionHandle(MTLFunction function, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.FunctionHandle, function.NativePtr, (nuint)stage);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : default;
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLIntersectionFunctionTable? NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewIntersectionFunctionTable, descriptor.NativePtr, (nuint)stage);
        return ptr is not 0 ? new MTLIntersectionFunctionTable(ptr) : default;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineState, binaryFunctionsDescriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : default;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineState, additionalBinaryFunctions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : default;
    }

    public MTLVisibleFunctionTable? NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewVisibleFunctionTable, descriptor.NativePtr, (nuint)stage);
        return ptr is not 0 ? new MTLVisibleFunctionTable(ptr) : default;
    }
}

file static class MTLRenderPipelineStateBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionHandle = Selector.Register("functionHandleWithName:stage:");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector ImageblockMemoryLength = Selector.Register("imageblockMemoryLengthForDimensions:");

    public static readonly Selector ImageblockSampleLength = Selector.Register("imageblockSampleLength");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = Selector.Register("maxTotalThreadgroupsPerMeshGrid");

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = Selector.Register("maxTotalThreadsPerMeshThreadgroup");

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = Selector.Register("maxTotalThreadsPerObjectThreadgroup");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector MeshThreadExecutionWidth = Selector.Register("meshThreadExecutionWidth");

    public static readonly Selector NewIntersectionFunctionTable = Selector.Register("newIntersectionFunctionTableWithDescriptor:stage:");

    public static readonly Selector NewRenderPipelineDescriptor = Selector.Register("newRenderPipelineDescriptorForSpecialization");

    public static readonly Selector NewRenderPipelineState = Selector.Register("newRenderPipelineStateWithBinaryFunctions:error:");

    public static readonly Selector NewVisibleFunctionTable = Selector.Register("newVisibleFunctionTableWithDescriptor:stage:");

    public static readonly Selector ObjectThreadExecutionWidth = Selector.Register("objectThreadExecutionWidth");

    public static readonly Selector Reflection = Selector.Register("reflection");

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = Selector.Register("requiredThreadsPerMeshThreadgroup");

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = Selector.Register("requiredThreadsPerObjectThreadgroup");

    public static readonly Selector RequiredThreadsPerTileThreadgroup = Selector.Register("requiredThreadsPerTileThreadgroup");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector ThreadgroupSizeMatchesTileSize = Selector.Register("threadgroupSizeMatchesTileSize");
}
