namespace Metal.NET;

public class MTL4Archive(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4Archive>
{
    #region INativeObject
    public static new MTL4Archive Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4Archive New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTL4ArchiveBindings.Label);
        set => SetProperty(ref field, MTL4ArchiveBindings.SetLabel, value);
    }

    public MTLComputePipelineState NewComputePipelineStateWithDescriptorError(MTL4ComputePipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewComputePipelineStateWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState NewComputePipelineStateWithDescriptorDynamicLinkingDescriptorError(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewComputePipelineStateWithDescriptordynamicLinkingDescriptorerror, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithDescriptorError(MTL4PipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewRenderPipelineStateWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState NewRenderPipelineStateWithDescriptorDynamicLinkingDescriptorError(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorerror, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4BinaryFunction NewBinaryFunctionWithDescriptorError(MTL4BinaryFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewBinaryFunctionWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTL4ArchiveBindings
{
    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunctionWithDescriptor = "newBinaryFunctionWithDescriptor:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptor = "newComputePipelineStateWithDescriptor:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptordynamicLinkingDescriptorerror = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor = "newRenderPipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorerror = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
