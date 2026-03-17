namespace Metal.NET;

/// <summary>
/// Encodes configuration and draw commands for a single render pass into a command buffer.
/// </summary>
public class MTL4RenderCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTL4CommandEncoder(nativePtr, ownership), INativeObject<MTL4RenderCommandEncoder>
{
    #region INativeObject
    public static new MTL4RenderCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Drawing with tile shaders - Properties

    /// <summary>
    /// Sets the width of a tile for this render pass.
    /// </summary>
    public nuint TileWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderBindings.TileWidth);
    }

    /// <summary>
    /// Sets the height of a tile for this render pass.
    /// </summary>
    public nuint TileHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderBindings.TileHeight);
    }
    #endregion

    #region Configuring pipeline state - Methods

    /// <summary>
    /// Configures this encoder with a render pipeline state that applies to your subsequent draw commands.
    /// </summary>
    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetRenderPipelineState, pipelineState.NativePtr);
    }
    #endregion

    #region Configuring the actions for attachments - Methods

    /// <summary>
    /// Configures the store action for a color attachment.
    /// </summary>
    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    /// <summary>
    /// Configures the store action for the depth attachment.
    /// </summary>
    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    /// <summary>
    /// Configures the store action for the stencil attachment.
    /// </summary>
    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }
    #endregion

    #region Configuring blend behavior - Methods

    /// <summary>
    /// Configures each pixel component value, including alpha, for the render pipeline’s constant blend color.
    /// </summary>
    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetBlendColor, red, green, blue, alpha);
    }

    /// <summary>
    /// Sets the mapping from logical shader color output to physical render pass color attachments.
    /// </summary>
    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetColorAttachmentMap, mapping.NativePtr);
    }
    #endregion

    #region Configuring rendering behavior - Methods

    /// <summary>
    /// Configures how subsequent draw commands rasterize triangle and triangle strip primitives.
    /// </summary>
    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetTriangleFillMode, (nuint)fillMode);
    }

    /// <summary>
    /// Configures the vertex winding order that determines which face of a geometric primitive is the front one.
    /// </summary>
    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    /// <summary>
    /// Controls whether Metal culls front facing primitives, back facing primitives, or culls no primitives at all.
    /// </summary>
    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetCullMode, (nuint)cullMode);
    }
    #endregion

    #region Configuring depth and stencil behavior - Methods

    /// <summary>
    /// Configures this encoder with a depth stencil state that applies to your subsequent draw commands.
    /// </summary>
    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    /// <summary>
    /// Configures the adjustments a render pass applies to depth values from fragment shader functions by a scaling factor and bias.
    /// </summary>
    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    /// <summary>
    /// Controls the behavior for fragments outside of the near or far planes.
    /// </summary>
    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    /// <summary>
    /// Configures the range for depth bounds testing.
    /// </summary>
    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthTestBounds, minBound, maxBound);
    }

    /// <summary>
    /// Configures this encoder with a reference value for stencil testing.
    /// </summary>
    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilReferenceValue, referenceValue);
    }
    #endregion

    #region Configuring viewport and scissor behavior - Methods

    /// <summary>
    /// Sets the viewport which that transforms vertices from normalized device coordinates to window coordinates.
    /// </summary>
    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewport, viewport);
    }

    /// <summary>
    /// Sets an array of viewports to transform vertices from normalized device coordinates to window coordinates.
    /// </summary>
    public unsafe void SetViewports(MTLViewport[] viewports)
    {
        fixed (MTLViewport* pViewports = viewports)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewports, (nint)pViewports, (nuint)viewports.Length);
        }
    }

    /// <summary>
    /// Sets a scissor rectangle to discard fragments outside a specific area.
    /// </summary>
    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetScissorRect, rect);
    }

    /// <summary>
    /// Sets an array of scissor rectangles for a fragment scissor test.
    /// </summary>
    public unsafe void SetScissorRects(MTLScissorRect[] scissorRects)
    {
        fixed (MTLScissorRect* pScissorRects = scissorRects)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetScissorRects, (nint)pScissorRects, (nuint)scissorRects.Length);
        }
    }
    #endregion

    #region Configuring visibility testing - Methods

    /// <summary>
    /// Configures a visibility test for Metal to run, and the destination for any results it generates.
    /// </summary>
    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetVisibilityResultMode, (nuint)mode, offset);
    }
    #endregion

    #region Configuring vertex amplification - Methods

    /// <summary>
    /// Sets the vertex amplification count and its view mapping for each amplification ID.
    /// </summary>
    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetVertexAmplificationCount, count, viewMappings);
    }
    #endregion

    #region Configuring persistent threadgroup memory - Methods

    /// <summary>
    /// Configures the size of a threadgroup memory buffer for a threadgroup argument in the object shader function.
    /// </summary>
    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    /// <summary>
    /// Configures the size of a threadgroup memory buffer for a threadgroup argument in the fragment and tile shader functions.
    /// </summary>
    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetThreadgroupMemoryLength, length, offset, index);
    }
    #endregion

    #region Binding argument tables - Methods

    /// <summary>
    /// Associates an argument table with a set of render stages.
    /// </summary>
    public void SetArgumentTable(MTL4ArgumentTable argumentTable, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr, (nuint)stages);
    }
    #endregion

    #region Drawing with vertices - Methods

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint indirectBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitivesindirectBuffer, (nuint)primitiveType, indirectBuffer);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitivesvertexStartvertexCountinstanceCountbaseInstance, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitivesvertexStartvertexCountinstanceCount, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }
    #endregion

    #region Drawing with indexed vertices - Methods

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive with indexed vertices.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint indirectBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, (nuint)indexType, indexBuffer, indexBufferLength, indirectBuffer);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive with indexed vertices.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCountbaseVertexbaseInstance, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength, instanceCount, baseVertex, baseInstance);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive with indexed vertices.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCount, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength, instanceCount);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive with indexed vertices.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLength, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength);
    }
    #endregion

    #region Drawing with meshes - Methods

    /// <summary>
    /// Encodes a draw command that invokes a mesh shader and, optionally, an object shader with a grid of threads.
    /// </summary>
    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    /// <summary>
    /// Encodes a draw command that invokes a mesh shader and, optionally, an object shader with a grid of threadgroups.
    /// </summary>
    public void DrawMeshThreadgroups(nuint indirectBuffer, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreadgroups, indirectBuffer, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    /// <summary>
    /// Encodes a draw command that invokes a mesh shader and, optionally, an object shader with a grid of threadgroups.
    /// </summary>
    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreadgroupsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }
    #endregion

    #region Drawing with tile shaders - Methods

    /// <summary>
    /// Encodes a command that invokes a tile shader function from the encoder’s current tile render pipeline state.
    /// </summary>
    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DispatchThreadsPerTile, threadsPerTile);
    }
    #endregion

    #region Running commands from indirect command buffers - Methods

    /// <summary>
    /// Encodes a command that runs a range of commands from an indirect command buffer.
    /// </summary>
    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    /// <summary>
    /// Encodes a command that runs a range of commands from an indirect command buffer.
    /// </summary>
    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint indirectRangeBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.ExecuteCommandsInBufferindirectBuffer, indirectCommandBuffer.NativePtr, indirectRangeBuffer);
    }
    #endregion

    #region Sampling counters - Methods

    /// <summary>
    /// Writes a GPU timestamp into the given  at index after stage completes.
    /// </summary>
    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTLRenderStages stage, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.WriteTimestamp, (nint)granularity, (nuint)stage, counterHeap.NativePtr, index);
    }
    #endregion

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilReferenceValues, frontReferenceValue, backReferenceValue);
    }
}

file static class MTL4RenderCommandEncoderBindings
{
    public static readonly Selector DispatchThreadsPerTile = "dispatchThreadsPerTile:";

    public static readonly Selector DrawIndexedPrimitives = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:";

    public static readonly Selector DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLength = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:";

    public static readonly Selector DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCount = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:";

    public static readonly Selector DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCountbaseVertexbaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:baseVertex:baseInstance:";

    public static readonly Selector DrawMeshThreadgroups = "drawMeshThreadgroupsWithIndirectBuffer:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreadgroupsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPrimitives = "drawPrimitives:vertexStart:vertexCount:";

    public static readonly Selector DrawPrimitivesindirectBuffer = "drawPrimitives:indirectBuffer:";

    public static readonly Selector DrawPrimitivesvertexStartvertexCountinstanceCount = "drawPrimitives:vertexStart:vertexCount:instanceCount:";

    public static readonly Selector DrawPrimitivesvertexStartvertexCountinstanceCountbaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:withRange:";

    public static readonly Selector ExecuteCommandsInBufferindirectBuffer = "executeCommandsInBuffer:indirectBuffer:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:atStages:";

    public static readonly Selector SetBlendColor = "setBlendColorRed:green:blue:alpha:";

    public static readonly Selector SetColorAttachmentMap = "setColorAttachmentMap:";

    public static readonly Selector SetColorStoreAction = "setColorStoreAction:atIndex:";

    public static readonly Selector SetCullMode = "setCullMode:";

    public static readonly Selector SetDepthBias = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthClipMode = "setDepthClipMode:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:";

    public static readonly Selector SetDepthStoreAction = "setDepthStoreAction:";

    public static readonly Selector SetDepthTestBounds = "setDepthTestMinBound:maxBound:";

    public static readonly Selector SetFrontFacingWinding = "setFrontFacingWinding:";

    public static readonly Selector SetObjectThreadgroupMemoryLength = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:";

    public static readonly Selector SetScissorRect = "setScissorRect:";

    public static readonly Selector SetScissorRects = "setScissorRects:count:";

    public static readonly Selector SetStencilReferenceValue = "setStencilReferenceValue:";

    public static readonly Selector SetStencilReferenceValues = "setStencilFrontReferenceValue:backReferenceValue:";

    public static readonly Selector SetStencilStoreAction = "setStencilStoreAction:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:offset:atIndex:";

    public static readonly Selector SetTriangleFillMode = "setTriangleFillMode:";

    public static readonly Selector SetVertexAmplificationCount = "setVertexAmplificationCount:viewMappings:";

    public static readonly Selector SetViewport = "setViewport:";

    public static readonly Selector SetViewports = "setViewports:count:";

    public static readonly Selector SetVisibilityResultMode = "setVisibilityResultMode:offset:";

    public static readonly Selector TileHeight = "tileHeight";

    public static readonly Selector TileWidth = "tileWidth";

    public static readonly Selector WriteTimestamp = "writeTimestampWithGranularity:afterStage:intoHeap:atIndex:";
}
