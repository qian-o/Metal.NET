namespace Metal.NET;

public class MTL4Archive(nint nativePtr) : NativeObject(nativePtr)
{

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArchiveSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4BinaryFunction? NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewBinaryFunction, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTL4BinaryFunction>(ptr);
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewComputePipelineState, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLComputePipelineState>(ptr);
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewComputePipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLComputePipelineState>(ptr);
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewRenderPipelineState, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLRenderPipelineState>(ptr);
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewRenderPipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLRenderPipelineState>(ptr);
    }
}

file static class MTL4ArchiveSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector NewBinaryFunction = Selector.Register("newBinaryFunctionWithDescriptor:error:");

    public static readonly Selector NewComputePipelineState = Selector.Register("newComputePipelineStateWithDescriptor:error:");

    public static readonly Selector NewRenderPipelineState = Selector.Register("newRenderPipelineStateWithDescriptor:error:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
