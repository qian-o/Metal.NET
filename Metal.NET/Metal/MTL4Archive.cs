namespace Metal.NET;

public readonly struct MTL4Archive(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTL4Archive value) => new(value.NativePtr);

    public MTL4Archive Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4ArchiveBindings.SetLabel, value.NativePtr);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewComputePipelineStateWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public MTLComputePipelineState MakeComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewComputePipelineStateWithDescriptor_DynamicLinkingDescriptor_Error, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewRenderPipelineStateWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public MTLRenderPipelineState MakeRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewRenderPipelineStateWithDescriptor_DynamicLinkingDescriptor_Error, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public MTL4BinaryFunction MakeBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4ArchiveBindings.NewBinaryFunctionWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
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
