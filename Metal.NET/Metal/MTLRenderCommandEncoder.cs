namespace Metal.NET;

public class MTLRenderCommandEncoder : IDisposable
{
    public MTLRenderCommandEncoder(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLRenderCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint TileHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderSelector.TileHeight);
    }

    public nuint TileWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderSelector.TileWidth);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DispatchThreadsPerTile, threadsPerTile);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer.NativePtr, indexBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset, (ulong)primitiveType, (ulong)indexType, indexBuffer.NativePtr, indexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesIndirectBufferIndirectBufferOffset, (ulong)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesIndirectBufferIndirectBufferOffset, (ulong)primitiveType, vertexStart, vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesIndirectBufferIndirectBufferOffset, (ulong)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesIndirectBufferIndirectBufferOffset, (ulong)primitiveType, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.MemoryBarrierWithResourcesCountAfterStagesBeforeStages, (ulong)scope, (ulong)after, (ulong)before);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SampleCountersInBufferAtSampleIndexWithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetBlendColorRedGreenBlueAlpha, red, green, blue, alpha);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreActionAtIndex, (ulong)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreActionOptionsAtIndex, (ulong)storeActionOptions, colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetCullMode, (ulong)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthBiasSlopeScaleClamp, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthClipMode, (ulong)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreAction, (ulong)storeAction);
    }

    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreActionOptions, (ulong)storeActionOptions);
    }

    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthTestMinBoundMaxBound, minBound, maxBound);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentAccelerationStructureAtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetFragmentBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBufferOffsetAtIndex2, offset, index);
    }

    public void SetFragmentBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBytesLengthAtIndex, bytes, length, index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetFragmentTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentTextureAtIndex, texture.NativePtr, index);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFrontFacingWinding, (ulong)frontFacingWinding);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetMeshBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBufferOffsetAtIndex2, offset, index);
    }

    public void SetMeshBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBytesLengthAtIndex, bytes, length, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetMeshTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshTextureAtIndex, texture.NativePtr, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetObjectBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBufferOffsetAtIndex2, offset, index);
    }

    public void SetObjectBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBytesLengthAtIndex, bytes, length, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetObjectTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectTextureAtIndex, texture.NativePtr, index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectThreadgroupMemoryLengthAtIndex, length, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetScissorRect, rect);
    }

    public void SetScissorRects(MTLScissorRect scissorRects, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetScissorRectsCount, scissorRects, count);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilFrontReferenceValueBackReferenceValue, frontReferenceValue, backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreAction, (ulong)storeAction);
    }

    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreActionOptions, (ulong)storeActionOptions);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorBufferOffsetInstanceStride, buffer.NativePtr, offset, instanceStride);
    }

    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorScale, scale);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetThreadgroupMemoryLengthOffsetAtIndex, length, offset, index);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileAccelerationStructureAtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetTileBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetTileBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBufferOffsetAtIndex2, offset, index);
    }

    public void SetTileBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBytesLengthAtIndex, bytes, length, index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetTileTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileTextureAtIndex, texture.NativePtr, index);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTriangleFillMode, (ulong)fillMode);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexAccelerationStructureAtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexAmplificationCountViewMappings, count, viewMappings);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetAttributeStrideAtIndex3, offset, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetAttributeStrideAtIndex3, offset, stride, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytesLengthAttributeStrideAtIndex, bytes, length, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytesLengthAttributeStrideAtIndex, bytes, length, stride, index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetVertexTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexTextureAtIndex, texture.NativePtr, index);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetViewport, viewport);
    }

    public void SetViewports(MTLViewport viewports, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetViewportsCount, viewports, count);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVisibilityResultModeOffset, (ulong)mode, offset);
    }

    public void TextureBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.TextureBarrier);
    }

    public void UpdateFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UpdateFenceAfterStages, fence.NativePtr, (ulong)stages);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeapStages, heap.NativePtr);
    }

    public void UseHeap(MTLHeap heap, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeapStages, heap.NativePtr, (ulong)stages);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResourceUsageStages, resource.NativePtr, (ulong)usage);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResourceUsageStages, resource.NativePtr, (ulong)usage, (ulong)stages);
    }

    public void WaitForFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.WaitForFenceBeforeStages, fence.NativePtr, (ulong)stages);
    }

    public static implicit operator nint(MTLRenderCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderCommandEncoder(nint value)
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
}

file class MTLRenderCommandEncoderSelector
{
    public static readonly Selector TileHeight = Selector.Register("tileHeight");

    public static readonly Selector TileWidth = Selector.Register("tileWidth");

    public static readonly Selector DispatchThreadsPerTile = Selector.Register("dispatchThreadsPerTile:");

    public static readonly Selector DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector DrawMeshThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector DrawPrimitivesIndirectBufferIndirectBufferOffset = Selector.Register("drawPrimitives:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset = Selector.Register("executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector MemoryBarrierWithResourcesCountAfterStagesBeforeStages = Selector.Register("memoryBarrierWithResources:count:afterStages:beforeStages:");

    public static readonly Selector SampleCountersInBufferAtSampleIndexWithBarrier = Selector.Register("sampleCountersInBuffer:atSampleIndex:withBarrier:");

    public static readonly Selector SetBlendColorRedGreenBlueAlpha = Selector.Register("setBlendColorRed:green:blue:alpha:");

    public static readonly Selector SetColorAttachmentMap = Selector.Register("setColorAttachmentMap:");

    public static readonly Selector SetColorStoreActionAtIndex = Selector.Register("setColorStoreAction:atIndex:");

    public static readonly Selector SetColorStoreActionOptionsAtIndex = Selector.Register("setColorStoreActionOptions:atIndex:");

    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");

    public static readonly Selector SetDepthBiasSlopeScaleClamp = Selector.Register("setDepthBias:slopeScale:clamp:");

    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");

    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthStoreActionOptions = Selector.Register("setDepthStoreActionOptions:");

    public static readonly Selector SetDepthTestMinBoundMaxBound = Selector.Register("setDepthTestMinBound:maxBound:");

    public static readonly Selector SetFragmentAccelerationStructureAtBufferIndex = Selector.Register("setFragmentAccelerationStructure:atBufferIndex:");

    public static readonly Selector SetFragmentBufferOffsetAtIndex = Selector.Register("setFragmentBuffer:offset:atIndex:");

    public static readonly Selector SetFragmentBufferOffsetAtIndex2 = Selector.Register("setFragmentBufferOffset:atIndex:");

    public static readonly Selector SetFragmentBytesLengthAtIndex = Selector.Register("setFragmentBytes:length:atIndex:");

    public static readonly Selector SetFragmentSamplerStateLodMinClampLodMaxClampAtIndex = Selector.Register("setFragmentSamplerState:lodMinClamp:lodMaxClamp:atIndex:");

    public static readonly Selector SetFragmentTextureAtIndex = Selector.Register("setFragmentTexture:atIndex:");

    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");

    public static readonly Selector SetMeshBufferOffsetAtIndex = Selector.Register("setMeshBuffer:offset:atIndex:");

    public static readonly Selector SetMeshBufferOffsetAtIndex2 = Selector.Register("setMeshBufferOffset:atIndex:");

    public static readonly Selector SetMeshBytesLengthAtIndex = Selector.Register("setMeshBytes:length:atIndex:");

    public static readonly Selector SetMeshSamplerStateLodMinClampLodMaxClampAtIndex = Selector.Register("setMeshSamplerState:lodMinClamp:lodMaxClamp:atIndex:");

    public static readonly Selector SetMeshTextureAtIndex = Selector.Register("setMeshTexture:atIndex:");

    public static readonly Selector SetObjectBufferOffsetAtIndex = Selector.Register("setObjectBuffer:offset:atIndex:");

    public static readonly Selector SetObjectBufferOffsetAtIndex2 = Selector.Register("setObjectBufferOffset:atIndex:");

    public static readonly Selector SetObjectBytesLengthAtIndex = Selector.Register("setObjectBytes:length:atIndex:");

    public static readonly Selector SetObjectSamplerStateLodMinClampLodMaxClampAtIndex = Selector.Register("setObjectSamplerState:lodMinClamp:lodMaxClamp:atIndex:");

    public static readonly Selector SetObjectTextureAtIndex = Selector.Register("setObjectTexture:atIndex:");

    public static readonly Selector SetObjectThreadgroupMemoryLengthAtIndex = Selector.Register("setObjectThreadgroupMemoryLength:atIndex:");

    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");

    public static readonly Selector SetScissorRect = Selector.Register("setScissorRect:");

    public static readonly Selector SetScissorRectsCount = Selector.Register("setScissorRects:count:");

    public static readonly Selector SetStencilReferenceValue = Selector.Register("setStencilReferenceValue:");

    public static readonly Selector SetStencilFrontReferenceValueBackReferenceValue = Selector.Register("setStencilFrontReferenceValue:backReferenceValue:");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetStencilStoreActionOptions = Selector.Register("setStencilStoreActionOptions:");

    public static readonly Selector SetTessellationFactorBufferOffsetInstanceStride = Selector.Register("setTessellationFactorBuffer:offset:instanceStride:");

    public static readonly Selector SetTessellationFactorScale = Selector.Register("setTessellationFactorScale:");

    public static readonly Selector SetThreadgroupMemoryLengthOffsetAtIndex = Selector.Register("setThreadgroupMemoryLength:offset:atIndex:");

    public static readonly Selector SetTileAccelerationStructureAtBufferIndex = Selector.Register("setTileAccelerationStructure:atBufferIndex:");

    public static readonly Selector SetTileBufferOffsetAtIndex = Selector.Register("setTileBuffer:offset:atIndex:");

    public static readonly Selector SetTileBufferOffsetAtIndex2 = Selector.Register("setTileBufferOffset:atIndex:");

    public static readonly Selector SetTileBytesLengthAtIndex = Selector.Register("setTileBytes:length:atIndex:");

    public static readonly Selector SetTileSamplerStateLodMinClampLodMaxClampAtIndex = Selector.Register("setTileSamplerState:lodMinClamp:lodMaxClamp:atIndex:");

    public static readonly Selector SetTileTextureAtIndex = Selector.Register("setTileTexture:atIndex:");

    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");

    public static readonly Selector SetVertexAccelerationStructureAtBufferIndex = Selector.Register("setVertexAccelerationStructure:atBufferIndex:");

    public static readonly Selector SetVertexAmplificationCountViewMappings = Selector.Register("setVertexAmplificationCount:viewMappings:");

    public static readonly Selector SetVertexBufferOffsetAttributeStrideAtIndex = Selector.Register("setVertexBuffer:offset:attributeStride:atIndex:");

    public static readonly Selector SetVertexBufferOffsetAttributeStrideAtIndex3 = Selector.Register("setVertexBufferOffset:attributeStride:atIndex:");

    public static readonly Selector SetVertexBytesLengthAttributeStrideAtIndex = Selector.Register("setVertexBytes:length:attributeStride:atIndex:");

    public static readonly Selector SetVertexSamplerStateLodMinClampLodMaxClampAtIndex = Selector.Register("setVertexSamplerState:lodMinClamp:lodMaxClamp:atIndex:");

    public static readonly Selector SetVertexTextureAtIndex = Selector.Register("setVertexTexture:atIndex:");

    public static readonly Selector SetViewport = Selector.Register("setViewport:");

    public static readonly Selector SetViewportsCount = Selector.Register("setViewports:count:");

    public static readonly Selector SetVisibilityResultModeOffset = Selector.Register("setVisibilityResultMode:offset:");

    public static readonly Selector TextureBarrier = Selector.Register("textureBarrier");

    public static readonly Selector UpdateFenceAfterStages = Selector.Register("updateFence:afterStages:");

    public static readonly Selector UseHeapStages = Selector.Register("useHeap:stages:");

    public static readonly Selector UseResourceUsageStages = Selector.Register("useResource:usage:stages:");

    public static readonly Selector WaitForFenceBeforeStages = Selector.Register("waitForFence:beforeStages:");
}
