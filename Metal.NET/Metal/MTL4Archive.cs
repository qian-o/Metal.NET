namespace Metal.NET;

public readonly struct MTL4Archive(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArchiveBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4BinaryFunction? NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewBinaryFunction, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTL4BinaryFunction(ptr) : default;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewComputePipelineState, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : default;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewComputePipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLComputePipelineState(ptr) : default;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewRenderPipelineState, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : default;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewRenderPipelineState, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return ptr is not 0 ? new MTLRenderPipelineState(ptr) : default;
    }
}

file static class MTL4ArchiveBindings
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector NewBinaryFunction = Selector.Register("newBinaryFunctionWithDescriptor:error:");

    public static readonly Selector NewComputePipelineState = Selector.Register("newComputePipelineStateWithDescriptor:error:");

    public static readonly Selector NewRenderPipelineState = Selector.Register("newRenderPipelineStateWithDescriptor:error:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
