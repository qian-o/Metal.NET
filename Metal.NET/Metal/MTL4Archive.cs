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

    public MTLComputePipelineState MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewComputePipelineStateWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewComputePipelineStateWithDescriptor_DynamicLinkingDescriptor_Error, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewRenderPipelineStateWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewRenderPipelineStateWithDescriptor_DynamicLinkingDescriptor_Error, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4BinaryFunction MakeBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewBinaryFunctionWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTL4ArchiveBindings
{
    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunctionWithDescriptor_Error = "newBinaryFunctionWithDescriptor:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptor_DynamicLinkingDescriptor_Error = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptor_Error = "newComputePipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor_DynamicLinkingDescriptor_Error = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptor_Error = "newRenderPipelineStateWithDescriptor:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
