namespace Metal.NET;

public class MTL4RenderCommandEncoder(nint nativePtr, bool ownsReference) : MTL4CommandEncoder(nativePtr, ownsReference), INativeObject<MTL4RenderCommandEncoder>
{
    public static new MTL4RenderCommandEncoder Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public nuint TileHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderBindings.TileHeight);
    }

    public nuint TileWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderCommandEncoderBindings.TileWidth);
    }

    public void DispatchThreadsPerTile(MTLSize threadsPerTile)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DispatchThreadsPerTile, threadsPerTile);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCount, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCountbaseVertexbaseInstance, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength, instanceCount, baseVertex, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitivesindexTypeindexBufferindexBufferLengthindirectBuffer, (nuint)primitiveType, (nuint)indexType, indexBuffer, indexBufferLength, indirectBuffer);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(nuint indirectBuffer, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreadgroupsWithIndirectBufferthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, indirectBuffer, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitivesvertexStartvertexCountinstanceCount, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitivesvertexStartvertexCountinstanceCountbaseInstance, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitivesindirectBuffer, (nuint)primitiveType, indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.ExecuteCommandsInBufferindirectBuffer, indirectCommandBuffer.NativePtr, indirectRangeBuffer);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr, (nuint)stages);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetBlendColor, red, green, blue, alpha);
    }

    public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetColorAttachmentMap, mapping.NativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetCullMode(MTLCullMode cullMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetCullMode, (nuint)cullMode);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthClipMode, (nuint)depthClipMode);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthTestBounds, minBound, maxBound);
    }

    public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetFrontFacingWinding, (nuint)frontFacingWinding);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetRenderPipelineState, pipelineState.NativePtr);
    }

    public void SetScissorRect(MTLScissorRect rect)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetScissorRect, rect);
    }

    public unsafe void SetScissorRects(MTLScissorRect[] scissorRects)
    {
        fixed (MTLScissorRect* pScissorRects = scissorRects)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetScissorRects, (nint)pScissorRects, (nuint)scissorRects.Length);
        }
    }

    public void SetStencilReferenceValue(uint referenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilReferenceValue, (nuint)referenceValue);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilReferenceValues, (nuint)frontReferenceValue, (nuint)backReferenceValue);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetThreadgroupMemoryLength, length, offset, index);
    }

    public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetTriangleFillMode, (nuint)fillMode);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetVertexAmplificationCount, count, viewMappings);
    }

    public void SetViewport(MTLViewport viewport)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewport, viewport);
    }

    public unsafe void SetViewports(MTLViewport[] viewports)
    {
        fixed (MTLViewport* pViewports = viewports)
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewports, (nint)pViewports, (nuint)viewports.Length);
        }
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetVisibilityResultMode, (nuint)mode, offset);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTLRenderStages stage, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.WriteTimestamp, (nint)granularity, (nuint)stage, counterHeap.NativePtr, index);
    }
}

file static class MTL4RenderCommandEncoderBindings
{
    public static readonly Selector DispatchThreadsPerTile = "dispatchThreadsPerTile:";

    public static readonly Selector DrawIndexedPrimitives = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:";

    public static readonly Selector DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCount = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:";

    public static readonly Selector DrawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCountbaseVertexbaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:baseVertex:baseInstance:";

    public static readonly Selector DrawIndexedPrimitivesindexTypeindexBufferindexBufferLengthindirectBuffer = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:";

    public static readonly Selector DrawMeshThreadgroups = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreadgroupsWithIndirectBufferthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroupsWithIndirectBuffer:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

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
