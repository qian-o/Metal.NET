using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4RenderCommandEncoder_Selectors
{
    internal static readonly Selector dispatchThreadsPerTile_ = Selector.Register("dispatchThreadsPerTile:");
    internal static readonly Selector drawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:");
    internal static readonly Selector drawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_instanceCount_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:");
    internal static readonly Selector drawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_instanceCount_baseVertex_baseInstance_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:baseVertex:baseInstance:");
    internal static readonly Selector drawIndexedPrimitives_indexType_indexBuffer_indexBufferLength_indirectBuffer_ = Selector.Register("drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:");
    internal static readonly Selector drawPrimitives_vertexStart_vertexCount_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:");
    internal static readonly Selector drawPrimitives_vertexStart_vertexCount_instanceCount_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:");
    internal static readonly Selector drawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");
    internal static readonly Selector drawPrimitives_indirectBuffer_ = Selector.Register("drawPrimitives:indirectBuffer:");
    internal static readonly Selector executeCommandsInBuffer_indirectRangeBuffer_ = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:");
    internal static readonly Selector setArgumentTable_stages_ = Selector.Register("setArgumentTable:stages:");
    internal static readonly Selector setColorAttachmentMap_ = Selector.Register("setColorAttachmentMap:");
    internal static readonly Selector setColorStoreAction_colorAttachmentIndex_ = Selector.Register("setColorStoreAction:colorAttachmentIndex:");
    internal static readonly Selector setCullMode_ = Selector.Register("setCullMode:");
    internal static readonly Selector setDepthClipMode_ = Selector.Register("setDepthClipMode:");
    internal static readonly Selector setDepthStencilState_ = Selector.Register("setDepthStencilState:");
    internal static readonly Selector setDepthStoreAction_ = Selector.Register("setDepthStoreAction:");
    internal static readonly Selector setFrontFacingWinding_ = Selector.Register("setFrontFacingWinding:");
    internal static readonly Selector setObjectThreadgroupMemoryLength_index_ = Selector.Register("setObjectThreadgroupMemoryLength:index:");
    internal static readonly Selector setRenderPipelineState_ = Selector.Register("setRenderPipelineState:");
    internal static readonly Selector setStencilReferenceValue_ = Selector.Register("setStencilReferenceValue:");
    internal static readonly Selector setStencilReferenceValues_backReferenceValue_ = Selector.Register("setStencilReferenceValues:backReferenceValue:");
    internal static readonly Selector setStencilStoreAction_ = Selector.Register("setStencilStoreAction:");
    internal static readonly Selector setThreadgroupMemoryLength_offset_index_ = Selector.Register("setThreadgroupMemoryLength:offset:index:");
    internal static readonly Selector setTriangleFillMode_ = Selector.Register("setTriangleFillMode:");
    internal static readonly Selector setVisibilityResultMode_offset_ = Selector.Register("setVisibilityResultMode:offset:");
    internal static readonly Selector writeTimestamp_stage_counterHeap_index_ = Selector.Register("writeTimestamp:stage:counterHeap:index:");
}

public class MTL4RenderCommandEncoder : IDisposable
{
    public nint NativePtr { get; }

    public MTL4RenderCommandEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4RenderCommandEncoder o) => o.NativePtr;
    public static implicit operator MTL4RenderCommandEncoder(nint ptr) => new MTL4RenderCommandEncoder(ptr);

    ~MTL4RenderCommandEncoder() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.dispatchThreadsPerTile_, threadsPerTile);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.drawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.drawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_instanceCount_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.drawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferLength_instanceCount_baseVertex_baseInstance_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)instanceCount, baseVertex, (nint)baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint indirectBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.drawIndexedPrimitives_indexType_indexBuffer_indexBufferLength_indirectBuffer_, (nint)(uint)primitiveType, (nint)(uint)indexType, (nint)indexBuffer, (nint)indexBufferLength, (nint)indirectBuffer);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.drawPrimitives_vertexStart_vertexCount_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.drawPrimitives_vertexStart_vertexCount_instanceCount_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.drawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount, (nint)baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint indirectBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.drawPrimitives_indirectBuffer_, (nint)(uint)primitiveType, (nint)indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.executeCommandsInBuffer_indirectRangeBuffer_, indirectCommandBuffer.NativePtr, (nint)indirectRangeBuffer);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable, nuint stages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setArgumentTable_stages_, argumentTable.NativePtr, (nint)stages);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setColorAttachmentMap_, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setColorStoreAction_colorAttachmentIndex_, (nint)(uint)storeAction, (nint)colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setCullMode_, (nint)(uint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setDepthClipMode_, (nint)(uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setDepthStencilState_, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setDepthStoreAction_, (nint)(uint)storeAction);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setFrontFacingWinding_, (nint)(uint)frontFacingWinding);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setObjectThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setRenderPipelineState_, pipelineState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setStencilReferenceValue_, (nint)referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setStencilReferenceValues_backReferenceValue_, (nint)frontReferenceValue, (nint)backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setStencilStoreAction_, (nint)(uint)storeAction);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setThreadgroupMemoryLength_offset_index_, (nint)length, (nint)offset, (nint)index);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setTriangleFillMode_, (nint)(uint)fillMode);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.setVisibilityResultMode_offset_, (nint)(uint)mode, (nint)offset);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, nuint stage, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderCommandEncoder_Selectors.writeTimestamp_stage_counterHeap_index_, (nint)(uint)granularity, (nint)stage, counterHeap.NativePtr, (nint)index);
    }

}
