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
        MTL4BinaryFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewBinaryFunctionWithDescriptorCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineStateWithDescriptorCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

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
        MTLDynamicLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibraryWithURLError, url.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, out NSError? error)
    {
        MTLLibrary result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewLibraryWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError? error)
    {
        MTL4MachineLearningPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewMachineLearningPipelineStateWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateWithDescriptorCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateBySpecializationWithDescriptorPipelineError, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr));

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

    public static readonly Selector NewBinaryFunctionWithDescriptorCompilerTaskOptionsError = Selector.Register("newBinaryFunctionWithDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewComputePipelineStateWithDescriptorCompilerTaskOptionsError = Selector.Register("newComputePipelineStateWithDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError = Selector.Register("newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewDynamicLibraryError = Selector.Register("newDynamicLibrary:error:");

    public static readonly Selector NewDynamicLibraryWithURLError = Selector.Register("newDynamicLibraryWithURL:error:");

    public static readonly Selector NewLibraryWithDescriptorError = Selector.Register("newLibraryWithDescriptor:error:");

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptorError = Selector.Register("newMachineLearningPipelineStateWithDescriptor:error:");

    public static readonly Selector NewRenderPipelineStateWithDescriptorCompilerTaskOptionsError = Selector.Register("newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError = Selector.Register("newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptorPipelineError = Selector.Register("newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:");
}
