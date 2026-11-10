namespace Metal.NET;

public readonly struct MTLComputePipelineState(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLAllocation(MTLComputePipelineState value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLComputePipelineState value) => new(value.NativePtr);

    public MTLComputePipelineState Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.Label));
    }

    public MTLComputePipelineReflection Reflection
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.Reflection));
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.Device));
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    public nuint ThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ThreadExecutionWidth);
    }

    public nuint StaticThreadgroupMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.StaticThreadgroupMemoryLength);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineStateBindings.SupportIndirectCommandBuffers);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLComputePipelineStateBindings.GpuResourceID);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineStateBindings.ShaderValidation);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLComputePipelineStateBindings.RequiredThreadsPerThreadgroup);
    }

    public MTLForwardProgressUsage ForwardProgressUsage
    {
        get => (MTLForwardProgressUsage)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineStateBindings.ForwardProgressUsage);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.AllocatedSize);
    }

    public MTLFunctionHandle FunctionHandle(NSString name)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithName, name.NativePtr);

        return new(nativePtr);
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        return new(nativePtr);
    }

    public MTLComputePipelineState MakeComputePipelineState(NSArray<MTL4BinaryFunction> additionalBinaryFunctions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineStateWithBinaryFunctions_Error, additionalBinaryFunctions.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ImageblockMemoryLengthForDimensions, imageblockDimensions);
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithFunction, function.NativePtr);

        return new(nativePtr);
    }

    public MTLComputePipelineState MakeComputePipelineStateWithAdditionalBinaryFunctions(NSArray<MTLFunction> functions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineStateWithAdditionalBinaryFunctions_Error, functions.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public MTLVisibleFunctionTable MakeVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewVisibleFunctionTableWithDescriptor, descriptor.NativePtr);

        return new(nativePtr);
    }

    public MTLIntersectionFunctionTable MakeIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewIntersectionFunctionTableWithDescriptor, descriptor.NativePtr);

        return new(nativePtr);
    }

    public nuint RecommendedPersistentThreadgroupsPerGrid(MTLSize threadsPerThreadgroup)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.RecommendedPersistentThreadgroupsPerGridForThreadsPerThreadgroup, threadsPerThreadgroup);
    }
}

file static class MTLComputePipelineStateBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector Device = "device";

    public static readonly Selector ForwardProgressUsage = "forwardProgressUsage";

    public static readonly Selector FunctionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:";

    public static readonly Selector FunctionHandleWithFunction = "functionHandleWithFunction:";

    public static readonly Selector FunctionHandleWithName = "functionHandleWithName:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ImageblockMemoryLengthForDimensions = "imageblockMemoryLengthForDimensions:";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector NewComputePipelineStateWithAdditionalBinaryFunctions_Error = "newComputePipelineStateWithAdditionalBinaryFunctions:error:";

    public static readonly Selector NewComputePipelineStateWithBinaryFunctions_Error = "newComputePipelineStateWithBinaryFunctions:error:";

    public static readonly Selector NewIntersectionFunctionTableWithDescriptor = "newIntersectionFunctionTableWithDescriptor:";

    public static readonly Selector NewVisibleFunctionTableWithDescriptor = "newVisibleFunctionTableWithDescriptor:";

    public static readonly Selector RecommendedPersistentThreadgroupsPerGridForThreadsPerThreadgroup = "recommendedPersistentThreadgroupsPerGridForThreadsPerThreadgroup:";

    public static readonly Selector Reflection = "reflection";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector StaticThreadgroupMemoryLength = "staticThreadgroupMemoryLength";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadExecutionWidth = "threadExecutionWidth";
}
