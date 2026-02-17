namespace Metal.NET;

public class MTL4CommandBuffer : IDisposable
{
    public MTL4CommandBuffer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.BeginCommandBuffer, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.BeginCommandBufferOptions, allocator.NativePtr, options.NativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.PushDebugGroup, @string.NativePtr);
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        var result = new MTL4RenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CommandBufferSelector.RenderCommandEncoder, descriptor.NativePtr));

        return result;
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, uint options)
    {
        var result = new MTL4RenderCommandEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4CommandBufferSelector.RenderCommandEncoderOptions, descriptor.NativePtr, (nint)options));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.SetLabel, label.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.UseResidencySet, residencySet.NativePtr);
    }

    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferSelector.WriteTimestampIntoHeapIndex, counterHeap.NativePtr, (nint)index);
    }

}

file class MTL4CommandBufferSelector
{
    public static readonly Selector BeginCommandBuffer = Selector.Register("beginCommandBuffer:");
    public static readonly Selector BeginCommandBufferOptions = Selector.Register("beginCommandBuffer:options:");
    public static readonly Selector EndCommandBuffer = Selector.Register("endCommandBuffer");
    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");
    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");
    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoder:");
    public static readonly Selector RenderCommandEncoderOptions = Selector.Register("renderCommandEncoder:options:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector UseResidencySet = Selector.Register("useResidencySet:");
    public static readonly Selector WriteTimestampIntoHeapIndex = Selector.Register("writeTimestampIntoHeap:index:");
}
