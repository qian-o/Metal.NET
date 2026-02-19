namespace Metal.NET;

public class MTL4CommandBuffer(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4ComputeCommandEncoder? ComputeCommandEncoder
    {
        get => GetProperty(ref field, MTL4CommandBufferBindings.ComputeCommandEncoder);
    }

    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTL4CommandBufferBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTL4CommandBufferBindings.Label);
        set => SetProperty(ref field, MTL4CommandBufferBindings.SetLabel, value);
    }

    public MTL4MachineLearningCommandEncoder? MachineLearningCommandEncoder
    {
        get => GetProperty(ref field, MTL4CommandBufferBindings.MachineLearningCommandEncoder);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBuffer, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBuffer, allocator.NativePtr, options.NativePtr);
    }

    public void EndCommandBuffer()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.EndCommandBuffer);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public MTL4RenderCommandEncoder? RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoder, descriptor.NativePtr);
        return ptr is not 0 ? new MTL4RenderCommandEncoder(ptr) : null;
    }

    public MTL4RenderCommandEncoder? RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, MTL4RenderEncoderOptions options)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoder, descriptor.NativePtr, (nuint)options);
        return ptr is not 0 ? new MTL4RenderCommandEncoder(ptr) : null;
    }

    public void ResolveCounterHeap(MTL4CounterHeap counterHeap, NSRange range, MTL4BufferRange bufferRange, MTLFence fenceToWait, MTLFence fenceToUpdate)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.ResolveCounterHeap, counterHeap.NativePtr, range, bufferRange, fenceToWait.NativePtr, fenceToUpdate.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.UseResidencySet, residencySet.NativePtr);
    }

    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.WriteTimestampIntoHeap, counterHeap.NativePtr, index);
    }
}

file static class MTL4CommandBufferBindings
{
    public static readonly Selector BeginCommandBuffer = "beginCommandBufferWithAllocator:";

    public static readonly Selector ComputeCommandEncoder = "computeCommandEncoder";

    public static readonly Selector Device = "device";

    public static readonly Selector EndCommandBuffer = "endCommandBuffer";

    public static readonly Selector Label = "label";

    public static readonly Selector MachineLearningCommandEncoder = "machineLearningCommandEncoder";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector RenderCommandEncoder = "renderCommandEncoderWithDescriptor:";

    public static readonly Selector ResolveCounterHeap = "resolveCounterHeap:withRange:intoBuffer:waitFence:updateFence:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector UseResidencySet = "useResidencySet:";

    public static readonly Selector WriteTimestampIntoHeap = "writeTimestampIntoHeap:atIndex:";
}
