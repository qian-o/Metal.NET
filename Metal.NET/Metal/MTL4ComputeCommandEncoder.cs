namespace Metal.NET;

public class MTL4ComputeCommandEncoder(nint nativePtr) : MTL4CommandEncoder(nativePtr)
{
    public MTLStages Stages
    {
        get => (MTLStages)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4ComputeCommandEncoderSelector.Stages));
    }

    public static implicit operator nint(MTL4ComputeCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4ComputeCommandEncoder(nint value)
    {
        return new(value);
    }

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTL4BufferRange scratchBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.BuildAccelerationStructureDescriptorScratchBuffer, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyAccelerationStructureToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyAndCompactAccelerationStructureToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (ulong)options);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTensorSourceOriginSourceDimensionsToTensorDestinationOriginDestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (ulong)options);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadgroupsWithIndirectBufferThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(nuint indirectBuffer, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadgroupsWithIndirectBufferThreadsPerThreadgroup, indirectBuffer, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadsWithIndirectBuffer, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadsWithIndirectBuffer, indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ExecuteCommandsInBufferIndirectBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ExecuteCommandsInBufferIndirectBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.FillBufferRangeValue, buffer.NativePtr, range, value);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.GenerateMipmapsForTexture, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeIndirectCommandBufferWithRange, indirectCommandBuffer.NativePtr, range);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.RefitAccelerationStructureDescriptorDestinationScratchBufferOptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.RefitAccelerationStructureDescriptorDestinationScratchBufferOptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer, (ulong)options);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ResetCommandsInBufferWithRange, buffer.NativePtr, range);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetArgumentTable, argumentTable.NativePtr);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetComputePipelineState, state.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetImageblockWidthHeight, width, height);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetThreadgroupMemoryLengthAtIndex, length, index);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTL4BufferRange buffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.WriteCompactedAccelerationStructureSizeToBuffer, accelerationStructure.NativePtr, buffer);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.WriteTimestampWithGranularityIntoHeapAtIndex, (ulong)granularity, counterHeap.NativePtr, index);
    }
}

file class MTL4ComputeCommandEncoderSelector
{
    public static readonly Selector Stages = Selector.Register("stages");

    public static readonly Selector BuildAccelerationStructureDescriptorScratchBuffer = Selector.Register("buildAccelerationStructure:descriptor:scratchBuffer:");

    public static readonly Selector CopyAccelerationStructureToAccelerationStructure = Selector.Register("copyAccelerationStructure:toAccelerationStructure:");

    public static readonly Selector CopyAndCompactAccelerationStructureToAccelerationStructure = Selector.Register("copyAndCompactAccelerationStructure:toAccelerationStructure:");

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:");

    public static readonly Selector CopyFromTensorSourceOriginSourceDimensionsToTensorDestinationOriginDestinationDimensions = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:");

    public static readonly Selector CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex = Selector.Register("copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:");

    public static readonly Selector DispatchThreadgroupsWithIndirectBufferThreadsPerThreadgroup = Selector.Register("dispatchThreadgroupsWithIndirectBuffer:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreadsWithIndirectBuffer = Selector.Register("dispatchThreadsWithIndirectBuffer:");

    public static readonly Selector ExecuteCommandsInBufferIndirectBuffer = Selector.Register("executeCommandsInBuffer:indirectBuffer:");

    public static readonly Selector FillBufferRangeValue = Selector.Register("fillBuffer:range:value:");

    public static readonly Selector GenerateMipmapsForTexture = Selector.Register("generateMipmapsForTexture:");

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = Selector.Register("optimizeContentsForCPUAccess:slice:level:");

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = Selector.Register("optimizeContentsForGPUAccess:slice:level:");

    public static readonly Selector OptimizeIndirectCommandBufferWithRange = Selector.Register("optimizeIndirectCommandBuffer:withRange:");

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationScratchBufferOptions = Selector.Register("refitAccelerationStructure:descriptor:destination:scratchBuffer:options:");

    public static readonly Selector ResetCommandsInBufferWithRange = Selector.Register("resetCommandsInBuffer:withRange:");

    public static readonly Selector SetArgumentTable = Selector.Register("setArgumentTable:");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:");

    public static readonly Selector SetImageblockWidthHeight = Selector.Register("setImageblockWidth:height:");

    public static readonly Selector SetThreadgroupMemoryLengthAtIndex = Selector.Register("setThreadgroupMemoryLength:atIndex:");

    public static readonly Selector WriteCompactedAccelerationStructureSizeToBuffer = Selector.Register("writeCompactedAccelerationStructureSize:toBuffer:");

    public static readonly Selector WriteTimestampWithGranularityIntoHeapAtIndex = Selector.Register("writeTimestampWithGranularity:intoHeap:atIndex:");
}
