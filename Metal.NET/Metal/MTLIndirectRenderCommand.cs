namespace Metal.NET;

public class MTLIndirectRenderCommand(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIndirectRenderCommand>
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

    public void SetVertexBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetVertexBuffer, buffer.NativePtr, offset, index);
    }

    public void SetFragmentBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }

    public void SetVertexBufferOffsetAttributeStrideAtIndex(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetVertexBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void DrawPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetInstanceCountBaseInstanceTessellationFactorBufferTessellationFactorBufferOffsetTessellationFactorBufferInstanceStride(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    public void DrawIndexedPatchesPatchStartPatchCountPatchIndexBufferPatchIndexBufferOffsetControlPointIndexBufferControlPointIndexBufferOffsetInstanceCountBaseInstanceTessellationFactorBufferTessellationFactorBufferOffsetTessellationFactorBufferInstanceStride(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    public void DrawPrimitivesVertexStartVertexCountInstanceCountBaseInstance(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawIndexedPrimitivesIndexCountIndexTypeIndexBufferIndexBufferOffsetInstanceCountBaseVertexBaseInstance(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void SetObjectThreadgroupMemoryLengthAtIndex(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetObjectBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    public void SetMeshBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    public void DrawMeshThreadgroupsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadsThreadsPerObjectThreadgroupThreadsPerMeshThreadgroup(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
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

    public void SetDepthBiasSlopeScaleClamp(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetCullMode, (nuint)cullMode);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
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

    public static readonly Selector DrawIndexedPatches = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:";

    public static readonly Selector DrawIndexedPrimitives = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";

    public static readonly Selector DrawMeshThreadgroups = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPatches = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:";

    public static readonly Selector DrawPrimitives = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBarrier = "setBarrier";

    public static readonly Selector SetCullMode = "setCullMode:";

    public static readonly Selector SetDepthBias = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthClipMode = "setDepthClipMode:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:";

    public static readonly Selector SetFragmentBuffer = "setFragmentBuffer:offset:atIndex:";

    public static readonly Selector SetFrontFacingWinding = "setFrontFacingWinding:";

    public static readonly Selector SetMeshBuffer = "setMeshBuffer:offset:atIndex:";

    public static readonly Selector SetObjectBuffer = "setObjectBuffer:offset:atIndex:";

    public static readonly Selector SetObjectThreadgroupMemoryLength = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:";

    public static readonly Selector SetTriangleFillMode = "setTriangleFillMode:";

    public static readonly Selector SetVertexBuffer = "setVertexBuffer:offset:atIndex:";

    public static readonly Selector SetVertexBufferOffsetAttributeStrideAtIndex = "setVertexBuffer:offset:attributeStride:atIndex:";
}
