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

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DispatchThreadsPerTile, threadsPerTile);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, uint indexBuffer, uint indexBufferLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLength, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, uint indexBuffer, uint indexBufferLength, uint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLengthInstanceCount, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, uint indexBuffer, uint indexBufferLength, uint instanceCount, int baseVertex, uint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLengthInstanceCountBaseVertexBaseInstance, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)instanceCount, baseVertex, (nint)baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, uint indexBuffer, uint indexBufferLength, uint indirectBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer, (nint)(uint)primitiveType, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)indirectBuffer);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCount, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCountInstanceCount, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint indirectBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitivesIndirectBuffer, (nint)(uint)primitiveType, (nint)indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, uint indirectRangeBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.ExecuteCommandsInBufferIndirectRangeBuffer, indirectCommandBuffer.NativePtr, (nint)indirectRangeBuffer);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable, uint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetArgumentTableStages, argumentTable.NativePtr, (nint)stages);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, uint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetColorStoreActionColorAttachmentIndex, (nint)(uint)storeAction, (nint)colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetCullMode, (nint)(uint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthClipMode, (nint)(uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthStoreAction, (nint)(uint)storeAction);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetFrontFacingWinding, (nint)(uint)frontFacingWinding);
    }

    public void SetObjectThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetObjectThreadgroupMemoryLengthIndex, (nint)length, (nint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilReferenceValue, (nint)referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilReferenceValuesBackReferenceValue, (nint)frontReferenceValue, (nint)backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilStoreAction, (nint)(uint)storeAction);
    }

    public void SetThreadgroupMemoryLength(uint length, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetThreadgroupMemoryLengthOffsetIndex, (nint)length, (nint)offset, (nint)index);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetTriangleFillMode, (nint)(uint)fillMode);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, uint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetVisibilityResultModeOffset, (nint)(uint)mode, (nint)offset);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, uint stage, MTL4CounterHeap counterHeap, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.WriteTimestampStageCounterHeapIndex, (nint)(uint)granularity, (nint)stage, counterHeap.NativePtr, (nint)index);
    }

}

file class MTL4RenderCommandEncoderSelector
{
    public static readonly Selector DispatchThreadsPerTile = Selector.Register("dispatchThreadsPerTile:");
    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLength = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:");
    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLengthInstanceCount = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:");
    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferLengthInstanceCountBaseVertexBaseInstance = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:baseVertex:baseInstance:");
    public static readonly Selector DrawIndexedPrimitivesIndexTypeIndexBufferIndexBufferLengthIndirectBuffer = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:");
    public static readonly Selector DrawPrimitivesVertexStartVertexCount = Selector.Register("drawPrimitives:vertexStart:vertexCount:");
    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCount = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:");
    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");
    public static readonly Selector DrawPrimitivesIndirectBuffer = Selector.Register("drawPrimitives:indirectBuffer:");
    public static readonly Selector ExecuteCommandsInBufferIndirectRangeBuffer = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:");
    public static readonly Selector SetArgumentTableStages = Selector.Register("setArgumentTable:stages:");
    public static readonly Selector SetColorAttachmentMap = Selector.Register("setColorAttachmentMap:");
    public static readonly Selector SetColorStoreActionColorAttachmentIndex = Selector.Register("setColorStoreAction:colorAttachmentIndex:");
    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");
    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");
    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");
    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");
    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");
    public static readonly Selector SetObjectThreadgroupMemoryLengthIndex = Selector.Register("setObjectThreadgroupMemoryLength:index:");
    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");
    public static readonly Selector SetStencilReferenceValue = Selector.Register("setStencilReferenceValue:");
    public static readonly Selector SetStencilReferenceValuesBackReferenceValue = Selector.Register("setStencilReferenceValues:backReferenceValue:");
    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");
    public static readonly Selector SetThreadgroupMemoryLengthOffsetIndex = Selector.Register("setThreadgroupMemoryLength:offset:index:");
    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");
    public static readonly Selector SetVisibilityResultModeOffset = Selector.Register("setVisibilityResultMode:offset:");
    public static readonly Selector WriteTimestampStageCounterHeapIndex = Selector.Register("writeTimestamp:stage:counterHeap:index:");
}
