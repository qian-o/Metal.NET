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
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewLibraryWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary MakeDynamicLibrary(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibrary_Error, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary MakeDynamicLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURL_Error, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptor_CompilerTaskOptions_Error, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptor_DynamicLinkingDescriptor_CompilerTaskOptions_Error, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptor_CompilerTaskOptions_Error, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptor_DynamicLinkingDescriptor_CompilerTaskOptions_Error, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecializationWithDescriptor_Pipeline_Error, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4BinaryFunction MakeBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewBinaryFunctionWithDescriptor_CompilerTaskOptions_Error, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeLibrary(MTL4LibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewLibraryWithDescriptor_CompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeDynamicLibrary(MTLLibrary library, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibrary_CompletionHandler, library.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeDynamicLibrary(NSURL url, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURL_CompletionHandler, url.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptor_CompilerTaskOptions_CompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptor_DynamicLinkingDescriptor_CompilerTaskOptions_CompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptor_CompilerTaskOptions_CompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptor_DynamicLinkingDescriptor_CompilerTaskOptions_CompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecializationWithDescriptor_Pipeline_CompletionHandler, descriptor.NativePtr, pipeline.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTL4NewBinaryFunctionCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewBinaryFunctionWithDescriptor_CompilerTaskOptions_CompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4MachineLearningPipelineState MakeMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineStateWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask MakeMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, MTL4NewMachineLearningPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineStateWithDescriptor_CompletionHandler, descriptor.NativePtr, completionHandler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTL4CompilerBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunctionWithDescriptor_CompilerTaskOptions_CompletionHandler = "newBinaryFunctionWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewBinaryFunctionWithDescriptor_CompilerTaskOptions_Error = "newBinaryFunctionWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptor_CompilerTaskOptions_CompletionHandler = "newComputePipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptor_CompilerTaskOptions_Error = "newComputePipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptor_DynamicLinkingDescriptor_CompilerTaskOptions_CompletionHandler = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptor_DynamicLinkingDescriptor_CompilerTaskOptions_Error = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewDynamicLibrary_CompletionHandler = "newDynamicLibrary:completionHandler:";

    public static readonly Selector NewDynamicLibrary_Error = "newDynamicLibrary:error:";

    public static readonly Selector NewDynamicLibraryWithURL_CompletionHandler = "newDynamicLibraryWithURL:completionHandler:";

    public static readonly Selector NewDynamicLibraryWithURL_Error = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewLibraryWithDescriptor_CompletionHandler = "newLibraryWithDescriptor:completionHandler:";

    public static readonly Selector NewLibraryWithDescriptor_Error = "newLibraryWithDescriptor:error:";

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptor_CompletionHandler = "newMachineLearningPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptor_Error = "newMachineLearningPipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptor_Pipeline_CompletionHandler = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:completionHandler:";

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptor_Pipeline_Error = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor_CompilerTaskOptions_CompletionHandler = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor_CompilerTaskOptions_Error = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor_DynamicLinkingDescriptor_CompilerTaskOptions_CompletionHandler = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor_DynamicLinkingDescriptor_CompilerTaskOptions_Error = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";
}
