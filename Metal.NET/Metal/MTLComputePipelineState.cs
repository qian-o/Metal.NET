namespace Metal.NET;

public class MTLComputePipelineState(nint nativePtr) : MTLAllocation(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Device));
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLComputePipelineStateSelector.GpuResourceID);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Label));
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.MaxTotalThreadsPerThreadgroup);
    }

    public MTLComputePipelineReflection? Reflection
    {
        get => GetNullableObject<MTLComputePipelineReflection>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Reflection));
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLComputePipelineStateSelector.RequiredThreadsPerThreadgroup);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.ShaderValidation);
    }

    public nuint StaticThreadgroupMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.StaticThreadgroupMemoryLength);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineStateSelector.SupportIndirectCommandBuffers);
    }

    public nuint ThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.ThreadExecutionWidth);
    }

    public MTLFunctionHandle? FunctionHandle(NSString name)
    {
        return GetNullableObject<MTLFunctionHandle>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, name.NativePtr));
    }

    public MTLFunctionHandle? FunctionHandle(MTL4BinaryFunction function)
    {
        return GetNullableObject<MTLFunctionHandle>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, function.NativePtr));
    }

    public MTLFunctionHandle? FunctionHandle(MTLFunction function)
    {
        return GetNullableObject<MTLFunctionHandle>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, function.NativePtr));
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLComputePipelineState? NewComputePipelineStateWithBinaryFunctions(NSArray additionalBinaryFunctions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewComputePipelineStateWithBinaryFunctions, additionalBinaryFunctions.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLComputePipelineState>(ptr);
    }

    public MTLComputePipelineState? NewComputePipelineState(NSArray functions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewComputePipelineState, functions.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLComputePipelineState>(ptr);
    }

    public MTLIntersectionFunctionTable? NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        return GetNullableObject<MTLIntersectionFunctionTable>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewIntersectionFunctionTable, descriptor.NativePtr));
    }

    public MTLVisibleFunctionTable? NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        return GetNullableObject<MTLVisibleFunctionTable>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewVisibleFunctionTable, descriptor.NativePtr));
    }
}

file static class MTLComputePipelineStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionHandle = Selector.Register("functionHandleWithName:");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector ImageblockMemoryLength = Selector.Register("imageblockMemoryLengthForDimensions:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector NewComputePipelineState = Selector.Register("newComputePipelineStateWithAdditionalBinaryFunctions:error:");

    public static readonly Selector NewComputePipelineStateWithBinaryFunctions = Selector.Register("newComputePipelineStateWithBinaryFunctions:error:");

    public static readonly Selector NewIntersectionFunctionTable = Selector.Register("newIntersectionFunctionTableWithDescriptor:");

    public static readonly Selector NewVisibleFunctionTable = Selector.Register("newVisibleFunctionTableWithDescriptor:");

    public static readonly Selector Reflection = Selector.Register("reflection");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector StaticThreadgroupMemoryLength = Selector.Register("staticThreadgroupMemoryLength");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector ThreadExecutionWidth = Selector.Register("threadExecutionWidth");
}
