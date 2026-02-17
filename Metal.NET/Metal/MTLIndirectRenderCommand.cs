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

    public void ClearBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.ClearBarrier);
    }

    public void DrawIndexedPatches(uint numberOfPatchControlPoints, uint patchStart, uint patchCount, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, uint controlPointIndexBufferOffset, uint instanceCount, uint baseInstance, MTLBuffer buffer, uint offset, uint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstanceBufferOffsetInstanceStride, (nuint)numberOfPatchControlPoints, (nuint)patchStart, (nuint)patchCount, patchIndexBuffer.NativePtr, (nuint)patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, (nuint)controlPointIndexBufferOffset, (nuint)instanceCount, (nuint)baseInstance, buffer.NativePtr, (nuint)offset, (nuint)instanceStride);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, uint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, uint indexBufferOffset, uint instanceCount, int baseVertex, uint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance, (uint)primitiveType, (nuint)indexCount, (uint)indexType, indexBuffer.NativePtr, (nuint)indexBufferOffset, (nuint)instanceCount, baseVertex, (nuint)baseInstance);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPatches(uint numberOfPatchControlPoints, uint patchStart, uint patchCount, MTLBuffer patchIndexBuffer, uint patchIndexBufferOffset, uint instanceCount, uint baseInstance, MTLBuffer buffer, uint offset, uint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstanceBufferOffsetInstanceStride, (nuint)numberOfPatchControlPoints, (nuint)patchStart, (nuint)patchCount, patchIndexBuffer.NativePtr, (nuint)patchIndexBufferOffset, (nuint)instanceCount, (nuint)baseInstance, buffer.NativePtr, (nuint)offset, (nuint)instanceStride);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, uint vertexStart, uint vertexCount, uint instanceCount, uint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance, (uint)primitiveType, (nuint)vertexStart, (nuint)vertexCount, (nuint)instanceCount, (nuint)baseInstance);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.Reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetBarrier);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetCullMode, (uint)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthBiasSlopeScaleClamp, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthClipMode, (uint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetFragmentBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWindning)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetFrontFacingWinding, (uint)frontFacingWindning);
    }

    public void SetMeshBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetMeshBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetObjectBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetObjectThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetObjectThreadgroupMemoryLengthIndex, (nuint)length, (nuint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetTriangleFillMode, (uint)fillMode);
    }

    public void SetVertexBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetVertexBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetVertexBufferOffsetStrideIndex, buffer.NativePtr, (nuint)offset, (nuint)stride, (nuint)index);
    }

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

}

file class MTLIndirectRenderCommandSelector
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");

    public static readonly Selector DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstanceBufferOffsetInstanceStride = Selector.Register("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:buffer:offset:instanceStride:");

    public static readonly Selector DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:");

    public static readonly Selector DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup = Selector.Register("drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstanceBufferOffsetInstanceStride = Selector.Register("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:buffer:offset:instanceStride:");

    public static readonly Selector DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetBarrier = Selector.Register("setBarrier");

    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");

    public static readonly Selector SetDepthBiasSlopeScaleClamp = Selector.Register("setDepthBias:slopeScale:clamp:");

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
