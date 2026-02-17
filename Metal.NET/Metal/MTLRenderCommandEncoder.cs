namespace Metal.NET;

public class MTLRenderCommandEncoder : IDisposable
{
    public MTLRenderCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint TileHeight => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderSelector.TileHeight);

    public nuint TileWidth => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderSelector.TileWidth);

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DispatchThreadsPerTile, threadsPerTile);
    }

    public void DrawIndexedPatches(uint numberOfPatchControlPoints, uint patchStart, uint patchCount, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, uint controlPointIndexBufferOffset, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstance, (nuint)numberOfPatchControlPoints, (nuint)patchStart, (nuint)patchCount, patchIndexBuffer.NativePtr, (nuint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nuint)controlPointIndexBufferOffset, (nuint)instanceCount, (nuint)baseInstance);
    }

    public void DrawIndexedPatches(uint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, uint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset, (nuint)numberOfPatchControlPoints, patchIndexBuffer.NativePtr, (nuint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nuint)controlPointIndexBufferOffset, indirectBuffer.NativePtr, (nuint)indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset, uint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCount, (uint)primitiveType, (nuint)indexCount, (uint)indexType, indexBuffer.NativePtr, (nuint)indexBufferOffset, (nuint)instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset, (uint)primitiveType, (nuint)indexCount, (uint)indexType, indexBuffer.NativePtr, (nuint)indexBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset, uint instanceCount, int baseVertex, uint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance, (uint)primitiveType, (nuint)indexCount, (uint)indexType, indexBuffer.NativePtr, (nuint)indexBufferOffset, (nuint)instanceCount, baseVertex, (nuint)baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset, MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset, (uint)primitiveType, (uint)indexType, indexBuffer.NativePtr, (nuint)indexBufferOffset, indirectBuffer.NativePtr, (nuint)indirectBufferOffset);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, uint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreadgroupsIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, indirectBuffer.NativePtr, (nuint)indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPatches(uint numberOfPatchControlPoints, uint patchStart, uint patchCount, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstance, (nuint)numberOfPatchControlPoints, (nuint)patchStart, (nuint)patchCount, patchIndexBuffer.NativePtr, (nuint)patchIndexBufferOffset, (nuint)instanceCount, (nuint)baseInstance);
    }

    public void DrawPatches(uint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset, (nuint)numberOfPatchControlPoints, patchIndexBuffer.NativePtr, (nuint)patchIndexBufferOffset, indirectBuffer.NativePtr, (nuint)indirectBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCountInstanceCount, (uint)primitiveType, (nuint)vertexStart, (nuint)vertexCount, (nuint)instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCount, (uint)primitiveType, (nuint)vertexStart, (nuint)vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance, (uint)primitiveType, (nuint)vertexStart, (nuint)vertexCount, (nuint)instanceCount, (nuint)baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesIndirectBufferIndirectBufferOffset, (uint)primitiveType, indirectBuffer.NativePtr, (nuint)indirectBufferOffset);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.ExecuteCommandsInBufferExecutionRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.ExecuteCommandsInBufferIndirectRangeBufferIndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, (nuint)indirectBufferOffset);
    }

    public void MemoryBarrier(uint scope, uint after, uint before)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.MemoryBarrierAfterBefore, (nuint)scope, (nuint)after, (nuint)before);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, uint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SampleCountersInBufferSampleIndexBarrier, sampleBuffer.NativePtr, (nuint)sampleIndex, barrier);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetBlendColorGreenBlueAlpha, red, green, blue, alpha);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, uint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreActionColorAttachmentIndex, (uint)storeAction, (nuint)colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(uint storeActionOptions, uint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreActionOptionsColorAttachmentIndex, (nuint)storeActionOptions, (nuint)colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetCullMode, (uint)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthBiasSlopeScaleClamp, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthClipMode, (uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreAction, (uint)storeAction);
    }

    public void SetDepthStoreActionOptions(uint storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthTestBoundsMaxBound, minBound, maxBound);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentAccelerationStructureBufferIndex, accelerationStructure.NativePtr, (nuint)bufferIndex);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetFragmentBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBufferOffsetIndex2, (nuint)offset, (nuint)index);
    }

    public void SetFragmentBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBytesLengthIndex, bytes, (nuint)length, (nuint)index);
    }

    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentIntersectionFunctionTableBufferIndex, intersectionFunctionTable.NativePtr, (nuint)bufferIndex);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentSamplerStateIndex, sampler.NativePtr, (nuint)index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentSamplerStateLodMinClampLodMaxClampIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, (nuint)index);
    }

    public void SetFragmentTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentTextureIndex, texture.NativePtr, (nuint)index);
    }

    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentVisibleFunctionTableBufferIndex, functionTable.NativePtr, (nuint)bufferIndex);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFrontFacingWinding, (uint)frontFacingWinding);
    }

    public void SetMeshBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetMeshBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBufferOffsetIndex2, (nuint)offset, (nuint)index);
    }

    public void SetMeshBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBytesLengthIndex, bytes, (nuint)length, (nuint)index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshSamplerStateIndex, sampler.NativePtr, (nuint)index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshSamplerStateLodMinClampLodMaxClampIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, (nuint)index);
    }

    public void SetMeshTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshTextureIndex, texture.NativePtr, (nuint)index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetObjectBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBufferOffsetIndex2, (nuint)offset, (nuint)index);
    }

    public void SetObjectBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBytesLengthIndex, bytes, (nuint)length, (nuint)index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectSamplerStateIndex, sampler.NativePtr, (nuint)index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectSamplerStateLodMinClampLodMaxClampIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, (nuint)index);
    }

    public void SetObjectTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectTextureIndex, texture.NativePtr, (nuint)index);
    }

    public void SetObjectThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectThreadgroupMemoryLengthIndex, (nuint)length, (nuint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetScissorRect, rect);
    }

    public void SetScissorRects(MTLScissorRect scissorRects, uint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetScissorRectsCount, scissorRects, (nuint)count);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValuesBackReferenceValue, frontReferenceValue, backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreAction, (uint)storeAction);
    }

    public void SetStencilStoreActionOptions(uint storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, uint offset, uint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorBufferOffsetInstanceStride, buffer.NativePtr, (nuint)offset, (nuint)instanceStride);
    }

    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorScale, scale);
    }

    public void SetThreadgroupMemoryLength(uint length, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetThreadgroupMemoryLengthOffsetIndex, (nuint)length, (nuint)offset, (nuint)index);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileAccelerationStructureBufferIndex, accelerationStructure.NativePtr, (nuint)bufferIndex);
    }

    public void SetTileBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetTileBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBufferOffsetIndex2, (nuint)offset, (nuint)index);
    }

    public void SetTileBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBytesLengthIndex, bytes, (nuint)length, (nuint)index);
    }

    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileIntersectionFunctionTableBufferIndex, intersectionFunctionTable.NativePtr, (nuint)bufferIndex);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileSamplerStateIndex, sampler.NativePtr, (nuint)index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileSamplerStateLodMinClampLodMaxClampIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, (nuint)index);
    }

    public void SetTileTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileTextureIndex, texture.NativePtr, (nuint)index);
    }

    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileVisibleFunctionTableBufferIndex, functionTable.NativePtr, (nuint)bufferIndex);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTriangleFillMode, (uint)fillMode);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexAccelerationStructureBufferIndex, accelerationStructure.NativePtr, (nuint)bufferIndex);
    }

    public void SetVertexAmplificationCount(uint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexAmplificationCountViewMappings, (nuint)count, viewMappings);
    }

    public void SetVertexBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetStrideIndex, buffer.NativePtr, (nuint)offset, (nuint)stride, (nuint)index);
    }

    public void SetVertexBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetIndex2, (nuint)offset, (nuint)index);
    }

    public void SetVertexBufferOffset(uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetStrideIndex3, (nuint)offset, (nuint)stride, (nuint)index);
    }

    public void SetVertexBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytesLengthIndex, bytes, (nuint)length, (nuint)index);
    }

    public void SetVertexBytes(int bytes, uint length, uint stride, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytesLengthStrideIndex, bytes, (nuint)length, (nuint)stride, (nuint)index);
    }

    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexIntersectionFunctionTableBufferIndex, intersectionFunctionTable.NativePtr, (nuint)bufferIndex);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexSamplerStateIndex, sampler.NativePtr, (nuint)index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexSamplerStateLodMinClampLodMaxClampIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, (nuint)index);
    }

    public void SetVertexTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexTextureIndex, texture.NativePtr, (nuint)index);
    }

    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexVisibleFunctionTableBufferIndex, functionTable.NativePtr, (nuint)bufferIndex);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetViewport, viewport);
    }

    public void SetViewports(MTLViewport viewports, uint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetViewportsCount, viewports, (nuint)count);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, uint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVisibilityResultModeOffset, (uint)mode, (nuint)offset);
    }

    public void TextureBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.TextureBarrier);
    }

    public void UpdateFence(MTLFence fence, uint stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UpdateFenceStages, fence.NativePtr, (nuint)stages);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeap, heap.NativePtr);
    }

    public void UseHeap(MTLHeap heap, uint stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeapStages, heap.NativePtr, (nuint)stages);
    }

    public void UseResource(MTLResource resource, uint usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResourceUsage, resource.NativePtr, (nuint)usage);
    }

    public void UseResource(MTLResource resource, uint usage, uint stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResourceUsageStages, resource.NativePtr, (nuint)usage, (nuint)stages);
    }

    public void WaitForFence(MTLFence fence, uint stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.WaitForFenceStages, fence.NativePtr, (nuint)stages);
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

    public static readonly Selector DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstance = Selector.Register("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:");

    public static readonly Selector DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCount = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:");

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:");

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:");

    public static readonly Selector DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawMeshThreadgroupsIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreadgroups:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstance = Selector.Register("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:");

    public static readonly Selector DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCount = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:");

    public static readonly Selector DrawPrimitivesVertexStartVertexCount = Selector.Register("drawPrimitives:vertexStart:vertexCount:");

    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");

    public static readonly Selector DrawPrimitivesIndirectBufferIndirectBufferOffset = Selector.Register("drawPrimitives:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector ExecuteCommandsInBufferExecutionRange = Selector.Register("executeCommandsInBuffer:executionRange:");

    public static readonly Selector ExecuteCommandsInBufferIndirectRangeBufferIndirectBufferOffset = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:indirectBufferOffset:");

    public static readonly Selector MemoryBarrierAfterBefore = Selector.Register("memoryBarrier:after:before:");

    public static readonly Selector SampleCountersInBufferSampleIndexBarrier = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");

    public static readonly Selector SetBlendColorGreenBlueAlpha = Selector.Register("setBlendColor:green:blue:alpha:");

    public static readonly Selector SetColorAttachmentMap = Selector.Register("setColorAttachmentMap:");

    public static readonly Selector SetColorStoreActionColorAttachmentIndex = Selector.Register("setColorStoreAction:colorAttachmentIndex:");

    public static readonly Selector SetColorStoreActionOptionsColorAttachmentIndex = Selector.Register("setColorStoreActionOptions:colorAttachmentIndex:");

    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");

    public static readonly Selector SetDepthBiasSlopeScaleClamp = Selector.Register("setDepthBias:slopeScale:clamp:");

    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");

    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthStoreActionOptions = Selector.Register("setDepthStoreActionOptions:");

    public static readonly Selector SetDepthTestBoundsMaxBound = Selector.Register("setDepthTestBounds:maxBound:");

    public static readonly Selector SetFragmentAccelerationStructureBufferIndex = Selector.Register("setFragmentAccelerationStructure:bufferIndex:");

    public static readonly Selector SetFragmentBufferOffsetIndex = Selector.Register("setFragmentBuffer:offset:index:");

    public static readonly Selector SetFragmentBufferOffsetIndex2 = Selector.Register("setFragmentBufferOffset:index:");

    public static readonly Selector SetFragmentBytesLengthIndex = Selector.Register("setFragmentBytes:length:index:");

    public static readonly Selector SetFragmentIntersectionFunctionTableBufferIndex = Selector.Register("setFragmentIntersectionFunctionTable:bufferIndex:");

    public static readonly Selector SetFragmentSamplerStateIndex = Selector.Register("setFragmentSamplerState:index:");

    public static readonly Selector SetFragmentSamplerStateLodMinClampLodMaxClampIndex = Selector.Register("setFragmentSamplerState:lodMinClamp:lodMaxClamp:index:");

    public static readonly Selector SetFragmentTextureIndex = Selector.Register("setFragmentTexture:index:");

    public static readonly Selector SetFragmentVisibleFunctionTableBufferIndex = Selector.Register("setFragmentVisibleFunctionTable:bufferIndex:");

    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");

    public static readonly Selector SetMeshBufferOffsetIndex = Selector.Register("setMeshBuffer:offset:index:");

    public static readonly Selector SetMeshBufferOffsetIndex2 = Selector.Register("setMeshBufferOffset:index:");

    public static readonly Selector SetMeshBytesLengthIndex = Selector.Register("setMeshBytes:length:index:");

    public static readonly Selector SetMeshSamplerStateIndex = Selector.Register("setMeshSamplerState:index:");

    public static readonly Selector SetMeshSamplerStateLodMinClampLodMaxClampIndex = Selector.Register("setMeshSamplerState:lodMinClamp:lodMaxClamp:index:");

    public static readonly Selector SetMeshTextureIndex = Selector.Register("setMeshTexture:index:");

    public static readonly Selector SetObjectBufferOffsetIndex = Selector.Register("setObjectBuffer:offset:index:");

    public static readonly Selector SetObjectBufferOffsetIndex2 = Selector.Register("setObjectBufferOffset:index:");

    public static readonly Selector SetObjectBytesLengthIndex = Selector.Register("setObjectBytes:length:index:");

    public static readonly Selector SetObjectSamplerStateIndex = Selector.Register("setObjectSamplerState:index:");

    public static readonly Selector SetObjectSamplerStateLodMinClampLodMaxClampIndex = Selector.Register("setObjectSamplerState:lodMinClamp:lodMaxClamp:index:");

    public static readonly Selector SetObjectTextureIndex = Selector.Register("setObjectTexture:index:");

    public static readonly Selector SetObjectThreadgroupMemoryLengthIndex = Selector.Register("setObjectThreadgroupMemoryLength:index:");

    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");

    public static readonly Selector SetScissorRect = Selector.Register("setScissorRect:");

    public static readonly Selector SetScissorRectsCount = Selector.Register("setScissorRects:count:");

    public static readonly Selector SetStencilReferenceValue = Selector.Register("setStencilReferenceValue:");

    public static readonly Selector SetStencilReferenceValuesBackReferenceValue = Selector.Register("setStencilReferenceValues:backReferenceValue:");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetStencilStoreActionOptions = Selector.Register("setStencilStoreActionOptions:");

    public static readonly Selector SetTessellationFactorBufferOffsetInstanceStride = Selector.Register("setTessellationFactorBuffer:offset:instanceStride:");

    public static readonly Selector SetTessellationFactorScale = Selector.Register("setTessellationFactorScale:");

    public static readonly Selector SetThreadgroupMemoryLengthOffsetIndex = Selector.Register("setThreadgroupMemoryLength:offset:index:");

    public static readonly Selector SetTileAccelerationStructureBufferIndex = Selector.Register("setTileAccelerationStructure:bufferIndex:");

    public static readonly Selector SetTileBufferOffsetIndex = Selector.Register("setTileBuffer:offset:index:");

    public static readonly Selector SetTileBufferOffsetIndex2 = Selector.Register("setTileBufferOffset:index:");

    public static readonly Selector SetTileBytesLengthIndex = Selector.Register("setTileBytes:length:index:");

    public static readonly Selector SetTileIntersectionFunctionTableBufferIndex = Selector.Register("setTileIntersectionFunctionTable:bufferIndex:");

    public static readonly Selector SetTileSamplerStateIndex = Selector.Register("setTileSamplerState:index:");

    public static readonly Selector SetTileSamplerStateLodMinClampLodMaxClampIndex = Selector.Register("setTileSamplerState:lodMinClamp:lodMaxClamp:index:");

    public static readonly Selector SetTileTextureIndex = Selector.Register("setTileTexture:index:");

    public static readonly Selector SetTileVisibleFunctionTableBufferIndex = Selector.Register("setTileVisibleFunctionTable:bufferIndex:");

    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");

    public static readonly Selector SetVertexAccelerationStructureBufferIndex = Selector.Register("setVertexAccelerationStructure:bufferIndex:");

    public static readonly Selector SetVertexAmplificationCountViewMappings = Selector.Register("setVertexAmplificationCount:viewMappings:");

    public static readonly Selector SetVertexBufferOffsetIndex = Selector.Register("setVertexBuffer:offset:index:");

    public static readonly Selector SetVertexBufferOffsetStrideIndex = Selector.Register("setVertexBuffer:offset:stride:index:");

    public static readonly Selector SetVertexBufferOffsetIndex2 = Selector.Register("setVertexBufferOffset:index:");

    public static readonly Selector SetVertexBufferOffsetStrideIndex3 = Selector.Register("setVertexBufferOffset:stride:index:");

    public static readonly Selector SetVertexBytesLengthIndex = Selector.Register("setVertexBytes:length:index:");

    public static readonly Selector SetVertexBytesLengthStrideIndex = Selector.Register("setVertexBytes:length:stride:index:");

    public static readonly Selector SetVertexIntersectionFunctionTableBufferIndex = Selector.Register("setVertexIntersectionFunctionTable:bufferIndex:");

    public static readonly Selector SetVertexSamplerStateIndex = Selector.Register("setVertexSamplerState:index:");

    public static readonly Selector SetVertexSamplerStateLodMinClampLodMaxClampIndex = Selector.Register("setVertexSamplerState:lodMinClamp:lodMaxClamp:index:");

    public static readonly Selector SetVertexTextureIndex = Selector.Register("setVertexTexture:index:");

    public static readonly Selector SetVertexVisibleFunctionTableBufferIndex = Selector.Register("setVertexVisibleFunctionTable:bufferIndex:");

    public static readonly Selector SetViewport = Selector.Register("setViewport:");

    public static readonly Selector SetViewportsCount = Selector.Register("setViewports:count:");

    public static readonly Selector SetVisibilityResultModeOffset = Selector.Register("setVisibilityResultMode:offset:");

    public static readonly Selector TextureBarrier = Selector.Register("textureBarrier");

    public static readonly Selector UpdateFenceStages = Selector.Register("updateFence:stages:");

    public static readonly Selector UseHeap = Selector.Register("useHeap:");

    public static readonly Selector UseHeapStages = Selector.Register("useHeap:stages:");

    public static readonly Selector UseResourceUsage = Selector.Register("useResource:usage:");

    public static readonly Selector UseResourceUsageStages = Selector.Register("useResource:usage:stages:");

    public static readonly Selector WaitForFenceStages = Selector.Register("waitForFence:stages:");
}
