namespace Metal.NET;

public partial class MTLIndirectRenderCommand(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIndirectRenderCommand>
{
    #region INativeObject
    public static new MTLIndirectRenderCommand Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectRenderCommand New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetVertexBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetFragmentBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetVertexBuffer_Offset_AttributeStride_AtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawPatches_PatchStart_PatchCount_PatchIndexBuffer_PatchIndexBufferOffset_InstanceCount_BaseInstance_TessellationFactorBuffer_TessellationFactorBufferOffset_TessellationFactorBufferInstanceStride, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawIndexedPatches_PatchStart_PatchCount_PatchIndexBuffer_PatchIndexBufferOffset_ControlPointIndexBuffer_ControlPointIndexBufferOffset_InstanceCount_BaseInstance_TessellationFactorBuffer_TessellationFactorBufferOffset_TessellationFactorBufferInstanceStride, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawPrimitives_VertexStart_VertexCount_InstanceCount_BaseInstance, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferOffset_InstanceCount_BaseVertex_BaseInstance, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetObjectThreadgroupMemoryLength_AtIndex, length, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetObjectBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetMeshBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawMeshThreadgroups_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawMeshThreads_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void SetBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetBarrier);
    }

    public void ClearBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.ClearBarrier);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthBias_SlopeScale_Clamp, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetCullMode, (nuint)cullMode);
    }

    public void SetFrontFacing(MTLWinding frontFacingWinding)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetTriangleFillMode, (nuint)fillMode);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.Reset);
    }
}

file static class MTLIndirectRenderCommandBindings
{
    public static readonly Selector ClearBarrier = "clearBarrier";

    public static readonly Selector DrawIndexedPatches_PatchStart_PatchCount_PatchIndexBuffer_PatchIndexBufferOffset_ControlPointIndexBuffer_ControlPointIndexBufferOffset_InstanceCount_BaseInstance_TessellationFactorBuffer_TessellationFactorBufferOffset_TessellationFactorBufferInstanceStride = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:";

    public static readonly Selector DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferOffset_InstanceCount_BaseVertex_BaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";

    public static readonly Selector DrawMeshThreadgroups_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPatches_PatchStart_PatchCount_PatchIndexBuffer_PatchIndexBufferOffset_InstanceCount_BaseInstance_TessellationFactorBuffer_TessellationFactorBufferOffset_TessellationFactorBufferInstanceStride = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:";

    public static readonly Selector DrawPrimitives_VertexStart_VertexCount_InstanceCount_BaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBarrier = "setBarrier";

    public static readonly Selector SetCullMode = "setCullMode:";

    public static readonly Selector SetDepthBias_SlopeScale_Clamp = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthClipMode = "setDepthClipMode:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:";

    public static readonly Selector SetFragmentBuffer_Offset_AtIndex = "setFragmentBuffer:offset:atIndex:";

    public static readonly Selector SetFrontFacingWinding = "setFrontFacingWinding:";

    public static readonly Selector SetMeshBuffer_Offset_AtIndex = "setMeshBuffer:offset:atIndex:";

    public static readonly Selector SetObjectBuffer_Offset_AtIndex = "setObjectBuffer:offset:atIndex:";

    public static readonly Selector SetObjectThreadgroupMemoryLength_AtIndex = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:";

    public static readonly Selector SetTriangleFillMode = "setTriangleFillMode:";

    public static readonly Selector SetVertexBuffer_Offset_AtIndex = "setVertexBuffer:offset:atIndex:";

    public static readonly Selector SetVertexBuffer_Offset_AttributeStride_AtIndex = "setVertexBuffer:offset:attributeStride:atIndex:";
}
