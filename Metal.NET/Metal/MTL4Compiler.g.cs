#nullable enable

namespace Metal.NET;

file class MTL4CompilerSelector
{
    public static readonly Selector NewBinaryFunction_compilerTaskOptions_error_ = Selector.Register("newBinaryFunction:compilerTaskOptions:error:");
    public static readonly Selector NewComputePipelineState_compilerTaskOptions_error_ = Selector.Register("newComputePipelineState:compilerTaskOptions:error:");
    public static readonly Selector NewComputePipelineState_dynamicLinkingDescriptor_compilerTaskOptions_error_ = Selector.Register("newComputePipelineState:dynamicLinkingDescriptor:compilerTaskOptions:error:");
    public static readonly Selector NewComputePipelineState_options_function_ = Selector.Register("newComputePipelineState:options:function:");
    public static readonly Selector NewDynamicLibrary_error_ = Selector.Register("newDynamicLibrary:error:");
    public static readonly Selector NewDynamicLibrary_function_ = Selector.Register("newDynamicLibrary:function:");
    public static readonly Selector NewLibrary_error_ = Selector.Register("newLibrary:error:");
    public static readonly Selector NewLibrary_function_ = Selector.Register("newLibrary:function:");
    public static readonly Selector NewMachineLearningPipelineState_error_ = Selector.Register("newMachineLearningPipelineState:error:");
    public static readonly Selector NewMachineLearningPipelineState_function_ = Selector.Register("newMachineLearningPipelineState:function:");
    public static readonly Selector NewRenderPipelineState_compilerTaskOptions_error_ = Selector.Register("newRenderPipelineState:compilerTaskOptions:error:");
    public static readonly Selector NewRenderPipelineState_dynamicLinkingDescriptor_compilerTaskOptions_error_ = Selector.Register("newRenderPipelineState:dynamicLinkingDescriptor:compilerTaskOptions:error:");
    public static readonly Selector NewRenderPipelineState_options_function_ = Selector.Register("newRenderPipelineState:options:function:");
    public static readonly Selector NewRenderPipelineStateBySpecialization_pipeline_error_ = Selector.Register("newRenderPipelineStateBySpecialization:pipeline:error:");
    public static readonly Selector NewRenderPipelineStateBySpecialization_pPipeline_function_ = Selector.Register("newRenderPipelineStateBySpecialization:pPipeline:function:");
}

public class MTL4Compiler : IDisposable
{
    public MTL4Compiler(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4Compiler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4Compiler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4Compiler(nint value)
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

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4BinaryFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewBinaryFunction_compilerTaskOptions_error_, descriptor.NativePtr, compilerTaskOptions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewComputePipelineState_compilerTaskOptions_error_, descriptor.NativePtr, compilerTaskOptions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewComputePipelineState_dynamicLinkingDescriptor_compilerTaskOptions_error_, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewComputePipelineState(MTL4ComputePipelineDescriptor pDescriptor, MTL4CompilerTaskOptions options, nint function)
    {
        var result = new MTL4CompilerTask(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewComputePipelineState_options_function_, pDescriptor.NativePtr, options.NativePtr, function));

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLDynamicLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewDynamicLibrary_error_, library.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLDynamicLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewDynamicLibrary_error_, url.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewDynamicLibrary(MTLLibrary pLibrary, nint function)
    {
        var result = new MTL4CompilerTask(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewDynamicLibrary_function_, pLibrary.NativePtr, function));

        return result;
    }

    public MTL4CompilerTask NewDynamicLibrary(NSURL pURL, nint function)
    {
        var result = new MTL4CompilerTask(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewDynamicLibrary_function_, pURL.NativePtr, function));

        return result;
    }

    public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLLibrary(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewLibrary_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewLibrary(MTL4LibraryDescriptor pDescriptor, nint function)
    {
        var result = new MTL4CompilerTask(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewLibrary_function_, pDescriptor.NativePtr, function));

        return result;
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4MachineLearningPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewMachineLearningPipelineState_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor pDescriptor, nint function)
    {
        var result = new MTL4CompilerTask(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewMachineLearningPipelineState_function_, pDescriptor.NativePtr, function));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewRenderPipelineState_compilerTaskOptions_error_, descriptor.NativePtr, compilerTaskOptions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewRenderPipelineState_dynamicLinkingDescriptor_compilerTaskOptions_error_, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewRenderPipelineState(MTL4PipelineDescriptor pDescriptor, MTL4CompilerTaskOptions options, nint function)
    {
        var result = new MTL4CompilerTask(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewRenderPipelineState_options_function_, pDescriptor.NativePtr, options.NativePtr, function));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateBySpecialization_pipeline_error_, descriptor.NativePtr, pipeline.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor pDescriptor, MTLRenderPipelineState pPipeline, nint function)
    {
        var result = new MTL4CompilerTask(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateBySpecialization_pPipeline_function_, pDescriptor.NativePtr, pPipeline.NativePtr, function));

        return result;
    }

}
