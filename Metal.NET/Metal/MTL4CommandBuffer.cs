namespace Metal.NET;

public class MTL4CommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandBuffer>
{
    #region INativeObject
    public static new MTL4CommandBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CommandBufferBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandBufferBindings.Label);
        set => SetProperty(ref field, MTL4CommandBufferBindings.SetLabel, value);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBuffer, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBufferWithAllocatoroptions, allocator.NativePtr, options.NativePtr);
    }

    public MTL4ComputeCommandEncoder ComputeCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.ComputeCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void EndCommandBuffer()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.EndCommandBuffer);
    }

    public MTL4MachineLearningCommandEncoder MachineLearningCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.MachineLearningCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoder, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, MTL4RenderEncoderOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoderWithDescriptoroptions, descriptor.NativePtr, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void ResolveCounterHeap(MTL4CounterHeap counterHeap, NSRange range, MTL4BufferRange bufferRange, MTLFence fenceToWait, MTLFence fenceToUpdate)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.ResolveCounterHeap, counterHeap.NativePtr, range, bufferRange, fenceToWait.NativePtr, fenceToUpdate.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.UseResidencySet, residencySet.NativePtr);
    }

    public unsafe void UseResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.UseResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.WriteTimestampIntoHeap, counterHeap.NativePtr, index);
    }
}

file static class MTL4CommandBufferBindings
{
    public static readonly Selector BeginCommandBuffer = "beginCommandBufferWithAllocator:";

    public static readonly Selector BeginCommandBufferWithAllocatoroptions = "beginCommandBufferWithAllocator:options:";

    public static readonly Selector ComputeCommandEncoder = "computeCommandEncoder";

    public static readonly Selector Device = "device";

    public static readonly Selector EndCommandBuffer = "endCommandBuffer";

    public static readonly Selector Label = "label";

    public static readonly Selector MachineLearningCommandEncoder = "machineLearningCommandEncoder";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector RenderCommandEncoder = "renderCommandEncoderWithDescriptor:";

    public static readonly Selector RenderCommandEncoderWithDescriptoroptions = "renderCommandEncoderWithDescriptor:options:";

    public static readonly Selector ResolveCounterHeap = "resolveCounterHeap:withRange:intoBuffer:waitFence:updateFence:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector UseResidencySet = "useResidencySet:";

    public static readonly Selector UseResidencySets = "useResidencySets:count:";

    public static readonly Selector WriteTimestampIntoHeap = "writeTimestampIntoHeap:atIndex:";
}
