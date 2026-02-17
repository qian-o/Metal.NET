#nullable enable

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

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTL4BinaryFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewBinaryFunctionError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewComputePipelineStateError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewComputePipelineStateDynamicLinkingDescriptorError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewRenderPipelineStateError, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewRenderPipelineStateDynamicLinkingDescriptorError, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArchiveSelector.SetLabel, label.NativePtr);
    }

}

file class MTL4ArchiveSelector
{
    public static readonly Selector NewBinaryFunctionError = Selector.Register("newBinaryFunction:error:");
    public static readonly Selector NewComputePipelineStateError = Selector.Register("newComputePipelineState:error:");
    public static readonly Selector NewComputePipelineStateDynamicLinkingDescriptorError = Selector.Register("newComputePipelineState:dynamicLinkingDescriptor:error:");
    public static readonly Selector NewRenderPipelineStateError = Selector.Register("newRenderPipelineState:error:");
    public static readonly Selector NewRenderPipelineStateDynamicLinkingDescriptorError = Selector.Register("newRenderPipelineState:dynamicLinkingDescriptor:error:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
