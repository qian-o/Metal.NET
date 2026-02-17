using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4Archive_Selectors
{
    internal static readonly Selector newBinaryFunction_error_ = Selector.Register("newBinaryFunction:error:");
    internal static readonly Selector newComputePipelineState_error_ = Selector.Register("newComputePipelineState:error:");
    internal static readonly Selector newComputePipelineState_dynamicLinkingDescriptor_error_ = Selector.Register("newComputePipelineState:dynamicLinkingDescriptor:error:");
    internal static readonly Selector newRenderPipelineState_error_ = Selector.Register("newRenderPipelineState:error:");
    internal static readonly Selector newRenderPipelineState_dynamicLinkingDescriptor_error_ = Selector.Register("newRenderPipelineState:dynamicLinkingDescriptor:error:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTL4Archive : IDisposable
{
    public nint NativePtr { get; }

    public MTL4Archive(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4Archive o) => o.NativePtr;
    public static implicit operator MTL4Archive(nint ptr) => new MTL4Archive(ptr);

    ~MTL4Archive() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTL4BinaryFunction(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Archive_Selectors.newBinaryFunction_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Archive_Selectors.newComputePipelineState_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLComputePipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Archive_Selectors.newComputePipelineState_dynamicLinkingDescriptor_error_, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Archive_Selectors.newRenderPipelineState_error_, descriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLRenderPipelineState(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4Archive_Selectors.newRenderPipelineState_dynamicLinkingDescriptor_error_, descriptor.NativePtr, dynamicLinkingDescriptor.NativePtr, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4Archive_Selectors.setLabel_, label.NativePtr);
    }

}
