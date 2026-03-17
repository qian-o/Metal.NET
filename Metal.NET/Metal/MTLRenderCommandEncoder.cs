namespace Metal.NET;

public class MTLRenderCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLRenderCommandEncoder>
{
    #region INativeObject
    public static new MTLRenderCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint TileWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderBindings.TileWidth);
    }

    public nuint TileHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderBindings.TileHeight);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetVertexBytesLengthAtIndex(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytes, bytes, length, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint index)
    {
        SetVertexBytesLengthAtIndex(bytes, length, index);
    }

    public void SetVertexBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffer, buffer.NativePtr, offset, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        SetVertexBufferOffsetAtIndex(buffer, offset, index);
    }

    public void SetVertexBufferOffsetAtIndex(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffset, offset, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint index)
    {
        SetVertexBufferOffsetAtIndex(offset, index);
    }

    public void SetVertexBufferOffsetAttributeStrideAtIndex(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        SetVertexBufferOffsetAttributeStrideAtIndex(buffer, offset, stride, index);
    }

    public void SetVertexBufferOffsetAttributeStrideAtIndex(nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffsetAttributeStrideAtIndex, offset, stride, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint stride, nuint index)
    {
        SetVertexBufferOffsetAttributeStrideAtIndex(offset, stride, index);
    }

    public void SetVertexBytesLengthAttributeStrideAtIndex(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytesLengthAttributeStrideAtIndex, bytes, length, stride, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        SetVertexBytesLengthAttributeStrideAtIndex(bytes, length, stride, index);
    }

    public void SetVertexTextureAtIndex(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexTexture, texture.NativePtr, index);
    }

    public void SetVertexTexture(MTLTexture texture, nuint index)
    {
        SetVertexTextureAtIndex(texture, index);
    }

    public void SetVertexSamplerStateAtIndex(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerState, sampler.NativePtr, index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, nuint index)
    {
        SetVertexSamplerStateAtIndex(sampler, index);
    }

    public void SetVertexSamplerStateLodMinClampLodMaxClampAtIndex(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        SetVertexSamplerStateLodMinClampLodMaxClampAtIndex(sampler, lodMinClamp, lodMaxClamp, index);
    }

    public void SetVertexVisibleFunctionTableAtBufferIndex(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        SetVertexVisibleFunctionTableAtBufferIndex(functionTable, bufferIndex);
    }

    public void SetVertexIntersectionFunctionTableAtBufferIndex(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        SetVertexIntersectionFunctionTableAtBufferIndex(intersectionFunctionTable, bufferIndex);
    }

    public void SetVertexAccelerationStructureAtBufferIndex(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        SetVertexAccelerationStructureAtBufferIndex(accelerationStructure, bufferIndex);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewport, viewport);
    }

    public void SetViewportsCount(MTLViewport viewports, nuint count)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewports, viewports, count);
    }

    public void SetViewports(MTLViewport viewports, nuint count)
    {
        SetViewportsCount(viewports, count);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    public void SetVertexAmplificationCountViewMappings(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAmplificationCount, count, viewMappings);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        SetVertexAmplificationCountViewMappings(count, viewMappings);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetCullMode, (nuint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetDepthBiasSlopeScaleClamp(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        SetDepthBiasSlopeScaleClamp(depthBias, slopeScale, clamp);
    }

    public void SetDepthTestMinBoundMaxBound(float minBound, float maxBound)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthTestMinBound, minBound, maxBound);
    }

    public void SetDepthTestMinBound(float minBound, float maxBound)
    {
        SetDepthTestMinBoundMaxBound(minBound, maxBound);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRect, rect);
    }

    public void SetScissorRectsCount(MTLScissorRect scissorRects, nuint count)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRects, scissorRects, count);
    }

    public void SetScissorRects(MTLScissorRect scissorRects, nuint count)
    {
        SetScissorRectsCount(scissorRects, count);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTriangleFillMode, (nuint)fillMode);
    }

    public void SetFragmentBytesLengthAtIndex(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBytes, bytes, length, index);
    }

    public void SetFragmentBytes(nint bytes, nuint length, nuint index)
    {
        SetFragmentBytesLengthAtIndex(bytes, length, index);
    }

    public void SetFragmentBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        SetFragmentBufferOffsetAtIndex(buffer, offset, index);
    }

    public void SetFragmentBufferOffsetAtIndex(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBufferOffset, offset, index);
    }

    public void SetFragmentBufferOffset(nuint offset, nuint index)
    {
        SetFragmentBufferOffsetAtIndex(offset, index);
    }

    public void SetFragmentTextureAtIndex(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentTexture, texture.NativePtr, index);
    }

    public void SetFragmentTexture(MTLTexture texture, nuint index)
    {
        SetFragmentTextureAtIndex(texture, index);
    }

    public void SetFragmentSamplerStateAtIndex(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerState, sampler.NativePtr, index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, nuint index)
    {
        SetFragmentSamplerStateAtIndex(sampler, index);
    }

    public void SetFragmentSamplerStateLodMinClampLodMaxClampAtIndex(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        SetFragmentSamplerStateLodMinClampLodMaxClampAtIndex(sampler, lodMinClamp, lodMaxClamp, index);
    }

    public void SetFragmentVisibleFunctionTableAtBufferIndex(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        SetFragmentVisibleFunctionTableAtBufferIndex(functionTable, bufferIndex);
    }

    public void SetFragmentIntersectionFunctionTableAtBufferIndex(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        SetFragmentIntersectionFunctionTableAtBufferIndex(intersectionFunctionTable, bufferIndex);
    }

    public void SetFragmentAccelerationStructureAtBufferIndex(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        SetFragmentAccelerationStructureAtBufferIndex(accelerationStructure, bufferIndex);
    }

    public void SetBlendColorRedGreenBlueAlpha(float red, float green, float blue, float alpha)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetBlendColorRed, red, green, blue, alpha);
    }

    public void SetBlendColorRed(float red, float green, float blue, float alpha)
    {
        SetBlendColorRedGreenBlueAlpha(red, green, blue, alpha);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilFrontReferenceValueBackReferenceValue(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilFrontReferenceValue, frontReferenceValue, backReferenceValue);
    }

    public void SetStencilFrontReferenceValue(uint frontReferenceValue, uint backReferenceValue)
    {
        SetStencilFrontReferenceValueBackReferenceValue(frontReferenceValue, backReferenceValue);
    }

    public void SetVisibilityResultModeOffset(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVisibilityResultMode, (nuint)mode, offset);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        SetVisibilityResultModeOffset(mode, offset);
    }

    public void SetColorStoreActionAtIndex(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        SetColorStoreActionAtIndex(storeAction, colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    public void SetColorStoreActionOptionsAtIndex(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        SetColorStoreActionOptionsAtIndex(storeActionOptions, colorAttachmentIndex);
    }

    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetObjectBytesLengthAtIndex(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBytes, bytes, length, index);
    }

    public void SetObjectBytes(nint bytes, nuint length, nuint index)
    {
        SetObjectBytesLengthAtIndex(bytes, length, index);
    }

    public void SetObjectBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        SetObjectBufferOffsetAtIndex(buffer, offset, index);
    }

    public void SetObjectBufferOffsetAtIndex(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBufferOffset, offset, index);
    }

    public void SetObjectBufferOffset(nuint offset, nuint index)
    {
        SetObjectBufferOffsetAtIndex(offset, index);
    }

    public void SetObjectTextureAtIndex(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectTexture, texture.NativePtr, index);
    }

    public void SetObjectTexture(MTLTexture texture, nuint index)
    {
        SetObjectTextureAtIndex(texture, index);
    }

    public void SetObjectSamplerStateAtIndex(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerState, sampler.NativePtr, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, nuint index)
    {
        SetObjectSamplerStateAtIndex(sampler, index);
    }

    public void SetObjectSamplerStateLodMinClampLodMaxClampAtIndex(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        SetObjectSamplerStateLodMinClampLodMaxClampAtIndex(sampler, lodMinClamp, lodMaxClamp, index);
    }

    public void SetObjectThreadgroupMemoryLengthAtIndex(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        SetObjectThreadgroupMemoryLengthAtIndex(length, index);
    }

    public void SetMeshBytesLengthAtIndex(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBytes, bytes, length, index);
    }

    public void SetMeshBytes(nint bytes, nuint length, nuint index)
    {
        SetMeshBytesLengthAtIndex(bytes, length, index);
    }

    public void SetMeshBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        SetMeshBufferOffsetAtIndex(buffer, offset, index);
    }

    public void SetMeshBufferOffsetAtIndex(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBufferOffset, offset, index);
    }

    public void SetMeshBufferOffset(nuint offset, nuint index)
    {
        SetMeshBufferOffsetAtIndex(offset, index);
    }

    public void SetMeshTextureAtIndex(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshTexture, texture.NativePtr, index);
    }

    public void SetMeshTexture(MTLTexture texture, nuint index)
    {
        SetMeshTextureAtIndex(texture, index);
    }

    public void SetMeshSamplerStateAtIndex(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerState, sampler.NativePtr, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, nuint index)
    {
        SetMeshSamplerStateAtIndex(sampler, index);
    }

    public void SetMeshSamplerStateLodMinClampLodMaxClampAtIndex(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        SetMeshSamplerStateLodMinClampLodMaxClampAtIndex(sampler, lodMinClamp, lodMaxClamp, index);
    }

    public void DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup(threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup(threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroupsWithIndirectBuffer, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        DrawMeshThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup(indirectBuffer, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPrimitivesVertexStartVertexCountInstanceCount(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        DrawPrimitivesVertexStartVertexCountInstanceCount(primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitivesVertexStartVertexCount(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesVertexStartVertexCount, (nuint)primitiveType, vertexStart, vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        DrawPrimitivesVertexStartVertexCount(primitiveType, vertexStart, vertexCount);
    }

    public void DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCount(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCount(primitiveType, indexCount, indexType, indexBuffer, indexBufferOffset, instanceCount);
    }

    public void DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset(primitiveType, indexCount, indexType, indexBuffer, indexBufferOffset);
    }

    public void DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance(primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance(primitiveType, indexCount, indexType, indexBuffer, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawPrimitivesIndirectBufferIndirectBufferOffset(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesIndirectBufferIndirectBufferOffset, (nuint)primitiveType, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        DrawPrimitivesIndirectBufferIndirectBufferOffset(primitiveType, indirectBuffer, indirectBufferOffset);
    }

    public void DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset, (nuint)primitiveType, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset(primitiveType, indexType, indexBuffer, indexBufferOffset, indirectBuffer, indirectBufferOffset);
    }

    /// <summary>
    /// Deprecated: Use memoryBarrierWithScope:MTLBarrierScopeRenderTargets instead
    /// </summary>
    [Obsolete("Use memoryBarrierWithScope:MTLBarrierScopeRenderTargets instead")]
    public void TextureBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.TextureBarrier);
    }

    public void UpdateFenceAfterStages(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UpdateFence, fence.NativePtr, (nuint)stages);
    }

    public void UpdateFence(MTLFence fence, MTLRenderStages stages)
    {
        UpdateFenceAfterStages(fence, stages);
    }

    public void WaitForFenceBeforeStages(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.WaitForFence, fence.NativePtr, (nuint)stages);
    }

    public void WaitForFence(MTLFence fence, MTLRenderStages stages)
    {
        WaitForFenceBeforeStages(fence, stages);
    }

    public void SetTessellationFactorBufferOffsetInstanceStride(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorBuffer, buffer.NativePtr, offset, instanceStride);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        SetTessellationFactorBufferOffsetInstanceStride(buffer, offset, instanceStride);
    }

    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorScale, scale);
    }

    public void DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstance(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstance(numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer, patchIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset(numberOfPatchControlPoints, patchIndexBuffer, patchIndexBufferOffset, indirectBuffer, indirectBufferOffset);
    }

    public void DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstance(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstance(numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer, patchIndexBufferOffset, controlPointIndexBuffer, controlPointIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset(numberOfPatchControlPoints, patchIndexBuffer, patchIndexBufferOffset, controlPointIndexBuffer, controlPointIndexBufferOffset, indirectBuffer, indirectBufferOffset);
    }

    public void SetTileBytesLengthAtIndex(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBytes, bytes, length, index);
    }

    public void SetTileBytes(nint bytes, nuint length, nuint index)
    {
        SetTileBytesLengthAtIndex(bytes, length, index);
    }

    public void SetTileBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBuffer, buffer.NativePtr, offset, index);
    }

    public void SetTileBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        SetTileBufferOffsetAtIndex(buffer, offset, index);
    }

    public void SetTileBufferOffsetAtIndex(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBufferOffset, offset, index);
    }

    public void SetTileBufferOffset(nuint offset, nuint index)
    {
        SetTileBufferOffsetAtIndex(offset, index);
    }

    public void SetTileTextureAtIndex(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileTexture, texture.NativePtr, index);
    }

    public void SetTileTexture(MTLTexture texture, nuint index)
    {
        SetTileTextureAtIndex(texture, index);
    }

    public void SetTileSamplerStateAtIndex(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerState, sampler.NativePtr, index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, nuint index)
    {
        SetTileSamplerStateAtIndex(sampler, index);
    }

    public void SetTileSamplerStateLodMinClampLodMaxClampAtIndex(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        SetTileSamplerStateLodMinClampLodMaxClampAtIndex(sampler, lodMinClamp, lodMaxClamp, index);
    }

    public void SetTileVisibleFunctionTableAtBufferIndex(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        SetTileVisibleFunctionTableAtBufferIndex(functionTable, bufferIndex);
    }

    public void SetTileIntersectionFunctionTableAtBufferIndex(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        SetTileIntersectionFunctionTableAtBufferIndex(intersectionFunctionTable, bufferIndex);
    }

    public void SetTileAccelerationStructureAtBufferIndex(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        SetTileAccelerationStructureAtBufferIndex(accelerationStructure, bufferIndex);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DispatchThreadsPerTile, threadsPerTile);
    }

    public void SetThreadgroupMemoryLengthOffsetAtIndex(nuint length, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetThreadgroupMemoryLength, length, offset, index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        SetThreadgroupMemoryLengthOffsetAtIndex(length, offset, index);
    }

    /// <summary>
    /// Deprecated: Use useResource:usage:stages: instead
    /// </summary>
    [Obsolete("Use useResource:usage:stages: instead")]
    public void UseResourceUsage(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        UseResourceUsage(resource, usage);
    }

    /// <summary>
    /// Deprecated: Use useResources:count:usage:stages: instead
    /// </summary>
    [Obsolete("Use useResources:count:usage:stages: instead")]
    public unsafe void UseResourcesCountUsage(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResources, (nint)pResources, (nuint)resources.Length, (nuint)usage);
    }

    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        UseResourcesCountUsage(resources, usage);
    }

    public void UseResourceUsageStages(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResourceUsageStages, resource.NativePtr, (nuint)usage, (nuint)stages);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
    {
        UseResourceUsageStages(resource, usage, stages);
    }

    public unsafe void UseResourcesCountUsageStages(MTLResource[] resources, MTLResourceUsage usage, MTLRenderStages stages)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResourcesCountUsageStages, (nint)pResources, (nuint)resources.Length, (nuint)usage, (nuint)stages);
    }

    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage, MTLRenderStages stages)
    {
        UseResourcesCountUsageStages(resources, usage, stages);
    }

    /// <summary>
    /// Deprecated: Use useHeap:stages: instead
    /// </summary>
    [Obsolete("Use useHeap:stages: instead")]
    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    /// <summary>
    /// Deprecated: Use useHeaps:count:stages: instead
    /// </summary>
    [Obsolete("Use useHeaps:count:stages: instead")]
    public unsafe void UseHeapsCount(MTLHeap[] heaps)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeaps, (nint)pHeaps, (nuint)heaps.Length);
    }

    public unsafe void UseHeaps(MTLHeap[] heaps)
    {
        UseHeapsCount(heaps);
    }

    public void UseHeapStages(MTLHeap heap, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeapStages, heap.NativePtr, (nuint)stages);
    }

    public void UseHeap(MTLHeap heap, MTLRenderStages stages)
    {
        UseHeapStages(heap, stages);
    }

    public unsafe void UseHeapsCountStages(MTLHeap[] heaps, MTLRenderStages stages)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeapsCountStages, (nint)pHeaps, (nuint)heaps.Length, (nuint)stages);
    }

    public unsafe void UseHeaps(MTLHeap[] heaps, MTLRenderStages stages)
    {
        UseHeapsCountStages(heaps, stages);
    }

    public void ExecuteCommandsInBufferWithRange(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ExecuteCommandsInBufferWithRange(indirectCommandBuffer, executionRange);
    }

    public void ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset(indirectCommandbuffer, indirectRangeBuffer, indirectBufferOffset);
    }

    public void MemoryBarrierWithScopeAfterStagesBeforeStages(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrierWithScope, (nuint)scope, (nuint)after, (nuint)before);
    }

    public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
    {
        MemoryBarrierWithScopeAfterStagesBeforeStages(scope, after, before);
    }

    public unsafe void MemoryBarrierWithResourcesCountAfterStagesBeforeStages(MTLResource[] resources, MTLRenderStages after, MTLRenderStages before)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrierWithResources, (nint)pResources, (nuint)resources.Length, (nuint)after, (nuint)before);
    }

    public unsafe void MemoryBarrier(MTLResource[] resources, MTLRenderStages after, MTLRenderStages before)
    {
        MemoryBarrierWithResourcesCountAfterStagesBeforeStages(resources, after, before);
    }

    public void SampleCountersInBufferAtSampleIndexWithBarrier(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        SampleCountersInBufferAtSampleIndexWithBarrier(sampleBuffer, sampleIndex, barrier);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorAttachmentMap, mapping.NativePtr);
    }
}

file static class MTLRenderCommandEncoderBindings
{
    public static readonly Selector DispatchThreadsPerTile = "dispatchThreadsPerTile:";

    public static readonly Selector DrawIndexedPatches = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset = "drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawIndexedPrimitives = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:";

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:";

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";

    public static readonly Selector DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawMeshThreadgroups = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreadgroupsWithIndirectBuffer = "drawMeshThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPatches = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset = "drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawPrimitives = "drawPrimitives:vertexStart:vertexCount:instanceCount:";

    public static readonly Selector DrawPrimitivesIndirectBufferIndirectBufferOffset = "drawPrimitives:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawPrimitivesVertexStartVertexCount = "drawPrimitives:vertexStart:vertexCount:";

    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:withRange:";

    public static readonly Selector ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector MemoryBarrierWithResources = "memoryBarrierWithResources:count:afterStages:beforeStages:";

    public static readonly Selector MemoryBarrierWithScope = "memoryBarrierWithScope:afterStages:beforeStages:";

    public static readonly Selector SampleCountersInBuffer = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetBlendColorRed = "setBlendColorRed:green:blue:alpha:";

    public static readonly Selector SetColorAttachmentMap = "setColorAttachmentMap:";

    public static readonly Selector SetColorStoreAction = "setColorStoreAction:atIndex:";

    public static readonly Selector SetColorStoreActionOptions = "setColorStoreActionOptions:atIndex:";

    public static readonly Selector SetCullMode = "setCullMode:";

    public static readonly Selector SetDepthBias = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthClipMode = "setDepthClipMode:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:";

    public static readonly Selector SetDepthStoreAction = "setDepthStoreAction:";

    public static readonly Selector SetDepthStoreActionOptions = "setDepthStoreActionOptions:";

    public static readonly Selector SetDepthTestMinBound = "setDepthTestMinBound:maxBound:";

    public static readonly Selector SetFragmentAccelerationStructure = "setFragmentAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetFragmentBuffer = "setFragmentBuffer:offset:atIndex:";

    public static readonly Selector SetFragmentBufferOffset = "setFragmentBufferOffset:atIndex:";

    public static readonly Selector SetFragmentBytes = "setFragmentBytes:length:atIndex:";

    public static readonly Selector SetFragmentIntersectionFunctionTable = "setFragmentIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetFragmentSamplerState = "setFragmentSamplerState:atIndex:";

    public static readonly Selector SetFragmentSamplerStateLodMinClampLodMaxClampAtIndex = "setFragmentSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetFragmentTexture = "setFragmentTexture:atIndex:";

    public static readonly Selector SetFragmentVisibleFunctionTable = "setFragmentVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetFrontFacingWinding = "setFrontFacingWinding:";

    public static readonly Selector SetMeshBuffer = "setMeshBuffer:offset:atIndex:";

    public static readonly Selector SetMeshBufferOffset = "setMeshBufferOffset:atIndex:";

    public static readonly Selector SetMeshBytes = "setMeshBytes:length:atIndex:";

    public static readonly Selector SetMeshSamplerState = "setMeshSamplerState:atIndex:";

    public static readonly Selector SetMeshSamplerStateLodMinClampLodMaxClampAtIndex = "setMeshSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetMeshTexture = "setMeshTexture:atIndex:";

    public static readonly Selector SetObjectBuffer = "setObjectBuffer:offset:atIndex:";

    public static readonly Selector SetObjectBufferOffset = "setObjectBufferOffset:atIndex:";

    public static readonly Selector SetObjectBytes = "setObjectBytes:length:atIndex:";

    public static readonly Selector SetObjectSamplerState = "setObjectSamplerState:atIndex:";

    public static readonly Selector SetObjectSamplerStateLodMinClampLodMaxClampAtIndex = "setObjectSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetObjectTexture = "setObjectTexture:atIndex:";

    public static readonly Selector SetObjectThreadgroupMemoryLength = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:";

    public static readonly Selector SetScissorRect = "setScissorRect:";

    public static readonly Selector SetScissorRects = "setScissorRects:count:";

    public static readonly Selector SetStencilFrontReferenceValue = "setStencilFrontReferenceValue:backReferenceValue:";

    public static readonly Selector SetStencilReferenceValue = "setStencilReferenceValue:";

    public static readonly Selector SetStencilStoreAction = "setStencilStoreAction:";

    public static readonly Selector SetStencilStoreActionOptions = "setStencilStoreActionOptions:";

    public static readonly Selector SetTessellationFactorBuffer = "setTessellationFactorBuffer:offset:instanceStride:";

    public static readonly Selector SetTessellationFactorScale = "setTessellationFactorScale:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:offset:atIndex:";

    public static readonly Selector SetTileAccelerationStructure = "setTileAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetTileBuffer = "setTileBuffer:offset:atIndex:";

    public static readonly Selector SetTileBufferOffset = "setTileBufferOffset:atIndex:";

    public static readonly Selector SetTileBytes = "setTileBytes:length:atIndex:";

    public static readonly Selector SetTileIntersectionFunctionTable = "setTileIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetTileSamplerState = "setTileSamplerState:atIndex:";

    public static readonly Selector SetTileSamplerStateLodMinClampLodMaxClampAtIndex = "setTileSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetTileTexture = "setTileTexture:atIndex:";

    public static readonly Selector SetTileVisibleFunctionTable = "setTileVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetTriangleFillMode = "setTriangleFillMode:";

    public static readonly Selector SetVertexAccelerationStructure = "setVertexAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetVertexAmplificationCount = "setVertexAmplificationCount:viewMappings:";

    public static readonly Selector SetVertexBuffer = "setVertexBuffer:offset:atIndex:";

    public static readonly Selector SetVertexBufferOffset = "setVertexBufferOffset:atIndex:";

    public static readonly Selector SetVertexBufferOffsetAttributeStrideAtIndex = "setVertexBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetVertexBytes = "setVertexBytes:length:atIndex:";

    public static readonly Selector SetVertexBytesLengthAttributeStrideAtIndex = "setVertexBytes:length:attributeStride:atIndex:";

    public static readonly Selector SetVertexIntersectionFunctionTable = "setVertexIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetVertexSamplerState = "setVertexSamplerState:atIndex:";

    public static readonly Selector SetVertexSamplerStateLodMinClampLodMaxClampAtIndex = "setVertexSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetVertexTexture = "setVertexTexture:atIndex:";

    public static readonly Selector SetVertexVisibleFunctionTable = "setVertexVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetViewport = "setViewport:";

    public static readonly Selector SetViewports = "setViewports:count:";

    public static readonly Selector SetVisibilityResultMode = "setVisibilityResultMode:offset:";

    public static readonly Selector TextureBarrier = "textureBarrier";

    public static readonly Selector TileHeight = "tileHeight";

    public static readonly Selector TileWidth = "tileWidth";

    public static readonly Selector UpdateFence = "updateFence:afterStages:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeaps = "useHeaps:count:";

    public static readonly Selector UseHeapsCountStages = "useHeaps:count:stages:";

    public static readonly Selector UseHeapStages = "useHeap:stages:";

    public static readonly Selector UseResource = "useResource:usage:";

    public static readonly Selector UseResources = "useResources:count:usage:";

    public static readonly Selector UseResourcesCountUsageStages = "useResources:count:usage:stages:";

    public static readonly Selector UseResourceUsageStages = "useResource:usage:stages:";

    public static readonly Selector WaitForFence = "waitForFence:beforeStages:";
}
