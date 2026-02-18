namespace Metal.NET;

public partial class MTLIndirectRenderCommand : NativeObject
{
    public MTLIndirectRenderCommand(nint nativePtr) : base(nativePtr)
    {
    }

    public void ClearBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.ClearBarrier);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetCullMode, (nuint)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWindning)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetFrontFacingWinding, (nuint)frontFacingWindning);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetTriangleFillMode, (nuint)fillMode);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetVertexBuffer, buffer.NativePtr, offset, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandSelector.SetVertexBuffer, buffer.NativePtr, offset, stride, index);
    }
}

file static class MTLIndirectRenderCommandSelector
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");

    public static readonly Selector DrawIndexedPatches = Selector.Register("drawIndexedPatches::::::::::::");

    public static readonly Selector DrawIndexedPrimitives = Selector.Register("drawIndexedPrimitives::::::::");

    public static readonly Selector DrawMeshThreadgroups = Selector.Register("drawMeshThreadgroups:::");

    public static readonly Selector DrawMeshThreads = Selector.Register("drawMeshThreads:::");

    public static readonly Selector DrawPatches = Selector.Register("drawPatches::::::::::");

    public static readonly Selector DrawPrimitives = Selector.Register("drawPrimitives:::::");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetBarrier = Selector.Register("setBarrier");

    public static readonly Selector SetCullMode = Selector.Register("setCullMode:");

    public static readonly Selector SetDepthBias = Selector.Register("setDepthBias:::");

    public static readonly Selector SetDepthClipMode = Selector.Register("setDepthClipMode:");

    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:");

    public static readonly Selector SetFragmentBuffer = Selector.Register("setFragmentBuffer:::");

    public static readonly Selector SetFrontFacingWinding = Selector.Register("setFrontFacingWinding:");

    public static readonly Selector SetMeshBuffer = Selector.Register("setMeshBuffer:::");

    public static readonly Selector SetObjectBuffer = Selector.Register("setObjectBuffer:::");

    public static readonly Selector SetObjectThreadgroupMemoryLength = Selector.Register("setObjectThreadgroupMemoryLength::");

    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:");

    public static readonly Selector SetTriangleFillMode = Selector.Register("setTriangleFillMode:");

    public static readonly Selector SetVertexBuffer = Selector.Register("setVertexBuffer:::");
}
