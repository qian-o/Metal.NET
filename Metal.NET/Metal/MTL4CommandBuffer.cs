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
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBufferWithAllocator, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBufferWithAllocator_Options, allocator.NativePtr, options.NativePtr);
    }

    public void EndCommandBuffer()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.EndCommandBuffer);
    }

    public MTL4RenderCommandEncoder MakeRenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoderWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4RenderCommandEncoder MakeRenderCommandEncoder(MTL4RenderPassDescriptor descriptor, MTL4RenderEncoderOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoderWithDescriptor_Options, descriptor.NativePtr, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4ComputeCommandEncoder MakeComputeCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferBindings.ComputeCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4MachineLearningCommandEncoder MakeMachineLearningCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferBindings.MachineLearningCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
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

        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.UseResidencySets_Count, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.PopDebugGroup);
    }

    public void WriteTimestamp(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.WriteTimestampIntoHeap_AtIndex, counterHeap.NativePtr, index);
    }

    public void ResolveCounterHeap(MTL4CounterHeap counterHeap, NSRange range, MTL4BufferRange bufferRange, MTLFence fenceToWait, MTLFence fenceToUpdate)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.ResolveCounterHeap_WithRange_IntoBuffer_WaitFence_UpdateFence, counterHeap.NativePtr, range, bufferRange, fenceToWait.NativePtr, fenceToUpdate.NativePtr);
    }
}

file static class MTL4CommandBufferBindings
{
    public static readonly Selector BeginCommandBufferWithAllocator = "beginCommandBufferWithAllocator:";

    public static readonly Selector BeginCommandBufferWithAllocator_Options = "beginCommandBufferWithAllocator:options:";

    public static readonly Selector ComputeCommandEncoder = "computeCommandEncoder";

    public static readonly Selector Device = "device";

    public static readonly Selector EndCommandBuffer = "endCommandBuffer";

    public static readonly Selector Label = "label";

    public static readonly Selector MachineLearningCommandEncoder = "machineLearningCommandEncoder";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector RenderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";

    public static readonly Selector RenderCommandEncoderWithDescriptor_Options = "renderCommandEncoderWithDescriptor:options:";

    public static readonly Selector ResolveCounterHeap_WithRange_IntoBuffer_WaitFence_UpdateFence = "resolveCounterHeap:withRange:intoBuffer:waitFence:updateFence:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector UseResidencySet = "useResidencySet:";

    public static readonly Selector UseResidencySets_Count = "useResidencySets:count:";

    public static readonly Selector WriteTimestampIntoHeap_AtIndex = "writeTimestampIntoHeap:atIndex:";
}
