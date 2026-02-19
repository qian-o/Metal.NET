namespace Metal.NET;

public readonly struct MTLComputePipelineState(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLComputePipelineStateBindings.GpuResourceID);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.MaxTotalThreadsPerThreadgroup);
    }

    public MTLComputePipelineReflection? Reflection
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.Reflection);
            return ptr is not 0 ? new MTLComputePipelineReflection(ptr) : default;
        }
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
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : default;
    }

    public MTLFunctionHandle? FunctionHandle(MTL4BinaryFunction function)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.FunctionHandle, function.NativePtr);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : default;
    }

    public MTLFunctionHandle? FunctionHandle(MTLFunction function)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.FunctionHandle, function.NativePtr);
        return ptr is not 0 ? new MTLFunctionHandle(ptr) : default;
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateBindings.ImageblockMemoryLength, imageblockDimensions);
    }

    public MTLComputePipelineState? NewComputePipelineStateWithBinaryFunctions(NSArray additionalBinaryFunctions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineStateWithBinaryFunctions, additionalBinaryFunctions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : default;
    }

    public MTLComputePipelineState? NewComputePipelineState(NSArray functions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewComputePipelineState, functions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : default;
    }

    public MTLIntersectionFunctionTable? NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewIntersectionFunctionTable, descriptor.NativePtr);
        return ptr is not 0 ? new MTLIntersectionFunctionTable(ptr) : default;
    }

    public MTLVisibleFunctionTable? NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateBindings.NewVisibleFunctionTable, descriptor.NativePtr);
        return ptr is not 0 ? new MTLVisibleFunctionTable(ptr) : default;
    }
}

file static class MTLComputePipelineStateBindings
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
