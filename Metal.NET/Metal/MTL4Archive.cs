namespace Metal.NET;

public class MTL4Archive : IDisposable
{
    public MTL4Archive(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
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

    public static implicit operator nint(MTL4Archive value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4Archive(nint value)
    {
        return new(value);
    }

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError? error)
    {
        MTL4BinaryFunction result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewBinaryFunctionWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewComputePipelineStateWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        MTLComputePipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewRenderPipelineStateWithDescriptorError, descriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        MTLRenderPipelineState result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveSelector.NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
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

    public static readonly Selector NewBinaryFunctionWithDescriptorError = Selector.Register("newBinaryFunctionWithDescriptor:error:");

    public static readonly Selector NewComputePipelineStateWithDescriptorError = Selector.Register("newComputePipelineStateWithDescriptor:error:");

    public static readonly Selector NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorError = Selector.Register("newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:error:");

    public static readonly Selector NewRenderPipelineStateWithDescriptorError = Selector.Register("newRenderPipelineStateWithDescriptor:error:");

    public static readonly Selector NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorError = Selector.Register("newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:error:");
}
