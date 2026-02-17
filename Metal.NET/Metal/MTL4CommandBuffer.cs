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

    public MTL4ComputeCommandEncoder ComputeCommandEncoder
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.ComputeCommandEncoder));
    }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.SetLabel, value.NativePtr);
    }

    public MTL4MachineLearningCommandEncoder MachineLearningCommandEncoder
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.MachineLearningCommandEncoder));
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.BeginCommandBuffer, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.BeginCommandBufferOptions, allocator.NativePtr, options.NativePtr);
    }

    public void EndCommandBuffer()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.EndCommandBuffer);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.PushDebugGroup, @string.NativePtr);
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        MTL4RenderCommandEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.RenderCommandEncoder, descriptor.NativePtr));

        return result;
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, nuint options)
    {
        MTL4RenderCommandEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.RenderCommandEncoderOptions, descriptor.NativePtr, options));

        return result;
    }

    public void ResolveCounterHeap(MTL4CounterHeap counterHeap, NSRange range, MTL4BufferRange bufferRange, MTLFence fenceToWait, MTLFence fenceToUpdate)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.ResolveCounterHeapRangeBufferRangeFenceToWaitFenceToUpdate, counterHeap.NativePtr, range, bufferRange, fenceToWait.NativePtr, fenceToUpdate.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.UseResidencySet, residencySet.NativePtr);
    }

    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.WriteTimestampIntoHeapIndex, counterHeap.NativePtr, index);
    }

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
}

file class MTL4CommandBufferSelector
{
    public static readonly Selector ComputeCommandEncoder = Selector.Register("computeCommandEncoder");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector MachineLearningCommandEncoder = Selector.Register("machineLearningCommandEncoder");

    public static readonly Selector BeginCommandBuffer = Selector.Register("beginCommandBuffer:");

    public static readonly Selector BeginCommandBufferOptions = Selector.Register("beginCommandBuffer:options:");

    public static readonly Selector EndCommandBuffer = Selector.Register("endCommandBuffer");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoder:");

    public static readonly Selector RenderCommandEncoderOptions = Selector.Register("renderCommandEncoder:options:");

    public static readonly Selector ResolveCounterHeapRangeBufferRangeFenceToWaitFenceToUpdate = Selector.Register("resolveCounterHeap:range:bufferRange:fenceToWait:fenceToUpdate:");

    public static readonly Selector UseResidencySet = Selector.Register("useResidencySet:");

    public static readonly Selector WriteTimestampIntoHeapIndex = Selector.Register("writeTimestampIntoHeap:index:");
}
