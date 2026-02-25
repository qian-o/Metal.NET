namespace Metal.NET;

public class MTL4CommandQueue(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CommandQueue>
{
    public static MTL4CommandQueue Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CommandQueueBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandQueueBindings.Label);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    public unsafe void AddResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.AddResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    public unsafe void Commit(MTL4CommandBuffer[] commandBuffers)
    {
        nint* pCommandBuffers = stackalloc nint[commandBuffers.Length];
        for (int i = 0; i < commandBuffers.Length; i++)
        {
            pCommandBuffers[i] = commandBuffers[i].NativePtr;
        }

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.Commit, (nint)pCommandBuffers, (nuint)commandBuffers.Length);
    }

    public unsafe void Commit(MTL4CommandBuffer[] commandBuffers, MTL4CommitOptions options)
    {
        nint* pCommandBuffers = stackalloc nint[commandBuffers.Length];
        for (int i = 0; i < commandBuffers.Length; i++)
        {
            pCommandBuffers[i] = commandBuffers[i].NativePtr;
        }

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.Commitcountoptions, (nint)pCommandBuffers, (nuint)commandBuffers.Length, options.NativePtr);
    }

    public unsafe void CopyBufferMappingsFromBuffer(MTLBuffer sourceBuffer, MTLBuffer destinationBuffer, MTL4CopySparseBufferMappingOperation[] operations)
    {
        fixed (MTL4CopySparseBufferMappingOperation* pOperations = operations)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyBufferMappingsFromBuffer, sourceBuffer.NativePtr, destinationBuffer.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public unsafe void CopyTextureMappingsFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture, MTL4CopySparseTextureMappingOperation[] operations)
    {
        fixed (MTL4CopySparseTextureMappingOperation* pOperations = operations)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyTextureMappingsFromTexture, sourceTexture.NativePtr, destinationTexture.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }

    public unsafe void RemoveResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    public void SignalDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalDrawable, drawable.NativePtr);
    }

    public void SignalEvent(MTLEvent @event, ulong value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalEvent, @event.NativePtr, (nuint)value);
    }

    public unsafe void UpdateBufferMappings(MTLBuffer buffer, MTLHeap heap, MTL4UpdateSparseBufferMappingOperation[] operations)
    {
        fixed (MTL4UpdateSparseBufferMappingOperation* pOperations = operations)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateBufferMappings, buffer.NativePtr, heap.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public unsafe void UpdateTextureMappings(MTLTexture texture, MTLHeap heap, MTL4UpdateSparseTextureMappingOperation[] operations)
    {
        fixed (MTL4UpdateSparseTextureMappingOperation* pOperations = operations)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateTextureMappings, texture.NativePtr, heap.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public void Wait(MTLEvent @event, ulong value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.Wait, @event.NativePtr, (nuint)value);
    }

    public void Wait(MTLDrawable drawable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueBindings.WaitForDrawable, drawable.NativePtr);
    }
}

file static class MTL4CommandQueueBindings
{
    public static readonly Selector AddResidencySet = "addResidencySet:";

    public static readonly Selector AddResidencySets = "addResidencySets:count:";

    public static readonly Selector Commit = "commit:count:";

    public static readonly Selector Commitcountoptions = "commit:count:options:";

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

    public static readonly Selector Wait = "waitForEvent:value:";

    public static readonly Selector WaitForDrawable = "waitForDrawable:";
}
