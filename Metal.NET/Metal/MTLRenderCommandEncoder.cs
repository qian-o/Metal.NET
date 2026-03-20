namespace Metal.NET;

public class MTLRenderCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLRenderCommandEncoder>
{
    #region INativeObject
    public static new MTLRenderCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint TileWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderBindings.TileWidth);
    }

    public nuint TileHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderCommandEncoderBindings.TileHeight);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytes_Length_AtIndex, bytes, length, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetVertexBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffset_AtIndex, offset, index);
    }

    public unsafe void SetVertexBuffers(MTLBuffer[] buffers, nuint[] offsets, NSRange range)
    {
        nint* pBuffers = stackalloc nint[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            pBuffers[i] = buffers[i].NativePtr;
        }

        nuint* pOffsets = stackalloc nuint[offsets.Length];
        for (int i = 0; i < offsets.Length; i++)
        {
            pOffsets[i] = offsets[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffer_Offset_AttributeStride_AtIndex, buffer.NativePtr, offset, stride, index);
    }

    public unsafe void SetVertexBuffers(MTLBuffer[] buffers, nuint[] offsets, nuint[] strides, NSRange range)
    {
        nint* pBuffers = stackalloc nint[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            pBuffers[i] = buffers[i].NativePtr;
        }

        nuint* pOffsets = stackalloc nuint[offsets.Length];
        for (int i = 0; i < offsets.Length; i++)
        {
            pOffsets[i] = offsets[i];
        }

        nuint* pStrides = stackalloc nuint[strides.Length];
        for (int i = 0; i < strides.Length; i++)
        {
            pStrides[i] = strides[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBuffers_Offsets_AttributeStrides_WithRange, (nint)pBuffers, (nint)pOffsets, (nint)pStrides, range);
    }

    public void SetVertexBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBufferOffset_AttributeStride_AtIndex, offset, stride, index);
    }

    public void SetVertexBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexBytes_Length_AttributeStride_AtIndex, bytes, length, stride, index);
    }

    public void SetVertexTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexTexture_AtIndex, texture.NativePtr, index);
    }

    public unsafe void SetVertexTextures(MTLTexture[] textures, NSRange range)
    {
        nint* pTextures = stackalloc nint[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            pTextures[i] = textures[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexTextures_WithRange, (nint)pTextures, range);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public unsafe void SetVertexSamplerStates(MTLSamplerState[] samplers, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerStates_WithRange, (nint)pSamplers, range);
    }

    public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerState_LodMinClamp_LodMaxClamp_AtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public unsafe void SetVertexSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        float* pLodMinClamps = stackalloc float[lodMinClamps.Length];
        for (int i = 0; i < lodMinClamps.Length; i++)
        {
            pLodMinClamps[i] = lodMinClamps[i];
        }

        float* pLodMaxClamps = stackalloc float[lodMaxClamps.Length];
        for (int i = 0; i < lodMaxClamps.Length; i++)
        {
            pLodMaxClamps[i] = lodMaxClamps[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexSamplerStates_LodMinClamps_LodMaxClamps_WithRange, (nint)pSamplers, (nint)pLodMinClamps, (nint)pLodMaxClamps, range);
    }

    public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexVisibleFunctionTable_AtBufferIndex, functionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetVertexVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
    {
        nint* pFunctionTables = stackalloc nint[functionTables.Length];
        for (int i = 0; i < functionTables.Length; i++)
        {
            pFunctionTables[i] = functionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexVisibleFunctionTables_WithBufferRange, (nint)pFunctionTables, range);
    }

    public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexIntersectionFunctionTable_AtBufferIndex, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetVertexIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
    {
        nint* pIntersectionFunctionTables = stackalloc nint[intersectionFunctionTables.Length];
        for (int i = 0; i < intersectionFunctionTables.Length; i++)
        {
            pIntersectionFunctionTables[i] = intersectionFunctionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexIntersectionFunctionTables_WithBufferRange, (nint)pIntersectionFunctionTables, range);
    }

    public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAccelerationStructure_AtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewport, viewport);
    }

    public unsafe void SetViewports(MTLViewport[] viewports)
    {
        fixed (MTLViewport* pViewports = viewports)
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetViewports_Count, (nint)pViewports, (nuint)viewports.Length);
        }
    }

    public void SetFrontFacing(MTLWinding frontFacingWinding)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVertexAmplificationCount_ViewMappings, count, viewMappings);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetCullMode, (nuint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthBias_SlopeScale_Clamp, depthBias, slopeScale, clamp);
    }

    public void SetDepthTestMinBound(float minBound, float maxBound)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthTestMinBound_MaxBound, minBound, maxBound);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRect, rect);
    }

    public unsafe void SetScissorRects(MTLScissorRect[] scissorRects)
    {
        fixed (MTLScissorRect* pScissorRects = scissorRects)
        {
            ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetScissorRects_Count, (nint)pScissorRects, (nuint)scissorRects.Length);
        }
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTriangleFillMode, (nuint)fillMode);
    }

    public void SetFragmentBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBytes_Length_AtIndex, bytes, length, index);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetFragmentBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBufferOffset_AtIndex, offset, index);
    }

    public unsafe void SetFragmentBuffers(MTLBuffer[] buffers, nuint[] offsets, NSRange range)
    {
        nint* pBuffers = stackalloc nint[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            pBuffers[i] = buffers[i].NativePtr;
        }

        nuint* pOffsets = stackalloc nuint[offsets.Length];
        for (int i = 0; i < offsets.Length; i++)
        {
            pOffsets[i] = offsets[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
    }

    public void SetFragmentTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentTexture_AtIndex, texture.NativePtr, index);
    }

    public unsafe void SetFragmentTextures(MTLTexture[] textures, NSRange range)
    {
        nint* pTextures = stackalloc nint[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            pTextures[i] = textures[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentTextures_WithRange, (nint)pTextures, range);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public unsafe void SetFragmentSamplerStates(MTLSamplerState[] samplers, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerStates_WithRange, (nint)pSamplers, range);
    }

    public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerState_LodMinClamp_LodMaxClamp_AtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public unsafe void SetFragmentSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        float* pLodMinClamps = stackalloc float[lodMinClamps.Length];
        for (int i = 0; i < lodMinClamps.Length; i++)
        {
            pLodMinClamps[i] = lodMinClamps[i];
        }

        float* pLodMaxClamps = stackalloc float[lodMaxClamps.Length];
        for (int i = 0; i < lodMaxClamps.Length; i++)
        {
            pLodMaxClamps[i] = lodMaxClamps[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentSamplerStates_LodMinClamps_LodMaxClamps_WithRange, (nint)pSamplers, (nint)pLodMinClamps, (nint)pLodMaxClamps, range);
    }

    public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentVisibleFunctionTable_AtBufferIndex, functionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetFragmentVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
    {
        nint* pFunctionTables = stackalloc nint[functionTables.Length];
        for (int i = 0; i < functionTables.Length; i++)
        {
            pFunctionTables[i] = functionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentVisibleFunctionTables_WithBufferRange, (nint)pFunctionTables, range);
    }

    public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentIntersectionFunctionTable_AtBufferIndex, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetFragmentIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
    {
        nint* pIntersectionFunctionTables = stackalloc nint[intersectionFunctionTables.Length];
        for (int i = 0; i < intersectionFunctionTables.Length; i++)
        {
            pIntersectionFunctionTables[i] = intersectionFunctionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentIntersectionFunctionTables_WithBufferRange, (nint)pIntersectionFunctionTables, range);
    }

    public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetFragmentAccelerationStructure_AtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetBlendColorRed_Green_Blue_Alpha, red, green, blue, alpha);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilFrontReferenceValue_BackReferenceValue, frontReferenceValue, backReferenceValue);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetVisibilityResultMode_Offset, (nuint)mode, offset);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreAction_AtIndex, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorStoreActionOptions_AtIndex, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetObjectBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBytes_Length_AtIndex, bytes, length, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetObjectBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBufferOffset_AtIndex, offset, index);
    }

    public unsafe void SetObjectBuffers(MTLBuffer[] buffers, nuint[] offsets, NSRange range)
    {
        nint* pBuffers = stackalloc nint[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            pBuffers[i] = buffers[i].NativePtr;
        }

        nuint* pOffsets = stackalloc nuint[offsets.Length];
        for (int i = 0; i < offsets.Length; i++)
        {
            pOffsets[i] = offsets[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
    }

    public void SetObjectTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectTexture_AtIndex, texture.NativePtr, index);
    }

    public unsafe void SetObjectTextures(MTLTexture[] textures, NSRange range)
    {
        nint* pTextures = stackalloc nint[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            pTextures[i] = textures[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectTextures_WithRange, (nint)pTextures, range);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public unsafe void SetObjectSamplerStates(MTLSamplerState[] samplers, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerStates_WithRange, (nint)pSamplers, range);
    }

    public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerState_LodMinClamp_LodMaxClamp_AtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public unsafe void SetObjectSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        float* pLodMinClamps = stackalloc float[lodMinClamps.Length];
        for (int i = 0; i < lodMinClamps.Length; i++)
        {
            pLodMinClamps[i] = lodMinClamps[i];
        }

        float* pLodMaxClamps = stackalloc float[lodMaxClamps.Length];
        for (int i = 0; i < lodMaxClamps.Length; i++)
        {
            pLodMaxClamps[i] = lodMaxClamps[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectSamplerStates_LodMinClamps_LodMaxClamps_WithRange, (nint)pSamplers, (nint)pLodMinClamps, (nint)pLodMaxClamps, range);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength_AtIndex, length, index);
    }

    public void SetMeshBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBytes_Length_AtIndex, bytes, length, index);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetMeshBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBufferOffset_AtIndex, offset, index);
    }

    public unsafe void SetMeshBuffers(MTLBuffer[] buffers, nuint[] offsets, NSRange range)
    {
        nint* pBuffers = stackalloc nint[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            pBuffers[i] = buffers[i].NativePtr;
        }

        nuint* pOffsets = stackalloc nuint[offsets.Length];
        for (int i = 0; i < offsets.Length; i++)
        {
            pOffsets[i] = offsets[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
    }

    public void SetMeshTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshTexture_AtIndex, texture.NativePtr, index);
    }

    public unsafe void SetMeshTextures(MTLTexture[] textures, NSRange range)
    {
        nint* pTextures = stackalloc nint[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            pTextures[i] = textures[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshTextures_WithRange, (nint)pTextures, range);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public unsafe void SetMeshSamplerStates(MTLSamplerState[] samplers, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerStates_WithRange, (nint)pSamplers, range);
    }

    public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerState_LodMinClamp_LodMaxClamp_AtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public unsafe void SetMeshSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        float* pLodMinClamps = stackalloc float[lodMinClamps.Length];
        for (int i = 0; i < lodMinClamps.Length; i++)
        {
            pLodMinClamps[i] = lodMinClamps[i];
        }

        float* pLodMaxClamps = stackalloc float[lodMaxClamps.Length];
        for (int i = 0; i < lodMaxClamps.Length; i++)
        {
            pLodMaxClamps[i] = lodMaxClamps[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetMeshSamplerStates_LodMinClamps_LodMaxClamps_WithRange, (nint)pSamplers, (nint)pLodMinClamps, (nint)pLodMaxClamps, range);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroups_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreads_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawMeshThreadgroupsWithIndirectBuffer_IndirectBufferOffset_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives_VertexStart_VertexCount_InstanceCount, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives_VertexStart_VertexCount, (nuint)primitiveType, vertexStart, vertexCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferOffset_InstanceCount, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferOffset, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives_VertexStart_VertexCount_InstanceCount_BaseInstance, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferOffset_InstanceCount_BaseVertex_BaseInstance, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPrimitives_IndirectBuffer_IndirectBufferOffset, (nuint)primitiveType, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPrimitives_IndexType_IndexBuffer_IndexBufferOffset_IndirectBuffer_IndirectBufferOffset, (nuint)primitiveType, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    /// <summary>
    /// Deprecated: Use memoryBarrierWithScope:MTLBarrierScopeRenderTargets instead
    /// </summary>
    [Obsolete("Use memoryBarrierWithScope:MTLBarrierScopeRenderTargets instead")]
    public void TextureBarrier()
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.TextureBarrier);
    }

    public void UpdateFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UpdateFence_AfterStages, fence.NativePtr, (nuint)stages);
    }

    public void WaitForFence(MTLFence fence, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.WaitForFence_BeforeStages, fence.NativePtr, (nuint)stages);
    }

    public void SetTessellationFactorBuffer(MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorBuffer_Offset_InstanceStride, buffer.NativePtr, offset, instanceStride);
    }

    public void SetTessellationFactorScale(float scale)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTessellationFactorScale, scale);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatches_PatchStart_PatchCount_PatchIndexBuffer_PatchIndexBufferOffset_InstanceCount_BaseInstance, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawPatches_PatchIndexBuffer_PatchIndexBufferOffset_IndirectBuffer_IndirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatches_PatchStart_PatchCount_PatchIndexBuffer_PatchIndexBufferOffset_ControlPointIndexBuffer_ControlPointIndexBufferOffset_InstanceCount_BaseInstance, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DrawIndexedPatches_PatchIndexBuffer_PatchIndexBufferOffset_ControlPointIndexBuffer_ControlPointIndexBufferOffset_IndirectBuffer_IndirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void SetTileBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBytes_Length_AtIndex, bytes, length, index);
    }

    public void SetTileBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetTileBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBufferOffset_AtIndex, offset, index);
    }

    public unsafe void SetTileBuffers(MTLBuffer[] buffers, nuint[] offsets, NSRange range)
    {
        nint* pBuffers = stackalloc nint[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            pBuffers[i] = buffers[i].NativePtr;
        }

        nuint* pOffsets = stackalloc nuint[offsets.Length];
        for (int i = 0; i < offsets.Length; i++)
        {
            pOffsets[i] = offsets[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
    }

    public void SetTileTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileTexture_AtIndex, texture.NativePtr, index);
    }

    public unsafe void SetTileTextures(MTLTexture[] textures, NSRange range)
    {
        nint* pTextures = stackalloc nint[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            pTextures[i] = textures[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileTextures_WithRange, (nint)pTextures, range);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public unsafe void SetTileSamplerStates(MTLSamplerState[] samplers, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerStates_WithRange, (nint)pSamplers, range);
    }

    public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerState_LodMinClamp_LodMaxClamp_AtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public unsafe void SetTileSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        float* pLodMinClamps = stackalloc float[lodMinClamps.Length];
        for (int i = 0; i < lodMinClamps.Length; i++)
        {
            pLodMinClamps[i] = lodMinClamps[i];
        }

        float* pLodMaxClamps = stackalloc float[lodMaxClamps.Length];
        for (int i = 0; i < lodMaxClamps.Length; i++)
        {
            pLodMaxClamps[i] = lodMaxClamps[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileSamplerStates_LodMinClamps_LodMaxClamps_WithRange, (nint)pSamplers, (nint)pLodMinClamps, (nint)pLodMaxClamps, range);
    }

    public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileVisibleFunctionTable_AtBufferIndex, functionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetTileVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
    {
        nint* pFunctionTables = stackalloc nint[functionTables.Length];
        for (int i = 0; i < functionTables.Length; i++)
        {
            pFunctionTables[i] = functionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileVisibleFunctionTables_WithBufferRange, (nint)pFunctionTables, range);
    }

    public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileIntersectionFunctionTable_AtBufferIndex, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetTileIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
    {
        nint* pIntersectionFunctionTables = stackalloc nint[intersectionFunctionTables.Length];
        for (int i = 0; i < intersectionFunctionTables.Length; i++)
        {
            pIntersectionFunctionTables[i] = intersectionFunctionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileIntersectionFunctionTables_WithBufferRange, (nint)pIntersectionFunctionTables, range);
    }

    public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetTileAccelerationStructure_AtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.DispatchThreadsPerTile, threadsPerTile);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetThreadgroupMemoryLength_Offset_AtIndex, length, offset, index);
    }

    /// <summary>
    /// Deprecated: Use useResource:usage:stages: instead
    /// </summary>
    [Obsolete("Use useResource:usage:stages: instead")]
    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResource_Usage, resource.NativePtr, (nuint)usage);
    }

    /// <summary>
    /// Deprecated: Use useResources:count:usage:stages: instead
    /// </summary>
    [Obsolete("Use useResources:count:usage:stages: instead")]
    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResources_Count_Usage, (nint)pResources, (nuint)resources.Length, (nuint)usage);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResource_Usage_Stages, resource.NativePtr, (nuint)usage, (nuint)stages);
    }

    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage, MTLRenderStages stages)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseResources_Count_Usage_Stages, (nint)pResources, (nuint)resources.Length, (nuint)usage, (nuint)stages);
    }

    /// <summary>
    /// Deprecated: Use useHeap:stages: instead
    /// </summary>
    [Obsolete("Use useHeap:stages: instead")]
    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    /// <summary>
    /// Deprecated: Use useHeaps:count:stages: instead
    /// </summary>
    [Obsolete("Use useHeaps:count:stages: instead")]
    public unsafe void UseHeaps(MTLHeap[] heaps)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeaps_Count, (nint)pHeaps, (nuint)heaps.Length);
    }

    public void UseHeap(MTLHeap heap, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeap_Stages, heap.NativePtr, (nuint)stages);
    }

    public unsafe void UseHeaps(MTLHeap[] heaps, MTLRenderStages stages)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.UseHeaps_Count_Stages, (nint)pHeaps, (nuint)heaps.Length, (nuint)stages);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBuffer_WithRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.ExecuteCommandsInBuffer_IndirectBuffer_IndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrierWithScope_AfterStages_BeforeStages, (nuint)scope, (nuint)after, (nuint)before);
    }

    public unsafe void MemoryBarrierWithResources(MTLResource[] resources, MTLRenderStages after, MTLRenderStages before)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.MemoryBarrierWithResources_Count_AfterStages_BeforeStages, (nint)pResources, (nuint)resources.Length, (nuint)after, (nuint)before);
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SampleCountersInBuffer_AtSampleIndex_WithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderCommandEncoderBindings.SetColorAttachmentMap, mapping.NativePtr);
    }
}

file static class MTLRenderCommandEncoderBindings
{
    public static readonly Selector DispatchThreadsPerTile = "dispatchThreadsPerTile:";

    public static readonly Selector DrawIndexedPatches_PatchIndexBuffer_PatchIndexBufferOffset_ControlPointIndexBuffer_ControlPointIndexBufferOffset_IndirectBuffer_IndirectBufferOffset = "drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawIndexedPatches_PatchStart_PatchCount_PatchIndexBuffer_PatchIndexBufferOffset_ControlPointIndexBuffer_ControlPointIndexBufferOffset_InstanceCount_BaseInstance = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferOffset = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:";

    public static readonly Selector DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferOffset_InstanceCount = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:";

    public static readonly Selector DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferOffset_InstanceCount_BaseVertex_BaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";

    public static readonly Selector DrawIndexedPrimitives_IndexType_IndexBuffer_IndexBufferOffset_IndirectBuffer_IndirectBufferOffset = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawMeshThreadgroups_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreadgroupsWithIndirectBuffer_IndirectBufferOffset_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup = "drawMeshThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPatches_PatchIndexBuffer_PatchIndexBufferOffset_IndirectBuffer_IndirectBufferOffset = "drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawPatches_PatchStart_PatchCount_PatchIndexBuffer_PatchIndexBufferOffset_InstanceCount_BaseInstance = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:";

    public static readonly Selector DrawPrimitives_IndirectBuffer_IndirectBufferOffset = "drawPrimitives:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector DrawPrimitives_VertexStart_VertexCount = "drawPrimitives:vertexStart:vertexCount:";

    public static readonly Selector DrawPrimitives_VertexStart_VertexCount_InstanceCount = "drawPrimitives:vertexStart:vertexCount:instanceCount:";

    public static readonly Selector DrawPrimitives_VertexStart_VertexCount_InstanceCount_BaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";

    public static readonly Selector ExecuteCommandsInBuffer_IndirectBuffer_IndirectBufferOffset = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector ExecuteCommandsInBuffer_WithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector MemoryBarrierWithResources_Count_AfterStages_BeforeStages = "memoryBarrierWithResources:count:afterStages:beforeStages:";

    public static readonly Selector MemoryBarrierWithScope_AfterStages_BeforeStages = "memoryBarrierWithScope:afterStages:beforeStages:";

    public static readonly Selector SampleCountersInBuffer_AtSampleIndex_WithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetBlendColorRed_Green_Blue_Alpha = "setBlendColorRed:green:blue:alpha:";

    public static readonly Selector SetColorAttachmentMap = "setColorAttachmentMap:";

    public static readonly Selector SetColorStoreAction_AtIndex = "setColorStoreAction:atIndex:";

    public static readonly Selector SetColorStoreActionOptions_AtIndex = "setColorStoreActionOptions:atIndex:";

    public static readonly Selector SetCullMode = "setCullMode:";

    public static readonly Selector SetDepthBias_SlopeScale_Clamp = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthClipMode = "setDepthClipMode:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:";

    public static readonly Selector SetDepthStoreAction = "setDepthStoreAction:";

    public static readonly Selector SetDepthStoreActionOptions = "setDepthStoreActionOptions:";

    public static readonly Selector SetDepthTestMinBound_MaxBound = "setDepthTestMinBound:maxBound:";

    public static readonly Selector SetFragmentAccelerationStructure_AtBufferIndex = "setFragmentAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetFragmentBuffer_Offset_AtIndex = "setFragmentBuffer:offset:atIndex:";

    public static readonly Selector SetFragmentBufferOffset_AtIndex = "setFragmentBufferOffset:atIndex:";

    public static readonly Selector SetFragmentBuffers_Offsets_WithRange = "setFragmentBuffers:offsets:withRange:";

    public static readonly Selector SetFragmentBytes_Length_AtIndex = "setFragmentBytes:length:atIndex:";

    public static readonly Selector SetFragmentIntersectionFunctionTable_AtBufferIndex = "setFragmentIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetFragmentIntersectionFunctionTables_WithBufferRange = "setFragmentIntersectionFunctionTables:withBufferRange:";

    public static readonly Selector SetFragmentSamplerState_AtIndex = "setFragmentSamplerState:atIndex:";

    public static readonly Selector SetFragmentSamplerState_LodMinClamp_LodMaxClamp_AtIndex = "setFragmentSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetFragmentSamplerStates_LodMinClamps_LodMaxClamps_WithRange = "setFragmentSamplerStates:lodMinClamps:lodMaxClamps:withRange:";

    public static readonly Selector SetFragmentSamplerStates_WithRange = "setFragmentSamplerStates:withRange:";

    public static readonly Selector SetFragmentTexture_AtIndex = "setFragmentTexture:atIndex:";

    public static readonly Selector SetFragmentTextures_WithRange = "setFragmentTextures:withRange:";

    public static readonly Selector SetFragmentVisibleFunctionTable_AtBufferIndex = "setFragmentVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetFragmentVisibleFunctionTables_WithBufferRange = "setFragmentVisibleFunctionTables:withBufferRange:";

    public static readonly Selector SetFrontFacingWinding = "setFrontFacingWinding:";

    public static readonly Selector SetMeshBuffer_Offset_AtIndex = "setMeshBuffer:offset:atIndex:";

    public static readonly Selector SetMeshBufferOffset_AtIndex = "setMeshBufferOffset:atIndex:";

    public static readonly Selector SetMeshBuffers_Offsets_WithRange = "setMeshBuffers:offsets:withRange:";

    public static readonly Selector SetMeshBytes_Length_AtIndex = "setMeshBytes:length:atIndex:";

    public static readonly Selector SetMeshSamplerState_AtIndex = "setMeshSamplerState:atIndex:";

    public static readonly Selector SetMeshSamplerState_LodMinClamp_LodMaxClamp_AtIndex = "setMeshSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetMeshSamplerStates_LodMinClamps_LodMaxClamps_WithRange = "setMeshSamplerStates:lodMinClamps:lodMaxClamps:withRange:";

    public static readonly Selector SetMeshSamplerStates_WithRange = "setMeshSamplerStates:withRange:";

    public static readonly Selector SetMeshTexture_AtIndex = "setMeshTexture:atIndex:";

    public static readonly Selector SetMeshTextures_WithRange = "setMeshTextures:withRange:";

    public static readonly Selector SetObjectBuffer_Offset_AtIndex = "setObjectBuffer:offset:atIndex:";

    public static readonly Selector SetObjectBufferOffset_AtIndex = "setObjectBufferOffset:atIndex:";

    public static readonly Selector SetObjectBuffers_Offsets_WithRange = "setObjectBuffers:offsets:withRange:";

    public static readonly Selector SetObjectBytes_Length_AtIndex = "setObjectBytes:length:atIndex:";

    public static readonly Selector SetObjectSamplerState_AtIndex = "setObjectSamplerState:atIndex:";

    public static readonly Selector SetObjectSamplerState_LodMinClamp_LodMaxClamp_AtIndex = "setObjectSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetObjectSamplerStates_LodMinClamps_LodMaxClamps_WithRange = "setObjectSamplerStates:lodMinClamps:lodMaxClamps:withRange:";

    public static readonly Selector SetObjectSamplerStates_WithRange = "setObjectSamplerStates:withRange:";

    public static readonly Selector SetObjectTexture_AtIndex = "setObjectTexture:atIndex:";

    public static readonly Selector SetObjectTextures_WithRange = "setObjectTextures:withRange:";

    public static readonly Selector SetObjectThreadgroupMemoryLength_AtIndex = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:";

    public static readonly Selector SetScissorRect = "setScissorRect:";

    public static readonly Selector SetScissorRects_Count = "setScissorRects:count:";

    public static readonly Selector SetStencilFrontReferenceValue_BackReferenceValue = "setStencilFrontReferenceValue:backReferenceValue:";

    public static readonly Selector SetStencilReferenceValue = "setStencilReferenceValue:";

    public static readonly Selector SetStencilStoreAction = "setStencilStoreAction:";

    public static readonly Selector SetStencilStoreActionOptions = "setStencilStoreActionOptions:";

    public static readonly Selector SetTessellationFactorBuffer_Offset_InstanceStride = "setTessellationFactorBuffer:offset:instanceStride:";

    public static readonly Selector SetTessellationFactorScale = "setTessellationFactorScale:";

    public static readonly Selector SetThreadgroupMemoryLength_Offset_AtIndex = "setThreadgroupMemoryLength:offset:atIndex:";

    public static readonly Selector SetTileAccelerationStructure_AtBufferIndex = "setTileAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetTileBuffer_Offset_AtIndex = "setTileBuffer:offset:atIndex:";

    public static readonly Selector SetTileBufferOffset_AtIndex = "setTileBufferOffset:atIndex:";

    public static readonly Selector SetTileBuffers_Offsets_WithRange = "setTileBuffers:offsets:withRange:";

    public static readonly Selector SetTileBytes_Length_AtIndex = "setTileBytes:length:atIndex:";

    public static readonly Selector SetTileIntersectionFunctionTable_AtBufferIndex = "setTileIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetTileIntersectionFunctionTables_WithBufferRange = "setTileIntersectionFunctionTables:withBufferRange:";

    public static readonly Selector SetTileSamplerState_AtIndex = "setTileSamplerState:atIndex:";

    public static readonly Selector SetTileSamplerState_LodMinClamp_LodMaxClamp_AtIndex = "setTileSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetTileSamplerStates_LodMinClamps_LodMaxClamps_WithRange = "setTileSamplerStates:lodMinClamps:lodMaxClamps:withRange:";

    public static readonly Selector SetTileSamplerStates_WithRange = "setTileSamplerStates:withRange:";

    public static readonly Selector SetTileTexture_AtIndex = "setTileTexture:atIndex:";

    public static readonly Selector SetTileTextures_WithRange = "setTileTextures:withRange:";

    public static readonly Selector SetTileVisibleFunctionTable_AtBufferIndex = "setTileVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetTileVisibleFunctionTables_WithBufferRange = "setTileVisibleFunctionTables:withBufferRange:";

    public static readonly Selector SetTriangleFillMode = "setTriangleFillMode:";

    public static readonly Selector SetVertexAccelerationStructure_AtBufferIndex = "setVertexAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetVertexAmplificationCount_ViewMappings = "setVertexAmplificationCount:viewMappings:";

    public static readonly Selector SetVertexBuffer_Offset_AtIndex = "setVertexBuffer:offset:atIndex:";

    public static readonly Selector SetVertexBuffer_Offset_AttributeStride_AtIndex = "setVertexBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetVertexBufferOffset_AtIndex = "setVertexBufferOffset:atIndex:";

    public static readonly Selector SetVertexBufferOffset_AttributeStride_AtIndex = "setVertexBufferOffset:attributeStride:atIndex:";

    public static readonly Selector SetVertexBuffers_Offsets_AttributeStrides_WithRange = "setVertexBuffers:offsets:attributeStrides:withRange:";

    public static readonly Selector SetVertexBuffers_Offsets_WithRange = "setVertexBuffers:offsets:withRange:";

    public static readonly Selector SetVertexBytes_Length_AtIndex = "setVertexBytes:length:atIndex:";

    public static readonly Selector SetVertexBytes_Length_AttributeStride_AtIndex = "setVertexBytes:length:attributeStride:atIndex:";

    public static readonly Selector SetVertexIntersectionFunctionTable_AtBufferIndex = "setVertexIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetVertexIntersectionFunctionTables_WithBufferRange = "setVertexIntersectionFunctionTables:withBufferRange:";

    public static readonly Selector SetVertexSamplerState_AtIndex = "setVertexSamplerState:atIndex:";

    public static readonly Selector SetVertexSamplerState_LodMinClamp_LodMaxClamp_AtIndex = "setVertexSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetVertexSamplerStates_LodMinClamps_LodMaxClamps_WithRange = "setVertexSamplerStates:lodMinClamps:lodMaxClamps:withRange:";

    public static readonly Selector SetVertexSamplerStates_WithRange = "setVertexSamplerStates:withRange:";

    public static readonly Selector SetVertexTexture_AtIndex = "setVertexTexture:atIndex:";

    public static readonly Selector SetVertexTextures_WithRange = "setVertexTextures:withRange:";

    public static readonly Selector SetVertexVisibleFunctionTable_AtBufferIndex = "setVertexVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetVertexVisibleFunctionTables_WithBufferRange = "setVertexVisibleFunctionTables:withBufferRange:";

    public static readonly Selector SetViewport = "setViewport:";

    public static readonly Selector SetViewports_Count = "setViewports:count:";

    public static readonly Selector SetVisibilityResultMode_Offset = "setVisibilityResultMode:offset:";

    public static readonly Selector TextureBarrier = "textureBarrier";

    public static readonly Selector TileHeight = "tileHeight";

    public static readonly Selector TileWidth = "tileWidth";

    public static readonly Selector UpdateFence_AfterStages = "updateFence:afterStages:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeap_Stages = "useHeap:stages:";

    public static readonly Selector UseHeaps_Count = "useHeaps:count:";

    public static readonly Selector UseHeaps_Count_Stages = "useHeaps:count:stages:";

    public static readonly Selector UseResource_Usage = "useResource:usage:";

    public static readonly Selector UseResource_Usage_Stages = "useResource:usage:stages:";

    public static readonly Selector UseResources_Count_Usage = "useResources:count:usage:";

    public static readonly Selector UseResources_Count_Usage_Stages = "useResources:count:usage:stages:";

    public static readonly Selector WaitForFence_BeforeStages = "waitForFence:beforeStages:";
}
