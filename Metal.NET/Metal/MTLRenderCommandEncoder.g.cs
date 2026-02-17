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

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DispatchThreadsPerTile, threadsPerTile);
    }

    public void DrawIndexedPatches(uint numberOfPatchControlPoints, uint patchStart, uint patchCount, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, uint controlPointIndexBufferOffset, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstance, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nint)controlPointIndexBufferOffset, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawIndexedPatches(uint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, uint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset, (nint)numberOfPatchControlPoints, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nint)controlPointIndexBufferOffset, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset, uint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCount, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, (nint)instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset, uint instanceCount, int baseVertex, uint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, (nint)instanceCount, baseVertex, (nint)baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset, MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset, (nint)(uint)primitiveType, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void DrawPatches(uint numberOfPatchControlPoints, uint patchStart, uint patchCount, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstance, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawPatches(uint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset, (nint)numberOfPatchControlPoints, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCountInstanceCount, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCount, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitivesIndirectBufferIndirectBufferOffset, (nint)(uint)primitiveType, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.ExecuteCommandsInBufferIndirectRangeBufferIndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void MemoryBarrier(uint scope, uint after, uint before)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.MemoryBarrierAfterBefore, (nint)scope, (nint)after, (nint)before);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, uint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SampleCountersInBufferSampleIndexBarrier, sampleBuffer.NativePtr, (nint)sampleIndex, (nint)barrier.Value);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, uint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreActionColorAttachmentIndex, (nint)(uint)storeAction, (nint)colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(uint storeActionOptions, uint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreActionOptionsColorAttachmentIndex, (nint)storeActionOptions, (nint)colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetCullMode, (nint)(uint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthClipMode, (nint)(uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreAction, (nint)(uint)storeAction);
    }

    public void SetDepthStoreActionOptions(uint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreActionOptions, (nint)storeActionOptions);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentAccelerationStructureBufferIndex, accelerationStructure.NativePtr, (nint)bufferIndex);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetFragmentBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBufferOffsetIndex2, (nint)offset, (nint)index);
    }

    public void SetFragmentBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBytesLengthIndex, bytes, (nint)length, (nint)index);
    }

    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentIntersectionFunctionTableBufferIndex, intersectionFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentSamplerStateIndex, sampler.NativePtr, (nint)index);
    }

    public void SetFragmentTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentTextureIndex, texture.NativePtr, (nint)index);
    }

    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentVisibleFunctionTableBufferIndex, functionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFrontFacingWinding, (nint)(uint)frontFacingWinding);
    }

    public void SetMeshBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetMeshBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBufferOffsetIndex2, (nint)offset, (nint)index);
    }

    public void SetMeshBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBytesLengthIndex, bytes, (nint)length, (nint)index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshSamplerStateIndex, sampler.NativePtr, (nint)index);
    }

    public void SetMeshTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshTextureIndex, texture.NativePtr, (nint)index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetObjectBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBufferOffsetIndex2, (nint)offset, (nint)index);
    }

    public void SetObjectBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBytesLengthIndex, bytes, (nint)length, (nint)index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectSamplerStateIndex, sampler.NativePtr, (nint)index);
    }

    public void SetObjectTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectTextureIndex, texture.NativePtr, (nint)index);
    }

    public void SetObjectThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectThreadgroupMemoryLengthIndex, (nint)length, (nint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValue, (nint)referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValuesBackReferenceValue, (nint)frontReferenceValue, (nint)backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreAction, (nint)(uint)storeAction);
    }

    public void SetStencilStoreActionOptions(uint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreActionOptions, (nint)storeActionOptions);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, uint offset, uint instanceStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorBufferOffsetInstanceStride, buffer.NativePtr, (nint)offset, (nint)instanceStride);
    }

    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorScale, scale);
    }

    public void SetThreadgroupMemoryLength(uint length, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetThreadgroupMemoryLengthOffsetIndex, (nint)length, (nint)offset, (nint)index);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileAccelerationStructureBufferIndex, accelerationStructure.NativePtr, (nint)bufferIndex);
    }

    public void SetTileBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetTileBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBufferOffsetIndex2, (nint)offset, (nint)index);
    }

    public void SetTileBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBytesLengthIndex, bytes, (nint)length, (nint)index);
    }

    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileIntersectionFunctionTableBufferIndex, intersectionFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileSamplerStateIndex, sampler.NativePtr, (nint)index);
    }

    public void SetTileTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileTextureIndex, texture.NativePtr, (nint)index);
    }

    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileVisibleFunctionTableBufferIndex, functionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTriangleFillMode, (nint)(uint)fillMode);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexAccelerationStructureBufferIndex, accelerationStructure.NativePtr, (nint)bufferIndex);
    }

    public void SetVertexBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetStrideIndex, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetVertexBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetIndex2, (nint)offset, (nint)index);
    }

    public void SetVertexBufferOffset(uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffsetStrideIndex3, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetVertexBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytesLengthIndex, bytes, (nint)length, (nint)index);
    }

    public void SetVertexBytes(int bytes, uint length, uint stride, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytesLengthStrideIndex, bytes, (nint)length, (nint)stride, (nint)index);
    }

    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexIntersectionFunctionTableBufferIndex, intersectionFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexSamplerStateIndex, sampler.NativePtr, (nint)index);
    }

    public void SetVertexTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexTextureIndex, texture.NativePtr, (nint)index);
    }

    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexVisibleFunctionTableBufferIndex, functionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, uint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVisibilityResultModeOffset, (nint)(uint)mode, (nint)offset);
    }

    public void TextureBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.TextureBarrier);
    }

    public void UpdateFence(MTLFence fence, uint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UpdateFenceStages, fence.NativePtr, (nint)stages);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeap, heap.NativePtr);
    }

    public void UseHeap(MTLHeap heap, uint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeapStages, heap.NativePtr, (nint)stages);
    }

    public void UseResource(MTLResource resource, uint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResourceUsage, resource.NativePtr, (nint)usage);
    }

    public void UseResource(MTLResource resource, uint usage, uint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResourceUsageStages, resource.NativePtr, (nint)usage, (nint)stages);
    }

    public void WaitForFence(MTLFence fence, uint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.WaitForFenceStages, fence.NativePtr, (nint)stages);
    }

}

file class MTLRenderCommandEncoderSelector
{
    public static readonly Selector DispatchThreadsPerTile = Selector.Register("dispatchThreadsPerTile:");
    public static readonly Selector DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstance = Selector.Register("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:");
    public static readonly Selector DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCount = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:");
    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:");
    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:");
    public static readonly Selector DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstance = Selector.Register("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:");
    public static readonly Selector DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset = Selector.Register("drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCount = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:");
    public static readonly Selector DrawPrimitivesVertexStartVertexCount = Selector.Register("drawPrimitives:vertexStart:vertexCount:");
    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");
    public static readonly Selector DrawPrimitivesIndirectBufferIndirectBufferOffset = Selector.Register("drawPrimitives:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector ExecuteCommandsInBufferIndirectRangeBufferIndirectBufferOffset = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:indirectBufferOffset:");
    public static readonly Selector MemoryBarrierAfterBefore = Selector.Register("memoryBarrier:after:before:");
    public static readonly Selector SampleCountersInBufferSampleIndexBarrier = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");
    public static readonly Selector SetColorAttachmentMap = Selector.Register("setColorAttachmentMap:");
    public static readonly Selector SetColorStoreActionColorAttachmentIndex = Selector.Register("setColorStoreAction:colorAttachmentIndex:");
    public static readonly Selector SetColorStoreActionOptionsColorAttachmentIndex = Selector.Register("setColorStoreActionOptions:colorAttachmentIndex:");
    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");
    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");
    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");
    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");
    public static readonly Selector SetDepthStoreActionOptions = Selector.Register("setDepthStoreActionOptions:");
    public static readonly Selector SetFragmentAccelerationStructureBufferIndex = Selector.Register("setFragmentAccelerationStructure:bufferIndex:");
    public static readonly Selector SetFragmentBufferOffsetIndex = Selector.Register("setFragmentBuffer:offset:index:");
    public static readonly Selector SetFragmentBufferOffsetIndex2 = Selector.Register("setFragmentBufferOffset:index:");
    public static readonly Selector SetFragmentBytesLengthIndex = Selector.Register("setFragmentBytes:length:index:");
    public static readonly Selector SetFragmentIntersectionFunctionTableBufferIndex = Selector.Register("setFragmentIntersectionFunctionTable:bufferIndex:");
    public static readonly Selector SetFragmentSamplerStateIndex = Selector.Register("setFragmentSamplerState:index:");
    public static readonly Selector SetFragmentTextureIndex = Selector.Register("setFragmentTexture:index:");
    public static readonly Selector SetFragmentVisibleFunctionTableBufferIndex = Selector.Register("setFragmentVisibleFunctionTable:bufferIndex:");
    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");
    public static readonly Selector SetMeshBufferOffsetIndex = Selector.Register("setMeshBuffer:offset:index:");
    public static readonly Selector SetMeshBufferOffsetIndex2 = Selector.Register("setMeshBufferOffset:index:");
    public static readonly Selector SetMeshBytesLengthIndex = Selector.Register("setMeshBytes:length:index:");
    public static readonly Selector SetMeshSamplerStateIndex = Selector.Register("setMeshSamplerState:index:");
    public static readonly Selector SetMeshTextureIndex = Selector.Register("setMeshTexture:index:");
    public static readonly Selector SetObjectBufferOffsetIndex = Selector.Register("setObjectBuffer:offset:index:");
    public static readonly Selector SetObjectBufferOffsetIndex2 = Selector.Register("setObjectBufferOffset:index:");
    public static readonly Selector SetObjectBytesLengthIndex = Selector.Register("setObjectBytes:length:index:");
    public static readonly Selector SetObjectSamplerStateIndex = Selector.Register("setObjectSamplerState:index:");
    public static readonly Selector SetObjectTextureIndex = Selector.Register("setObjectTexture:index:");
    public static readonly Selector SetObjectThreadgroupMemoryLengthIndex = Selector.Register("setObjectThreadgroupMemoryLength:index:");
    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");
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
    public static readonly Selector SetTileTextureIndex = Selector.Register("setTileTexture:index:");
    public static readonly Selector SetTileVisibleFunctionTableBufferIndex = Selector.Register("setTileVisibleFunctionTable:bufferIndex:");
    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");
    public static readonly Selector SetVertexAccelerationStructureBufferIndex = Selector.Register("setVertexAccelerationStructure:bufferIndex:");
    public static readonly Selector SetVertexBufferOffsetIndex = Selector.Register("setVertexBuffer:offset:index:");
    public static readonly Selector SetVertexBufferOffsetStrideIndex = Selector.Register("setVertexBuffer:offset:stride:index:");
    public static readonly Selector SetVertexBufferOffsetIndex2 = Selector.Register("setVertexBufferOffset:index:");
    public static readonly Selector SetVertexBufferOffsetStrideIndex3 = Selector.Register("setVertexBufferOffset:stride:index:");
    public static readonly Selector SetVertexBytesLengthIndex = Selector.Register("setVertexBytes:length:index:");
    public static readonly Selector SetVertexBytesLengthStrideIndex = Selector.Register("setVertexBytes:length:stride:index:");
    public static readonly Selector SetVertexIntersectionFunctionTableBufferIndex = Selector.Register("setVertexIntersectionFunctionTable:bufferIndex:");
    public static readonly Selector SetVertexSamplerStateIndex = Selector.Register("setVertexSamplerState:index:");
    public static readonly Selector SetVertexTextureIndex = Selector.Register("setVertexTexture:index:");
    public static readonly Selector SetVertexVisibleFunctionTableBufferIndex = Selector.Register("setVertexVisibleFunctionTable:bufferIndex:");
    public static readonly Selector SetVisibilityResultModeOffset = Selector.Register("setVisibilityResultMode:offset:");
    public static readonly Selector TextureBarrier = Selector.Register("textureBarrier");
    public static readonly Selector UpdateFenceStages = Selector.Register("updateFence:stages:");
    public static readonly Selector UseHeap = Selector.Register("useHeap:");
    public static readonly Selector UseHeapStages = Selector.Register("useHeap:stages:");
    public static readonly Selector UseResourceUsage = Selector.Register("useResource:usage:");
    public static readonly Selector UseResourceUsageStages = Selector.Register("useResource:usage:stages:");
    public static readonly Selector WaitForFenceStages = Selector.Register("waitForFence:stages:");
}
