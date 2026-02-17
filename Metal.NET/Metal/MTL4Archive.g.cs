#nullable enable

namespace Metal.NET;

file class MTL4ArchiveSelector
{
    public static readonly Selector NewBinaryFunction_error_ = Selector.Register("newBinaryFunction:error:");
    public static readonly Selector NewComputePipelineState_error_ = Selector.Register("newComputePipelineState:error:");
    public static readonly Selector NewComputePipelineState_dynamicLinkingDescriptor_error_ = Selector.Register("newComputePipelineState:dynamicLinkingDescriptor:error:");
    public static readonly Selector NewRenderPipelineState_error_ = Selector.Register("newRenderPipelineState:error:");
    public static readonly Selector NewRenderPipelineState_dynamicLinkingDescriptor_error_ = Selector.Register("newRenderPipelineState:dynamicLinkingDescriptor:error:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTL4Archive : IDisposable
{
    public MTL4Archive(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var result = new MTL4BinaryFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewBinaryFunction_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewComputePipelineState_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewComputePipelineState_dynamicLinkingDescriptor_error_, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewRenderPipelineState_error_, descriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4ArchiveSelector.NewRenderPipelineState_dynamicLinkingDescriptor_error_, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArchiveSelector.SetLabel_, label.NativePtr);
    }

}
