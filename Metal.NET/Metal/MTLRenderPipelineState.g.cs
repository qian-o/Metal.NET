#nullable enable

namespace Metal.NET;

public class MTLRenderPipelineState : IDisposable
{
    public MTLRenderPipelineState(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPipelineState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPipelineState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPipelineState(nint value)
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

    public MTLFunctionHandle FunctionHandle(NSString name, uint stage)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.FunctionHandleStage, name.NativePtr, (nint)stage));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function, uint stage)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.FunctionHandleStage, function.NativePtr, (nint)stage));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function, uint stage)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.FunctionHandleStage, function.NativePtr, (nint)stage));

        return result;
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, uint stage)
    {
        var result = new MTLIntersectionFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewIntersectionFunctionTableStage, descriptor.NativePtr, (nint)stage));

        return result;
    }

    public MTL4PipelineDescriptor NewRenderPipelineDescriptor()
    {
        var result = new MTL4PipelineDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineDescriptor));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4RenderPipelineBinaryFunctionsDescriptor binaryFunctionsDescriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineStateError, binaryFunctionsDescriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineStateError, additionalBinaryFunctions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, uint stage)
    {
        var result = new MTLVisibleFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewVisibleFunctionTableStage, descriptor.NativePtr, (nint)stage));

        return result;
    }

}

file class MTLRenderPipelineStateSelector
{
    public static readonly Selector FunctionHandleStage = Selector.Register("functionHandle:stage:");
    public static readonly Selector NewIntersectionFunctionTableStage = Selector.Register("newIntersectionFunctionTable:stage:");
    public static readonly Selector NewRenderPipelineDescriptor = Selector.Register("newRenderPipelineDescriptor");
    public static readonly Selector NewRenderPipelineStateError = Selector.Register("newRenderPipelineState:error:");
    public static readonly Selector NewVisibleFunctionTableStage = Selector.Register("newVisibleFunctionTable:stage:");
}
