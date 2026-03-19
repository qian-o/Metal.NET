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

    public MTLLibrary MakeLibrary(MTL4LibraryDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewLibraryWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary MakeDynamicLibrary(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryError, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary MakeDynamicLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURLError, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecializationWithDescriptorPipelineError, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4BinaryFunction MakeBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewBinaryFunctionWithDescriptorCompilerTaskOptionsError, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeLibrary(MTL4LibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewLibraryWithDescriptorCompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeDynamicLibrary(MTLLibrary library, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryCompletionHandler, library.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeDynamicLibrary(NSURL url, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURLCompletionHandler, url.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecializationWithDescriptorPipelineCompletionHandler, descriptor.NativePtr, pipeline.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTL4NewBinaryFunctionCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewBinaryFunctionWithDescriptorCompilerTaskOptionsCompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4MachineLearningPipelineState MakeMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineStateWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, MTL4NewMachineLearningPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineStateWithDescriptorCompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTL4CompilerBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunctionWithDescriptorCompilerTaskOptionsCompletionHandler = "newBinaryFunctionWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewBinaryFunctionWithDescriptorCompilerTaskOptionsError = "newBinaryFunctionWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler = "newComputePipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptorCompilerTaskOptionsError = "newComputePipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewDynamicLibraryCompletionHandler = "newDynamicLibrary:completionHandler:";

    public static readonly Selector NewDynamicLibraryError = "newDynamicLibrary:error:";

    public static readonly Selector NewDynamicLibraryWithURLCompletionHandler = "newDynamicLibraryWithURL:completionHandler:";

    public static readonly Selector NewDynamicLibraryWithURLError = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewLibraryWithDescriptorCompletionHandler = "newLibraryWithDescriptor:completionHandler:";

    public static readonly Selector NewLibraryWithDescriptorError = "newLibraryWithDescriptor:error:";

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptorCompletionHandler = "newMachineLearningPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptorError = "newMachineLearningPipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptorPipelineCompletionHandler = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:completionHandler:";

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptorPipelineError = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorCompilerTaskOptionsCompletionHandler = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorCompilerTaskOptionsError = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsCompletionHandler = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorCompilerTaskOptionsError = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";
}
