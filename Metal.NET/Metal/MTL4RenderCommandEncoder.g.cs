namespace Metal.NET;

file class MTL4RenderCommandEncoderSelector
{
    public static readonly Selector DispatchThreadsPerTile_ = Selector.Register("dispatchThreadsPerTile:");
    public static readonly Selector DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:");
    public static readonly Selector DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_instanceCount_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:");
    public static readonly Selector DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_instanceCount_baseVertex_baseInstance_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:baseVertex:baseInstance:");
    public static readonly Selector DrawIndexedPrimitives_indexType_indexBuffer_indexBufferLength_indirectBuffer_ = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:");
    public static readonly Selector DrawPrimitives_vertexStart_vertexCount_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:");
    public static readonly Selector DrawPrimitives_vertexStart_vertexCount_instanceCount_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:");
    public static readonly Selector DrawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");
    public static readonly Selector DrawPrimitives_indirectBuffer_ = Selector.Register("drawPrimitives:indirectBuffer:");
    public static readonly Selector ExecuteCommandsInBuffer_indirectRangeBuffer_ = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:");
    public static readonly Selector SetArgumentTable_stages_ = Selector.Register("setArgumentTable:stages:");
    public static readonly Selector SetColorAttachmentMap_ = Selector.Register("setColorAttachmentMap:");
    public static readonly Selector SetColorStoreAction_colorAttachmentIndex_ = Selector.Register("setColorStoreAction:colorAttachmentIndex:");
    public static readonly Selector SetCullMode_ = Selector.Register("setCullMode:");
    public static readonly Selector SetDepthClipMode_ = Selector.Register("setDepthClipMode:");
    public static readonly Selector SetDepthStencilState_ = Selector.Register("setDepthStencilState:");
    public static readonly Selector SetDepthStoreAction_ = Selector.Register("setDepthStoreAction:");
    public static readonly Selector SetFrontFacingWinding_ = Selector.Register("setFrontFacingWinding:");
    public static readonly Selector SetObjectThreadgroupMemoryLength_index_ = Selector.Register("setObjectThreadgroupMemoryLength:index:");
    public static readonly Selector SetRenderPipelineState_ = Selector.Register("setRenderPipelineState:");
    public static readonly Selector SetStencilReferenceValue_ = Selector.Register("setStencilReferenceValue:");
    public static readonly Selector SetStencilReferenceValues_backReferenceValue_ = Selector.Register("setStencilReferenceValues:backReferenceValue:");
    public static readonly Selector SetStencilStoreAction_ = Selector.Register("setStencilStoreAction:");
    public static readonly Selector SetThreadgroupMemoryLength_offset_index_ = Selector.Register("setThreadgroupMemoryLength:offset:index:");
    public static readonly Selector SetTriangleFillMode_ = Selector.Register("setTriangleFillMode:");
    public static readonly Selector SetVisibilityResultMode_offset_ = Selector.Register("setVisibilityResultMode:offset:");
    public static readonly Selector WriteTimestamp_stage_counterHeap_index_ = Selector.Register("writeTimestamp:stage:counterHeap:index:");
}

public class MTL4RenderCommandEncoder : IDisposable
{
    public MTL4RenderCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DispatchThreadsPerTile_, threadsPerTile);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_instanceCount_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_instanceCount_baseVertex_baseInstance_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)instanceCount, baseVertex, (nint)baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint indirectBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawIndexedPrimitives_indexType_indexBuffer_indexBufferLength_indirectBuffer_, (nint)(uint)primitiveType, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)indirectBuffer);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitives_vertexStart_vertexCount_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitives_vertexStart_vertexCount_instanceCount_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint indirectBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.DrawPrimitives_indirectBuffer_, (nint)(uint)primitiveType, (nint)indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.ExecuteCommandsInBuffer_indirectRangeBuffer_, indirectCommandBuffer.NativePtr, (nint)indirectRangeBuffer);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable, nuint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetArgumentTable_stages_, argumentTable.NativePtr, (nint)stages);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetColorAttachmentMap_, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetColorStoreAction_colorAttachmentIndex_, (nint)(uint)storeAction, (nint)colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetCullMode_, (nint)(uint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthClipMode_, (nint)(uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthStencilState_, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetDepthStoreAction_, (nint)(uint)storeAction);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetFrontFacingWinding_, (nint)(uint)frontFacingWinding);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetObjectThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetRenderPipelineState_, pipelineState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilReferenceValue_, (nint)referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilReferenceValues_backReferenceValue_, (nint)frontReferenceValue, (nint)backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetStencilStoreAction_, (nint)(uint)storeAction);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetThreadgroupMemoryLength_offset_index_, (nint)length, (nint)offset, (nint)index);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetTriangleFillMode_, (nint)(uint)fillMode);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.SetVisibilityResultMode_offset_, (nint)(uint)mode, (nint)offset);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, nuint stage, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoderSelector.WriteTimestamp_stage_counterHeap_index_, (nint)(uint)granularity, (nint)stage, counterHeap.NativePtr, (nint)index);
    }

}
