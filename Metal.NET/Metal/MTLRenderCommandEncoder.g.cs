namespace Metal.NET;

file class MTLRenderCommandEncoderSelector
{
    public static readonly Selector DispatchThreadsPerTile_ = Selector.Register("dispatchThreadsPerTile:");
    public static readonly Selector DrawIndexedPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_controlPointIndexBuffer_controlPointIndexBufferOffset_instanceCount_baseInstance_ = Selector.Register("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:");
    public static readonly Selector DrawIndexedPatches_patchIndexBuffer_patchIndexBufferOffset_controlPointIndexBuffer_controlPointIndexBufferOffset_indirectBuffer_indirectBufferOffset_ = Selector.Register("drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_instanceCount_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:");
    public static readonly Selector DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:");
    public static readonly Selector DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_instanceCount_baseVertex_baseInstance_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:");
    public static readonly Selector DrawIndexedPrimitives_indexType_indexBuffer_indexBufferOffset_indirectBuffer_indirectBufferOffset_ = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector DrawPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_instanceCount_baseInstance_ = Selector.Register("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:");
    public static readonly Selector DrawPatches_patchIndexBuffer_patchIndexBufferOffset_indirectBuffer_indirectBufferOffset_ = Selector.Register("drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector DrawPrimitives_vertexStart_vertexCount_instanceCount_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:");
    public static readonly Selector DrawPrimitives_vertexStart_vertexCount_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:");
    public static readonly Selector DrawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");
    public static readonly Selector DrawPrimitives_indirectBuffer_indirectBufferOffset_ = Selector.Register("drawPrimitives:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector ExecuteCommandsInBuffer_indirectRangeBuffer_indirectBufferOffset_ = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:indirectBufferOffset:");
    public static readonly Selector MemoryBarrier_after_before_ = Selector.Register("memoryBarrier:after:before:");
    public static readonly Selector SampleCountersInBuffer_sampleIndex_barrier_ = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");
    public static readonly Selector SetColorAttachmentMap_ = Selector.Register("setColorAttachmentMap:");
    public static readonly Selector SetColorStoreAction_colorAttachmentIndex_ = Selector.Register("setColorStoreAction:colorAttachmentIndex:");
    public static readonly Selector SetColorStoreActionOptions_colorAttachmentIndex_ = Selector.Register("setColorStoreActionOptions:colorAttachmentIndex:");
    public static readonly Selector SetCullMode_ = Selector.Register("setCullMode:");
    public static readonly Selector SetDepthClipMode_ = Selector.Register("setDepthClipMode:");
    public static readonly Selector SetDepthStencilState_ = Selector.Register("setDepthStencilState:");
    public static readonly Selector SetDepthStoreAction_ = Selector.Register("setDepthStoreAction:");
    public static readonly Selector SetDepthStoreActionOptions_ = Selector.Register("setDepthStoreActionOptions:");
    public static readonly Selector SetFragmentAccelerationStructure_bufferIndex_ = Selector.Register("setFragmentAccelerationStructure:bufferIndex:");
    public static readonly Selector SetFragmentBuffer_offset_index_ = Selector.Register("setFragmentBuffer:offset:index:");
    public static readonly Selector SetFragmentBufferOffset_index_ = Selector.Register("setFragmentBufferOffset:index:");
    public static readonly Selector SetFragmentBytes_length_index_ = Selector.Register("setFragmentBytes:length:index:");
    public static readonly Selector SetFragmentIntersectionFunctionTable_bufferIndex_ = Selector.Register("setFragmentIntersectionFunctionTable:bufferIndex:");
    public static readonly Selector SetFragmentSamplerState_index_ = Selector.Register("setFragmentSamplerState:index:");
    public static readonly Selector SetFragmentTexture_index_ = Selector.Register("setFragmentTexture:index:");
    public static readonly Selector SetFragmentVisibleFunctionTable_bufferIndex_ = Selector.Register("setFragmentVisibleFunctionTable:bufferIndex:");
    public static readonly Selector SetFrontFacingWinding_ = Selector.Register("setFrontFacingWinding:");
    public static readonly Selector SetMeshBuffer_offset_index_ = Selector.Register("setMeshBuffer:offset:index:");
    public static readonly Selector SetMeshBufferOffset_index_ = Selector.Register("setMeshBufferOffset:index:");
    public static readonly Selector SetMeshBytes_length_index_ = Selector.Register("setMeshBytes:length:index:");
    public static readonly Selector SetMeshSamplerState_index_ = Selector.Register("setMeshSamplerState:index:");
    public static readonly Selector SetMeshTexture_index_ = Selector.Register("setMeshTexture:index:");
    public static readonly Selector SetObjectBuffer_offset_index_ = Selector.Register("setObjectBuffer:offset:index:");
    public static readonly Selector SetObjectBufferOffset_index_ = Selector.Register("setObjectBufferOffset:index:");
    public static readonly Selector SetObjectBytes_length_index_ = Selector.Register("setObjectBytes:length:index:");
    public static readonly Selector SetObjectSamplerState_index_ = Selector.Register("setObjectSamplerState:index:");
    public static readonly Selector SetObjectTexture_index_ = Selector.Register("setObjectTexture:index:");
    public static readonly Selector SetObjectThreadgroupMemoryLength_index_ = Selector.Register("setObjectThreadgroupMemoryLength:index:");
    public static readonly Selector SetRenderPipelineState_ = Selector.Register("setRenderPipelineState:");
    public static readonly Selector SetStencilReferenceValue_ = Selector.Register("setStencilReferenceValue:");
    public static readonly Selector SetStencilReferenceValues_backReferenceValue_ = Selector.Register("setStencilReferenceValues:backReferenceValue:");
    public static readonly Selector SetStencilStoreAction_ = Selector.Register("setStencilStoreAction:");
    public static readonly Selector SetStencilStoreActionOptions_ = Selector.Register("setStencilStoreActionOptions:");
    public static readonly Selector SetTessellationFactorBuffer_offset_instanceStride_ = Selector.Register("setTessellationFactorBuffer:offset:instanceStride:");
    public static readonly Selector SetTessellationFactorScale_ = Selector.Register("setTessellationFactorScale:");
    public static readonly Selector SetThreadgroupMemoryLength_offset_index_ = Selector.Register("setThreadgroupMemoryLength:offset:index:");
    public static readonly Selector SetTileAccelerationStructure_bufferIndex_ = Selector.Register("setTileAccelerationStructure:bufferIndex:");
    public static readonly Selector SetTileBuffer_offset_index_ = Selector.Register("setTileBuffer:offset:index:");
    public static readonly Selector SetTileBufferOffset_index_ = Selector.Register("setTileBufferOffset:index:");
    public static readonly Selector SetTileBytes_length_index_ = Selector.Register("setTileBytes:length:index:");
    public static readonly Selector SetTileIntersectionFunctionTable_bufferIndex_ = Selector.Register("setTileIntersectionFunctionTable:bufferIndex:");
    public static readonly Selector SetTileSamplerState_index_ = Selector.Register("setTileSamplerState:index:");
    public static readonly Selector SetTileTexture_index_ = Selector.Register("setTileTexture:index:");
    public static readonly Selector SetTileVisibleFunctionTable_bufferIndex_ = Selector.Register("setTileVisibleFunctionTable:bufferIndex:");
    public static readonly Selector SetTriangleFillMode_ = Selector.Register("setTriangleFillMode:");
    public static readonly Selector SetVertexAccelerationStructure_bufferIndex_ = Selector.Register("setVertexAccelerationStructure:bufferIndex:");
    public static readonly Selector SetVertexBuffer_offset_index_ = Selector.Register("setVertexBuffer:offset:index:");
    public static readonly Selector SetVertexBuffer_offset_stride_index_ = Selector.Register("setVertexBuffer:offset:stride:index:");
    public static readonly Selector SetVertexBufferOffset_index_ = Selector.Register("setVertexBufferOffset:index:");
    public static readonly Selector SetVertexBufferOffset_stride_index_ = Selector.Register("setVertexBufferOffset:stride:index:");
    public static readonly Selector SetVertexBytes_length_index_ = Selector.Register("setVertexBytes:length:index:");
    public static readonly Selector SetVertexBytes_length_stride_index_ = Selector.Register("setVertexBytes:length:stride:index:");
    public static readonly Selector SetVertexIntersectionFunctionTable_bufferIndex_ = Selector.Register("setVertexIntersectionFunctionTable:bufferIndex:");
    public static readonly Selector SetVertexSamplerState_index_ = Selector.Register("setVertexSamplerState:index:");
    public static readonly Selector SetVertexTexture_index_ = Selector.Register("setVertexTexture:index:");
    public static readonly Selector SetVertexVisibleFunctionTable_bufferIndex_ = Selector.Register("setVertexVisibleFunctionTable:bufferIndex:");
    public static readonly Selector SetVisibilityResultMode_offset_ = Selector.Register("setVisibilityResultMode:offset:");
    public static readonly Selector TextureBarrier = Selector.Register("textureBarrier");
    public static readonly Selector UpdateFence_stages_ = Selector.Register("updateFence:stages:");
    public static readonly Selector UseHeap_ = Selector.Register("useHeap:");
    public static readonly Selector UseHeap_stages_ = Selector.Register("useHeap:stages:");
    public static readonly Selector UseResource_usage_ = Selector.Register("useResource:usage:");
    public static readonly Selector UseResource_usage_stages_ = Selector.Register("useResource:usage:stages:");
    public static readonly Selector WaitForFence_stages_ = Selector.Register("waitForFence:stages:");
}

public class MTLRenderCommandEncoder : IDisposable
{
    public MTLRenderCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DispatchThreadsPerTile_, threadsPerTile);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_controlPointIndexBuffer_controlPointIndexBufferOffset_instanceCount_baseInstance_, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nint)controlPointIndexBufferOffset, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatches_patchIndexBuffer_patchIndexBufferOffset_controlPointIndexBuffer_controlPointIndexBufferOffset_indirectBuffer_indirectBufferOffset_, (nint)numberOfPatchControlPoints, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nint)controlPointIndexBufferOffset, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_instanceCount_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, (nint)instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_instanceCount_baseVertex_baseInstance_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, (nint)instanceCount, baseVertex, (nint)baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitives_indexType_indexBuffer_indexBufferOffset_indirectBuffer_indirectBufferOffset_, (nint)(uint)primitiveType, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_instanceCount_baseInstance_, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatches_patchIndexBuffer_patchIndexBufferOffset_indirectBuffer_indirectBufferOffset_, (nint)numberOfPatchControlPoints, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitives_vertexStart_vertexCount_instanceCount_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitives_vertexStart_vertexCount_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitives_indirectBuffer_indirectBufferOffset_, (nint)(uint)primitiveType, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.ExecuteCommandsInBuffer_indirectRangeBuffer_indirectBufferOffset_, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void MemoryBarrier(nuint scope, nuint after, nuint before)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.MemoryBarrier_after_before_, (nint)scope, (nint)after, (nint)before);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SampleCountersInBuffer_sampleIndex_barrier_, sampleBuffer.NativePtr, (nint)sampleIndex, (nint)barrier.Value);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorAttachmentMap_, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreAction_colorAttachmentIndex_, (nint)(uint)storeAction, (nint)colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(nuint storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreActionOptions_colorAttachmentIndex_, (nint)storeActionOptions, (nint)colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetCullMode_, (nint)(uint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthClipMode_, (nint)(uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStencilState_, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreAction_, (nint)(uint)storeAction);
    }

    public void SetDepthStoreActionOptions(nuint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreActionOptions_, (nint)storeActionOptions);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentAccelerationStructure_bufferIndex_, accelerationStructure.NativePtr, (nint)bufferIndex);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetFragmentBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBufferOffset_index_, (nint)offset, (nint)index);
    }

    public void SetFragmentBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBytes_length_index_, bytes, (nint)length, (nint)index);
    }

    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentIntersectionFunctionTable_bufferIndex_, intersectionFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetFragmentTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentVisibleFunctionTable_bufferIndex_, functionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFrontFacingWinding_, (nint)(uint)frontFacingWinding);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetMeshBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBufferOffset_index_, (nint)offset, (nint)index);
    }

    public void SetMeshBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBytes_length_index_, bytes, (nint)length, (nint)index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetMeshTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetObjectBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBufferOffset_index_, (nint)offset, (nint)index);
    }

    public void SetObjectBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBytes_length_index_, bytes, (nint)length, (nint)index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetObjectTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetRenderPipelineState_, pipelineState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValue_, (nint)referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValues_backReferenceValue_, (nint)frontReferenceValue, (nint)backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreAction_, (nint)(uint)storeAction);
    }

    public void SetStencilStoreActionOptions(nuint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreActionOptions_, (nint)storeActionOptions);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorBuffer_offset_instanceStride_, buffer.NativePtr, (nint)offset, (nint)instanceStride);
    }

    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorScale_, scale);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetThreadgroupMemoryLength_offset_index_, (nint)length, (nint)offset, (nint)index);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileAccelerationStructure_bufferIndex_, accelerationStructure.NativePtr, (nint)bufferIndex);
    }

    public void SetTileBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetTileBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBufferOffset_index_, (nint)offset, (nint)index);
    }

    public void SetTileBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBytes_length_index_, bytes, (nint)length, (nint)index);
    }

    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileIntersectionFunctionTable_bufferIndex_, intersectionFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetTileTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileVisibleFunctionTable_bufferIndex_, functionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTriangleFillMode_, (nint)(uint)fillMode);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexAccelerationStructure_bufferIndex_, accelerationStructure.NativePtr, (nint)bufferIndex);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBuffer_offset_stride_index_, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffset_index_, (nint)offset, (nint)index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffset_stride_index_, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytes_length_index_, bytes, (nint)length, (nint)index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytes_length_stride_index_, bytes, (nint)length, (nint)stride, (nint)index);
    }

    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexIntersectionFunctionTable_bufferIndex_, intersectionFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetVertexTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexVisibleFunctionTable_bufferIndex_, functionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVisibilityResultMode_offset_, (nint)(uint)mode, (nint)offset);
    }

    public void TextureBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.TextureBarrier);
    }

    public void UpdateFence(MTLFence fence, nuint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UpdateFence_stages_, fence.NativePtr, (nint)stages);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeap_, heap.NativePtr);
    }

    public void UseHeap(MTLHeap heap, nuint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeap_stages_, heap.NativePtr, (nint)stages);
    }

    public void UseResource(MTLResource resource, nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResource_usage_, resource.NativePtr, (nint)usage);
    }

    public void UseResource(MTLResource resource, nuint usage, nuint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResource_usage_stages_, resource.NativePtr, (nint)usage, (nint)stages);
    }

    public void WaitForFence(MTLFence fence, nuint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderCommandEncoderSelector.WaitForFence_stages_, fence.NativePtr, (nint)stages);
    }

}
