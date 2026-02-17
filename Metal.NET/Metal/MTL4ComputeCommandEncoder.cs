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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize, sourceBuffer.NativePtr, (nint)sourceOffset, destinationBuffer.NativePtr, (nint)destinationOffset, (nint)size);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, uint sourceBytesPerRow, uint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceBuffer.NativePtr, (nint)sourceOffset, (nint)sourceBytesPerRow, (nint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, (nint)sliceCount, (nint)levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadgroupsThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadsThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(uint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreads, (nint)indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, uint indirectRangeBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ExecuteCommandsInBufferIndirectRangeBuffer, indirectCommandbuffer.NativePtr, (nint)indirectRangeBuffer);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, (nint)slice, (nint)level);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetImageblockWidthHeight, (nint)width, (nint)height);
    }

    public void SetThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetThreadgroupMemoryLengthIndex, (nint)length, (nint)index);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.WriteTimestampCounterHeapIndex, (nint)(uint)granularity, counterHeap.NativePtr, (nint)index);
    }

}

file class MTL4ComputeCommandEncoderSelector
{
    public static readonly Selector CopyAccelerationStructureDestinationAccelerationStructure = Selector.Register("copyAccelerationStructure:destinationAccelerationStructure:");

    public static readonly Selector CopyAndCompactAccelerationStructureDestinationAccelerationStructure = Selector.Register("copyAndCompactAccelerationStructure:destinationAccelerationStructure:");

    public static readonly Selector CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize = Selector.Register("copyFromBuffer:sourceOffset:destinationBuffer:destinationOffset:size:");

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector CopyFromTensorSourceOriginSourceDimensionsDestinationTensorDestinationOriginDestinationDimensions = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:destinationTensor:destinationOrigin:destinationDimensions:");

    public static readonly Selector CopyFromTextureDestinationTexture = Selector.Register("copyFromTexture:destinationTexture:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:destinationTexture:destinationSlice:destinationLevel:sliceCount:levelCount:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector DispatchThreadgroupsThreadsPerThreadgroup = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreadsThreadsPerThreadgroup = Selector.Register("dispatchThreads:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreads = Selector.Register("dispatchThreads:");

    public static readonly Selector ExecuteCommandsInBufferIndirectRangeBuffer = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:");

    public static readonly Selector GenerateMipmaps = Selector.Register("generateMipmaps:");

    public static readonly Selector OptimizeContentsForCPUAccess = Selector.Register("optimizeContentsForCPUAccess:");

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = Selector.Register("optimizeContentsForCPUAccess:slice:level:");

    public static readonly Selector OptimizeContentsForGPUAccess = Selector.Register("optimizeContentsForGPUAccess:");

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = Selector.Register("optimizeContentsForGPUAccess:slice:level:");

    public static readonly Selector SetArgumentTable = Selector.Register("setArgumentTable:");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:");

    public static readonly Selector SetImageblockWidthHeight = Selector.Register("setImageblockWidth:height:");

    public static readonly Selector SetThreadgroupMemoryLengthIndex = Selector.Register("setThreadgroupMemoryLength:index:");

    public static readonly Selector WriteTimestampCounterHeapIndex = Selector.Register("writeTimestamp:counterHeap:index:");
}
