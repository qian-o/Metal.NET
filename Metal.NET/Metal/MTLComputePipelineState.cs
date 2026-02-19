namespace Metal.NET;

public class MTLComputePipelineState(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty<MTLDevice>(ref field, MTLComputePipelineStateBindings.Device);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLComputePipelineStateBindings.GpuResourceID);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLComputePipelineStateBindings.Label);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    public MTLComputePipelineReflection? Reflection
    {
        get => GetProperty<MTLComputePipelineReflection>(ref field, MTLComputePipelineStateBindings.Reflection);
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

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineStateBindings.SupportIndirectCommandBuffers);
    }

    public nuint ThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ThreadExecutionWidth);
    }

    public MTLFunctionHandle? FunctionHandle(NSString name)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.FunctionHandle, name.NativePtr);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : null;
    }

    public MTLFunctionHandle? FunctionHandle(MTL4BinaryFunction function)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.FunctionHandle, function.NativePtr);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : null;
    }

    public MTLFunctionHandle? FunctionHandle(MTLFunction function)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.FunctionHandle, function.NativePtr);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : null;
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLComputePipelineState? NewComputePipelineStateWithBinaryFunctions(NSArray additionalBinaryFunctions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineStateWithBinaryFunctions, additionalBinaryFunctions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : null;
    }

    public MTLComputePipelineState? NewComputePipelineState(NSArray functions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineState, functions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : null;
    }

    public MTLIntersectionFunctionTable? NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewIntersectionFunctionTable, descriptor.NativePtr);
        return ptr is not 0 ? new MTLIntersectionFunctionTable(ptr) : null;
    }

    public MTLVisibleFunctionTable? NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewVisibleFunctionTable, descriptor.NativePtr);
        return ptr is not 0 ? new MTLVisibleFunctionTable(ptr) : null;
    }
}

file static class MTLComputePipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionHandle = "functionHandleWithName:";

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
