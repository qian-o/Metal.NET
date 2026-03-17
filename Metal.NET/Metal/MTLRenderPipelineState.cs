namespace Metal.NET;

public class MTLRenderPipelineState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineState>
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

    public MTLFunctionHandle FunctionHandleWithNameStage(NSString name, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithName, name.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandleWithBinaryFunctionStage(MTL4BinaryFunction function, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithBinaryFunction, function.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithBinaryFunctionsError(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineStateWithBinaryFunctions, binaryFunctionsDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4PipelineDescriptor NewRenderPipelineDescriptorForSpecialization()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineDescriptorForSpecialization);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public nuint ImageblockMemoryLengthForDimensions(MTLSize imageblockDimensions)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ImageblockMemoryLengthForDimensions, imageblockDimensions);
    }

    public MTLFunctionHandle FunctionHandleWithFunctionStage(MTLFunction function, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithFunction, function.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTableWithDescriptorStage(MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewVisibleFunctionTableWithDescriptor, descriptor.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTableWithDescriptorStage(MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewIntersectionFunctionTableWithDescriptor, descriptor.NativePtr, (nuint)stage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithAdditionalBinaryFunctionsError(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineStateWithAdditionalBinaryFunctions, additionalBinaryFunctions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLRenderPipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:stage:";

    public static readonly Selector FunctionHandleWithFunction = "functionHandleWithFunction:stage:";

    public static readonly Selector FunctionHandleWithName = "functionHandleWithName:stage:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ImageblockMemoryLengthForDimensions = "imageblockMemoryLengthForDimensions:";

    public static readonly Selector ImageblockSampleLength = "imageblockSampleLength";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector MeshThreadExecutionWidth = "meshThreadExecutionWidth";

    public static readonly Selector NewIntersectionFunctionTableWithDescriptor = "newIntersectionFunctionTableWithDescriptor:stage:";

    public static readonly Selector NewRenderPipelineDescriptorForSpecialization = "newRenderPipelineDescriptorForSpecialization";

    public static readonly Selector NewRenderPipelineStateWithAdditionalBinaryFunctions = "newRenderPipelineStateWithAdditionalBinaryFunctions:error:";

    public static readonly Selector NewRenderPipelineStateWithBinaryFunctions = "newRenderPipelineStateWithBinaryFunctions:error:";

    public static readonly Selector NewVisibleFunctionTableWithDescriptor = "newVisibleFunctionTableWithDescriptor:stage:";

    public static readonly Selector ObjectThreadExecutionWidth = "objectThreadExecutionWidth";

    public static readonly Selector Reflection = "reflection";

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = "requiredThreadsPerMeshThreadgroup";

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = "requiredThreadsPerObjectThreadgroup";

    public static readonly Selector RequiredThreadsPerTileThreadgroup = "requiredThreadsPerTileThreadgroup";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";
}
