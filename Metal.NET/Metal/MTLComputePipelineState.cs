namespace Metal.NET;

public class MTLComputePipelineState : IDisposable
{
    public MTLComputePipelineState(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLComputePipelineState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputePipelineState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePipelineState(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public MTLDevice Device
    {
        get => new MTLDevice(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Device));
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Label));
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.MaxTotalThreadsPerThreadgroup);
    }

    public MTLComputePipelineReflection Reflection
    {
        get => new MTLComputePipelineReflection(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.Reflection));
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLComputePipelineStateSelector.ShaderValidation));
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

    public MTLFunctionHandle FunctionHandle(NSString name)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, name.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, function.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        MTLFunctionHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, function.NativePtr));

        return result;
    }

    public nuint ImageblockMemoryLength(MTLSize imageblockDimensions)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineStateSelector.ImageblockMemoryLength, imageblockDimensions);

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
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewComputePipelineStateError, functions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        MTLIntersectionFunctionTable result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewIntersectionFunctionTable, descriptor.NativePtr));

        return result;
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        MTLVisibleFunctionTable result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineStateSelector.NewVisibleFunctionTable, descriptor.NativePtr));

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

    public static readonly Selector FunctionHandle = Selector.Register("functionHandle:");

    public static readonly Selector ImageblockMemoryLength = Selector.Register("imageblockMemoryLength:");

    public static readonly Selector NewComputePipelineStateWithBinaryFunctionsError = Selector.Register("newComputePipelineStateWithBinaryFunctions:error:");

    public static readonly Selector NewComputePipelineStateError = Selector.Register("newComputePipelineState:error:");

    public static readonly Selector NewIntersectionFunctionTable = Selector.Register("newIntersectionFunctionTable:");

    public static readonly Selector NewVisibleFunctionTable = Selector.Register("newVisibleFunctionTable:");
}
