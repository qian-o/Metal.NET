namespace Metal.NET;

public partial class MTL4ComputeCommandEncoder : NativeObject
{
    public MTL4ComputeCommandEncoder(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLStages Stages
    {
        get => (MTLStages)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ComputeCommandEncoderSelector.Stages);
    }

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTL4BufferRange scratchBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.BuildAccelerationStructure, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyAndCompactAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTensor, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyIndirectCommandBuffer, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreads, indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.FillBuffer, buffer.NativePtr, range, value);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.GenerateMipmaps, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccess, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccess, texture.NativePtr, slice, level);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeIndirectCommandBuffer, indirectCommandBuffer.NativePtr, range);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer, (nuint)options);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ResetCommandsInBuffer, buffer.NativePtr, range);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetImageblockWidth, width, height);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetThreadgroupMemoryLength, length, index);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTL4BufferRange buffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.WriteCompactedAccelerationStructureSize, accelerationStructure.NativePtr, buffer);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderSelector.WriteTimestamp, (nint)granularity, counterHeap.NativePtr, index);
    }
}

file static class MTL4ComputeCommandEncoderSelector
{
    public static readonly Selector BuildAccelerationStructure = Selector.Register("buildAccelerationStructure:::");

    public static readonly Selector CopyAccelerationStructure = Selector.Register("copyAccelerationStructure::");

    public static readonly Selector CopyAndCompactAccelerationStructure = Selector.Register("copyAndCompactAccelerationStructure::");

    public static readonly Selector CopyFromBuffer = Selector.Register("copyFromBuffer:::::");

    public static readonly Selector CopyFromTensor = Selector.Register("copyFromTensor::::::");

    public static readonly Selector CopyFromTexture = Selector.Register("copyFromTexture::");

    public static readonly Selector CopyIndirectCommandBuffer = Selector.Register("copyIndirectCommandBuffer::::");

    public static readonly Selector DispatchThreadgroups = Selector.Register("dispatchThreadgroups::");

    public static readonly Selector DispatchThreads = Selector.Register("dispatchThreads::");

    public static readonly Selector ExecuteCommandsInBuffer = Selector.Register("executeCommandsInBuffer::");

    public static readonly Selector FillBuffer = Selector.Register("fillBuffer:::");

    public static readonly Selector GenerateMipmaps = Selector.Register("generateMipmaps:");

    public static readonly Selector OptimizeContentsForCPUAccess = Selector.Register("optimizeContentsForCPUAccess:");

    public static readonly Selector OptimizeContentsForGPUAccess = Selector.Register("optimizeContentsForGPUAccess:");

    public static readonly Selector OptimizeIndirectCommandBuffer = Selector.Register("optimizeIndirectCommandBuffer::");

    public static readonly Selector RefitAccelerationStructure = Selector.Register("refitAccelerationStructure::::");

    public static readonly Selector ResetCommandsInBuffer = Selector.Register("resetCommandsInBuffer::");

    public static readonly Selector SetArgumentTable = Selector.Register("setArgumentTable:");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:");

    public static readonly Selector SetImageblockWidth = Selector.Register("setImageblockWidth::");

    public static readonly Selector SetThreadgroupMemoryLength = Selector.Register("setThreadgroupMemoryLength::");

    public static readonly Selector Stages = Selector.Register("stages");

    public static readonly Selector WriteCompactedAccelerationStructureSize = Selector.Register("writeCompactedAccelerationStructureSize::");

    public static readonly Selector WriteTimestamp = Selector.Register("writeTimestamp:::");
}
