namespace Metal.NET;

/// <summary>Records a sequence of GPU commands.</summary>
public class MTL4CommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandBuffer>
{
    #region INativeObject
    public static new MTL4CommandBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>Returns the GPU device that this command buffer belongs to.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CommandBufferBindings.Device);
    }

    /// <summary>Assigns an optional label with this command buffer.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandBufferBindings.Label);
        set => SetProperty(ref field, MTL4CommandBufferBindings.SetLabel, value);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Prepares a command buffer for encoding.</summary>
    public void BeginCommandBuffer(MTL4CommandAllocator allocator)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBuffer, allocator.NativePtr);
    }

    /// <summary>Prepares a command buffer for encoding.</summary>
    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBufferWithAllocatoroptions, allocator.NativePtr, options.NativePtr);
    }

    /// <summary>Closes a command buffer to prepare it for submission to a command queue.</summary>
    public void EndCommandBuffer()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.EndCommandBuffer);
    }

    /// <summary>Creates a compute command encoder.</summary>
    public MTL4ComputeCommandEncoder ComputeCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferBindings.ComputeCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a machine learning command encoder.</summary>
    public MTL4MachineLearningCommandEncoder MachineLearningCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferBindings.MachineLearningCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a render command encoder from a render pass descriptor with additional options.</summary>
    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoder, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a render command encoder from a render pass descriptor with additional options.</summary>
    public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, MTL4RenderEncoderOptions options)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoderWithDescriptoroptions, descriptor.NativePtr, (nuint)options);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Pops the latest string from the stack of debug groups for this command buffer.</summary>
    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.PopDebugGroup);
    }

    /// <summary>Pushes a string onto a stack of debug groups for this command buffer.</summary>
    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    /// <summary>Encodes a command that resolves an opaque counter heap into a buffer.</summary>
    public void ResolveCounterHeap(MTL4CounterHeap counterHeap, NSRange range, MTL4BufferRange bufferRange, MTLFence fenceToWait, MTLFence fenceToUpdate)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.ResolveCounterHeap, counterHeap.NativePtr, range, bufferRange, fenceToWait.NativePtr, fenceToUpdate.NativePtr);
    }

    /// <summary>Applies a residency set to a command buffer.</summary>
    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.UseResidencySet, residencySet.NativePtr);
    }

    /// <summary>Applies multiple residency sets to a command buffer.</summary>
    public unsafe void UseResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.UseResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }

    /// <summary>Writes a GPU timestamp into the given counter heap.</summary>
    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferBindings.WriteTimestampIntoHeap, counterHeap.NativePtr, index);
    }
    #endregion
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
