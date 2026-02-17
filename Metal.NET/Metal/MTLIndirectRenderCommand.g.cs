using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIndirectRenderCommand_Selectors
{
    internal static readonly Selector clearBarrier = Selector.Register("clearBarrier");
    internal static readonly Selector drawIndexedPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_controlPointIndexBuffer_controlPointIndexBufferOffset_instanceCount_baseInstance_buffer_offset_instanceStride_ = Selector.Register("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:buffer:offset:instanceStride:");
    internal static readonly Selector drawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_instanceCount_baseVertex_baseInstance_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:");
    internal static readonly Selector drawPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_instanceCount_baseInstance_buffer_offset_instanceStride_ = Selector.Register("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:buffer:offset:instanceStride:");
    internal static readonly Selector drawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setBarrier = Selector.Register("setBarrier");
    internal static readonly Selector setCullMode_ = Selector.Register("setCullMode:");
    internal static readonly Selector setDepthClipMode_ = Selector.Register("setDepthClipMode:");
    internal static readonly Selector setDepthStencilState_ = Selector.Register("setDepthStencilState:");
    internal static readonly Selector setFragmentBuffer_offset_index_ = Selector.Register("setFragmentBuffer:offset:index:");
    internal static readonly Selector setFrontFacingWinding_ = Selector.Register("setFrontFacingWinding:");
    internal static readonly Selector setMeshBuffer_offset_index_ = Selector.Register("setMeshBuffer:offset:index:");
    internal static readonly Selector setObjectBuffer_offset_index_ = Selector.Register("setObjectBuffer:offset:index:");
    internal static readonly Selector setObjectThreadgroupMemoryLength_index_ = Selector.Register("setObjectThreadgroupMemoryLength:index:");
    internal static readonly Selector setRenderPipelineState_ = Selector.Register("setRenderPipelineState:");
    internal static readonly Selector setTriangleFillMode_ = Selector.Register("setTriangleFillMode:");
    internal static readonly Selector setVertexBuffer_offset_index_ = Selector.Register("setVertexBuffer:offset:index:");
    internal static readonly Selector setVertexBuffer_offset_stride_index_ = Selector.Register("setVertexBuffer:offset:stride:index:");
}

public class MTLIndirectRenderCommand : IDisposable
{
    public nint NativePtr { get; }

    public MTLIndirectRenderCommand(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIndirectRenderCommand o) => o.NativePtr;
    public static implicit operator MTLIndirectRenderCommand(nint ptr) => new MTLIndirectRenderCommand(ptr);

    ~MTLIndirectRenderCommand() => Release();

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

    public void ClearBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.clearBarrier);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.drawIndexedPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_controlPointIndexBuffer_controlPointIndexBufferOffset_instanceCount_baseInstance_buffer_offset_instanceStride_, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nint)controlPointIndexBufferOffset, (nint)instanceCount, (nint)baseInstance, buffer.NativePtr, (nint)offset, (nint)instanceStride);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.drawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_instanceCount_baseVertex_baseInstance_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, (nint)instanceCount, baseVertex, (nint)baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.drawPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_instanceCount_baseInstance_buffer_offset_instanceStride_, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, (nint)instanceCount, (nint)baseInstance, buffer.NativePtr, (nint)offset, (nint)instanceStride);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.drawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount, (nint)baseInstance);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setBarrier);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setCullMode_, (nint)(uint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setDepthClipMode_, (nint)(uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setDepthStencilState_, depthStencilState.NativePtr);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setFragmentBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWindning)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setFrontFacingWinding_, (nint)(uint)frontFacingWindning);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setMeshBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setObjectBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setObjectThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setRenderPipelineState_, pipelineState.NativePtr);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setTriangleFillMode_, (nint)(uint)fillMode);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setVertexBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommand_Selectors.setVertexBuffer_offset_stride_index_, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

}
