namespace Metal.NET;

/// <summary>
/// Encodes computation dispatches, resource copying commands, and acceleration structure building commands for a single pass into a command buffer.
/// </summary>
public class MTL4ComputeCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTL4CommandEncoder(nativePtr, ownership), INativeObject<MTL4ComputeCommandEncoder>
{
    #region INativeObject
    public static new MTL4ComputeCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4ComputeCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Configuring the pass - Methods

    /// <summary>
    /// Configures this encoder with a compute pipeline state that applies to your subsequent dispatch commands.
    /// </summary>
    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetComputePipelineState, state.NativePtr);
    }

    /// <summary>
    /// Sets an argument table for the compute shader stage of this pipeline.
    /// </summary>
    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr);
    }

    /// <summary>
    /// Configures the size of a threadgroup memory buffer for a threadgroup argument in the compute shader function.
    /// </summary>
    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetThreadgroupMemoryLength, length, index);
    }
    #endregion

    #region Inspecting the pass - Methods

    /// <summary>
    /// Queries a bitmask representing the shader stages on which commands currently present in this command encoder operate.
    /// </summary>
    public MTLStages Stages()
    {
        return (MTLStages)ObjectiveC.MsgSendULong(NativePtr, MTL4ComputeCommandEncoderBindings.Stages);
    }
    #endregion

    #region Running dispatch commands - Methods

    /// <summary>
    /// Encodes a compute dispatch command using an arbitrarily-sized grid.
    /// </summary>
    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    /// <summary>
    /// Encodes a compute dispatch command using an arbitrarily-sized grid.
    /// </summary>
    public void DispatchThreads(nuint indirectBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadsWithIndirectBuffer, indirectBuffer);
    }

    /// <summary>
    /// Encodes a compute dispatch command with a grid that aligns to threadgroup boundaries.
    /// </summary>
    public void DispatchThreadgroups(nuint indirectBuffer, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadgroups, indirectBuffer, threadsPerThreadgroup);
    }

    /// <summary>
    /// Encodes a compute dispatch command with a grid that aligns to threadgroup boundaries.
    /// </summary>
    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadgroupsthreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }
    #endregion

    #region Encoding buffer copy commands - Methods

    /// <summary>
    /// Encodes a command that copies data from a buffer instance into another.
    /// </summary>
    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    /// <summary>
    /// Encodes a command that copies data from a buffer instance into another.
    /// </summary>
    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    /// <summary>
    /// Encodes a command that copies data from a buffer instance into another.
    /// </summary>
    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }
    #endregion

    #region Encoding texture copy commands - Methods

    /// <summary>
    /// Encodes a command to copy data from a tensor instance into another.
    /// </summary>
    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTensor, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    /// <summary>
    /// Encodes a command that copies data from a texture to another.
    /// </summary>
    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    /// <summary>
    /// Encodes a command that copies slices of a texture to slices of another texture.
    /// </summary>
    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    /// <summary>
    /// Encodes a command that copies slices of a texture to slices of another texture.
    /// </summary>
    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    /// <summary>
    /// Encodes a command that copies slices of a texture to slices of another texture.
    /// </summary>
    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    /// <summary>
    /// Encodes a command that copies slices of a texture to slices of another texture.
    /// </summary>
    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexturesourceSlicesourceLeveltoTexturedestinationSlicedestinationLevelsliceCountlevelCount, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    /// <summary>
    /// Encodes a command that copies slices of a texture to slices of another texture.
    /// </summary>
    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexturetoTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }
    #endregion

    #region Encoding buffer fill commands - Methods

    /// <summary>
    /// Encodes a command that fills a buffer with a constant value for each byte.
    /// </summary>
    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.FillBuffer, buffer.NativePtr, range, value);
    }
    #endregion

    #region Encoding mipmap generation commands - Methods

    /// <summary>
    /// Encodes a command that generates mipmaps for a texture instance from the base mipmap level up to the highest mipmap level.
    /// </summary>
    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.GenerateMipmaps, texture.NativePtr);
    }
    #endregion

    #region Encoding optimization commands - Methods

    /// <summary>
    /// Encodes a command that modifies the contents of a texture to improve the performance of CPU accesses to its contents.
    /// </summary>
    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    /// <summary>
    /// Encodes a command that modifies the contents of a texture to improve the performance of CPU accesses to its contents.
    /// </summary>
    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForCPUAccessslicelevel, texture.NativePtr, slice, level);
    }
    #endregion

    #region Encoding reset commands - Methods

    /// <summary>
    /// Encodes a command that resets a range of commands in an indirect command buffer.
    /// </summary>
    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ResetCommandsInBuffer, buffer.NativePtr, range);
    }
    #endregion

    #region Encoding acceleration structure build commands - Methods

    /// <summary>
    /// Encodes an acceleration structure build into the command buffer.
    /// </summary>
    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTL4BufferRange scratchBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.BuildAccelerationStructure, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer);
    }
    #endregion

    #region Encoding acceleration structure copy commands - Methods

    /// <summary>
    /// Encodes a command to copy and compact an acceleration structure.
    /// </summary>
    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyAndCompactAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }
    #endregion

    #region Encoding acceleration structure refit commands - Methods

    /// <summary>
    /// Encodes an acceleration structure refit operation into the command buffer, providing additional options.
    /// </summary>
    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer);
    }

    /// <summary>
    /// Encodes an acceleration structure refit operation into the command buffer, providing additional options.
    /// </summary>
    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.RefitAccelerationStructuredescriptordestinationscratchBufferoptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer, (nuint)options);
    }
    #endregion

    #region Encoding indirect command buffers - Methods

    /// <summary>
    /// Encodes a command to execute commands from an indirect command buffer.
    /// </summary>
    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, nuint indirectRangeBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer);
    }

    /// <summary>
    /// Encodes a command to execute commands from an indirect command buffer.
    /// </summary>
    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ExecuteCommandsInBufferwithRange, indirectCommandBuffer.NativePtr, executionRange);
    }
    #endregion

    #region Encoding performance measurement commands - Methods

    /// <summary>
    /// Writes a GPU timestamp into a heap.
    /// </summary>
    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.WriteTimestamp, (nint)granularity, counterHeap.NativePtr, index);
    }
    #endregion

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyIndirectCommandBuffer, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForGPUAccessslicelevel, texture.NativePtr, slice, level);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeIndirectCommandBuffer, indirectCommandBuffer.NativePtr, range);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetImageblockWidth, width, height);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTL4BufferRange buffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.WriteCompactedAccelerationStructureSize, accelerationStructure.NativePtr, buffer);
    }
}

file static class MTL4ComputeCommandEncoderBindings
{
    public static readonly Selector BuildAccelerationStructure = "buildAccelerationStructure:descriptor:scratchBuffer:";

    public static readonly Selector CopyAccelerationStructure = "copyAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyAndCompactAccelerationStructure = "copyAndCompactAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyFromBuffer = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";

    public static readonly Selector CopyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";

    public static readonly Selector CopyFromTensor = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";

    public static readonly Selector CopyFromTexture = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLeveltoTexturedestinationSlicedestinationLevelsliceCountlevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";

    public static readonly Selector CopyFromTexturetoTexture = "copyFromTexture:toTexture:";

    public static readonly Selector CopyIndirectCommandBuffer = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";

    public static readonly Selector DispatchThreadgroups = "dispatchThreadgroupsWithIndirectBuffer:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadgroupsthreadsPerThreadgroup = "dispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreads = "dispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadsWithIndirectBuffer = "dispatchThreadsWithIndirectBuffer:";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:indirectBuffer:";

    public static readonly Selector ExecuteCommandsInBufferwithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector FillBuffer = "fillBuffer:range:value:";

    public static readonly Selector GenerateMipmaps = "generateMipmapsForTexture:";

    public static readonly Selector OptimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";

    public static readonly Selector OptimizeContentsForCPUAccessslicelevel = "optimizeContentsForCPUAccess:slice:level:";

    public static readonly Selector OptimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";

    public static readonly Selector OptimizeContentsForGPUAccessslicelevel = "optimizeContentsForGPUAccess:slice:level:";

    public static readonly Selector OptimizeIndirectCommandBuffer = "optimizeIndirectCommandBuffer:withRange:";

    public static readonly Selector RefitAccelerationStructure = "refitAccelerationStructure:descriptor:destination:scratchBuffer:";

    public static readonly Selector RefitAccelerationStructuredescriptordestinationscratchBufferoptions = "refitAccelerationStructure:descriptor:destination:scratchBuffer:options:";

    public static readonly Selector ResetCommandsInBuffer = "resetCommandsInBuffer:withRange:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidth = "setImageblockWidth:height:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:atIndex:";

    public static readonly Selector Stages = "stages";

    public static readonly Selector WriteCompactedAccelerationStructureSize = "writeCompactedAccelerationStructureSize:toBuffer:";

    public static readonly Selector WriteTimestamp = "writeTimestampWithGranularity:intoHeap:atIndex:";
}
