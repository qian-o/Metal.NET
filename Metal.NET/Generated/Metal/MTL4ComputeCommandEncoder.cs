namespace Metal.NET;

public partial class MTL4ComputeCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTL4CommandEncoder(nativePtr, ownership), INativeObject<MTL4ComputeCommandEncoder>
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
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetThreadgroupMemoryLength_AtIndex, length, index);
    }

    public void SetImageblockSize(nuint width, nuint height)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetImageblockWidth_Height, width, height);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreads_ThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadgroups_ThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(nuint indirectBuffer, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadgroupsWithIndirectBuffer_ThreadsPerThreadgroup, indirectBuffer, threadsPerThreadgroup);
    }

    public void DispatchThreads(nuint indirectBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadsWithIndirectBuffer, indirectBuffer);
    }

    public void ExecuteCommands(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ExecuteCommandsInBuffer_WithRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommands(MTLIndirectCommandBuffer indirectCommandbuffer, nuint indirectRangeBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ExecuteCommandsInBuffer_IndirectBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer);
    }

    public void Copy(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture_ToTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture_SourceSlice_SourceLevel_ToTexture_DestinationSlice_DestinationLevel_SliceCount_LevelCount, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToBuffer_DestinationOffset_DestinationBytesPerRow_DestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToBuffer_DestinationOffset_DestinationBytesPerRow_DestinationBytesPerImage_Options, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffer_SourceOffset_ToBuffer_DestinationOffset_Size, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffer_SourceOffset_SourceBytesPerRow_SourceBytesPerImage_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffer_SourceOffset_SourceBytesPerRow_SourceBytesPerImage_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin_Options, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    public void Copy(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTensor_SourceOrigin_SourceDimensions_ToTensor_DestinationOrigin_DestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.GenerateMipmapsForTexture, texture.NativePtr);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.FillBuffer_Range_Value, buffer.NativePtr, range, value);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccessSliceLevel(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForGPUAccess_Slice_Level, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccessSliceLevel(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForCPUAccess_Slice_Level, texture.NativePtr, slice, level);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ResetCommandsInBuffer_WithRange, buffer.NativePtr, range);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyIndirectCommandBuffer_SourceRange_Destination_DestinationIndex, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeIndirectCommandBuffer_WithRange, indirectCommandBuffer.NativePtr, range);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr);
    }

    public void Build(MTLAccelerationStructure accelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTL4BufferRange scratchBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.BuildAccelerationStructure_Descriptor_ScratchBuffer, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer);
    }

    public void Refit(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer);
    }

    public void Refit(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer_Options, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer, (nuint)options);
    }

    public void Copy(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyAccelerationStructure_ToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void WriteCompactedSize(MTLAccelerationStructure accelerationStructure, MTL4BufferRange buffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.WriteCompactedAccelerationStructureSize_ToBuffer, accelerationStructure.NativePtr, buffer);
    }

    public void CopyAndCompact(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyAndCompactAccelerationStructure_ToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.WriteTimestampWithGranularity_IntoHeap_AtIndex, (nint)granularity, counterHeap.NativePtr, index);
    }
}

file static class MTL4ComputeCommandEncoderBindings
{
    public static readonly Selector BuildAccelerationStructure_Descriptor_ScratchBuffer = "buildAccelerationStructure:descriptor:scratchBuffer:";

    public static readonly Selector CopyAccelerationStructure_ToAccelerationStructure = "copyAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyAndCompactAccelerationStructure_ToAccelerationStructure = "copyAndCompactAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyFromBuffer_SourceOffset_SourceBytesPerRow_SourceBytesPerImage_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromBuffer_SourceOffset_SourceBytesPerRow_SourceBytesPerImage_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin_Options = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";

    public static readonly Selector CopyFromBuffer_SourceOffset_ToBuffer_DestinationOffset_Size = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";

    public static readonly Selector CopyFromTensor_SourceOrigin_SourceDimensions_ToTensor_DestinationOrigin_DestinationDimensions = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";

    public static readonly Selector CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToBuffer_DestinationOffset_DestinationBytesPerRow_DestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";

    public static readonly Selector CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToBuffer_DestinationOffset_DestinationBytesPerRow_DestinationBytesPerImage_Options = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";

    public static readonly Selector CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromTexture_SourceSlice_SourceLevel_ToTexture_DestinationSlice_DestinationLevel_SliceCount_LevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";

    public static readonly Selector CopyFromTexture_ToTexture = "copyFromTexture:toTexture:";

    public static readonly Selector CopyIndirectCommandBuffer_SourceRange_Destination_DestinationIndex = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";

    public static readonly Selector DispatchThreadgroups_ThreadsPerThreadgroup = "dispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadgroupsWithIndirectBuffer_ThreadsPerThreadgroup = "dispatchThreadgroupsWithIndirectBuffer:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreads_ThreadsPerThreadgroup = "dispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadsWithIndirectBuffer = "dispatchThreadsWithIndirectBuffer:";

    public static readonly Selector ExecuteCommandsInBuffer_IndirectBuffer = "executeCommandsInBuffer:indirectBuffer:";

    public static readonly Selector ExecuteCommandsInBuffer_WithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector FillBuffer_Range_Value = "fillBuffer:range:value:";

    public static readonly Selector GenerateMipmapsForTexture = "generateMipmapsForTexture:";

    public static readonly Selector OptimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";

    public static readonly Selector OptimizeContentsForCPUAccess_Slice_Level = "optimizeContentsForCPUAccess:slice:level:";

    public static readonly Selector OptimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";

    public static readonly Selector OptimizeContentsForGPUAccess_Slice_Level = "optimizeContentsForGPUAccess:slice:level:";

    public static readonly Selector OptimizeIndirectCommandBuffer_WithRange = "optimizeIndirectCommandBuffer:withRange:";

    public static readonly Selector RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer = "refitAccelerationStructure:descriptor:destination:scratchBuffer:";

    public static readonly Selector RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer_Options = "refitAccelerationStructure:descriptor:destination:scratchBuffer:options:";

    public static readonly Selector ResetCommandsInBuffer_WithRange = "resetCommandsInBuffer:withRange:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidth_Height = "setImageblockWidth:height:";

    public static readonly Selector SetThreadgroupMemoryLength_AtIndex = "setThreadgroupMemoryLength:atIndex:";

    public static readonly Selector Stages = "stages";

    public static readonly Selector WriteCompactedAccelerationStructureSize_ToBuffer = "writeCompactedAccelerationStructureSize:toBuffer:";

    public static readonly Selector WriteTimestampWithGranularity_IntoHeap_AtIndex = "writeTimestampWithGranularity:intoHeap:atIndex:";
}
