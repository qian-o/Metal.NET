namespace Metal.NET;

public class MTL4Compiler(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTL4CompilerBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTL4CompilerBindings.Label);
    }

    public MTL4PipelineDataSetSerializer? PipelineDataSetSerializer
    {
        get => GetProperty(ref field, MTL4CompilerBindings.PipelineDataSetSerializer);
    }

    public MTL4BinaryFunction? NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewBinaryFunction, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTL4BinaryFunction(ptr) : null;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewComputePipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : null;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewComputePipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : null;
    }

    public MTLDynamicLibrary? NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewDynamicLibrary, library.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLDynamicLibrary(ptr) : null;
    }

    public MTLDynamicLibrary? NewDynamicLibrary(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewDynamicLibrary, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLDynamicLibrary(ptr) : null;
    }

    public MTLLibrary? NewLibrary(MTL4LibraryDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewLibrary, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLLibrary(ptr) : null;
    }

    public MTL4MachineLearningPipelineState? NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewMachineLearningPipelineState, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTL4MachineLearningPipelineState(ptr) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerBindings.NewRenderPipelineStateBySpecialization, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : null;
    }
}

file static class MTL4CompilerBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunction = "newBinaryFunctionWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewComputePipelineState = "newComputePipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewDynamicLibrary = "newDynamicLibrary:error:";

    public static readonly Selector NewLibrary = "newLibraryWithDescriptor:error:";

    public static readonly Selector NewMachineLearningPipelineState = "newMachineLearningPipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineState = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:";

    public static readonly Selector NewRenderPipelineStateBySpecialization = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";
}
