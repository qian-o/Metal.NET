namespace Metal.NET;

file class MTL4CommandBufferSelector
{
    public static readonly Selector BeginCommandBuffer_ = Selector.Register("beginCommandBuffer:");
    public static readonly Selector BeginCommandBuffer_options_ = Selector.Register("beginCommandBuffer:options:");
    public static readonly Selector EndCommandBuffer = Selector.Register("endCommandBuffer");
    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");
    public static readonly Selector PushDebugGroup_ = Selector.Register("pushDebugGroup:");
    public static readonly Selector RenderCommandEncoder_ = Selector.Register("renderCommandEncoder:");
    public static readonly Selector RenderCommandEncoder_options_ = Selector.Register("renderCommandEncoder:options:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector UseResidencySet_ = Selector.Register("useResidencySet:");
    public static readonly Selector WriteTimestampIntoHeap_index_ = Selector.Register("writeTimestampIntoHeap:index:");
}

public class MTL4CommandBuffer : IDisposable
{
    public MTL4CommandBuffer(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4CommandBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommandBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandBuffer(nint value)
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

    public void BeginCommandBuffer(MTL4CommandAllocator allocator)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.BeginCommandBuffer_, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.BeginCommandBuffer_options_, allocator.NativePtr, options.NativePtr);
    }

    public void EndCommandBuffer()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.EndCommandBuffer);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.PushDebugGroup_, @string.NativePtr);
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        var result = new MTL4RenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CommandBufferSelector.RenderCommandEncoder_, descriptor.NativePtr));

        return result;
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, nuint options)
    {
        var result = new MTL4RenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CommandBufferSelector.RenderCommandEncoder_options_, descriptor.NativePtr, (nint)options));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.SetLabel_, label.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.UseResidencySet_, residencySet.NativePtr);
    }

    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.WriteTimestampIntoHeap_index_, counterHeap.NativePtr, (nint)index);
    }

}
