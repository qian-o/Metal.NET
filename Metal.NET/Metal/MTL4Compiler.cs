namespace Metal.NET;

public class MTL4Compiler : IDisposable
{
    public MTL4Compiler(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4Compiler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.Device));

    public NSString Label => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.Label));

    public MTL4PipelineDataSetSerializer PipelineDataSetSerializer => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.PipelineDataSetSerializer));

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTL4BinaryFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewBinaryFunctionCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineStateCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineStateDynamicLinkingDescriptorCompilerTaskOptionsError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewComputePipelineState(MTL4ComputePipelineDescriptor pDescriptor, MTL4CompilerTaskOptions options, nint function)
    {
        MTL4CompilerTask result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineStateOptionsFunction, pDescriptor.NativePtr, options.NativePtr, function));

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibraryError, library.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError? error)
    {
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibraryError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewDynamicLibrary(MTLLibrary pLibrary, nint function)
    {
        MTL4CompilerTask result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibraryFunction, pLibrary.NativePtr, function));

        return result;
    }

    public MTL4CompilerTask NewDynamicLibrary(NSURL pURL, nint function)
    {
        MTL4CompilerTask result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibraryFunction, pURL.NativePtr, function));

        return result;
    }

    public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewLibraryError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewLibrary(MTL4LibraryDescriptor pDescriptor, nint function)
    {
        MTL4CompilerTask result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewLibraryFunction, pDescriptor.NativePtr, function));

        return result;
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError? error)
    {
        MTL4MachineLearningPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewMachineLearningPipelineStateError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor pDescriptor, nint function)
    {
        MTL4CompilerTask result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewMachineLearningPipelineStateFunction, pDescriptor.NativePtr, function));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateDynamicLinkingDescriptorCompilerTaskOptionsError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewRenderPipelineState(MTL4PipelineDescriptor pDescriptor, MTL4CompilerTaskOptions options, nint function)
    {
        MTL4CompilerTask result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateOptionsFunction, pDescriptor.NativePtr, options.NativePtr, function));

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateBySpecializationPipelineError, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4CompilerTask NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor pDescriptor, MTLRenderPipelineState pPipeline, nint function)
    {
        MTL4CompilerTask result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateBySpecializationPPipelineFunction, pDescriptor.NativePtr, pPipeline.NativePtr, function));

        return result;
    }

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

}

file class MTL4CompilerSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PipelineDataSetSerializer = Selector.Register("pipelineDataSetSerializer");

    public static readonly Selector NewBinaryFunctionCompilerTaskOptionsError = Selector.Register("newBinaryFunction:compilerTaskOptions:error:");

    public static readonly Selector NewComputePipelineStateCompilerTaskOptionsError = Selector.Register("newComputePipelineState:compilerTaskOptions:error:");

    public static readonly Selector NewComputePipelineStateDynamicLinkingDescriptorCompilerTaskOptionsError = Selector.Register("newComputePipelineState:dynamicLinkingDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewComputePipelineStateOptionsFunction = Selector.Register("newComputePipelineState:options:function:");

    public static readonly Selector NewDynamicLibraryError = Selector.Register("newDynamicLibrary:error:");

    public static readonly Selector NewDynamicLibraryFunction = Selector.Register("newDynamicLibrary:function:");

    public static readonly Selector NewLibraryError = Selector.Register("newLibrary:error:");

    public static readonly Selector NewLibraryFunction = Selector.Register("newLibrary:function:");

    public static readonly Selector NewMachineLearningPipelineStateError = Selector.Register("newMachineLearningPipelineState:error:");

    public static readonly Selector NewMachineLearningPipelineStateFunction = Selector.Register("newMachineLearningPipelineState:function:");

    public static readonly Selector NewRenderPipelineStateCompilerTaskOptionsError = Selector.Register("newRenderPipelineState:compilerTaskOptions:error:");

    public static readonly Selector NewRenderPipelineStateDynamicLinkingDescriptorCompilerTaskOptionsError = Selector.Register("newRenderPipelineState:dynamicLinkingDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewRenderPipelineStateOptionsFunction = Selector.Register("newRenderPipelineState:options:function:");

    public static readonly Selector NewRenderPipelineStateBySpecializationPipelineError = Selector.Register("newRenderPipelineStateBySpecialization:pipeline:error:");

    public static readonly Selector NewRenderPipelineStateBySpecializationPPipelineFunction = Selector.Register("newRenderPipelineStateBySpecialization:pPipeline:function:");
}
