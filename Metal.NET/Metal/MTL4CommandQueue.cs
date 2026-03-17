namespace Metal.NET;

/// <summary>
/// An abstraction representing a command queue that you use commit and synchronize command buffers and to perform other GPU operations.
/// </summary>
public class MTL4CommandQueue(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandQueue>
{
    #region INativeObject
    public static new MTL4CommandQueue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandQueue New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// Returns the GPU device that the command queue belongs to.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CommandQueueBindings.Device);
    }

    /// <summary>
    /// Obtains this queue’s optional label for debugging purposes.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandQueueBindings.Label);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Applies a residency set to a queue, which Metal applies to the queue’s command buffers as you commit them.
    /// </summary>
    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    /// <summary>
    /// Applies multiple residency sets to a queue, which Metal applies to the queue’s command buffers as you commit them.
    /// </summary>
    public unsafe void AddResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.AddResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    /// <summary>
    /// Enqueues an array of command buffer instances for execution with a set of options.
    /// </summary>
    public unsafe void Commit(MTL4CommandBuffer[] commandBuffers)
    {
        nint* pCommandBuffers = stackalloc nint[commandBuffers.Length];
        for (int i = 0; i < commandBuffers.Length; i++)
        {
            pCommandBuffers[i] = commandBuffers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.Commit, (nint)pCommandBuffers, (nuint)commandBuffers.Length);
    }

    /// <summary>
    /// Enqueues an array of command buffer instances for execution with a set of options.
    /// </summary>
    public unsafe void Commit(MTL4CommandBuffer[] commandBuffers, MTL4CommitOptions options)
    {
        nint* pCommandBuffers = stackalloc nint[commandBuffers.Length];
        for (int i = 0; i < commandBuffers.Length; i++)
        {
            pCommandBuffers[i] = commandBuffers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.Commitcountoptions, (nint)pCommandBuffers, (nuint)commandBuffers.Length, options.NativePtr);
    }

    /// <summary>
    /// Removes a residency set from a command queue’s list, which means Metal doesn’t apply it to the queue’s command buffers as you commit them.
    /// </summary>
    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }

    /// <summary>
    /// Removes multiple residency sets from a command queue’s list, which means Metal doesn’t apply them to the queue’s command buffers as you commit them.
    /// </summary>
    public unsafe void RemoveResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.RemoveResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    /// <summary>
    /// Schedules a signal operation on the command queue to indicate when rendering to a Metal drawable is complete.
    /// </summary>
    public void SignalDrawable(MTLDrawable drawable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalDrawable, drawable.NativePtr);
    }

    /// <summary>
    /// Schedules an operation to signal a GPU event with a specific value after all GPU work prior to this point is complete.
    /// </summary>
    public void SignalEvent(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.SignalEvent, @event.NativePtr, value);
    }
    #endregion

    public unsafe void CopyBufferMappingsFromBuffer(MTLBuffer sourceBuffer, MTLBuffer destinationBuffer, MTL4CopySparseBufferMappingOperation[] operations)
    {
        fixed (MTL4CopySparseBufferMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.CopyBufferMappingsFromBuffer, sourceBuffer.NativePtr, destinationBuffer.NativePtr, (nint)pOperations, (nuint)operations.Length);
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

    public unsafe void UpdateTextureMappings(MTLTexture texture, MTLHeap heap, MTL4UpdateSparseTextureMappingOperation[] operations)
    {
        fixed (MTL4UpdateSparseTextureMappingOperation* pOperations = operations)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.UpdateTextureMappings, texture.NativePtr, heap.NativePtr, (nint)pOperations, (nuint)operations.Length);
        }
    }

    public void Wait(MTLEvent @event, ulong value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.Wait, @event.NativePtr, value);
    }

    public void Wait(MTLDrawable drawable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueBindings.WaitForDrawable, drawable.NativePtr);
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
