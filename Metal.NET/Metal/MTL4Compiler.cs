namespace Metal.NET;

public class MTL4Compiler : IDisposable
{
    public MTL4Compiler(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4Compiler()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.Label));
    }

    public MTL4PipelineDataSetSerializer PipelineDataSetSerializer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.PipelineDataSetSerializer));
    }

    public static implicit operator nint(MTL4Compiler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4Compiler(nint value)
    {
        return new(value);
    }

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTL4BinaryFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewBinaryFunctionWithDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibraryWithURLCompletionHandler, library.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError? error)
    {
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibraryWithURLCompletionHandler, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewLibraryWithDescriptorCompletionHandler, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError? error)
    {
        MTL4MachineLearningPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewMachineLearningPipelineStateWithDescriptorCompletionHandler, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateBySpecializationWithDescriptorPipelineCompletionHandler, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
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

    public static readonly Selector NewBinaryFunctionWithDescriptorCompilerTaskOptionsCompletionHandler = Selector.Register("newBinaryFunctionWithDescriptor:compilerTaskOptions:completionHandler:");

    public static readonly Selector NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler = Selector.Register("newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:");

    public static readonly Selector NewDynamicLibraryWithURLCompletionHandler = Selector.Register("newDynamicLibraryWithURL:completionHandler:");

    public static readonly Selector NewLibraryWithDescriptorCompletionHandler = Selector.Register("newLibraryWithDescriptor:completionHandler:");

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptorCompletionHandler = Selector.Register("newMachineLearningPipelineStateWithDescriptor:completionHandler:");

    public static readonly Selector NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler = Selector.Register("newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:");

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptorPipelineCompletionHandler = Selector.Register("newRenderPipelineStateBySpecializationWithDescriptor:pipeline:completionHandler:");
}
