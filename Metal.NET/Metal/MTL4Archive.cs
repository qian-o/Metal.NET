namespace Metal.NET;

public class MTL4Archive : IDisposable
{
    public MTL4Archive(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4Archive()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ArchiveSelector.SetLabel, value.NativePtr);
    }

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError? error)
    {
        MTL4BinaryFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewBinaryFunctionError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewComputePipelineStateError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewComputePipelineStateDynamicLinkingDescriptorError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewRenderPipelineStateError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewRenderPipelineStateDynamicLinkingDescriptorError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public static implicit operator nint(MTL4Archive value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4Archive(nint value)
    {
        return new(value);
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

file class MTL4ArchiveSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector NewBinaryFunctionError = Selector.Register("newBinaryFunction:error:");

    public static readonly Selector NewComputePipelineStateError = Selector.Register("newComputePipelineState:error:");

    public static readonly Selector NewComputePipelineStateDynamicLinkingDescriptorError = Selector.Register("newComputePipelineState:dynamicLinkingDescriptor:error:");

    public static readonly Selector NewRenderPipelineStateError = Selector.Register("newRenderPipelineState:error:");

    public static readonly Selector NewRenderPipelineStateDynamicLinkingDescriptorError = Selector.Register("newRenderPipelineState:dynamicLinkingDescriptor:error:");
}
