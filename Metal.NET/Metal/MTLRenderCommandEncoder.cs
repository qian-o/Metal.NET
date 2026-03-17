namespace Metal.NET;

/// <summary>
/// Encodes configuration and draw commands for a single render pass into a command buffer.
/// </summary>
public class MTLRenderCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLRenderCommandEncoder>
{
    #region INativeObject
    public static new MTLRenderCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Drawing with tile shaders - Properties

    /// <summary>
    /// The width of the tiles, in pixels, for the render command encoder.
    /// </summary>
    public nuint TileWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderBindings.TileWidth);
    }

    /// <summary>
    /// The height of the tiles, in pixels, for the render command encoder.
    /// </summary>
    public nuint TileHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderBindings.TileHeight);
    }
    #endregion

    #region Drawing with vertices - Methods

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesvertexStartvertexCount, (nuint)primitiveType, vertexStart, vertexCount);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesvertexStartvertexCountinstanceCountbaseInstance, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive.
    /// </summary>
    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitivesindirectBufferindirectBufferOffset, (nuint)primitiveType, indirectBuffer.NativePtr, indirectBufferOffset);
    }
    #endregion

    #region Drawing with indexed vertices - Methods

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive with indexed vertices.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive with indexed vertices.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffset, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive with indexed vertices.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCountbaseVertexbaseInstance, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    /// <summary>
    /// Encodes a draw command that renders an instance of a geometric primitive with indexed vertices.
    /// </summary>
    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitivesindexTypeindexBufferindexBufferOffsetindirectBufferindirectBufferOffset, (nuint)primitiveType, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }
    #endregion

    #region Drawing with meshes - Methods

    /// <summary>
    /// Encodes a draw command that invokes a mesh shader and, optionally, an object shader with a grid of threads.
    /// </summary>
    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    /// <summary>
    /// Encodes a draw command that invokes a mesh shader and, optionally, an object shader with a grid of threadgroups.
    /// </summary>
    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    /// <summary>
    /// Encodes a draw command that invokes a mesh shader and, optionally, an object shader with a grid of threadgroups.
    /// </summary>
    public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }
    #endregion

    #region Drawing with tessellation patches - Methods

    /// <summary>
    /// Encodes a draw command that renders multiple instances of tessellated patches.
    /// </summary>
    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance);
    }

    /// <summary>
    /// Encodes a draw command that renders multiple instances of tessellated patches.
    /// </summary>
    public void DrawPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatchespatchIndexBufferpatchIndexBufferOffsetindirectBufferindirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }
    #endregion

    #region Drawing with indexed tessellation patches - Methods

    /// <summary>
    /// Encodes a draw command that renders multiple instances of tessellated patches with a control point index buffer.
    /// </summary>
    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance);
    }

    /// <summary>
    /// Encodes a draw command that renders multiple instances of tessellated patches with a control point index buffer.
    /// </summary>
    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatchespatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetindirectBufferindirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }
    #endregion

    #region Drawing with tile shaders - Methods

    /// <summary>
    /// Encodes a command that invokes GPU functions from the encoder’s current tile render pipeline state.
    /// </summary>
    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DispatchThreadsPerTile, threadsPerTile);
    }
    #endregion

    #region Preventing resource access conflicts - Methods

    /// <summary>
    /// Encodes a command that instructs the GPU to pause before starting one or more stages of the render pass until a pass updates a fence.
    /// </summary>
    public void WaitForFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.WaitForFence, fence.NativePtr, (nuint)stages);
    }

    /// <summary>
    /// Encodes a command that instructs the GPU to update a fence after one or more stages, which can unblock other passes waiting for the fence.
    /// </summary>
    public void UpdateFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UpdateFence, fence.NativePtr, (nuint)stages);
    }

    /// <summary>
    /// Creates a memory barrier that enforces the order of write and read operations for specific resources.
    /// </summary>
    public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrier, (nuint)scope, (nuint)after, (nuint)before);
    }

    /// <summary>
    /// Creates a memory barrier that enforces the order of write and read operations for specific resources.
    /// </summary>
    public unsafe void MemoryBarrier(MTLResource[] resources, MTLRenderStages after, MTLRenderStages before)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrierWithResourcescountafterStagesbeforeStages, (nint)pResources, (nuint)resources.Length, (nuint)after, (nuint)before);
    }
    #endregion

    #region Running commands from indirect command buffers - Methods

    /// <summary>
    /// Encodes a command that runs a range of commands from an indirect command buffer (ICB).
    /// </summary>
    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    /// <summary>
    /// Encodes a command that runs a range of commands from an indirect command buffer (ICB).
    /// </summary>
    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBufferwithRange, indirectCommandBuffer.NativePtr, executionRange);
    }
    #endregion

    #region Sampling counters - Methods

    /// <summary>
    /// Encodes a command that samples hardware counters during the render pass and stores the data into a counter sample buffer.
    /// </summary>
    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, barrier);
    }
    #endregion

    #region Configuring pipeline state - Methods

    /// <summary>
    /// Configures the encoder with a render or tile pipeline state that applies to your subsequent draw commands.
    /// </summary>
    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetRenderPipelineState, pipelineState.NativePtr);
    }
    #endregion

    #region Configuring the actions for attachments - Methods

    /// <summary>
    /// Configures the store action for a color attachment.
    /// </summary>
    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    /// <summary>
    /// Configures the store action options for a color attachment.
    /// </summary>
    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    /// <summary>
    /// Configures the store action for the depth attachment.
    /// </summary>
    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    /// <summary>
    /// Configures the store action options for the depth attachment.
    /// </summary>
    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    /// <summary>
    /// Configures the store action for the stencil attachment.
    /// </summary>
    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    /// <summary>
    /// Configures the store action options for the stencil attachment.
    /// </summary>
    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }
    #endregion

    #region Configuring blend behavior - Methods

    /// <summary>
    /// Configures each pixel component value, including alpha, for the render pipeline’s constant blend color.
    /// </summary>
    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetBlendColor, red, green, blue, alpha);
    }

    /// <summary>
    /// Sets the mapping from logical shader color output to physical render pass color attachments.
    /// </summary>
    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorAttachmentMap, mapping.NativePtr);
    }
    #endregion

    #region Configuring rendering behavior - Methods

    /// <summary>
    /// Configures how subsequent draw commands rasterize triangle and triangle strip primitives.
    /// </summary>
    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTriangleFillMode, (nuint)fillMode);
    }

    /// <summary>
    /// Configures which face of a primitive, such as a triangle, is the front.
    /// </summary>
    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    /// <summary>
    /// Configures how the render pipeline determines which primitives to remove.
    /// </summary>
    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetCullMode, (nuint)cullMode);
    }
    #endregion

    #region Configuring depth and stencil behavior - Methods

    /// <summary>
    /// Configures the combined depth and stencil state.
    /// </summary>
    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    /// <summary>
    /// Configures the adjustments a render pass applies to depth values from fragment functions by a scaling factor and bias.
    /// </summary>
    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    /// <summary>
    /// Configures how the render pipeline handles fragments outside the near and far planes of the view frustum.
    /// </summary>
    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    /// <summary>
    /// Configures the range for depth bounds testing.
    /// </summary>
    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthTestBounds, minBound, maxBound);
    }

    /// <summary>
    /// Configures the same comparison value for front- and back-facing primitives.
    /// </summary>
    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilReferenceValue, referenceValue);
    }

    /// <summary>
    /// Configures different comparison values for front- and back-facing primitives.
    /// </summary>
    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilReferenceValues, frontReferenceValue, backReferenceValue);
    }
    #endregion

    #region Configuring viewport and scissor behavior - Methods

    /// <summary>
    /// Configures the render pipeline with a viewport that applies a transformation and a clipping rectangle.
    /// </summary>
    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewport, viewport);
    }

    /// <summary>
    /// Configures the render pipeline with multiple viewports that apply transformations and clipping rectangles.
    /// </summary>
    public unsafe void SetViewports(MTLViewport[] viewports)
    {
        fixed (MTLViewport* pViewports = viewports)
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewports, (nint)pViewports, (nuint)viewports.Length);
        }
    }

    /// <summary>
    /// Configures a rectangle for the fragment scissor test.
    /// </summary>
    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRect, rect);
    }

    /// <summary>
    /// Configures multiple rectangles for the fragment scissor test.
    /// </summary>
    public unsafe void SetScissorRects(MTLScissorRect[] scissorRects)
    {
        fixed (MTLScissorRect* pScissorRects = scissorRects)
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRects, (nint)pScissorRects, (nuint)scissorRects.Length);
        }
    }
    #endregion

    #region Configuring visibility testing - Methods

    /// <summary>
    /// Configures which visibility test the GPU runs and the destination for any results it generates.
    /// </summary>
    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVisibilityResultMode, (nuint)mode, offset);
    }
    #endregion

    #region Configuring vertex amplification - Methods

    /// <summary>
    /// Configures the number of output vertices the render pipeline produces for each input vertex, optionally with render target and viewport offsets.
    /// </summary>
    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAmplificationCount, count, viewMappings);
    }
    #endregion

    #region Configuring tessellation factors - Methods

    /// <summary>
    /// Configures the scale factor for per-patch tessellation factors.
    /// </summary>
    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorScale, scale);
    }

    /// <summary>
    /// Configures the per-patch tessellation factors for any subsequent patch-drawing commands.
    /// </summary>
    public void SetTessellationFactorBuffer(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorBuffer, buffer.NativePtr, offset, instanceStride);
    }
    #endregion

    #region Configuring persistent threadgroup memory - Methods

    /// <summary>
    /// Configures the size of a threadgroup memory buffer for an entry in the object argument table.
    /// </summary>
    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    /// <summary>
    /// Configures the size of a threadgroup memory buffer for an entry in the fragment or tile shader argument table.
    /// </summary>
    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetThreadgroupMemoryLength, length, offset, index);
    }
    #endregion

    #region Assigning buffers for object shaders - Methods

    /// <summary>
    /// Assigns a buffer to an entry in the object shader argument table.
    /// </summary>
    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    /// <summary>
    /// Creates a buffer from bytes and assigns it to an entry in the object shader argument table.
    /// </summary>
    public void SetObjectBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBytes, bytes, length, index);
    }

    /// <summary>
    /// Updates an entry in the object shader argument table with a new location within the entry’s current buffer.
    /// </summary>
    public void SetObjectBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBufferOffset, offset, index);
    }
    #endregion

    #region Assigning textures for object shaders - Methods

    /// <summary>
    /// Assigns a texture to an entry in the object shader argument table.
    /// </summary>
    public void SetObjectTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectTexture, texture.NativePtr, index);
    }
    #endregion

    #region Assigning sampler states for object shaders - Methods

    /// <summary>
    /// Assigns a sampler state to an entry in the object shader argument table.
    /// </summary>
    public void SetObjectSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerState, sampler.NativePtr, index);
    }

    /// <summary>
    /// Assigns a sampler state to an entry in the object shader argument table.
    /// </summary>
    public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerStatelodMinClamplodMaxClampatIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }
    #endregion

    #region Assigning buffers for mesh shaders - Methods

    /// <summary>
    /// Assigns a buffer to an entry in the mesh shader argument table.
    /// </summary>
    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    /// <summary>
    /// Creates a buffer from bytes and assigns it to an entry in the mesh shader argument table.
    /// </summary>
    public void SetMeshBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBytes, bytes, length, index);
    }

    /// <summary>
    /// Updates an entry in the mesh shader argument table with a new location within the entry’s current buffer.
    /// </summary>
    public void SetMeshBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBufferOffset, offset, index);
    }
    #endregion

    #region Assigning textures for mesh shaders - Methods

    /// <summary>
    /// Assigns a texture to an entry in the mesh shader argument table.
    /// </summary>
    public void SetMeshTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshTexture, texture.NativePtr, index);
    }
    #endregion

    #region Assigning sampler states for mesh shaders - Methods

    /// <summary>
    /// Assigns a sampler state to an entry in the mesh shader argument table.
    /// </summary>
    public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    /// <summary>
    /// Assigns a sampler state to an entry in the mesh shader argument table.
    /// </summary>
    public void SetMeshSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerStateatIndex, sampler.NativePtr, index);
    }
    #endregion

    #region Assigning buffers - Methods

    /// <summary>
    /// Assigns a buffer to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffer, buffer.NativePtr, offset, stride, index);
    }

    /// <summary>
    /// Assigns a buffer to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferoffsetatIndex, buffer.NativePtr, offset, index);
    }

    /// <summary>
    /// Creates a buffer from bytes and assigns it to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytes, bytes, length, stride, index);
    }

    /// <summary>
    /// Creates a buffer from bytes and assigns it to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexByteslengthatIndex, bytes, length, index);
    }

    /// <summary>
    /// Updates an entry in the vertex shader argument table with a new location within the entry’s current buffer.
    /// </summary>
    public void SetVertexBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffset, offset, stride, index);
    }

    /// <summary>
    /// Updates an entry in the vertex shader argument table with a new location within the entry’s current buffer.
    /// </summary>
    public void SetVertexBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffsetatIndex, offset, index);
    }

    /// <summary>
    /// Assigns a buffer to an entry in the fragment shader argument table.
    /// </summary>
    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }

    /// <summary>
    /// Creates a buffer from bytes and assigns it to an entry in the fragment shader argument table.
    /// </summary>
    public void SetFragmentBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBytes, bytes, length, index);
    }

    /// <summary>
    /// Updates an entry in the fragment shader argument table with a new location within the entry’s current buffer.
    /// </summary>
    public void SetFragmentBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBufferOffset, offset, index);
    }

    /// <summary>
    /// Assigns a buffer to an entry in the tile shader argument table.
    /// </summary>
    public void SetTileBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBuffer, buffer.NativePtr, offset, index);
    }

    /// <summary>
    /// Creates a buffer from bytes and assigns it to an entry in the tile shader argument table.
    /// </summary>
    public void SetTileBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBytes, bytes, length, index);
    }

    /// <summary>
    /// Updates an entry in the tile shader argument table with a new location within the entry’s current buffer.
    /// </summary>
    public void SetTileBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBufferOffset, offset, index);
    }
    #endregion

    #region Assigning textures - Methods

    /// <summary>
    /// Assigns a texture to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexTexture, texture.NativePtr, index);
    }

    /// <summary>
    /// Assigns a texture to an entry in the fragment shader argument table.
    /// </summary>
    public void SetFragmentTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentTexture, texture.NativePtr, index);
    }

    /// <summary>
    /// Assigns a texture to an entry in the tile shader argument table.
    /// </summary>
    public void SetTileTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileTexture, texture.NativePtr, index);
    }
    #endregion

    #region Assigning sampler states - Methods

    /// <summary>
    /// Assigns a sampler state to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    /// <summary>
    /// Assigns a sampler state to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerStateatIndex, sampler.NativePtr, index);
    }

    /// <summary>
    /// Assigns a sampler state to an entry in the fragment shader argument table.
    /// </summary>
    public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    /// <summary>
    /// Assigns a sampler state to an entry in the fragment shader argument table.
    /// </summary>
    public void SetFragmentSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerStateatIndex, sampler.NativePtr, index);
    }

    /// <summary>
    /// Assigns a sampler state to an entry in the tile shader argument table.
    /// </summary>
    public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    /// <summary>
    /// Assigns a sampler state to an entry in the tile shader argument table.
    /// </summary>
    public void SetTileSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerStateatIndex, sampler.NativePtr, index);
    }
    #endregion

    #region Assigning acceleration structures - Methods

    /// <summary>
    /// Assigns an acceleration structure to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    /// <summary>
    /// Assigns an acceleration structure to an entry in the fragment shader argument table.
    /// </summary>
    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    /// <summary>
    /// Assigns an acceleration structure to an entry in the tile shader argument table.
    /// </summary>
    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }
    #endregion

    #region Assigning visible function tables - Methods

    /// <summary>
    /// Assigns a visible function table to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    /// <summary>
    /// Assigns a visible function table to an entry in the fragment shader argument table.
    /// </summary>
    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }

    /// <summary>
    /// Assigns a visible function table to an entry in the tile shader argument table.
    /// </summary>
    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }
    #endregion

    #region Assigning intersection function tables - Methods

    /// <summary>
    /// Assigns an intersection function table to an entry in the vertex shader argument table.
    /// </summary>
    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    /// <summary>
    /// Assigns an intersection function table to an entry in the fragment shader argument table.
    /// </summary>
    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    /// <summary>
    /// Assigns an intersection function table to an entry in the tile shader argument table.
    /// </summary>
    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }
    #endregion

    #region Loading individual resources for argument buffers - Methods

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to a resource.
    /// </summary>
    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to a resource.
    /// </summary>
    public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResourceusagestages, resource.NativePtr, (nuint)usage, (nuint)stages);
    }

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to multiple resources.
    /// </summary>
    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResources, (nint)pResources, (nuint)resources.Length, (nuint)usage);
    }

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to multiple resources.
    /// </summary>
    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage, MTLRenderStages stages)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResourcescountusagestages, (nint)pResources, (nuint)resources.Length, (nuint)usage, (nuint)stages);
    }
    #endregion

    #region Loading heaps and the resources they contain for argument buffers - Methods

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to the resources you allocate from a heap.
    /// </summary>
    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to the resources you allocate from a heap.
    /// </summary>
    public void UseHeap(MTLHeap heap, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeapstages, heap.NativePtr, (nuint)stages);
    }

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to the resources you allocate from multiple heaps.
    /// </summary>
    public unsafe void UseHeaps(MTLHeap[] heaps)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeaps, (nint)pHeaps, (nuint)heaps.Length);
    }

    /// <summary>
    /// Ensures the shaders in the render pass’s subsequent draw commands have access to the resources you allocate from multiple heaps.
    /// </summary>
    public unsafe void UseHeaps(MTLHeap[] heaps, MTLRenderStages stages)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeapscountstages, (nint)pHeaps, (nuint)heaps.Length, (nuint)stages);
    }
    #endregion

    #region Deprecated methods - Methods

    /// <summary>
    /// Adds a barrier, which forces any texture read operations to wait until write operations to the same texture finish.
    /// </summary>
    [Obsolete("Call memoryBarrier(scope:after:before:) instead.")]
    public void TextureBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.TextureBarrier);
    }
    #endregion
}

file static class MTLRenderCommandEncoderBindings
{
    public static readonly Selector DispatchThreadsPerTile = "dispatchThreadsPerTile:";

    public static readonly Selector DrawIndexedPatches = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawIndexedPatchespatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetindirectBufferindirectBufferOffset = "drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawIndexedPrimitives = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:";

    public static readonly Selector DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffset = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:";

    public static readonly Selector DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCountbaseVertexbaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";

    public static readonly Selector DrawIndexedPrimitivesindexTypeindexBufferindexBufferOffsetindirectBufferindirectBufferOffset = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawMeshThreadgroups = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPatches = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawPatchespatchIndexBufferpatchIndexBufferOffsetindirectBufferindirectBufferOffset = "drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawPrimitives = "drawPrimitives:vertexStart:vertexCount:instanceCount:";

    public static readonly Selector DrawPrimitivesindirectBufferindirectBufferOffset = "drawPrimitives:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawPrimitivesvertexStartvertexCount = "drawPrimitives:vertexStart:vertexCount:";

    public static readonly Selector DrawPrimitivesvertexStartvertexCountinstanceCountbaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector ExecuteCommandsInBufferwithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector MemoryBarrier = "memoryBarrierWithScope:afterStages:beforeStages:";

    public static readonly Selector MemoryBarrierWithResourcescountafterStagesbeforeStages = "memoryBarrierWithResources:count:afterStages:beforeStages:";

    public static readonly Selector SampleCountersInBuffer = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetBlendColor = "setBlendColorRed:green:blue:alpha:";

    public static readonly Selector SetColorAttachmentMap = "setColorAttachmentMap:";

    public static readonly Selector SetColorStoreAction = "setColorStoreAction:atIndex:";

    public static readonly Selector SetColorStoreActionOptions = "setColorStoreActionOptions:atIndex:";

    public static readonly Selector SetCullMode = "setCullMode:";

    public static readonly Selector SetDepthBias = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthClipMode = "setDepthClipMode:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:";

    public static readonly Selector SetDepthStoreAction = "setDepthStoreAction:";

    public static readonly Selector SetDepthStoreActionOptions = "setDepthStoreActionOptions:";

    public static readonly Selector SetDepthTestBounds = "setDepthTestMinBound:maxBound:";

    public static readonly Selector SetFragmentAccelerationStructure = "setFragmentAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetFragmentBuffer = "setFragmentBuffer:offset:atIndex:";

    public static readonly Selector SetFragmentBufferOffset = "setFragmentBufferOffset:atIndex:";

    public static readonly Selector SetFragmentBytes = "setFragmentBytes:length:atIndex:";

    public static readonly Selector SetFragmentIntersectionFunctionTable = "setFragmentIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetFragmentSamplerState = "setFragmentSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetFragmentSamplerStateatIndex = "setFragmentSamplerState:atIndex:";

    public static readonly Selector SetFragmentTexture = "setFragmentTexture:atIndex:";

    public static readonly Selector SetFragmentVisibleFunctionTable = "setFragmentVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetFrontFacingWinding = "setFrontFacingWinding:";

    public static readonly Selector SetMeshBuffer = "setMeshBuffer:offset:atIndex:";

    public static readonly Selector SetMeshBufferOffset = "setMeshBufferOffset:atIndex:";

    public static readonly Selector SetMeshBytes = "setMeshBytes:length:atIndex:";

    public static readonly Selector SetMeshSamplerState = "setMeshSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetMeshSamplerStateatIndex = "setMeshSamplerState:atIndex:";

    public static readonly Selector SetMeshTexture = "setMeshTexture:atIndex:";

    public static readonly Selector SetObjectBuffer = "setObjectBuffer:offset:atIndex:";

    public static readonly Selector SetObjectBufferOffset = "setObjectBufferOffset:atIndex:";

    public static readonly Selector SetObjectBytes = "setObjectBytes:length:atIndex:";

    public static readonly Selector SetObjectSamplerState = "setObjectSamplerState:atIndex:";

    public static readonly Selector SetObjectSamplerStatelodMinClamplodMaxClampatIndex = "setObjectSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetObjectTexture = "setObjectTexture:atIndex:";

    public static readonly Selector SetObjectThreadgroupMemoryLength = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:";

    public static readonly Selector SetScissorRect = "setScissorRect:";

    public static readonly Selector SetScissorRects = "setScissorRects:count:";

    public static readonly Selector SetStencilReferenceValue = "setStencilReferenceValue:";

    public static readonly Selector SetStencilReferenceValues = "setStencilFrontReferenceValue:backReferenceValue:";

    public static readonly Selector SetStencilStoreAction = "setStencilStoreAction:";

    public static readonly Selector SetStencilStoreActionOptions = "setStencilStoreActionOptions:";

    public static readonly Selector SetTessellationFactorBuffer = "setTessellationFactorBuffer:offset:instanceStride:";

    public static readonly Selector SetTessellationFactorScale = "setTessellationFactorScale:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:offset:atIndex:";

    public static readonly Selector SetTileAccelerationStructure = "setTileAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetTileBuffer = "setTileBuffer:offset:atIndex:";

    public static readonly Selector SetTileBufferOffset = "setTileBufferOffset:atIndex:";

    public static readonly Selector SetTileBytes = "setTileBytes:length:atIndex:";

    public static readonly Selector SetTileIntersectionFunctionTable = "setTileIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetTileSamplerState = "setTileSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetTileSamplerStateatIndex = "setTileSamplerState:atIndex:";

    public static readonly Selector SetTileTexture = "setTileTexture:atIndex:";

    public static readonly Selector SetTileVisibleFunctionTable = "setTileVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetTriangleFillMode = "setTriangleFillMode:";

    public static readonly Selector SetVertexAccelerationStructure = "setVertexAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetVertexAmplificationCount = "setVertexAmplificationCount:viewMappings:";

    public static readonly Selector SetVertexBuffer = "setVertexBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetVertexBufferOffset = "setVertexBufferOffset:attributeStride:atIndex:";

    public static readonly Selector SetVertexBufferoffsetatIndex = "setVertexBuffer:offset:atIndex:";

    public static readonly Selector SetVertexBufferOffsetatIndex = "setVertexBufferOffset:atIndex:";

    public static readonly Selector SetVertexBytes = "setVertexBytes:length:attributeStride:atIndex:";

    public static readonly Selector SetVertexByteslengthatIndex = "setVertexBytes:length:atIndex:";

    public static readonly Selector SetVertexIntersectionFunctionTable = "setVertexIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetVertexSamplerState = "setVertexSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetVertexSamplerStateatIndex = "setVertexSamplerState:atIndex:";

    public static readonly Selector SetVertexTexture = "setVertexTexture:atIndex:";

    public static readonly Selector SetVertexVisibleFunctionTable = "setVertexVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetViewport = "setViewport:";

    public static readonly Selector SetViewports = "setViewports:count:";

    public static readonly Selector SetVisibilityResultMode = "setVisibilityResultMode:offset:";

    public static readonly Selector TextureBarrier = "textureBarrier";

    public static readonly Selector TileHeight = "tileHeight";

    public static readonly Selector TileWidth = "tileWidth";

    public static readonly Selector UpdateFence = "updateFence:afterStages:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeaps = "useHeaps:count:";

    public static readonly Selector UseHeapscountstages = "useHeaps:count:stages:";

    public static readonly Selector UseHeapstages = "useHeap:stages:";

    public static readonly Selector UseResource = "useResource:usage:";

    public static readonly Selector UseResources = "useResources:count:usage:";

    public static readonly Selector UseResourcescountusagestages = "useResources:count:usage:stages:";

    public static readonly Selector UseResourceusagestages = "useResource:usage:stages:";

    public static readonly Selector WaitForFence = "waitForFence:beforeStages:";
}
