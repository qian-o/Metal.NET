#nullable enable

namespace Metal.NET;

file class MTLRenderPipelineStateSelector
{
    public static readonly Selector FunctionHandle_stage_ = Selector.Register("functionHandle:stage:");
    public static readonly Selector NewIntersectionFunctionTable_stage_ = Selector.Register("newIntersectionFunctionTable:stage:");
    public static readonly Selector NewRenderPipelineDescriptor = Selector.Register("newRenderPipelineDescriptor");
    public static readonly Selector NewRenderPipelineState_error_ = Selector.Register("newRenderPipelineState:error:");
    public static readonly Selector NewVisibleFunctionTable_stage_ = Selector.Register("newVisibleFunctionTable:stage:");
}

public class MTLRenderPipelineState : IDisposable
{
    public MTLRenderPipelineState(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLFunctionHandle FunctionHandle(NSString name, nuint stage)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.FunctionHandle_stage_, name.NativePtr, (nint)stage));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function, nuint stage)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.FunctionHandle_stage_, function.NativePtr, (nint)stage));

        return result;
    }

    public MTLFunctionHandle FunctionHandle(MTLFunction function, nuint stage)
    {
        var result = new MTLFunctionHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.FunctionHandle_stage_, function.NativePtr, (nint)stage));

        return result;
    }

    public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, nuint stage)
    {
        var result = new MTLIntersectionFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewIntersectionFunctionTable_stage_, descriptor.NativePtr, (nint)stage));

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
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineState_error_, binaryFunctionsDescriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewRenderPipelineState_error_, additionalBinaryFunctions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, nuint stage)
    {
        var result = new MTLVisibleFunctionTable(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPipelineStateSelector.NewVisibleFunctionTable_stage_, descriptor.NativePtr, (nint)stage));

        return result;
    }

}
