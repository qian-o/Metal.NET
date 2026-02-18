namespace Metal.NET;

public class MTL4CommandBuffer(nint nativePtr) : NativeObject(nativePtr)
{

    public MTL4ComputeCommandEncoder? ComputeCommandEncoder
    {
        get => GetNullableObject<MTL4ComputeCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.ComputeCommandEncoder));
    }

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4MachineLearningCommandEncoder? MachineLearningCommandEncoder
    {
        get => GetNullableObject<MTL4MachineLearningCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.MachineLearningCommandEncoder));
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.BeginCommandBuffer, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.BeginCommandBuffer, allocator.NativePtr, options.NativePtr);
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

    public MTL4RenderCommandEncoder? RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        return GetNullableObject<MTL4RenderCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.RenderCommandEncoder, descriptor.NativePtr));
    }

    public MTL4RenderCommandEncoder? RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, MTL4RenderEncoderOptions options)
    {
        return GetNullableObject<MTL4RenderCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferSelector.RenderCommandEncoder, descriptor.NativePtr, (nuint)options));
    }

    public void ResolveCounterHeap(MTL4CounterHeap counterHeap, NSRange range, MTL4BufferRange bufferRange, MTLFence fenceToWait, MTLFence fenceToUpdate)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.ResolveCounterHeap, counterHeap.NativePtr, range, bufferRange, fenceToWait.NativePtr, fenceToUpdate.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.UseResidencySet, residencySet.NativePtr);
    }

    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferSelector.WriteTimestampIntoHeap, counterHeap.NativePtr, index);
    }
}

file static class MTL4CommandBufferSelector
{
    public static readonly Selector BeginCommandBuffer = Selector.Register("beginCommandBufferWithAllocator:");

    public static readonly Selector ComputeCommandEncoder = Selector.Register("computeCommandEncoder");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndCommandBuffer = Selector.Register("endCommandBuffer");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MachineLearningCommandEncoder = Selector.Register("machineLearningCommandEncoder");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoderWithDescriptor:");

    public static readonly Selector ResolveCounterHeap = Selector.Register("resolveCounterHeap:withRange:intoBuffer:waitFence:updateFence:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector UseResidencySet = Selector.Register("useResidencySet:");

    public static readonly Selector WriteTimestampIntoHeap = Selector.Register("writeTimestampIntoHeap:atIndex:");
}
