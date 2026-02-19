namespace Metal.NET;

public readonly struct MTL4Compiler(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public MTL4PipelineDataSetSerializer? PipelineDataSetSerializer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.PipelineDataSetSerializer);
            return ptr is not 0 ? new MTL4PipelineDataSetSerializer(ptr) : default;
        }
    }

    public MTL4BinaryFunction? NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewBinaryFunction, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4BinaryFunction(ptr) : default;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewComputePipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : default;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewComputePipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : default;
    }

    public MTLDynamicLibrary? NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewDynamicLibrary, library.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLDynamicLibrary(ptr) : default;
    }

    public MTLDynamicLibrary? NewDynamicLibrary(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewDynamicLibrary, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLDynamicLibrary(ptr) : default;
    }

    public MTLLibrary? NewLibrary(MTL4LibraryDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewLibrary, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLLibrary(ptr) : default;
    }

    public MTL4MachineLearningPipelineState? NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineState, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4MachineLearningPipelineState(ptr) : default;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : default;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : default;
    }

    public MTLRenderPipelineState? NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecialization, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : default;
    }
}

file static class MTL4CompilerBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector NewBinaryFunction = Selector.Register("newBinaryFunctionWithDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewComputePipelineState = Selector.Register("newComputePipelineStateWithDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewDynamicLibrary = Selector.Register("newDynamicLibrary:error:");

    public static readonly Selector NewLibrary = Selector.Register("newLibraryWithDescriptor:error:");

    public static readonly Selector NewMachineLearningPipelineState = Selector.Register("newMachineLearningPipelineStateWithDescriptor:error:");

    public static readonly Selector NewRenderPipelineState = Selector.Register("newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:");

    public static readonly Selector NewRenderPipelineStateBySpecialization = Selector.Register("newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:");

    public static readonly Selector PipelineDataSetSerializer = Selector.Register("pipelineDataSetSerializer");
}
