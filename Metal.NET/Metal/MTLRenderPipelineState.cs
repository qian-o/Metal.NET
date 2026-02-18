namespace Metal.NET;

public partial class MTLRenderPipelineState : NativeObject
{
    public MTLRenderPipelineState(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLRenderPipelineStateSelector.GpuResourceID);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.ImageblockSampleLength);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
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

    public MTL4PipelineDescriptor? NewRenderPipelineDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint ObjectThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.ObjectThreadExecutionWidth);
    }

    public MTLRenderPipelineReflection? Reflection
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.Reflection);
            return ptr is not 0 ? new(ptr) : null;
        }
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
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.ShaderValidation);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineStateSelector.SupportIndirectCommandBuffers);
    }

    public bool ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineStateSelector.ThreadgroupSizeMatchesTileSize);
    }

    public MTLFunctionHandle? FunctionHandle(NSString name, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.FunctionHandle, name.NativePtr, (nuint)stage);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLFunctionHandle? FunctionHandle(MTL4BinaryFunction function, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.FunctionHandle, function.NativePtr, (nuint)stage);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLFunctionHandle? FunctionHandle(MTLFunction function, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.FunctionHandle, function.NativePtr, (nuint)stage);
        return ptr is not 0 ? new(ptr) : null;
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateSelector.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLIntersectionFunctionTable? NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewIntersectionFunctionTable, descriptor.NativePtr, (nuint)stage);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineState, binaryFunctionsDescriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineState, additionalBinaryFunctions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLVisibleFunctionTable? NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateSelector.NewVisibleFunctionTable, descriptor.NativePtr, (nuint)stage);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLRenderPipelineStateSelector
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
