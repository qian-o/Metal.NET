namespace Metal.NET;

public class MTL4Compiler(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.Label));
    }

    public MTL4PipelineDataSetSerializer? PipelineDataSetSerializer
    {
        get => GetNullableObject<MTL4PipelineDataSetSerializer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.PipelineDataSetSerializer));
    }

    public MTL4BinaryFunction? NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewBinaryFunction, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4BinaryFunction>(ptr);
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLComputePipelineState>(ptr);
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewComputePipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLComputePipelineState>(ptr);
    }

    public MTLDynamicLibrary? NewDynamicLibrary(MTLLibrary library, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibrary, library.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLDynamicLibrary>(ptr);
    }

    public MTLDynamicLibrary? NewDynamicLibrary(NSURL url, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewDynamicLibrary, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLDynamicLibrary>(ptr);
    }

    public MTLLibrary? NewLibrary(MTL4LibraryDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewLibrary, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLLibrary>(ptr);
    }

    public MTL4MachineLearningPipelineState? NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewMachineLearningPipelineState, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4MachineLearningPipelineState>(ptr);
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineState, descriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLRenderPipelineState>(ptr);
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, compilerTaskOptions.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLRenderPipelineState>(ptr);
    }

    public MTLRenderPipelineState? NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerSelector.NewRenderPipelineStateBySpecialization, descriptor.NativePtr, pipeline.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLRenderPipelineState>(ptr);
    }
}

file static class MTL4CompilerSelector
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
