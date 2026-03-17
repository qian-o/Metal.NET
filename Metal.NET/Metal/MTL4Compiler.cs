namespace Metal.NET;

public class MTL4Compiler(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4Compiler>
{
    #region INativeObject
    public static new MTL4Compiler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4Compiler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CompilerBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CompilerBindings.Label);
    }

    public MTL4PipelineDataSetSerializer PipelineDataSetSerializer
    {
        get => GetProperty(ref field, MTL4CompilerBindings.PipelineDataSetSerializer);
    }

    public MTLLibrary NewLibraryWithDescriptorError(MTL4LibraryDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewLibraryWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, out NSError error)
    {
        return NewLibraryWithDescriptorError(descriptor, out error);
    }

    public MTLDynamicLibrary NewDynamicLibraryError(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibrary, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError error)
    {
        return NewDynamicLibraryError(library, out error);
    }

    public MTLDynamicLibrary NewDynamicLibraryWithURLError(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError error)
    {
        return NewDynamicLibraryWithURLError(url, out error);
    }

    public MTLComputePipelineState NewComputePipelineStateWithDescriptorCompilerTaskOptionsError(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptor, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        return NewComputePipelineStateWithDescriptorCompilerTaskOptionsError(descriptor, compilerTaskOptions, out error);
    }

    public MTLComputePipelineState NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        return NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError(descriptor, dynamicLinkingDescriptor, compilerTaskOptions, out error);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithDescriptorCompilerTaskOptionsError(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptor, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        return NewRenderPipelineStateWithDescriptorCompilerTaskOptionsError(descriptor, compilerTaskOptions, out error);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        return NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError(descriptor, dynamicLinkingDescriptor, compilerTaskOptions, out error);
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecializationWithDescriptorPipelineError(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecializationWithDescriptor, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError error)
    {
        return NewRenderPipelineStateBySpecializationWithDescriptorPipelineError(descriptor, pipeline, out error);
    }

    public MTL4BinaryFunction NewBinaryFunctionWithDescriptorCompilerTaskOptionsError(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewBinaryFunctionWithDescriptor, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        return NewBinaryFunctionWithDescriptorCompilerTaskOptionsError(descriptor, compilerTaskOptions, out error);
    }

    public MTL4CompilerTask NewLibraryWithDescriptorCompletionHandler(MTL4LibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewLibraryWithDescriptorCompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewLibrary(MTL4LibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        return NewLibraryWithDescriptorCompletionHandler(descriptor, completionHandler);
    }

    public MTL4CompilerTask NewDynamicLibraryCompletionHandler(MTLLibrary library, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryCompletionHandler, library.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewDynamicLibrary(MTLLibrary library, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        return NewDynamicLibraryCompletionHandler(library, completionHandler);
    }

    public MTL4CompilerTask NewDynamicLibraryWithURLCompletionHandler(NSURL url, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURLCompletionHandler, url.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewDynamicLibrary(NSURL url, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        return NewDynamicLibraryWithURLCompletionHandler(url, completionHandler);
    }

    public MTL4CompilerTask NewComputePipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        return NewComputePipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler(descriptor, compilerTaskOptions, completionHandler);
    }

    public MTL4CompilerTask NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        return NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler(descriptor, dynamicLinkingDescriptor, compilerTaskOptions, completionHandler);
    }

    public MTL4CompilerTask NewRenderPipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        return NewRenderPipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler(descriptor, compilerTaskOptions, completionHandler);
    }

    public MTL4CompilerTask NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        return NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler(descriptor, dynamicLinkingDescriptor, compilerTaskOptions, completionHandler);
    }

    public MTL4CompilerTask NewRenderPipelineStateBySpecializationWithDescriptorPipelineCompletionHandler(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecializationWithDescriptorPipelineCompletionHandler, descriptor.NativePtr, pipeline.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        return NewRenderPipelineStateBySpecializationWithDescriptorPipelineCompletionHandler(descriptor, pipeline, completionHandler);
    }

    public MTL4CompilerTask NewBinaryFunctionWithDescriptorCompilerTaskOptionsCompletionHandler(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTL4NewBinaryFunctionCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewBinaryFunctionWithDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTL4NewBinaryFunctionCompletionHandler completionHandler)
    {
        return NewBinaryFunctionWithDescriptorCompilerTaskOptionsCompletionHandler(descriptor, compilerTaskOptions, completionHandler);
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineStateWithDescriptorError(MTL4MachineLearningPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineStateWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError error)
    {
        return NewMachineLearningPipelineStateWithDescriptorError(descriptor, out error);
    }

    public MTL4CompilerTask NewMachineLearningPipelineStateWithDescriptorCompletionHandler(MTL4MachineLearningPipelineDescriptor descriptor, MTL4NewMachineLearningPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineStateWithDescriptorCompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, MTL4NewMachineLearningPipelineStateCompletionHandler completionHandler)
    {
        return NewMachineLearningPipelineStateWithDescriptorCompletionHandler(descriptor, completionHandler);
    }
}

file static class MTL4CompilerBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunctionWithDescriptor = "newBinaryFunctionWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewBinaryFunctionWithDescriptorCompilerTaskOptionsCompletionHandler = "newBinaryFunctionWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptor = "newComputePipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler = "newComputePipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewDynamicLibrary = "newDynamicLibrary:error:";

    public static readonly Selector NewDynamicLibraryCompletionHandler = "newDynamicLibrary:completionHandler:";

    public static readonly Selector NewDynamicLibraryWithURL = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewDynamicLibraryWithURLCompletionHandler = "newDynamicLibraryWithURL:completionHandler:";

    public static readonly Selector NewLibraryWithDescriptor = "newLibraryWithDescriptor:error:";

    public static readonly Selector NewLibraryWithDescriptorCompletionHandler = "newLibraryWithDescriptor:completionHandler:";

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptor = "newMachineLearningPipelineStateWithDescriptor:error:";

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptorCompletionHandler = "newMachineLearningPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptor = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:";

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptorPipelineCompletionHandler = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";
}
