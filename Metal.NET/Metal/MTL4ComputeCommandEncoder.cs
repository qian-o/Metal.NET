namespace Metal.NET;

public readonly struct MTL4ComputeCommandEncoder(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLStages Stages
    {
        get => (MTLStages)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ComputeCommandEncoderBindings.Stages);
    }

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTL4BufferRange scratchBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.BuildAccelerationStructure, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyAndCompactAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTensor, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.CopyIndirectCommandBuffer, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(nuint indirectBuffer, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreadgroups, indirectBuffer, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.DispatchThreads, indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.FillBuffer, buffer.NativePtr, range, value);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.GenerateMipmaps, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr, slice, level);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.OptimizeIndirectCommandBuffer, indirectCommandBuffer.NativePtr, range);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer, (nuint)options);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.ResetCommandsInBuffer, buffer.NativePtr, range);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetImageblockWidth, width, height);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.SetThreadgroupMemoryLength, length, index);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTL4BufferRange buffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputeCommandEncoderBindings.WriteCompactedAccelerationStructureSize, accelerationStructure.NativePtr, buffer);
    }
}

file static class MTL4ComputeCommandEncoderBindings
{
    public static readonly Selector BuildAccelerationStructure = Selector.Register("buildAccelerationStructure:descriptor:scratchBuffer:");

    public static readonly Selector CopyAccelerationStructure = Selector.Register("copyAccelerationStructure:toAccelerationStructure:");

    public static readonly Selector CopyAndCompactAccelerationStructure = Selector.Register("copyAndCompactAccelerationStructure:toAccelerationStructure:");

    public static readonly Selector CopyFromBuffer = Selector.Register("copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:");

    public static readonly Selector CopyFromTensor = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:");

    public static readonly Selector CopyFromTexture = Selector.Register("copyFromTexture:toTexture:");

    public static readonly Selector CopyIndirectCommandBuffer = Selector.Register("copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:");

    public static readonly Selector DispatchThreadgroups = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreads = Selector.Register("dispatchThreads:threadsPerThreadgroup:");

    public static readonly Selector ExecuteCommandsInBuffer = Selector.Register("executeCommandsInBuffer:withRange:");

    public static readonly Selector FillBuffer = Selector.Register("fillBuffer:range:value:");

    public static readonly Selector GenerateMipmaps = Selector.Register("generateMipmapsForTexture:");

    public static readonly Selector OptimizeContentsForCPUAccess = Selector.Register("optimizeContentsForCPUAccess:");

    public static readonly Selector OptimizeContentsForGPUAccess = Selector.Register("optimizeContentsForGPUAccess:");

    public static readonly Selector OptimizeIndirectCommandBuffer = Selector.Register("optimizeIndirectCommandBuffer:withRange:");

    public static readonly Selector RefitAccelerationStructure = Selector.Register("refitAccelerationStructure:descriptor:destination:scratchBuffer:");

    public static readonly Selector ResetCommandsInBuffer = Selector.Register("resetCommandsInBuffer:withRange:");

    public static readonly Selector SetImageblockWidth = Selector.Register("setImageblockWidth:height:");

    public static readonly Selector SetThreadgroupMemoryLength = Selector.Register("setThreadgroupMemoryLength:atIndex:");

    public static readonly Selector Stages = Selector.Register("stages");

    public static readonly Selector WriteCompactedAccelerationStructureSize = Selector.Register("writeCompactedAccelerationStructureSize:toBuffer:");
}
