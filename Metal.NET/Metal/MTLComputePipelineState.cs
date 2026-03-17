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

    public NSString Label
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Label);
    }

    public MTLComputePipelineReflection Reflection
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Reflection);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLComputePipelineStateBindings.Device);
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

    public MTLFunctionHandle FunctionHandleWithName(NSString name)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithName, name.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFunctionHandle FunctionHandleWithBinaryFunction(MTL4BinaryFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithBinaryFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public nuint ImageblockMemoryLengthForDimensions(MTLSize imageblockDimensions)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ImageblockMemoryLengthForDimensions, imageblockDimensions);
    }

    public MTLFunctionHandle FunctionHandleWithFunction(MTLFunction function)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.FunctionHandleWithFunction, function.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTableWithDescriptor(MTLVisibleFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewVisibleFunctionTableWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTableWithDescriptor(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineStateBindings.NewIntersectionFunctionTableWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLComputePipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:";

    public static readonly Selector FunctionHandleWithFunction = "functionHandleWithFunction:";

    public static readonly Selector FunctionHandleWithName = "functionHandleWithName:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector ImageblockMemoryLengthForDimensions = "imageblockMemoryLengthForDimensions:";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector NewIntersectionFunctionTableWithDescriptor = "newIntersectionFunctionTableWithDescriptor:";

    public static readonly Selector NewVisibleFunctionTableWithDescriptor = "newVisibleFunctionTableWithDescriptor:";

    public static readonly Selector Reflection = "reflection";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector StaticThreadgroupMemoryLength = "staticThreadgroupMemoryLength";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadExecutionWidth = "threadExecutionWidth";
}
