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
    public static readonly Selector FunctionHandle = Selector.Register("functionHandle:");

    public static readonly Selector NewComputePipelineStateWithBinaryFunctionsError = Selector.Register("newComputePipelineStateWithBinaryFunctions:error:");

    public static readonly Selector NewComputePipelineStateError = Selector.Register("newComputePipelineState:error:");

    public static readonly Selector NewIntersectionFunctionTable = Selector.Register("newIntersectionFunctionTable:");

    public static readonly Selector NewVisibleFunctionTable = Selector.Register("newVisibleFunctionTable:");
}
