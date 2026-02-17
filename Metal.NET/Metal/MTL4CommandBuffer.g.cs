using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommandBuffer_Selectors
{
    internal static readonly Selector beginCommandBuffer_ = Selector.Register("beginCommandBuffer:");
    internal static readonly Selector beginCommandBuffer_options_ = Selector.Register("beginCommandBuffer:options:");
    internal static readonly Selector endCommandBuffer = Selector.Register("endCommandBuffer");
    internal static readonly Selector popDebugGroup = Selector.Register("popDebugGroup");
    internal static readonly Selector pushDebugGroup_ = Selector.Register("pushDebugGroup:");
    internal static readonly Selector renderCommandEncoder_ = Selector.Register("renderCommandEncoder:");
    internal static readonly Selector renderCommandEncoder_options_ = Selector.Register("renderCommandEncoder:options:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector useResidencySet_ = Selector.Register("useResidencySet:");
    internal static readonly Selector writeTimestampIntoHeap_index_ = Selector.Register("writeTimestampIntoHeap:index:");
}

public class MTL4CommandBuffer : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CommandBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommandBuffer o) => o.NativePtr;
    public static implicit operator MTL4CommandBuffer(nint ptr) => new MTL4CommandBuffer(ptr);

    ~MTL4CommandBuffer() => Release();

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

    public void BeginCommandBuffer(MTL4CommandAllocator allocator)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.beginCommandBuffer_, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.beginCommandBuffer_options_, allocator.NativePtr, options.NativePtr);
    }

    public void EndCommandBuffer()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.endCommandBuffer);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.popDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.pushDebugGroup_, @string.NativePtr);
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        var __r = new MTL4RenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.renderCommandEncoder_, descriptor.NativePtr));
        return __r;
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, nuint options)
    {
        var __r = new MTL4RenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.renderCommandEncoder_options_, descriptor.NativePtr, (nint)options));
        return __r;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.setLabel_, label.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.useResidencySet_, residencySet.NativePtr);
    }

    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBuffer_Selectors.writeTimestampIntoHeap_index_, counterHeap.NativePtr, (nint)index);
    }

}
