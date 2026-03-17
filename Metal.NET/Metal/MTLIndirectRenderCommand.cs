namespace Metal.NET;

/// <summary>
/// A render command in an indirect command buffer.
/// </summary>
public class MTLIndirectRenderCommand(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIndirectRenderCommand>
{
    #region INativeObject
    public static new MTLIndirectRenderCommand Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectRenderCommand New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Setting command arguments - Methods

    /// <summary>
    /// Sets the render pipeline state for the command.
    /// </summary>
    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetRenderPipelineState, pipelineState.NativePtr);
    }

    /// <summary>
    /// Sets a vertex buffer argument for the command.
    /// </summary>
    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetVertexBuffer, buffer.NativePtr, offset, stride, index);
    }

    /// <summary>
    /// Sets a vertex buffer argument for the command.
    /// </summary>
    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetVertexBufferoffsetatIndex, buffer.NativePtr, offset, index);
    }

    /// <summary>
    /// Sets a fragment buffer argument for the command.
    /// </summary>
    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }
    #endregion

    #region Encoding a drawing command - Methods

    /// <summary>
    /// Encodes a command to render a number of instances of primitives using vertex data in contiguous array elements, starting from the base instance.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    /// <summary>
    /// Encodes a command to render a number of instances of primitives using an index list specified in a buffer, starting from the base vertex of the base instance.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    /// <summary>
    /// Encodes a command to render a number of instances of tessellated patches.
    /// </summary>
    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    /// <summary>
    /// Encodes a command to render a number of instances of tessellated patches, using a control point index buffer.
    /// </summary>
    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }
    #endregion

    #region Resetting a command - Methods

    /// <summary>
    /// Resets the command to its default state.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.Reset);
    }
    #endregion

    #region Instance Methods - Methods

    public void ClearBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.ClearBarrier);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void SetBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetBarrier);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetCullMode, (nuint)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetTriangleFillMode, (nuint)fillMode);
    }
    #endregion
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

    public static readonly Selector SetVertexBuffer = "setVertexBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetVertexBufferoffsetatIndex = "setVertexBuffer:offset:atIndex:";
}
