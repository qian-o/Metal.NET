namespace Metal.NET;

public class MTL4RenderCommandEncoder : IDisposable
{
    public MTL4RenderCommandEncoder(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4RenderCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint TileHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderSelector.TileHeight);
    }

    public nuint TileWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderSelector.TileWidth);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DispatchThreadsPerTile, threadsPerTile);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferLength);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferLength, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferLength, instanceCount, baseVertex, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer, (ulong)primitiveType, (ulong)indexType, indexBuffer, indexBufferLength, indirectBuffer);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawMeshThreadgroupsWithIndirectBufferThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(nuint indirectBuffer, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawMeshThreadgroupsWithIndirectBufferThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, indirectBuffer, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesIndirectBuffer, (ulong)primitiveType, vertexStart, vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesIndirectBuffer, (ulong)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesIndirectBuffer, (ulong)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesIndirectBuffer, (ulong)primitiveType, indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.ExecuteCommandsInBufferIndirectBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.ExecuteCommandsInBufferIndirectBuffer, indirectCommandBuffer.NativePtr, indirectRangeBuffer);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetArgumentTableAtStages, argumentTable.NativePtr, (ulong)stages);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetBlendColorRedGreenBlueAlpha, red, green, blue, alpha);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetColorStoreActionAtIndex, (ulong)storeAction, colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetCullMode, (ulong)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthBiasSlopeScaleClamp, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthClipMode, (ulong)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthStoreAction, (ulong)storeAction);
    }

    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthTestMinBoundMaxBound, minBound, maxBound);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetFrontFacingWinding, (ulong)frontFacingWinding);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetObjectThreadgroupMemoryLengthAtIndex, length, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetScissorRect, rect);
    }

    public void SetScissorRects(MTLScissorRect scissorRects, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetScissorRectsCount, scissorRects, count);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilFrontReferenceValueBackReferenceValue, frontReferenceValue, backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilStoreAction, (ulong)storeAction);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetThreadgroupMemoryLengthOffsetAtIndex, length, offset, index);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetTriangleFillMode, (ulong)fillMode);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetVertexAmplificationCountViewMappings, count, viewMappings);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetViewport, viewport);
    }

    public void SetViewports(MTLViewport viewports, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetViewportsCount, viewports, count);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetVisibilityResultModeOffset, (ulong)mode, offset);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTLRenderStages stage, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderSelector.WriteTimestampWithGranularityAfterStageIntoHeapAtIndex, (ulong)granularity, (ulong)stage, counterHeap.NativePtr, index);
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

    public static readonly Selector DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:");

    public static readonly Selector DrawMeshThreadgroupsWithIndirectBufferThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreadgroupsWithIndirectBuffer:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawPrimitivesIndirectBuffer = Selector.Register("drawPrimitives:indirectBuffer:");

    public static readonly Selector ExecuteCommandsInBufferIndirectBuffer = Selector.Register("executeCommandsInBuffer:indirectBuffer:");

    public static readonly Selector SetArgumentTableAtStages = Selector.Register("setArgumentTable:atStages:");

    public static readonly Selector SetBlendColorRedGreenBlueAlpha = Selector.Register("setBlendColorRed:green:blue:alpha:");

    public static readonly Selector SetColorAttachmentMap = Selector.Register("setColorAttachmentMap:");

    public static readonly Selector SetColorStoreActionAtIndex = Selector.Register("setColorStoreAction:atIndex:");

    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");

    public static readonly Selector SetDepthBiasSlopeScaleClamp = Selector.Register("setDepthBias:slopeScale:clamp:");

    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");

    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthTestMinBoundMaxBound = Selector.Register("setDepthTestMinBound:maxBound:");

    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");

    public static readonly Selector SetObjectThreadgroupMemoryLengthAtIndex = Selector.Register("setObjectThreadgroupMemoryLength:atIndex:");

    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");

    public static readonly Selector SetScissorRect = Selector.Register("setScissorRect:");

    public static readonly Selector SetScissorRectsCount = Selector.Register("setScissorRects:count:");

    public static readonly Selector SetStencilReferenceValue = Selector.Register("setStencilReferenceValue:");

    public static readonly Selector SetStencilFrontReferenceValueBackReferenceValue = Selector.Register("setStencilFrontReferenceValue:backReferenceValue:");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetThreadgroupMemoryLengthOffsetAtIndex = Selector.Register("setThreadgroupMemoryLength:offset:atIndex:");

    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");

    public static readonly Selector SetVertexAmplificationCountViewMappings = Selector.Register("setVertexAmplificationCount:viewMappings:");

    public static readonly Selector SetViewport = Selector.Register("setViewport:");

    public static readonly Selector SetViewportsCount = Selector.Register("setViewports:count:");

    public static readonly Selector SetVisibilityResultModeOffset = Selector.Register("setVisibilityResultMode:offset:");

    public static readonly Selector WriteTimestampWithGranularityAfterStageIntoHeapAtIndex = Selector.Register("writeTimestampWithGranularity:afterStage:intoHeap:atIndex:");
}
