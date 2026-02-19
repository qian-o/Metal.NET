namespace Metal.NET;

public class MTLRenderCommandEncoder(nint nativePtr) : MTLCommandEncoder(nativePtr)
{
    public nuint TileHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderBindings.TileHeight);
    }

    public nuint TileWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderBindings.TileWidth);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DispatchThreadsPerTile, threadsPerTile);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatches, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroups, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatches, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrier, (nuint)scope, (nuint)after, (nuint)before);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, (Bool8)barrier);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetBlendColor, red, green, blue, alpha);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthTestBounds, minBound, maxBound);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }

    public void SetFragmentBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBufferOffset, offset, index);
    }

    public void SetFragmentBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBytes, bytes, length, index);
    }

    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerState, sampler.NativePtr, index);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetFragmentTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentTexture, texture.NativePtr, index);
    }

    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    public void SetMeshBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBufferOffset, offset, index);
    }

    public void SetMeshBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBytes, bytes, length, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerState, sampler.NativePtr, index);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetMeshTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshTexture, texture.NativePtr, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBufferOffset, offset, index);
    }

    public void SetObjectBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBytes, bytes, length, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerState, sampler.NativePtr, index);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetObjectTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectTexture, texture.NativePtr, index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetScissorRects(MTLScissorRect scissorRects, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRects, scissorRects, count);
    }

    public void SetStencilReferenceValues(nuint frontReferenceValue, nuint backReferenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilReferenceValues, frontReferenceValue, backReferenceValue);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorBuffer, buffer.NativePtr, offset, instanceStride);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetThreadgroupMemoryLength, length, offset, index);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetTileBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBuffer, buffer.NativePtr, offset, index);
    }

    public void SetTileBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBufferOffset, offset, index);
    }

    public void SetTileBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBytes, bytes, length, index);
    }

    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerState, sampler.NativePtr, index);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetTileTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileTexture, texture.NativePtr, index);
    }

    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAmplificationCount, count, viewMappings);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffer, buffer.NativePtr, offset, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffer, buffer.NativePtr, offset, stride, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffset, offset, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffset, offset, stride, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytes, bytes, length, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytes, bytes, length, stride, index);
    }

    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerState, sampler.NativePtr, index);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetVertexTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexTexture, texture.NativePtr, index);
    }

    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    public void SetViewports(MTLViewport viewports, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewports, viewports, count);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVisibilityResultMode, (nuint)mode, offset);
    }

    public void TextureBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.TextureBarrier);
    }

    public void UpdateFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UpdateFence, fence.NativePtr, (nuint)stages);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    public void UseHeap(MTLHeap heap, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeap, heap.NativePtr, (nuint)stages);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage, (nuint)stages);
    }

    public void WaitForFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.WaitForFence, fence.NativePtr, (nuint)stages);
    }
}

file static class MTLRenderCommandEncoderBindings
{
    public static readonly Selector DispatchThreadsPerTile = "dispatchThreadsPerTile:";

    public static readonly Selector DrawIndexedPatches = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawIndexedPrimitives = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:";

    public static readonly Selector DrawMeshThreadgroups = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPatches = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawPrimitives = "drawPrimitives:vertexStart:vertexCount:instanceCount:";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:withRange:";

    public static readonly Selector MemoryBarrier = "memoryBarrierWithScope:afterStages:beforeStages:";

    public static readonly Selector SampleCountersInBuffer = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetBlendColor = "setBlendColorRed:green:blue:alpha:";

    public static readonly Selector SetColorStoreAction = "setColorStoreAction:atIndex:";

    public static readonly Selector SetColorStoreActionOptions = "setColorStoreActionOptions:atIndex:";

    public static readonly Selector SetDepthBias = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthTestBounds = "setDepthTestMinBound:maxBound:";

    public static readonly Selector SetFragmentAccelerationStructure = "setFragmentAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetFragmentBuffer = "setFragmentBuffer:offset:atIndex:";

    public static readonly Selector SetFragmentBufferOffset = "setFragmentBufferOffset:atIndex:";

    public static readonly Selector SetFragmentBytes = "setFragmentBytes:length:atIndex:";

    public static readonly Selector SetFragmentIntersectionFunctionTable = "setFragmentIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetFragmentSamplerState = "setFragmentSamplerState:atIndex:";

    public static readonly Selector SetFragmentTexture = "setFragmentTexture:atIndex:";

    public static readonly Selector SetFragmentVisibleFunctionTable = "setFragmentVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetMeshBuffer = "setMeshBuffer:offset:atIndex:";

    public static readonly Selector SetMeshBufferOffset = "setMeshBufferOffset:atIndex:";

    public static readonly Selector SetMeshBytes = "setMeshBytes:length:atIndex:";

    public static readonly Selector SetMeshSamplerState = "setMeshSamplerState:atIndex:";

    public static readonly Selector SetMeshTexture = "setMeshTexture:atIndex:";

    public static readonly Selector SetObjectBuffer = "setObjectBuffer:offset:atIndex:";

    public static readonly Selector SetObjectBufferOffset = "setObjectBufferOffset:atIndex:";

    public static readonly Selector SetObjectBytes = "setObjectBytes:length:atIndex:";

    public static readonly Selector SetObjectSamplerState = "setObjectSamplerState:atIndex:";

    public static readonly Selector SetObjectTexture = "setObjectTexture:atIndex:";

    public static readonly Selector SetObjectThreadgroupMemoryLength = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetScissorRects = "setScissorRects:count:";

    public static readonly Selector SetStencilReferenceValues = "setStencilFrontReferenceValue:backReferenceValue:";

    public static readonly Selector SetTessellationFactorBuffer = "setTessellationFactorBuffer:offset:instanceStride:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:offset:atIndex:";

    public static readonly Selector SetTileAccelerationStructure = "setTileAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetTileBuffer = "setTileBuffer:offset:atIndex:";

    public static readonly Selector SetTileBufferOffset = "setTileBufferOffset:atIndex:";

    public static readonly Selector SetTileBytes = "setTileBytes:length:atIndex:";

    public static readonly Selector SetTileIntersectionFunctionTable = "setTileIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetTileSamplerState = "setTileSamplerState:atIndex:";

    public static readonly Selector SetTileTexture = "setTileTexture:atIndex:";

    public static readonly Selector SetTileVisibleFunctionTable = "setTileVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetVertexAccelerationStructure = "setVertexAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetVertexAmplificationCount = "setVertexAmplificationCount:viewMappings:";

    public static readonly Selector SetVertexBuffer = "setVertexBuffer:offset:atIndex:";

    public static readonly Selector SetVertexBufferOffset = "setVertexBufferOffset:atIndex:";

    public static readonly Selector SetVertexBytes = "setVertexBytes:length:atIndex:";

    public static readonly Selector SetVertexIntersectionFunctionTable = "setVertexIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetVertexSamplerState = "setVertexSamplerState:atIndex:";

    public static readonly Selector SetVertexTexture = "setVertexTexture:atIndex:";

    public static readonly Selector SetVertexVisibleFunctionTable = "setVertexVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetViewports = "setViewports:count:";

    public static readonly Selector SetVisibilityResultMode = "setVisibilityResultMode:offset:";

    public static readonly Selector TextureBarrier = "textureBarrier";

    public static readonly Selector TileHeight = "tileHeight";

    public static readonly Selector TileWidth = "tileWidth";

    public static readonly Selector UpdateFence = "updateFence:afterStages:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseResource = "useResource:usage:";

    public static readonly Selector WaitForFence = "waitForFence:beforeStages:";
}
