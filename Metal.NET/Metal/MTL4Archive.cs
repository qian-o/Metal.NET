namespace Metal.NET;

public class MTL4Archive(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public NSString? Label
    {
        get => GetProperty(ref field, MTL4ArchiveBindings.Label);
        set => SetProperty(ref field, MTL4ArchiveBindings.SetLabel, value);
    }

    public MTL4BinaryFunction? NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError? error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewBinaryFunction, descriptor.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            error = new(errorPtr, true);
        }
        else
        {
            error = null;
        }

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError? error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewComputePipelineState, descriptor.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            error = new(errorPtr, true);
        }
        else
        {
            error = null;
        }

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLComputePipelineState? NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewComputePipelineStateWithDescriptordynamicLinkingDescriptorerror, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            error = new(errorPtr, true);
        }
        else
        {
            error = null;
        }

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError? error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewRenderPipelineState, descriptor.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            error = new(errorPtr, true);
        }
        else
        {
            error = null;
        }

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLRenderPipelineState? NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ArchiveBindings.NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorerror, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            error = new(errorPtr, true);
        }
        else
        {
            error = null;
        }

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }
}

file static class MTL4ArchiveBindings
{
    public static readonly Selector Label = "label";

    public static readonly Selector NewBinaryFunction = "newBinaryFunctionWithDescriptor:error:";

    public static readonly Selector NewComputePipelineState = "newComputePipelineStateWithDescriptor:error:";

    public static readonly Selector NewComputePipelineStateWithDescriptordynamicLinkingDescriptorerror = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:error:";

    public static readonly Selector NewRenderPipelineState = "newRenderPipelineStateWithDescriptor:error:";

    public static readonly Selector NewRenderPipelineStateWithDescriptordynamicLinkingDescriptorerror = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
