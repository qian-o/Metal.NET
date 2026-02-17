namespace Metal.NET;

public class MTLIndirectRenderCommand : IDisposable
{
    public MTLIndirectRenderCommand(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void DrawIndexedPatches(uint numberOfPatchControlPoints, uint patchStart, uint patchCount, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, uint controlPointIndexBufferOffset, uint instanceCount, uint baseInstance, MTLBuffer buffer, uint offset, uint instanceStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstanceBufferOffsetInstanceStride, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nint)controlPointIndexBufferOffset, (nint)instanceCount, (nint)baseInstance, buffer.NativePtr, (nint)offset, (nint)instanceStride);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset, uint instanceCount, int baseVertex, uint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance, (nint)(uint)primitiveType, (nint)indexCount, (nint)(uint)indexType, indexBuffer.NativePtr, (nint)indexBufferOffset, (nint)instanceCount, baseVertex, (nint)baseInstance);
    }

    public void DrawPatches(uint numberOfPatchControlPoints, uint patchStart, uint patchCount, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, uint instanceCount, uint baseInstance, MTLBuffer buffer, uint offset, uint instanceStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstanceBufferOffsetInstanceStride, (nint)numberOfPatchControlPoints, (nint)patchStart, (nint)patchCount, patchIndexBuffer.NativePtr, (nint)patchIndexBufferOffset, (nint)instanceCount, (nint)baseInstance, buffer.NativePtr, (nint)offset, (nint)instanceStride);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance, (nint)(uint)primitiveType, (nint)vertexStart, (nint)vertexCount, (nint)instanceCount, (nint)baseInstance);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetCullMode, (nint)(uint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthClipMode, (nint)(uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetFragmentBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWindning)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetFrontFacingWinding, (nint)(uint)frontFacingWindning);
    }

    public void SetMeshBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetMeshBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetObjectBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetObjectThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetObjectThreadgroupMemoryLengthIndex, (nint)length, (nint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetTriangleFillMode, (nint)(uint)fillMode);
    }

    public void SetVertexBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetVertexBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectRenderCommandSelector.SetVertexBufferOffsetStrideIndex, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

}

file class MTLIndirectRenderCommandSelector
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");
    public static readonly Selector DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstanceBufferOffsetInstanceStride = Selector.Register("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:buffer:offset:instanceStride:");
    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:");
    public static readonly Selector DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstanceBufferOffsetInstanceStride = Selector.Register("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:buffer:offset:instanceStride:");
    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetBarrier = Selector.Register("setBarrier");
    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");
    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");
    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");
    public static readonly Selector SetFragmentBufferOffsetIndex = Selector.Register("setFragmentBuffer:offset:index:");
    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");
    public static readonly Selector SetMeshBufferOffsetIndex = Selector.Register("setMeshBuffer:offset:index:");
    public static readonly Selector SetObjectBufferOffsetIndex = Selector.Register("setObjectBuffer:offset:index:");
    public static readonly Selector SetObjectThreadgroupMemoryLengthIndex = Selector.Register("setObjectThreadgroupMemoryLength:index:");
    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");
    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");
    public static readonly Selector SetVertexBufferOffsetIndex = Selector.Register("setVertexBuffer:offset:index:");
    public static readonly Selector SetVertexBufferOffsetStrideIndex = Selector.Register("setVertexBuffer:offset:stride:index:");
}
