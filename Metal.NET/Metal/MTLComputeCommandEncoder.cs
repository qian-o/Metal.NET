namespace Metal.NET;

/// <summary>
/// Encodes computation dispatch commands for a single compute pass into a command buffer.
/// </summary>
public class MTLComputeCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLComputeCommandEncoder>
{
    #region INativeObject
    public static new MTLComputeCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputeCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Configuring the pipeline state - Properties

    /// <summary>
    /// The dispatch type to use when submitting compute work to the GPU.
    /// </summary>
    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveC.MsgSendULong(NativePtr, MTLComputeCommandEncoderBindings.DispatchType);
    }
    #endregion

    #region Configuring the pipeline state - Methods

    /// <summary>
    /// Configures the compute encoder with a pipeline state for subsequent kernel calls.
    /// </summary>
    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetComputePipelineState, state.NativePtr);
    }
    #endregion

    #region Binding buffers - Methods

    /// <summary>
    /// Binds a buffer to the buffer argument table, allowing compute kernels to access its data on the GPU.
    /// </summary>
    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBuffer, buffer.NativePtr, offset, index);
    }

    /// <summary>
    /// Binds a buffer to the buffer argument table, allowing compute kernels to access its data on the GPU.
    /// </summary>
    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferoffsetattributeStrideatIndex, buffer.NativePtr, offset, stride, index);
    }

    /// <summary>
    /// Changes where the data begins in a buffer already bound to the buffer argument table.
    /// </summary>
    public void SetBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffset, offset, stride, index);
    }

    /// <summary>
    /// Changes where the data begins in a buffer already bound to the buffer argument table.
    /// </summary>
    public void SetBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffsetatIndex, offset, index);
    }
    #endregion

    #region Binding raw bytes - Methods

    /// <summary>
    /// Copies data directly to the GPU to populate an entry in the buffer argument table.
    /// </summary>
    public void SetBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBytes, bytes, length, index);
    }

    /// <summary>
    /// Copies data directly to the GPU to populate an entry in the buffer argument table.
    /// </summary>
    public void SetBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetByteslengthattributeStrideatIndex, bytes, length, stride, index);
    }
    #endregion

    #region Binding textures - Methods

    /// <summary>
    /// Binds a texture to the texture argument table, allowing compute kernels to access its data on the GPU.
    /// </summary>
    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetTexture, texture.NativePtr, index);
    }
    #endregion

    #region Binding texture samplers - Methods

    /// <summary>
    /// Encodes a texture sampler, allowing compute kernels to use it for sampling textures on the GPU.
    /// </summary>
    public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    /// <summary>
    /// Encodes a texture sampler, allowing compute kernels to use it for sampling textures on the GPU.
    /// </summary>
    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerStateatIndex, sampler.NativePtr, index);
    }
    #endregion

    #region Binding function tables - Methods

    /// <summary>
    /// Binds a visible function table to the buffer argument table, allowing you to call its functions on the GPU.
    /// </summary>
    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetVisibleFunctionTable, visibleFunctionTable.NativePtr, bufferIndex);
    }
    #endregion

    #region Binding arguments for acceleration structures - Methods

    /// <summary>
    /// Binds an acceleration structure to the buffer argument table, allowing functions to access it on the GPU.
    /// </summary>
    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    /// <summary>
    /// Binds an intersection function table to the buffer argument table, making it callable in your Metal shaders.
    /// </summary>
    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }
    #endregion

    #region Making indirect resources resident - Methods

    /// <summary>
    /// Ensures kernel calls that the system encodes in subsequent commands have access to a resource.
    /// </summary>
    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    /// <summary>
    /// Ensures kernel calls that the system encodes in subsequent commands have access to multiple resources.
    /// </summary>
    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseResources, (nint)pResources, (nuint)resources.Length, (nuint)usage);
    }

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to all of the resources you allocate from a heap.
    /// </summary>
    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to all of the resources you allocate from multiple heaps.
    /// </summary>
    public unsafe void UseHeaps(MTLHeap[] heaps)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseHeaps, (nint)pHeaps, (nuint)heaps.Length);
    }
    #endregion

    #region Configuring tile memory - Methods

    /// <summary>
    /// Configures the size of a block of threadgroup memory.
    /// </summary>
    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetThreadgroupMemoryLength, length, index);
    }

    /// <summary>
    /// Sets the size, in pixels, of imageblock data in tile memory.
    /// </summary>
    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetImageblockWidth, width, height);
    }
    #endregion

    #region Configuring stage-in data - Methods

    /// <summary>
    /// Sets the dimensions over the thread grid of how your compute kernel receives stage-in arguments.
    /// </summary>
    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetStageInRegion, region);
    }

    /// <summary>
    /// Sets the dimensions over the thread grid of how your compute kernel receives stage-in arguments.
    /// </summary>
    public void SetStageInRegion(MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetStageInRegionWithIndirectBufferindirectBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }
    #endregion

    #region Dispatching kernel calls directly - Methods

    /// <summary>
    /// Encodes a compute command using an arbitrarily sized grid.
    /// </summary>
    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    /// <summary>
    /// Encodes a compute dispatch command using a grid aligned to threadgroup boundaries.
    /// </summary>
    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    /// <summary>
    /// Encodes a compute dispatch command using a grid aligned to threadgroup boundaries.
    /// </summary>
    public void DispatchThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerThreadgroup, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerThreadgroup);
    }
    #endregion

    #region Dispatching from indirect command buffers - Methods

    /// <summary>
    /// Encodes an instruction to run commands from an indirect buffer.
    /// </summary>
    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    /// <summary>
    /// Encodes an instruction to run commands from an indirect buffer.
    /// </summary>
    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.ExecuteCommandsInBufferwithRange, indirectCommandBuffer.NativePtr, executionRange);
    }
    #endregion

    #region Preventing resource access conflicts - Methods

    /// <summary>
    /// Encodes a command that instructs the GPU to pause the compute pass until another pass updates a fence.
    /// </summary>
    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    /// <summary>
    /// Encodes a command that instructs the GPU to update a fence after the compute pass completes.
    /// </summary>
    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    /// <summary>
    /// Creates a memory barrier that enforces the order of write and read operations for specific resource types.
    /// </summary>
    public unsafe void MemoryBarrier(MTLResource[] resources)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.MemoryBarrier, (nint)pResources, (nuint)resources.Length);
    }

    /// <summary>
    /// Creates a memory barrier that enforces the order of write and read operations for specific resource types.
    /// </summary>
    public void MemoryBarrier(MTLBarrierScope scope)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.MemoryBarrierWithScope, (nuint)scope);
    }
    #endregion

    #region Sampling counters - Methods

    /// <summary>
    /// Encodes a command to sample hardware counters, providing performance information.
    /// </summary>
    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, barrier);
    }
    #endregion
}

file static class MTLComputeCommandEncoderBindings
{
    public static readonly Selector DispatchThreadgroups = "dispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerThreadgroup = "dispatchThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreads = "dispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector DispatchType = "dispatchType";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector ExecuteCommandsInBufferwithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector MemoryBarrier = "memoryBarrierWithResources:count:";

    public static readonly Selector MemoryBarrierWithScope = "memoryBarrierWithScope:";

    public static readonly Selector SampleCountersInBuffer = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetAccelerationStructure = "setAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetBuffer = "setBuffer:offset:atIndex:";

    public static readonly Selector SetBufferOffset = "setBufferOffset:attributeStride:atIndex:";

    public static readonly Selector SetBufferOffsetatIndex = "setBufferOffset:atIndex:";

    public static readonly Selector SetBufferoffsetattributeStrideatIndex = "setBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetBytes = "setBytes:length:atIndex:";

    public static readonly Selector SetByteslengthattributeStrideatIndex = "setBytes:length:attributeStride:atIndex:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidth = "setImageblockWidth:height:";

    public static readonly Selector SetIntersectionFunctionTable = "setIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetSamplerState = "setSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetSamplerStateatIndex = "setSamplerState:atIndex:";

    public static readonly Selector SetStageInRegion = "setStageInRegion:";

    public static readonly Selector SetStageInRegionWithIndirectBufferindirectBufferOffset = "setStageInRegionWithIndirectBuffer:indirectBufferOffset:";

    public static readonly Selector SetTexture = "setTexture:atIndex:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetVisibleFunctionTable = "setVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeaps = "useHeaps:count:";

    public static readonly Selector UseResource = "useResource:usage:";

    public static readonly Selector UseResources = "useResources:count:usage:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
