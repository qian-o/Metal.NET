namespace Metal.NET;

public class MTLComputePipelineState(nint nativePtr) : MTLAllocation(nativePtr)
{
    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Device));
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLComputePipelineStateSelector.GpuResourceID);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Label));
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.MaxTotalThreadsPerThreadgroup);
    }

    public MTLComputePipelineReflection Reflection
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Reflection));
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLComputePipelineStateSelector.RequiredThreadsPerThreadgroup);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLComputePipelineStateSelector.ShaderValidation);
    }

    public nuint StaticThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.StaticThreadgroupMemoryLength);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineStateSelector.SupportIndirectCommandBuffers);
    }

    public nuint ThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.ThreadExecutionWidth);
    }

    public static implicit operator nint(MTLComputePipelineState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePipelineState(nint value)
    {
        return new(value);
    }

    public MTLFunctionHandle FunctionHandle(NSString name)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandleWithName, name.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandleWithBinaryFunction, function.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandleWithFunction, function.NativePtr));

        return result;
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.ImageblockMemoryLengthForDimensions, imageblockDimensions);

        return result;
    }

    public MTLComputePipelineState NewComputePipelineStateWithBinaryFunctions(NSArray additionalBinaryFunctions, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewComputePipelineStateWithBinaryFunctionsError, additionalBinaryFunctions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(NSArray functions, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewComputePipelineStateWithAdditionalBinaryFunctionsError, functions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        MTLIntersectionFunctionTable result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewIntersectionFunctionTableWithDescriptor, descriptor.NativePtr));

        return result;
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        MTLVisibleFunctionTable result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewVisibleFunctionTableWithDescriptor, descriptor.NativePtr));

        return result;
    }
}

file class MTLComputePipelineStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector Reflection = Selector.Register("reflection");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector StaticThreadgroupMemoryLength = Selector.Register("staticThreadgroupMemoryLength");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector ThreadExecutionWidth = Selector.Register("threadExecutionWidth");

    public static readonly Selector FunctionHandleWithName = Selector.Register("functionHandleWithName:");

    public static readonly Selector FunctionHandleWithBinaryFunction = Selector.Register("functionHandleWithBinaryFunction:");

    public static readonly Selector FunctionHandleWithFunction = Selector.Register("functionHandleWithFunction:");

    public static readonly Selector ImageblockMemoryLengthForDimensions = Selector.Register("imageblockMemoryLengthForDimensions:");

    public static readonly Selector NewComputePipelineStateWithBinaryFunctionsError = Selector.Register("newComputePipelineStateWithBinaryFunctions:error:");

    public static readonly Selector NewComputePipelineStateWithAdditionalBinaryFunctionsError = Selector.Register("newComputePipelineStateWithAdditionalBinaryFunctions:error:");

    public static readonly Selector NewIntersectionFunctionTableWithDescriptor = Selector.Register("newIntersectionFunctionTableWithDescriptor:");

    public static readonly Selector NewVisibleFunctionTableWithDescriptor = Selector.Register("newVisibleFunctionTableWithDescriptor:");
}
