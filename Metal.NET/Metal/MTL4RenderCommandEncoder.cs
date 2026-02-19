namespace Metal.NET;

public class MTL4RenderCommandEncoder(nint nativePtr) : MTL4CommandEncoder(nativePtr)
{
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength, instanceCount);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer, indexBufferLength, instanceCount, baseVertex, baseInstance);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, nuint indexBuffer, nuint indexBufferLength, nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawIndexedPrimitives, (nuint)primitiveType, (nuint)indexType, indexBuffer, indexBufferLength, indirectBuffer);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreadgroups(nuint indirectBuffer, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawMeshThreadgroups, indirectBuffer, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint indirectBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.DrawPrimitives, (nuint)primitiveType, indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, indirectRangeBuffer);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable, MTLRenderStages stages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr, (nuint)stages);
    }

    public void SetBlendColor(float red, float green, float blue, float alpha)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetBlendColor, red, green, blue, alpha);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetDepthTestBounds(float minBound, float maxBound)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetDepthTestBounds, minBound, maxBound);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetScissorRects(MTLScissorRect scissorRects, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetScissorRects, scissorRects, count);
    }

    public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetStencilReferenceValues, frontReferenceValue, backReferenceValue);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetThreadgroupMemoryLength, length, offset, index);
    }

    public void SetVertexAmplificationCount(nuint count, MTLVertexAmplificationViewMapping viewMappings)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetVertexAmplificationCount, count, viewMappings);
    }

    public void SetViewports(MTLViewport viewports, nuint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetViewports, viewports, count);
    }

    public void SetVisibilityResultMode(MTLVisibilityResultMode mode, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderCommandEncoderBindings.SetVisibilityResultMode, (nuint)mode, offset);
    }
}

file static class MTL4RenderCommandEncoderBindings
{
    public static readonly Selector DispatchThreadsPerTile = "dispatchThreadsPerTile:";

    public static readonly Selector DrawIndexedPrimitives = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:";

    public static readonly Selector DrawMeshThreadgroups = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawMeshThreads = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";

    public static readonly Selector DrawPrimitives = "drawPrimitives:vertexStart:vertexCount:";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:withRange:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:atStages:";

    public static readonly Selector SetBlendColor = "setBlendColorRed:green:blue:alpha:";

    public static readonly Selector SetColorStoreAction = "setColorStoreAction:atIndex:";

    public static readonly Selector SetDepthBias = "setDepthBias:slopeScale:clamp:";

    public static readonly Selector SetDepthTestBounds = "setDepthTestMinBound:maxBound:";

    public static readonly Selector SetObjectThreadgroupMemoryLength = "setObjectThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetScissorRects = "setScissorRects:count:";

    public static readonly Selector SetStencilReferenceValues = "setStencilFrontReferenceValue:backReferenceValue:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:offset:atIndex:";

    public static readonly Selector SetVertexAmplificationCount = "setVertexAmplificationCount:viewMappings:";

    public static readonly Selector SetViewports = "setViewports:count:";

    public static readonly Selector SetVisibilityResultMode = "setVisibilityResultMode:offset:";

    public static readonly Selector TileHeight = "tileHeight";

    public static readonly Selector TileWidth = "tileWidth";
}
