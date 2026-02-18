namespace Metal.NET;

public partial class MTLRenderCommandEncoder : NativeObject
{
    public MTLRenderCommandEncoder(nint nativePtr) : base(nativePtr)
    {
    }

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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPatches, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreadgroups, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPatches, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.ExecuteCommandsInBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.MemoryBarrier, (nuint)scope, (nuint)after, (nuint)before);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, (Bool8)barrier);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetBlendColor, red, green, blue, alpha);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetCullMode, (nuint)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetDepthTestBounds, minBound, maxBound);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }

    public void SetFragmentBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBufferOffset, offset, index);
    }

    public void SetFragmentBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentBytes, bytes, length, index);
    }

    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentSamplerState, sampler.NativePtr, index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetFragmentTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentTexture, texture.NativePtr, index);
    }

    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFragmentVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    public void SetMeshBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBufferOffset, offset, index);
    }

    public void SetMeshBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshBytes, bytes, length, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshSamplerState, sampler.NativePtr, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetMeshTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetMeshTexture, texture.NativePtr, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBufferOffset, offset, index);
    }

    public void SetObjectBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectBytes, bytes, length, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectSamplerState, sampler.NativePtr, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetObjectTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectTexture, texture.NativePtr, index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetObjectThreadgroupMemoryLength, length, index);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetScissorRects, scissorRects, count);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilReferenceValues, frontReferenceValue, backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreAction, (nuint)storeAction);
    }

    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorBuffer, buffer.NativePtr, offset, instanceStride);
    }

    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTessellationFactorScale, scale);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetThreadgroupMemoryLength, length, offset, index);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetTileBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBuffer, buffer.NativePtr, offset, index);
    }

    public void SetTileBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBufferOffset, offset, index);
    }

    public void SetTileBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileBytes, bytes, length, index);
    }

    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileSamplerState, sampler.NativePtr, index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetTileTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileTexture, texture.NativePtr, index);
    }

    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTileVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetTriangleFillMode, (nuint)fillMode);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexAmplificationCount, count, viewMappings);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBuffer, buffer.NativePtr, offset, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBuffer, buffer.NativePtr, offset, stride, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffset, offset, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBufferOffset, offset, stride, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytes, bytes, length, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexBytes, bytes, length, stride, index);
    }

    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexSamplerState, sampler.NativePtr, index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetVertexTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexTexture, texture.NativePtr, index);
    }

    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVertexVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetViewport, viewport);
    }

    public void SetViewports(MTLViewport viewports, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetViewports, viewports, count);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.SetVisibilityResultMode, (nuint)mode, offset);
    }

    public void TextureBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.TextureBarrier);
    }

    public void UpdateFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UpdateFence, fence.NativePtr, (nuint)stages);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeap, heap.NativePtr);
    }

    public void UseHeap(MTLHeap heap, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseHeap, heap.NativePtr, (nuint)stages);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResource, resource.NativePtr, (nuint)usage);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.UseResource, resource.NativePtr, (nuint)usage, (nuint)stages);
    }

    public void WaitForFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderSelector.WaitForFence, fence.NativePtr, (nuint)stages);
    }
}

file static class MTLRenderCommandEncoderSelector
{
    public static readonly Selector DispatchThreadsPerTile = Selector.Register("dispatchThreadsPerTile:");

    public static readonly Selector DrawIndexedPatches = Selector.Register("drawIndexedPatches:::::::::");

    public static readonly Selector DrawIndexedPrimitives = Selector.Register("drawIndexedPrimitives::::::");

    public static readonly Selector DrawMeshThreadgroups = Selector.Register("drawMeshThreadgroups:::");

    public static readonly Selector DrawMeshThreads = Selector.Register("drawMeshThreads:::");

    public static readonly Selector DrawPatches = Selector.Register("drawPatches:::::::");

    public static readonly Selector DrawPrimitives = Selector.Register("drawPrimitives::::");

    public static readonly Selector ExecuteCommandsInBuffer = Selector.Register("executeCommandsInBuffer::");

    public static readonly Selector MemoryBarrier = Selector.Register("memoryBarrier:::");

    public static readonly Selector SampleCountersInBuffer = Selector.Register("sampleCountersInBuffer:::");

    public static readonly Selector SetBlendColor = Selector.Register("setBlendColor::::");

    public static readonly Selector SetColorAttachmentMap = Selector.Register("setColorAttachmentMap:");

    public static readonly Selector SetColorStoreAction = Selector.Register("setColorStoreAction::");

    public static readonly Selector SetColorStoreActionOptions = Selector.Register("setColorStoreActionOptions::");

    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");

    public static readonly Selector SetDepthBias = Selector.Register("setDepthBias:::");

    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");

    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthStoreActionOptions = Selector.Register("setDepthStoreActionOptions:");

    public static readonly Selector SetDepthTestBounds = Selector.Register("setDepthTestBounds::");

    public static readonly Selector SetFragmentAccelerationStructure = Selector.Register("setFragmentAccelerationStructure::");

    public static readonly Selector SetFragmentBuffer = Selector.Register("setFragmentBuffer:::");

    public static readonly Selector SetFragmentBufferOffset = Selector.Register("setFragmentBufferOffset::");

    public static readonly Selector SetFragmentBytes = Selector.Register("setFragmentBytes:::");

    public static readonly Selector SetFragmentIntersectionFunctionTable = Selector.Register("setFragmentIntersectionFunctionTable::");

    public static readonly Selector SetFragmentSamplerState = Selector.Register("setFragmentSamplerState::");

    public static readonly Selector SetFragmentTexture = Selector.Register("setFragmentTexture::");

    public static readonly Selector SetFragmentVisibleFunctionTable = Selector.Register("setFragmentVisibleFunctionTable::");

    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");

    public static readonly Selector SetMeshBuffer = Selector.Register("setMeshBuffer:::");

    public static readonly Selector SetMeshBufferOffset = Selector.Register("setMeshBufferOffset::");

    public static readonly Selector SetMeshBytes = Selector.Register("setMeshBytes:::");

    public static readonly Selector SetMeshSamplerState = Selector.Register("setMeshSamplerState::");

    public static readonly Selector SetMeshTexture = Selector.Register("setMeshTexture::");

    public static readonly Selector SetObjectBuffer = Selector.Register("setObjectBuffer:::");

    public static readonly Selector SetObjectBufferOffset = Selector.Register("setObjectBufferOffset::");

    public static readonly Selector SetObjectBytes = Selector.Register("setObjectBytes:::");

    public static readonly Selector SetObjectSamplerState = Selector.Register("setObjectSamplerState::");

    public static readonly Selector SetObjectTexture = Selector.Register("setObjectTexture::");

    public static readonly Selector SetObjectThreadgroupMemoryLength = Selector.Register("setObjectThreadgroupMemoryLength::");

    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");

    public static readonly Selector SetScissorRect = Selector.Register("setScissorRect:");

    public static readonly Selector SetScissorRects = Selector.Register("setScissorRects::");

    public static readonly Selector SetStencilReferenceValue = Selector.Register("setStencilReferenceValue:");

    public static readonly Selector SetStencilReferenceValues = Selector.Register("setStencilReferenceValues::");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetStencilStoreActionOptions = Selector.Register("setStencilStoreActionOptions:");

    public static readonly Selector SetTessellationFactorBuffer = Selector.Register("setTessellationFactorBuffer:::");

    public static readonly Selector SetTessellationFactorScale = Selector.Register("setTessellationFactorScale:");

    public static readonly Selector SetThreadgroupMemoryLength = Selector.Register("setThreadgroupMemoryLength:::");

    public static readonly Selector SetTileAccelerationStructure = Selector.Register("setTileAccelerationStructure::");

    public static readonly Selector SetTileBuffer = Selector.Register("setTileBuffer:::");

    public static readonly Selector SetTileBufferOffset = Selector.Register("setTileBufferOffset::");

    public static readonly Selector SetTileBytes = Selector.Register("setTileBytes:::");

    public static readonly Selector SetTileIntersectionFunctionTable = Selector.Register("setTileIntersectionFunctionTable::");

    public static readonly Selector SetTileSamplerState = Selector.Register("setTileSamplerState::");

    public static readonly Selector SetTileTexture = Selector.Register("setTileTexture::");

    public static readonly Selector SetTileVisibleFunctionTable = Selector.Register("setTileVisibleFunctionTable::");

    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");

    public static readonly Selector SetVertexAccelerationStructure = Selector.Register("setVertexAccelerationStructure::");

    public static readonly Selector SetVertexAmplificationCount = Selector.Register("setVertexAmplificationCount::");

    public static readonly Selector SetVertexBuffer = Selector.Register("setVertexBuffer:::");

    public static readonly Selector SetVertexBufferOffset = Selector.Register("setVertexBufferOffset::");

    public static readonly Selector SetVertexBytes = Selector.Register("setVertexBytes:::");

    public static readonly Selector SetVertexIntersectionFunctionTable = Selector.Register("setVertexIntersectionFunctionTable::");

    public static readonly Selector SetVertexSamplerState = Selector.Register("setVertexSamplerState::");

    public static readonly Selector SetVertexTexture = Selector.Register("setVertexTexture::");

    public static readonly Selector SetVertexVisibleFunctionTable = Selector.Register("setVertexVisibleFunctionTable::");

    public static readonly Selector SetViewport = Selector.Register("setViewport:");

    public static readonly Selector SetViewports = Selector.Register("setViewports::");

    public static readonly Selector SetVisibilityResultMode = Selector.Register("setVisibilityResultMode::");

    public static readonly Selector TextureBarrier = Selector.Register("textureBarrier");

    public static readonly Selector TileHeight = Selector.Register("tileHeight");

    public static readonly Selector TileWidth = Selector.Register("tileWidth");

    public static readonly Selector UpdateFence = Selector.Register("updateFence::");

    public static readonly Selector UseHeap = Selector.Register("useHeap:");

    public static readonly Selector UseResource = Selector.Register("useResource::");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence::");
}
