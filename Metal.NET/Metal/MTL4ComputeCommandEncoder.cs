namespace Metal.NET;

public class MTL4ComputeCommandEncoder : IDisposable
{
    public MTL4ComputeCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4ComputeCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4ComputeCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4ComputeCommandEncoder(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public nuint Stages
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ComputeCommandEncoderSelector.Stages);
    }

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTL4BufferRange scratchBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.BuildAccelerationStructureDescriptorScratchBuffer, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyAccelerationStructureDestinationAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyAndCompactAccelerationStructureDestinationAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, MTLBuffer destinationBuffer, uint destinationOffset, uint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize, sourceBuffer.NativePtr, (nuint)sourceOffset, destinationBuffer.NativePtr, (nuint)destinationOffset, (nuint)size);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, uint sourceBytesPerRow, uint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceBuffer.NativePtr, (nuint)sourceOffset, (nuint)sourceBytesPerRow, (nuint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nuint)destinationSlice, (nuint)destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, uint sourceBytesPerRow, uint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin, uint options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, (nuint)sourceOffset, (nuint)sourceBytesPerRow, (nuint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nuint)destinationSlice, (nuint)destinationLevel, destinationOrigin, (nuint)options);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTensorSourceOriginSourceDimensionsDestinationTensorDestinationOriginDestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureDestinationTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, uint sliceCount, uint levelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount, sourceTexture.NativePtr, (nuint)sourceSlice, (nuint)sourceLevel, destinationTexture.NativePtr, (nuint)destinationSlice, (nuint)destinationLevel, (nuint)sliceCount, (nuint)levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, (nuint)sourceSlice, (nuint)sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, (nuint)destinationSlice, (nuint)destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, uint destinationOffset, uint destinationBytesPerRow, uint destinationBytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage, sourceTexture.NativePtr, (nuint)sourceSlice, (nuint)sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, (nuint)destinationOffset, (nuint)destinationBytesPerRow, (nuint)destinationBytesPerImage);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, uint destinationOffset, uint destinationBytesPerRow, uint destinationBytesPerImage, uint options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, (nuint)sourceSlice, (nuint)sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, (nuint)destinationOffset, (nuint)destinationBytesPerRow, (nuint)destinationBytesPerImage, (nuint)options);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, uint destinationIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex, source.NativePtr, sourceRange, destination.NativePtr, (nuint)destinationIndex);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadgroupsThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(uint indirectBuffer, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadgroupsThreadsPerThreadgroup, (nuint)indirectBuffer, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadsThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(uint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreads, (nuint)indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ExecuteCommandsInBufferExecutionRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, uint indirectRangeBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ExecuteCommandsInBufferIndirectRangeBuffer, indirectCommandbuffer.NativePtr, (nuint)indirectRangeBuffer);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.FillBufferRangeValue, buffer.NativePtr, range, value);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.GenerateMipmaps, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, (nuint)slice, (nuint)level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, (nuint)slice, (nuint)level);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeIndirectCommandBufferRange, indirectCommandBuffer.NativePtr, range);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.RefitAccelerationStructureDescriptorDestinationAccelerationStructureScratchBuffer, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer, uint options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.RefitAccelerationStructureDescriptorDestinationAccelerationStructureScratchBufferOptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer, (nuint)options);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ResetCommandsInBufferRange, buffer.NativePtr, range);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetArgumentTable, argumentTable.NativePtr);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetComputePipelineState, state.NativePtr);
    }

    public void SetImageblockWidth(uint width, uint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetImageblockWidthHeight, (nuint)width, (nuint)height);
    }

    public void SetThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetThreadgroupMemoryLengthIndex, (nuint)length, (nuint)index);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTL4BufferRange buffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.WriteCompactedAccelerationStructureSizeBuffer, accelerationStructure.NativePtr, buffer);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.WriteTimestampCounterHeapIndex, (uint)granularity, counterHeap.NativePtr, (nuint)index);
    }

}

file class MTL4ComputeCommandEncoderSelector
{
    public static readonly Selector Stages = Selector.Register("stages");

    public static readonly Selector BuildAccelerationStructureDescriptorScratchBuffer = Selector.Register("buildAccelerationStructure:descriptor:scratchBuffer:");

    public static readonly Selector CopyAccelerationStructureDestinationAccelerationStructure = Selector.Register("copyAccelerationStructure:destinationAccelerationStructure:");

    public static readonly Selector CopyAndCompactAccelerationStructureDestinationAccelerationStructure = Selector.Register("copyAndCompactAccelerationStructure:destinationAccelerationStructure:");

    public static readonly Selector CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize = Selector.Register("copyFromBuffer:sourceOffset:destinationBuffer:destinationOffset:size:");

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOriginOptions = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:options:");

    public static readonly Selector CopyFromTensorSourceOriginSourceDimensionsDestinationTensorDestinationOriginDestinationDimensions = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:destinationTensor:destinationOrigin:destinationDimensions:");

    public static readonly Selector CopyFromTextureDestinationTexture = Selector.Register("copyFromTexture:destinationTexture:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:destinationTexture:destinationSlice:destinationLevel:sliceCount:levelCount:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:");

    public static readonly Selector CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex = Selector.Register("copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:");

    public static readonly Selector DispatchThreadgroupsThreadsPerThreadgroup = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreadsThreadsPerThreadgroup = Selector.Register("dispatchThreads:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreads = Selector.Register("dispatchThreads:");

    public static readonly Selector ExecuteCommandsInBufferExecutionRange = Selector.Register("executeCommandsInBuffer:executionRange:");

    public static readonly Selector ExecuteCommandsInBufferIndirectRangeBuffer = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:");

    public static readonly Selector FillBufferRangeValue = Selector.Register("fillBuffer:range:value:");

    public static readonly Selector GenerateMipmaps = Selector.Register("generateMipmaps:");

    public static readonly Selector OptimizeContentsForCPUAccess = Selector.Register("optimizeContentsForCPUAccess:");

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = Selector.Register("optimizeContentsForCPUAccess:slice:level:");

    public static readonly Selector OptimizeContentsForGPUAccess = Selector.Register("optimizeContentsForGPUAccess:");

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = Selector.Register("optimizeContentsForGPUAccess:slice:level:");

    public static readonly Selector OptimizeIndirectCommandBufferRange = Selector.Register("optimizeIndirectCommandBuffer:range:");

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationAccelerationStructureScratchBuffer = Selector.Register("refitAccelerationStructure:descriptor:destinationAccelerationStructure:scratchBuffer:");

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationAccelerationStructureScratchBufferOptions = Selector.Register("refitAccelerationStructure:descriptor:destinationAccelerationStructure:scratchBuffer:options:");

    public static readonly Selector ResetCommandsInBufferRange = Selector.Register("resetCommandsInBuffer:range:");

    public static readonly Selector SetArgumentTable = Selector.Register("setArgumentTable:");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:");

    public static readonly Selector SetImageblockWidthHeight = Selector.Register("setImageblockWidth:height:");

    public static readonly Selector SetThreadgroupMemoryLengthIndex = Selector.Register("setThreadgroupMemoryLength:index:");

    public static readonly Selector WriteCompactedAccelerationStructureSizeBuffer = Selector.Register("writeCompactedAccelerationStructureSize:buffer:");

    public static readonly Selector WriteTimestampCounterHeapIndex = Selector.Register("writeTimestamp:counterHeap:index:");
}
