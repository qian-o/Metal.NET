namespace Metal.NET;

public class MTLComputePipelineState(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTLComputePipelineState>
{
    #region INativeObject
    public static new MTLComputePipelineState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePipelineState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Device);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLComputePipelineStateBindings.GpuResourceID);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Label);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    public MTLComputePipelineReflection Reflection
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Reflection);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLComputePipelineStateBindings.RequiredThreadsPerThreadgroup);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineStateBindings.ShaderValidation);
    }

    public nuint StaticThreadgroupMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.StaticThreadgroupMemoryLength);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineStateBindings.SupportIndirectCommandBuffers);
    }

    public nuint ThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ThreadExecutionWidth);
    }

    public MTLFunctionHandle FunctionHandle(NSString name)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandle, name.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLComputePipelineState NewComputePipelineStateWithBinaryFunctions(MTL4BinaryFunction[] additionalBinaryFunctions, out NSError error)
    {
        nint pAdditionalBinaryFunctions = NSArray.FromArray(additionalBinaryFunctions);

        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineStateWithBinaryFunctions, pAdditionalBinaryFunctions, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        ObjectiveC.Release(pAdditionalBinaryFunctions);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction[] functions, out NSError error)
    {
        nint pFunctions = NSArray.FromArray(functions);

        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineState, pFunctions, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        ObjectiveC.Release(pFunctions);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewIntersectionFunctionTable, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewVisibleFunctionTable, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLComputePipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionHandle = "functionHandleWithName:";

    public static readonly Selector FunctionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:";

    public static readonly Selector FunctionHandleWithFunction = "functionHandleWithFunction:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ImageblockMemoryLength = "imageblockMemoryLengthForDimensions:";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector NewComputePipelineState = "newComputePipelineStateWithAdditionalBinaryFunctions:error:";

    public static readonly Selector NewComputePipelineStateWithBinaryFunctions = "newComputePipelineStateWithBinaryFunctions:error:";

    public static readonly Selector NewIntersectionFunctionTable = "newIntersectionFunctionTableWithDescriptor:";

    public static readonly Selector NewVisibleFunctionTable = "newVisibleFunctionTableWithDescriptor:";

    public static readonly Selector Reflection = "reflection";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector StaticThreadgroupMemoryLength = "staticThreadgroupMemoryLength";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadExecutionWidth = "threadExecutionWidth";
}
