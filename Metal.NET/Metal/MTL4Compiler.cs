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

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewBinaryFunction, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTL4NewBinaryFunctionCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewBinaryFunctionWithDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewComputePipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibrary, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLDynamicLibrary NewDynamicLibrary(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURLerror, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewDynamicLibrary(MTLLibrary library, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibrarycompletionHandler, library.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewDynamicLibrary(NSURL url, MTLNewDynamicLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewDynamicLibraryWithURLcompletionHandler, url.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewLibrary, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewLibrary(MTL4LibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewLibraryWithDescriptorcompletionHandler, descriptor.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineState, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, MTL4NewMachineLearningPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineStateWithDescriptorcompletionHandler, descriptor.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionscompletionHandler, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecialization, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4CompilerTask NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, MTLNewRenderPipelineStateCompletionHandler completionHandler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecializationWithDescriptorpipelinecompletionHandler, descriptor.NativePtr, pipeline.NativePtr, completionHandler);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTL4CompilerBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunction = "newBinaryFunctionWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewBinaryFunctionWithDescriptorcompilerTaskOptionscompletionHandler = "newBinaryFunctionWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineState = "newComputePipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptorcompilerTaskOptionscompletionHandler = "newComputePipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionscompletionHandler = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewDynamicLibrary = "newDynamicLibrary:error:";

    public static readonly Selector NewDynamicLibrarycompletionHandler = "newDynamicLibrary:completionHandler:";

    public static readonly Selector NewDynamicLibraryWithURLcompletionHandler = "newDynamicLibraryWithURL:completionHandler:";

    public static readonly Selector NewDynamicLibraryWithURLerror = "newDynamicLibraryWithURL:error:";

    public static readonly Selector NewLibrary = "newLibraryWithDescriptor:error:";

    public static readonly Selector NewLibraryWithDescriptorcompletionHandler = "newLibraryWithDescriptor:completionHandler:";

    public static readonly Selector NewMachineLearningPipelineState = "newMachineLearningPipelineStateWithDescriptor:error:";

    public static readonly Selector NewMachineLearningPipelineStateWithDescriptorcompletionHandler = "newMachineLearningPipelineStateWithDescriptor:completionHandler:";

    public static readonly Selector NewRenderPipelineState = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewRenderPipelineStateBySpecialization = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:";

    public static readonly Selector NewRenderPipelineStateBySpecializationWithDescriptorpipelinecompletionHandler = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptorcompilerTaskOptionscompletionHandler = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionscompletionHandler = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:completionHandler:";

    public static readonly Selector NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";
}
