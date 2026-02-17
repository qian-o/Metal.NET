#nullable enable

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
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, name.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, function.NativePtr));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineStateSelector.FunctionHandle, function.NativePtr));

        return result;
    }

    public MTLComputePipelineState NewComputePipelineStateWithBinaryFunctions(NSArray additionalBinaryFunctions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineStateSelector.NewComputePipelineStateWithBinaryFunctionsError, additionalBinaryFunctions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(NSArray functions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineStateSelector.NewComputePipelineStateError, functions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
    {
        var result = new MTLIntersectionFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineStateSelector.NewIntersectionFunctionTable, descriptor.NativePtr));

        return result;
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
    {
        var result = new MTLVisibleFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePipelineStateSelector.NewVisibleFunctionTable, descriptor.NativePtr));

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
