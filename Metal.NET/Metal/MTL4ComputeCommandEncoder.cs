namespace Metal.NET;

public class MTL4ComputeCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTL4CommandEncoder(nativePtr, ownership), INativeObject<MTL4ComputeCommandEncoder>
{
    #region INativeObject
    public static new MTL4ComputeCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4ComputeCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStages Stages()
    {
        return (MTLStages)ObjectiveC.MsgSendULong(NativePtr, MTL4ComputeCommandEncoderBindings.Stages);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetComputePipelineState, state.NativePtr);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetThreadgroupMemoryLengthAtIndex, length, index);
    }

    public void SetImageblockSize(nuint width, nuint height)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetImageblockWidthHeight, width, height);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadsThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadgroupsThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(nuint indirectBuffer, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadgroupsWithIndirectBufferThreadsPerThreadgroup, indirectBuffer, threadsPerThreadgroup);
    }

    public void DispatchThreads(nuint indirectBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadsWithIndirectBuffer, indirectBuffer);
    }

    public void ExecuteCommands(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ExecuteCommandsInBufferWithRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommands(MTLIndirectCommandBuffer indirectCommandbuffer, nuint indirectRangeBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ExecuteCommandsInBufferIndirectBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer);
    }

    public void Copy(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTextureToTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelToTextureDestinationSliceDestinationLevelSliceCountLevelCount, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBufferSourceOffsetToBufferDestinationOffsetSize, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    public void Copy(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTensorSourceOriginSourceDimensionsToTensorDestinationOriginDestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.GenerateMipmapsForTexture, texture.NativePtr);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.FillBufferRangeValue, buffer.NativePtr, range, value);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccessSliceLevel(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccessSliceLevel(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ResetCommandsInBufferWithRange, buffer.NativePtr, range);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeIndirectCommandBufferWithRange, indirectCommandBuffer.NativePtr, range);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr);
    }

    public void Build(MTLAccelerationStructure accelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTL4BufferRange scratchBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.BuildAccelerationStructureDescriptorScratchBuffer, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer);
    }

    public void Refit(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.RefitAccelerationStructureDescriptorDestinationScratchBuffer, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer);
    }

    public void Refit(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.RefitAccelerationStructureDescriptorDestinationScratchBufferOptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer, (nuint)options);
    }

    public void Copy(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyAccelerationStructureToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void WriteCompactedSize(MTLAccelerationStructure accelerationStructure, MTL4BufferRange buffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.WriteCompactedAccelerationStructureSizeToBuffer, accelerationStructure.NativePtr, buffer);
    }

    public void CopyAndCompact(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyAndCompactAccelerationStructureToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.WriteTimestampWithGranularityIntoHeapAtIndex, (nint)granularity, counterHeap.NativePtr, index);
    }
}

file static class MTL4ComputeCommandEncoderBindings
{
    public static readonly Selector BuildAccelerationStructureDescriptorScratchBuffer = "buildAccelerationStructure:descriptor:scratchBuffer:";

    public static readonly Selector CopyAccelerationStructureToAccelerationStructure = "copyAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyAndCompactAccelerationStructureToAccelerationStructure = "copyAndCompactAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";

    public static readonly Selector CopyFromBufferSourceOffsetToBufferDestinationOffsetSize = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";

    public static readonly Selector CopyFromTensorSourceOriginSourceDimensionsToTensorDestinationOriginDestinationDimensions = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelToTextureDestinationSliceDestinationLevelSliceCountLevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";

    public static readonly Selector CopyFromTextureToTexture = "copyFromTexture:toTexture:";

    public static readonly Selector CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";

    public static readonly Selector DispatchThreadgroupsThreadsPerThreadgroup = "dispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadgroupsWithIndirectBufferThreadsPerThreadgroup = "dispatchThreadgroupsWithIndirectBuffer:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadsThreadsPerThreadgroup = "dispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadsWithIndirectBuffer = "dispatchThreadsWithIndirectBuffer:";

    public static readonly Selector ExecuteCommandsInBufferIndirectBuffer = "executeCommandsInBuffer:indirectBuffer:";

    public static readonly Selector ExecuteCommandsInBufferWithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector FillBufferRangeValue = "fillBuffer:range:value:";

    public static readonly Selector GenerateMipmapsForTexture = "generateMipmapsForTexture:";

    public static readonly Selector OptimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = "optimizeContentsForCPUAccess:slice:level:";

    public static readonly Selector OptimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = "optimizeContentsForGPUAccess:slice:level:";

    public static readonly Selector OptimizeIndirectCommandBufferWithRange = "optimizeIndirectCommandBuffer:withRange:";

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationScratchBuffer = "refitAccelerationStructure:descriptor:destination:scratchBuffer:";

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationScratchBufferOptions = "refitAccelerationStructure:descriptor:destination:scratchBuffer:options:";

    public static readonly Selector ResetCommandsInBufferWithRange = "resetCommandsInBuffer:withRange:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidthHeight = "setImageblockWidth:height:";

    public static readonly Selector SetThreadgroupMemoryLengthAtIndex = "setThreadgroupMemoryLength:atIndex:";

    public static readonly Selector Stages = "stages";

    public static readonly Selector WriteCompactedAccelerationStructureSizeToBuffer = "writeCompactedAccelerationStructureSize:toBuffer:";

    public static readonly Selector WriteTimestampWithGranularityIntoHeapAtIndex = "writeTimestampWithGranularity:intoHeap:atIndex:";
}
