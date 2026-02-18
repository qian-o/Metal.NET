namespace Metal.NET;

public class MTLRenderPipelineState : IDisposable
{
    public MTLRenderPipelineState(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLRenderPipelineState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.Device));
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLRenderPipelineStateSelector.GpuResourceID);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.ImageblockSampleLength);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.Label));
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.MaxTotalThreadgroupsPerMeshGrid);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.MaxTotalThreadsPerMeshThreadgroup);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.MaxTotalThreadsPerObjectThreadgroup);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.MaxTotalThreadsPerThreadgroup);
    }

    public nuint MeshThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.MeshThreadExecutionWidth);
    }

    public nuint ObjectThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.ObjectThreadExecutionWidth);
    }

    public MTLRenderPipelineReflection Reflection
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.Reflection));
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateSelector.RequiredThreadsPerMeshThreadgroup);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateSelector.RequiredThreadsPerObjectThreadgroup);
    }

    public MTLSize RequiredThreadsPerTileThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateSelector.RequiredThreadsPerTileThreadgroup);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLRenderPipelineStateSelector.ShaderValidation));
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineStateSelector.SupportIndirectCommandBuffers);
    }

    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineStateSelector.ThreadgroupSizeMatchesTileSize);
    }

    public MTLFunctionHandle FunctionHandle(NSString name, MTLRenderStages stage)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.FunctionHandleWithFunctionStage, name.NativePtr, (ulong)stage));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function, MTLRenderStages stage)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.FunctionHandleWithFunctionStage, function.NativePtr, (ulong)stage));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function, MTLRenderStages stage)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.FunctionHandleWithFunctionStage, function.NativePtr, (ulong)stage));

        return result;
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.ImageblockMemoryLengthForDimensions, imageblockDimensions);

        return result;
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        MTLIntersectionFunctionTable result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewIntersectionFunctionTableWithDescriptorStage, descriptor.NativePtr, (ulong)stage));

        return result;
    }

    public MTL4PipelineDescriptor NewRenderPipelineDescriptor()
    {
        MTL4PipelineDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineDescriptorForSpecialization));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineStateWithAdditionalBinaryFunctionsError, binaryFunctionsDescriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineStateWithAdditionalBinaryFunctionsError, additionalBinaryFunctions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        MTLVisibleFunctionTable result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewVisibleFunctionTableWithDescriptorStage, descriptor.NativePtr, (ulong)stage));

        return result;
    }

    public static implicit operator nint(MTLRenderPipelineState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPipelineState(nint value)
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

file class MTLRenderPipelineStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector ImageblockSampleLength = Selector.Register("imageblockSampleLength");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = Selector.Register("maxTotalThreadgroupsPerMeshGrid");

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = Selector.Register("maxTotalThreadsPerMeshThreadgroup");

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = Selector.Register("maxTotalThreadsPerObjectThreadgroup");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector MeshThreadExecutionWidth = Selector.Register("meshThreadExecutionWidth");

    public static readonly Selector ObjectThreadExecutionWidth = Selector.Register("objectThreadExecutionWidth");

    public static readonly Selector Reflection = Selector.Register("reflection");

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = Selector.Register("requiredThreadsPerMeshThreadgroup");

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = Selector.Register("requiredThreadsPerObjectThreadgroup");

    public static readonly Selector RequiredThreadsPerTileThreadgroup = Selector.Register("requiredThreadsPerTileThreadgroup");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector ThreadgroupSizeMatchesTileSize = Selector.Register("threadgroupSizeMatchesTileSize");

    public static readonly Selector FunctionHandleWithFunctionStage = Selector.Register("functionHandleWithFunction:stage:");

    public static readonly Selector ImageblockMemoryLengthForDimensions = Selector.Register("imageblockMemoryLengthForDimensions:");

    public static readonly Selector NewIntersectionFunctionTableWithDescriptorStage = Selector.Register("newIntersectionFunctionTableWithDescriptor:stage:");

    public static readonly Selector NewRenderPipelineDescriptorForSpecialization = Selector.Register("newRenderPipelineDescriptorForSpecialization");

    public static readonly Selector NewRenderPipelineStateWithAdditionalBinaryFunctionsError = Selector.Register("newRenderPipelineStateWithAdditionalBinaryFunctions:error:");

    public static readonly Selector NewVisibleFunctionTableWithDescriptorStage = Selector.Register("newVisibleFunctionTableWithDescriptor:stage:");
}
