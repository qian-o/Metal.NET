namespace Metal.NET;

public class MTL4RenderCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTL4CommandEncoder(nativePtr, ownership), INativeObject<MTL4RenderCommandEncoder>
{
    #region INativeObject
    public static new MTL4RenderCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint TileWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderBindings.TileWidth);
    }

    public nuint TileHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderBindings.TileHeight);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewport, viewport);
    }

    public unsafe void SetViewports(MTLViewport[] viewports)
    {
        fixed (MTLViewport* pViewports = viewports)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewports_Count, (nint)pViewports, (nuint)viewports.Length);
        }
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetVertexAmplificationCount_ViewMappings, count, viewMappings);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetCullMode, (nuint)cullMode);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthBias_SlopeScale_Clamp, depthBias, slopeScale, clamp);
    }

    public void SetDepthTestMinBound(float minBound, float maxBound)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthTestMinBound_MaxBound, minBound, maxBound);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetScissorRect, rect);
    }

    public unsafe void SetScissorRects(MTLScissorRect[] scissorRects)
    {
        fixed (MTLScissorRect* pScissorRects = scissorRects)
        {
            ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetScissorRects_Count, (nint)pScissorRects, (nuint)scissorRects.Length);
        }
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetTriangleFillMode, (nuint)fillMode);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetBlendColorRed_Green_Blue_Alpha, red, green, blue, alpha);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilReferenceValue, referenceValue);
    }

    public void SetStencilReferenceValue(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilFrontReferenceValue_BackReferenceValue, frontReferenceValue, backReferenceValue);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetVisibilityResultMode_Offset, (nuint)mode, offset);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetColorStoreAction_AtIndex, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives_VertexStart_VertexCount, (nuint)primitiveType, vertexStart, vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives_VertexStart_VertexCount_InstanceCount, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives_VertexStart_VertexCount_InstanceCount_BaseInstance, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferLength, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferLength_InstanceCount, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferLength_InstanceCount_BaseVertex_BaseInstance, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength, instanceCount, baseVertex, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint indirectBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives_IndirectBuffer, (nuint)primitiveType, indirectBuffer);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint indirectBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives_IndexType_IndexBuffer_IndexBufferLength_IndirectBuffer, (nuint)primitiveType, (nuint)indexType, indexBuffer, indexBufferLength, indirectBuffer);
    }

    public void ExecuteCommands(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.ExecuteCommandsInBuffer_WithRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommands(MTLIndirectCommandBuffer indirectCommandBuffer, nuint indirectRangeBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.ExecuteCommandsInBuffer_IndirectBuffer, indirectCommandBuffer.NativePtr, indirectRangeBuffer);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength_AtIndex, length, index);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreadgroups_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreads_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(nuint indirectBuffer, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreadgroupsWithIndirectBuffer_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup, indirectBuffer, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DispatchThreadsPerTile, threadsPerTile);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetThreadgroupMemoryLength_Offset_AtIndex, length, offset, index);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable, MTLRenderStages stages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetArgumentTable_AtStages, argumentTable.NativePtr, (nuint)stages);
    }

    public void SetFrontFacing(MTLWinding frontFacingWinding)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTLRenderStages stage, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.WriteTimestampWithGranularity_AfterStage_IntoHeap_AtIndex, (nint)granularity, (nuint)stage, counterHeap.NativePtr, index);
    }
}

file static class MTL4RenderCommandEncoderBindings
{
    public static readonly Selector DispatchThreadsPerTile = "dispatchThreadsPerTile:";

    public static readonly Selector DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferLength = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:";

    public static readonly Selector DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferLength_InstanceCount = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:";

    public static readonly Selector DrawIndexedPrimitives_IndexCount_IndexType_IndexBuffer_IndexBufferLength_InstanceCount_BaseVertex_BaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:baseVertex:baseInstance:";

    public static readonly Selector DrawIndexedPrimitives_IndexType_IndexBuffer_IndexBufferLength_IndirectBuffer = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:";

    public static readonly Selector DrawMeshThreadgroups_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreadgroupsWithIndirectBuffer_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup = "drawMeshThreadgroupsWithIndirectBuffer:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads_ThreadsPerObjectThreadgroup_ThreadsPerMeshThreadgroup = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPrimitives_IndirectBuffer = "drawPrimitives:indirectBuffer:";

    public static readonly Selector DrawPrimitives_VertexStart_VertexCount = "drawPrimitives:vertexStart:vertexCount:";

    public static readonly Selector DrawPrimitives_VertexStart_VertexCount_InstanceCount = "drawPrimitives:vertexStart:vertexCount:instanceCount:";

    public static readonly Selector DrawPrimitives_VertexStart_VertexCount_InstanceCount_BaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";

    public static readonly Selector ExecuteCommandsInBuffer_IndirectBuffer = "executeCommandsInBuffer:indirectBuffer:";

    public static readonly Selector ExecuteCommandsInBuffer_WithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector SetArgumentTable_AtStages = "setArgumentTable:atStages:";

    public static readonly Selector SetBlendColorRed_Green_Blue_Alpha = "setBlendColorRed:green:blue:alpha:";

    public static readonly Selector SetColorAttachmentMap = "setColorAttachmentMap:";

    public static readonly Selector SetColorStoreAction_AtIndex = "setColorStoreAction:atIndex:";

    public static readonly Selector SetCullMode = "setCullMode:";

    public static readonly Selector SetDepthBias_SlopeScale_Clamp = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthClipMode = "setDepthClipMode:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:";

    public static readonly Selector SetDepthStoreAction = "setDepthStoreAction:";

    public static readonly Selector SetDepthTestMinBound_MaxBound = "setDepthTestMinBound:maxBound:";

    public static readonly Selector SetFrontFacingWinding = "setFrontFacingWinding:";

    public static readonly Selector SetObjectThreadgroupMemoryLength_AtIndex = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:";

    public static readonly Selector SetScissorRect = "setScissorRect:";

    public static readonly Selector SetScissorRects_Count = "setScissorRects:count:";

    public static readonly Selector SetStencilFrontReferenceValue_BackReferenceValue = "setStencilFrontReferenceValue:backReferenceValue:";

    public static readonly Selector SetStencilReferenceValue = "setStencilReferenceValue:";

    public static readonly Selector SetStencilStoreAction = "setStencilStoreAction:";

    public static readonly Selector SetThreadgroupMemoryLength_Offset_AtIndex = "setThreadgroupMemoryLength:offset:atIndex:";

    public static readonly Selector SetTriangleFillMode = "setTriangleFillMode:";

    public static readonly Selector SetVertexAmplificationCount_ViewMappings = "setVertexAmplificationCount:viewMappings:";

    public static readonly Selector SetViewport = "setViewport:";

    public static readonly Selector SetViewports_Count = "setViewports:count:";

    public static readonly Selector SetVisibilityResultMode_Offset = "setVisibilityResultMode:offset:";

    public static readonly Selector TileHeight = "tileHeight";

    public static readonly Selector TileWidth = "tileWidth";

    public static readonly Selector WriteTimestampWithGranularity_AfterStage_IntoHeap_AtIndex = "writeTimestampWithGranularity:afterStage:intoHeap:atIndex:";
}
