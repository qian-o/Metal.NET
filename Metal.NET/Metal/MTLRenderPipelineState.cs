namespace Metal.NET;

public class MTLRenderPipelineState(nint nativePtr, bool retain) : MTLAllocation(nativePtr, retain)
{
    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Device);
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
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Label);
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

    public nuint ObjectThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ObjectThreadExecutionWidth);
    }

    public MTLRenderPipelineReflection? Reflection
    {
        get => GetProperty(ref field, MTLRenderPipelineStateBindings.Reflection);
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
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.FunctionHandle, name.NativePtr, (nuint)stage);

        return nativePtr is not 0 ? new(nativePtr, true) : null;
    }

    public MTLFunctionHandle? FunctionHandle(MTL4BinaryFunction function, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithBinaryFunctionstage, function.NativePtr, (nuint)stage);

        return nativePtr is not 0 ? new(nativePtr, true) : null;
    }

    public MTLFunctionHandle? FunctionHandle(MTLFunction function, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.FunctionHandleWithFunctionstage, function.NativePtr, (nuint)stage);

        return nativePtr is not 0 ? new(nativePtr, true) : null;
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLIntersectionFunctionTable? NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewIntersectionFunctionTable, descriptor.NativePtr, (nuint)stage);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTL4PipelineDescriptor? NewRenderPipelineDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineDescriptor);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError? error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineState, binaryFunctionsDescriptor.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            error = new(errorPtr, true);
        }
        else
        {
            error = null;
        }

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError? error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewRenderPipelineStateWithAdditionalBinaryFunctionserror, additionalBinaryFunctions.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            error = new(errorPtr, true);
        }
        else
        {
            error = null;
        }

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLVisibleFunctionTable? NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineStateBindings.NewVisibleFunctionTable, descriptor.NativePtr, (nuint)stage);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }
}

file static class MTLRenderPipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionHandle = "functionHandleWithName:stage:";

    public static readonly Selector FunctionHandleWithBinaryFunctionstage = "functionHandleWithBinaryFunction:stage:";

    public static readonly Selector FunctionHandleWithFunctionstage = "functionHandleWithFunction:stage:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ImageblockMemoryLength = "imageblockMemoryLengthForDimensions:";

    public static readonly Selector ImageblockSampleLength = "imageblockSampleLength";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector MeshThreadExecutionWidth = "meshThreadExecutionWidth";

    public static readonly Selector NewIntersectionFunctionTable = "newIntersectionFunctionTableWithDescriptor:stage:";

    public static readonly Selector NewRenderPipelineDescriptor = "newRenderPipelineDescriptorForSpecialization";

    public static readonly Selector NewRenderPipelineState = "newRenderPipelineStateWithBinaryFunctions:error:";

    public static readonly Selector NewRenderPipelineStateWithAdditionalBinaryFunctionserror = "newRenderPipelineStateWithAdditionalBinaryFunctions:error:";

    public static readonly Selector NewVisibleFunctionTable = "newVisibleFunctionTableWithDescriptor:stage:";

    public static readonly Selector ObjectThreadExecutionWidth = "objectThreadExecutionWidth";

    public static readonly Selector Reflection = "reflection";

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = "requiredThreadsPerMeshThreadgroup";

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = "requiredThreadsPerObjectThreadgroup";

    public static readonly Selector RequiredThreadsPerTileThreadgroup = "requiredThreadsPerTileThreadgroup";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";
}
