namespace Metal.NET;

file class MTLIndirectRenderCommandSelector
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");
    public static readonly Selector DrawIndexedPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_controlPointIndexBuffer_controlPointIndexBufferOffset_instanceCount_baseInstance_buffer_offset_instanceStride_ = Selector.Register("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:buffer:offset:instanceStride:");
    public static readonly Selector DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_instanceCount_baseVertex_baseInstance_ = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:");
    public static readonly Selector DrawPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_instanceCount_baseInstance_buffer_offset_instanceStride_ = Selector.Register("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:buffer:offset:instanceStride:");
    public static readonly Selector DrawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_ = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetBarrier = Selector.Register("setBarrier");
    public static readonly Selector SetCullMode_ = Selector.Register("setCullMode:");
    public static readonly Selector SetDepthClipMode_ = Selector.Register("setDepthClipMode:");
    public static readonly Selector SetDepthStencilState_ = Selector.Register("setDepthStencilState:");
    public static readonly Selector SetFragmentBuffer_offset_index_ = Selector.Register("setFragmentBuffer:offset:index:");
    public static readonly Selector SetFrontFacingWinding_ = Selector.Register("setFrontFacingWinding:");
    public static readonly Selector SetMeshBuffer_offset_index_ = Selector.Register("setMeshBuffer:offset:index:");
    public static readonly Selector SetObjectBuffer_offset_index_ = Selector.Register("setObjectBuffer:offset:index:");
    public static readonly Selector SetObjectThreadgroupMemoryLength_index_ = Selector.Register("setObjectThreadgroupMemoryLength:index:");
    public static readonly Selector SetRenderPipelineState_ = Selector.Register("setRenderPipelineState:");
    public static readonly Selector SetTriangleFillMode_ = Selector.Register("setTriangleFillMode:");
    public static readonly Selector SetVertexBuffer_offset_index_ = Selector.Register("setVertexBuffer:offset:index:");
    public static readonly Selector SetVertexBuffer_offset_stride_index_ = Selector.Register("setVertexBuffer:offset:stride:index:");
}

public class MTLIndirectRenderCommand : IDisposable
{
    public MTLIndirectRenderCommand(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIndirectRenderCommand()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIndirectRenderCommand value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectRenderCommand(nint value)
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

    public void ClearBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.ClearBarrier);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawIndexedPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_controlPointIndexBuffer_controlPointIndexBufferOffset_instanceCount_baseInstance_buffer_offset_instanceStride_, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nint)controlPointIndexBufferOffset, (nint)instanceCount, (nint)baseInstance, buffer.NativePtr, (nint)offset, (nint)instanceStride);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawIndexedPrimitives_indexCount_indexType_indexBuffer_indexBufferOffset_instanceCount_baseVertex_baseInstance_, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, (nint)instanceCount, baseVertex, (nint)baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawPatches_patchStart_patchCount_patchIndexBuffer_patchIndexBufferOffset_instanceCount_baseInstance_buffer_offset_instanceStride_, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, (nint)instanceCount, (nint)baseInstance, buffer.NativePtr, (nint)offset, (nint)instanceStride);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawPrimitives_vertexStart_vertexCount_instanceCount_baseInstance_, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount, (nint)baseInstance);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.Reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetBarrier);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetCullMode_, (nint)(uint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthClipMode_, (nint)(uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthStencilState_, depthStencilState.NativePtr);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetFragmentBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWindning)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetFrontFacingWinding_, (nint)(uint)frontFacingWindning);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetMeshBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetObjectBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetObjectThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetRenderPipelineState_, pipelineState.NativePtr);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetTriangleFillMode_, (nint)(uint)fillMode);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetVertexBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetVertexBuffer_offset_stride_index_, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

}
