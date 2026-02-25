namespace Metal.NET;

public class MTLComputePipelineState(nint nativePtr, bool ownsReference) : MTLAllocation(nativePtr, ownsReference), INativeObject<MTLComputePipelineState>
{
    public static new MTLComputePipelineState Null { get; } = new(0, false);

    public static new MTLComputePipelineState Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Device);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLComputePipelineStateBindings.GpuResourceID);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Label);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    public MTLComputePipelineReflection Reflection
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Reflection);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLComputePipelineStateBindings.RequiredThreadsPerThreadgroup);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.ShaderValidation);
    }

    public nuint StaticThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.StaticThreadgroupMemoryLength);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineStateBindings.SupportIndirectCommandBuffers);
    }

    public nuint ThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ThreadExecutionWidth);
    }

    public MTLFunctionHandle FunctionHandle(NSString name)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.FunctionHandle, name.NativePtr);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithFunction, function.NativePtr);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLComputePipelineState NewComputePipelineStateWithBinaryFunctions(MTL4BinaryFunction[] additionalBinaryFunctions, out NSError error)
    {
        nint pAdditionalBinaryFunctions = NSArray.FromArray(additionalBinaryFunctions);

        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineStateWithBinaryFunctions, pAdditionalBinaryFunctions, out nint errorPtr);

        error = new(errorPtr, false);

        ObjectiveCRuntime.Release(pAdditionalBinaryFunctions);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
    }

    public MTLComputePipelineState NewComputePipelineState(MTLFunction[] functions, out NSError error)
    {
        nint pFunctions = NSArray.FromArray(functions);

        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineState, pFunctions, out nint errorPtr);

        error = new(errorPtr, false);

        ObjectiveCRuntime.Release(pFunctions);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewIntersectionFunctionTable, descriptor.NativePtr);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewVisibleFunctionTable, descriptor.NativePtr);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
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
