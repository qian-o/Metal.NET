namespace Metal.NET;

public class MTL4RenderCommandEncoder : IDisposable
{
    public MTL4RenderCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4RenderCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint TileHeight => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderSelector.TileHeight);

    public nuint TileWidth => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderSelector.TileWidth);

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DispatchThreadsPerTile, threadsPerTile);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, uint indexBuffer, uint indexBufferLength)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLength, (uint)primitiveType, (nuint)indexCount, (uint)indexType, (nuint)indexBuffer, (nuint)indexBufferLength);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, uint indexBuffer, uint indexBufferLength, uint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLengthInstanceCount, (uint)primitiveType, (nuint)indexCount, (uint)indexType, (nuint)indexBuffer, (nuint)indexBufferLength, (nuint)instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, uint indexBuffer, uint indexBufferLength, uint instanceCount, int baseVertex, uint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLengthInstanceCountBaseVertexBaseInstance, (uint)primitiveType, (nuint)indexCount, (uint)indexType, (nuint)indexBuffer, (nuint)indexBufferLength, (nuint)instanceCount, baseVertex, (nuint)baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, uint indexBuffer, uint indexBufferLength, uint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer, (uint)primitiveType, (uint)indexType, (nuint)indexBuffer, (nuint)indexBufferLength, (nuint)indirectBuffer);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(uint indirectBuffer, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, (nuint)indirectBuffer, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCount, (uint)primitiveType, (nuint)vertexStart, (nuint)vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCountInstanceCount, (uint)primitiveType, (nuint)vertexStart, (nuint)vertexCount, (nuint)instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance, (uint)primitiveType, (nuint)vertexStart, (nuint)vertexCount, (nuint)instanceCount, (nuint)baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesIndirectBuffer, (uint)primitiveType, (nuint)indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.ExecuteCommandsInBufferExecutionRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, uint indirectRangeBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.ExecuteCommandsInBufferIndirectRangeBuffer, indirectCommandBuffer.NativePtr, (nuint)indirectRangeBuffer);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable, uint stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetArgumentTableStages, argumentTable.NativePtr, (nuint)stages);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetBlendColorGreenBlueAlpha, red, green, blue, alpha);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, uint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetColorStoreActionColorAttachmentIndex, (uint)storeAction, (nuint)colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetCullMode, (uint)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthBiasSlopeScaleClamp, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthClipMode, (uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthStoreAction, (uint)storeAction);
    }

    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthTestBoundsMaxBound, minBound, maxBound);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetFrontFacingWinding, (uint)frontFacingWinding);
    }

    public void SetObjectThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetObjectThreadgroupMemoryLengthIndex, (nuint)length, (nuint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetScissorRect, rect);
    }

    public void SetScissorRects(MTLScissorRect scissorRects, uint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetScissorRectsCount, scissorRects, (nuint)count);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilReferenceValuesBackReferenceValue, frontReferenceValue, backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilStoreAction, (uint)storeAction);
    }

    public void SetThreadgroupMemoryLength(uint length, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetThreadgroupMemoryLengthOffsetIndex, (nuint)length, (nuint)offset, (nuint)index);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetTriangleFillMode, (uint)fillMode);
    }

    public void SetVertexAmplificationCount(uint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetVertexAmplificationCountViewMappings, (nuint)count, viewMappings);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetViewport, viewport);
    }

    public void SetViewports(MTLViewport viewports, uint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetViewportsCount, viewports, (nuint)count);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, uint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetVisibilityResultModeOffset, (uint)mode, (nuint)offset);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, uint stage, MTL4CounterHeap counterHeap, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.WriteTimestampStageCounterHeapIndex, (uint)granularity, (nuint)stage, counterHeap.NativePtr, (nuint)index);
    }

    public static implicit operator nint(MTL4RenderCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4RenderCommandEncoder(nint value)
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

file class MTL4RenderCommandEncoderSelector
{
    public static readonly Selector TileHeight = Selector.Register("tileHeight");

    public static readonly Selector TileWidth = Selector.Register("tileWidth");

    public static readonly Selector DispatchThreadsPerTile = Selector.Register("dispatchThreadsPerTile:");

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLength = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:");

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLengthInstanceCount = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:");

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLengthInstanceCountBaseVertexBaseInstance = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:baseVertex:baseInstance:");

    public static readonly Selector DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:");

    public static readonly Selector DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawPrimitivesVertexStartVertexCount = Selector.Register("drawPrimitives:vertexStart:vertexCount:");

    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCount = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:");

    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");

    public static readonly Selector DrawPrimitivesIndirectBuffer = Selector.Register("drawPrimitives:indirectBuffer:");

    public static readonly Selector ExecuteCommandsInBufferExecutionRange = Selector.Register("executeCommandsInBuffer:executionRange:");

    public static readonly Selector ExecuteCommandsInBufferIndirectRangeBuffer = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:");

    public static readonly Selector SetArgumentTableStages = Selector.Register("setArgumentTable:stages:");

    public static readonly Selector SetBlendColorGreenBlueAlpha = Selector.Register("setBlendColor:green:blue:alpha:");

    public static readonly Selector SetColorAttachmentMap = Selector.Register("setColorAttachmentMap:");

    public static readonly Selector SetColorStoreActionColorAttachmentIndex = Selector.Register("setColorStoreAction:colorAttachmentIndex:");

    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");

    public static readonly Selector SetDepthBiasSlopeScaleClamp = Selector.Register("setDepthBias:slopeScale:clamp:");

    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");

    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthTestBoundsMaxBound = Selector.Register("setDepthTestBounds:maxBound:");

    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");

    public static readonly Selector SetObjectThreadgroupMemoryLengthIndex = Selector.Register("setObjectThreadgroupMemoryLength:index:");

    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");

    public static readonly Selector SetScissorRect = Selector.Register("setScissorRect:");

    public static readonly Selector SetScissorRectsCount = Selector.Register("setScissorRects:count:");

    public static readonly Selector SetStencilReferenceValue = Selector.Register("setStencilReferenceValue:");

    public static readonly Selector SetStencilReferenceValuesBackReferenceValue = Selector.Register("setStencilReferenceValues:backReferenceValue:");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetThreadgroupMemoryLengthOffsetIndex = Selector.Register("setThreadgroupMemoryLength:offset:index:");

    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");

    public static readonly Selector SetVertexAmplificationCountViewMappings = Selector.Register("setVertexAmplificationCount:viewMappings:");

    public static readonly Selector SetViewport = Selector.Register("setViewport:");

    public static readonly Selector SetViewportsCount = Selector.Register("setViewports:count:");

    public static readonly Selector SetVisibilityResultModeOffset = Selector.Register("setVisibilityResultMode:offset:");

    public static readonly Selector WriteTimestampStageCounterHeapIndex = Selector.Register("writeTimestamp:stage:counterHeap:index:");
}
