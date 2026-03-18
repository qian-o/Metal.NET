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

    public void SetVertexBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytes, bytes, length, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffer, buffer.NativePtr, offset, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffset, offset, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffsetAttributeStrideAtIndex, offset, stride, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytesLengthAttributeStrideAtIndex, bytes, length, stride, index);
    }

    public void SetVertexTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexTexture, texture.NativePtr, index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerState, sampler.NativePtr, index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewport, viewport);
    }

    public unsafe void SetViewports(MTLViewport[] viewports)
    {
        fixed (MTLViewport* pViewports = viewports)
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewports, (nint)pViewports, (nuint)viewports.Length);
        }
    }

    public void SetFrontFacing(MTLWinding frontFacingWinding)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFrontFacing, (nuint)frontFacingWinding);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAmplificationCount, count, viewMappings);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetCullMode, (nuint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthTestMinBound(float minBound, float maxBound)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthTestMinBound, minBound, maxBound);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRect, rect);
    }

    public unsafe void SetScissorRects(MTLScissorRect[] scissorRects)
    {
        fixed (MTLScissorRect* pScissorRects = scissorRects)
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRects, (nint)pScissorRects, (nuint)scissorRects.Length);
        }
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTriangleFillMode, (nuint)fillMode);
    }

    public void SetFragmentBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBytes, bytes, length, index);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }

    public void SetFragmentBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBufferOffset, offset, index);
    }

    public void SetFragmentTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentTexture, texture.NativePtr, index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerState, sampler.NativePtr, index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetBlendColor, red, green, blue, alpha);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilReferenceValues, frontReferenceValue, backReferenceValue);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVisibilityResultMode, (nuint)mode, offset);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetObjectBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBytes, bytes, length, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBufferOffset, offset, index);
    }

    public void SetObjectTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectTexture, texture.NativePtr, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerState, sampler.NativePtr, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetMeshBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBytes, bytes, length, index);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    public void SetMeshBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBufferOffset, offset, index);
    }

    public void SetMeshTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshTexture, texture.NativePtr, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerState, sampler.NativePtr, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesVertexStartVertexCount, (nuint)primitiveType, vertexStart, vertexCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffset, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesIndirectBufferIndirectBufferOffset, (nuint)primitiveType, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferOffsetIndirectBufferIndirectBufferOffset, (nuint)primitiveType, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    /// <summary>
    /// Deprecated: Use memoryBarrierWithScope:MTLBarrierScopeRenderTargets instead
    /// </summary>
    [Obsolete("Use memoryBarrierWithScope:MTLBarrierScopeRenderTargets instead")]
    public void TextureBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.TextureBarrier);
    }

    public void UpdateFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UpdateFence, fence.NativePtr, (nuint)stages);
    }

    public void WaitForFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.WaitForFence, fence.NativePtr, (nuint)stages);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorBuffer, buffer.NativePtr, offset, instanceStride);
    }

    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorScale, scale);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatchesPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetIndirectBufferIndirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void SetTileBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBytes, bytes, length, index);
    }

    public void SetTileBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBuffer, buffer.NativePtr, offset, index);
    }

    public void SetTileBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBufferOffset, offset, index);
    }

    public void SetTileTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileTexture, texture.NativePtr, index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerState, sampler.NativePtr, index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DispatchThreadsPerTile, threadsPerTile);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetThreadgroupMemoryLength, length, offset, index);
    }

    /// <summary>
    /// Deprecated: Use useResource:usage:stages: instead
    /// </summary>
    [Obsolete("Use useResource:usage:stages: instead")]
    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    /// <summary>
    /// Deprecated: Use useResources:count:usage:stages: instead
    /// </summary>
    [Obsolete("Use useResources:count:usage:stages: instead")]
    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResources, (nint)pResources, (nuint)resources.Length, (nuint)usage);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResourceUsageStages, resource.NativePtr, (nuint)usage, (nuint)stages);
    }

    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage, MTLRenderStages stages)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResourcesCountUsageStages, (nint)pResources, (nuint)resources.Length, (nuint)usage, (nuint)stages);
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
    public unsafe void UseHeaps(MTLHeap[] heaps)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeaps, (nint)pHeaps, (nuint)heaps.Length);
    }

    public void UseHeap(MTLHeap heap, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeapStages, heap.NativePtr, (nuint)stages);
    }

    public unsafe void UseHeaps(MTLHeap[] heaps, MTLRenderStages stages)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeapsCountStages, (nint)pHeaps, (nuint)heaps.Length, (nuint)stages);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrier, (nuint)scope, (nuint)after, (nuint)before);
    }

    public unsafe void MemoryBarrierWithResources(MTLResource[] resources, MTLRenderStages after, MTLRenderStages before)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrierWithResources, (nint)pResources, (nuint)resources.Length, (nuint)after, (nuint)before);
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SampleCounters, sampleBuffer.NativePtr, sampleIndex, barrier);
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

    public static readonly Selector DrawMeshThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = "drawMeshThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPatches = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawPatchesPatchIndexBufferPatchIndexBufferOffsetIndirectBufferIndirectBufferOffset = "drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawPrimitives = "drawPrimitives:vertexStart:vertexCount:instanceCount:";

    public static readonly Selector DrawPrimitivesIndirectBufferIndirectBufferOffset = "drawPrimitives:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawPrimitivesVertexStartVertexCount = "drawPrimitives:vertexStart:vertexCount:";

    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:withRange:";

    public static readonly Selector ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector MemoryBarrier = "memoryBarrierWithScope:afterStages:beforeStages:";

    public static readonly Selector MemoryBarrierWithResources = "memoryBarrierWithResources:count:afterStages:beforeStages:";

    public static readonly Selector SampleCounters = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetBlendColor = "setBlendColorRed:green:blue:alpha:";

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

    public static readonly Selector SetFrontFacing = "setFrontFacingWinding:";

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

    public static readonly Selector SetStencilReferenceValue = "setStencilReferenceValue:";

    public static readonly Selector SetStencilReferenceValues = "setStencilFrontReferenceValue:backReferenceValue:";

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
