namespace Metal.NET;

public readonly struct MTL4CommandQueue(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CommandQueue value) => new(value.NativePtr);

    public MTL4CommandQueue Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandQueueBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandQueueBindings.Label));
    }

    public unsafe void Commit(ReadOnlySpan<MTL4CommandBuffer> commandBuffers)
    {
        fixed (MTL4CommandBuffer* pCommandBuffers = commandBuffers)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.Commit_Count, (nint)pCommandBuffers, (nuint)commandBuffers.Length);
        }
    }

    public unsafe void Commit(ReadOnlySpan<MTL4CommandBuffer> commandBuffers, MTL4CommitOptions options)
    {
        fixed (MTL4CommandBuffer* pCommandBuffers = commandBuffers)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.Commit_Count_Options, (nint)pCommandBuffers, (nuint)commandBuffers.Length, options.NativePtr);
        }
    }

    public void SignalEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalEvent_Value, @event.NativePtr, value);
    }

    public void WaitForEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.WaitForEvent_Value, @event.NativePtr, value);
    }

    public void SignalDrawable(MTLDrawable drawable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalDrawable, drawable.NativePtr);
    }

    public void WaitForDrawable(MTLDrawable drawable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.WaitForDrawable, drawable.NativePtr);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    public unsafe void AddResidencySets(ReadOnlySpan<MTLResidencySet> residencySets)
    {
        fixed (MTLResidencySet* pResidencySets = residencySets)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.AddResidencySets_Count, (nint)pResidencySets, (nuint)residencySets.Length);
        }
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }

    public unsafe void RemoveResidencySets(ReadOnlySpan<MTLResidencySet> residencySets)
    {
        fixed (MTLResidencySet* pResidencySets = residencySets)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySets_Count, (nint)pResidencySets, (nuint)residencySets.Length);
        }
    }

    public unsafe void UpdateTextureMappings(MTLTexture texture, MTLHeap heap, ReadOnlySpan<MTL4UpdateSparseTextureMappingOperation> operations)
    {
        fixed (MTL4UpdateSparseTextureMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateTextureMappings_Heap_Operations_Count, texture.NativePtr, heap.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public unsafe void CopyTextureMappingsFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture, ReadOnlySpan<MTL4CopySparseTextureMappingOperation> operations)
    {
        fixed (MTL4CopySparseTextureMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyTextureMappingsFromTexture_ToTexture_Operations_Count, sourceTexture.NativePtr, destinationTexture.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public unsafe void UpdateBufferMappings(MTLBuffer buffer, MTLHeap heap, ReadOnlySpan<MTL4UpdateSparseBufferMappingOperation> operations)
    {
        fixed (MTL4UpdateSparseBufferMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateBufferMappings_Heap_Operations_Count, buffer.NativePtr, heap.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public unsafe void CopyBufferMappingsFromBuffer(MTLBuffer sourceBuffer, MTLBuffer destinationBuffer, ReadOnlySpan<MTL4CopySparseBufferMappingOperation> operations)
    {
        fixed (MTL4CopySparseBufferMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyBufferMappingsFromBuffer_ToBuffer_Operations_Count, sourceBuffer.NativePtr, destinationBuffer.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }
}

file static class MTL4CommandQueueBindings
{
    public static readonly Selector AddResidencySet = "addResidencySet:";

    public static readonly Selector AddResidencySets_Count = "addResidencySets:count:";

    public static readonly Selector Commit_Count = "commit:count:";

    public static readonly Selector Commit_Count_Options = "commit:count:options:";

    public static readonly Selector CopyBufferMappingsFromBuffer_ToBuffer_Operations_Count = "copyBufferMappingsFromBuffer:toBuffer:operations:count:";

    public static readonly Selector CopyTextureMappingsFromTexture_ToTexture_Operations_Count = "copyTextureMappingsFromTexture:toTexture:operations:count:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector RemoveResidencySet = "removeResidencySet:";

    public static readonly Selector RemoveResidencySets_Count = "removeResidencySets:count:";

    public static readonly Selector SignalDrawable = "signalDrawable:";

    public static readonly Selector SignalEvent_Value = "signalEvent:value:";

    public static readonly Selector UpdateBufferMappings_Heap_Operations_Count = "updateBufferMappings:heap:operations:count:";

    public static readonly Selector UpdateTextureMappings_Heap_Operations_Count = "updateTextureMappings:heap:operations:count:";

    public static readonly Selector WaitForDrawable = "waitForDrawable:";

    public static readonly Selector WaitForEvent_Value = "waitForEvent:value:";
}
