namespace Metal.NET;

public class MTLRenderPipelineState(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTLRenderPipelineState>
{
    #region INativeObject
    public static new MTLRenderPipelineState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Label);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Device);
    }

    public MTLRenderPipelineReflection Reflection
    {
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Reflection);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineStateBindings.ThreadgroupSizeMatchesTileSize);
    }

    public nuint ImageblockSampleLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ImageblockSampleLength);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineStateBindings.SupportIndirectCommandBuffers);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerObjectThreadgroup);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadsPerMeshThreadgroup);
    }

    public nuint ObjectThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ObjectThreadExecutionWidth);
    }

    public nuint MeshThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MeshThreadExecutionWidth);
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.MaxTotalThreadgroupsPerMeshGrid);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLRenderPipelineStateBindings.GpuResourceID);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLRenderPipelineStateBindings.ShaderValidation);
    }

    public MTLSize RequiredThreadsPerTileThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerTileThreadgroup);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerObjectThreadgroup);
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRenderPipelineStateBindings.RequiredThreadsPerMeshThreadgroup);
    }

    public MTLFunctionHandle FunctionHandle(NSString name, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandle, name.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithBinaryFunctionStage, function.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.MakeRenderPipelineState, binaryFunctionsDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4PipelineDescriptor MakeRenderPipelineDescriptorForSpecialization()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.MakeRenderPipelineDescriptorForSpecialization);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithFunctionStage, function.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLVisibleFunctionTable MakeVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.MakeVisibleFunctionTable, descriptor.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIntersectionFunctionTable MakeIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.MakeIntersectionFunctionTable, descriptor.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineStateWithAdditionalBinaryFunctionsError, additionalBinaryFunctions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLRenderPipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionHandle = "functionHandleWithName:stage:";

    public static readonly Selector FunctionHandleWithBinaryFunctionStage = "functionHandleWithBinaryFunction:stage:";

    public static readonly Selector FunctionHandleWithFunctionStage = "functionHandleWithFunction:stage:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ImageblockMemoryLength = "imageblockMemoryLengthForDimensions:";

    public static readonly Selector ImageblockSampleLength = "imageblockSampleLength";

    public static readonly Selector Label = "label";

    public static readonly Selector MakeIntersectionFunctionTable = "newIntersectionFunctionTableWithDescriptor:stage:";

    public static readonly Selector MakeRenderPipelineDescriptorForSpecialization = "newRenderPipelineDescriptorForSpecialization";

    public static readonly Selector MakeRenderPipelineState = "newRenderPipelineStateWithBinaryFunctions:error:";

    public static readonly Selector MakeVisibleFunctionTable = "newVisibleFunctionTableWithDescriptor:stage:";

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector MeshThreadExecutionWidth = "meshThreadExecutionWidth";

    public static readonly Selector NewRenderPipelineStateWithAdditionalBinaryFunctionsError = "newRenderPipelineStateWithAdditionalBinaryFunctions:error:";

    public static readonly Selector ObjectThreadExecutionWidth = "objectThreadExecutionWidth";

    public static readonly Selector Reflection = "reflection";

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = "requiredThreadsPerMeshThreadgroup";

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = "requiredThreadsPerObjectThreadgroup";

    public static readonly Selector RequiredThreadsPerTileThreadgroup = "requiredThreadsPerTileThreadgroup";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";
}
