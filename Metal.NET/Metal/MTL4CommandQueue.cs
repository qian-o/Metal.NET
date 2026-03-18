namespace Metal.NET;

public class MTL4CommandQueue(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandQueue>
{
    #region INativeObject
    public static new MTL4CommandQueue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandQueue New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CommandQueueBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandQueueBindings.Label);
    }

    public unsafe void Commit(MTL4CommandBuffer[] commandBuffers)
    {
        nint* pCommandBuffers = stackalloc nint[commandBuffers.Length];
        for (int i = 0; i < commandBuffers.Length; i++)
        {
            pCommandBuffers[i] = commandBuffers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.Commit, (nint)pCommandBuffers, (nuint)commandBuffers.Length);
    }

    public unsafe void Commit(MTL4CommandBuffer[] commandBuffers, MTL4CommitOptions options)
    {
        nint* pCommandBuffers = stackalloc nint[commandBuffers.Length];
        for (int i = 0; i < commandBuffers.Length; i++)
        {
            pCommandBuffers[i] = commandBuffers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.CommitCountOptions, (nint)pCommandBuffers, (nuint)commandBuffers.Length, options.NativePtr);
    }

    public void SignalEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalEvent, @event.NativePtr, value);
    }

    public void WaitForEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.WaitForEvent, @event.NativePtr, value);
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

    public unsafe void AddResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.AddResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }

    public unsafe void RemoveResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    public unsafe void UpdateTextureMappings(MTLTexture texture, MTLHeap heap, MTL4UpdateSparseTextureMappingOperation[] operations)
    {
        fixed (MTL4UpdateSparseTextureMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateTextureMappings, texture.NativePtr, heap.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public unsafe void CopyTextureMappingsFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture, MTL4CopySparseTextureMappingOperation[] operations)
    {
        fixed (MTL4CopySparseTextureMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyTextureMappingsFromTexture, sourceTexture.NativePtr, destinationTexture.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public unsafe void UpdateBufferMappings(MTLBuffer buffer, MTLHeap heap, MTL4UpdateSparseBufferMappingOperation[] operations)
    {
        fixed (MTL4UpdateSparseBufferMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateBufferMappings, buffer.NativePtr, heap.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public unsafe void CopyBufferMappingsFromBuffer(MTLBuffer sourceBuffer, MTLBuffer destinationBuffer, MTL4CopySparseBufferMappingOperation[] operations)
    {
        fixed (MTL4CopySparseBufferMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyBufferMappingsFromBuffer, sourceBuffer.NativePtr, destinationBuffer.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }
}

file static class MTL4CommandQueueBindings
{
    public static readonly Selector AddResidencySet = "addResidencySet:";

    public static readonly Selector AddResidencySets = "addResidencySets:count:";

    public static readonly Selector Commit = "commit:count:";

    public static readonly Selector CommitCountOptions = "commit:count:options:";

    public static readonly Selector CopyBufferMappingsFromBuffer = "copyBufferMappingsFromBuffer:toBuffer:operations:count:";

    public static readonly Selector CopyTextureMappingsFromTexture = "copyTextureMappingsFromTexture:toTexture:operations:count:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector RemoveResidencySet = "removeResidencySet:";

    public static readonly Selector RemoveResidencySets = "removeResidencySets:count:";

    public static readonly Selector SignalDrawable = "signalDrawable:";

    public static readonly Selector SignalEvent = "signalEvent:value:";

    public static readonly Selector UpdateBufferMappings = "updateBufferMappings:heap:operations:count:";

    public static readonly Selector UpdateTextureMappings = "updateTextureMappings:heap:operations:count:";

    public static readonly Selector WaitForDrawable = "waitForDrawable:";

    public static readonly Selector WaitForEvent = "waitForEvent:value:";
}
