namespace Metal.NET;

public class MTLIndirectRenderCommand(nint nativePtr) : NativeObject(nativePtr)
{
    public void ClearBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.ClearBarrier);
    }

    public void DrawIndexedPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawIndexedPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, controlPointIndexBuffer.NativePtr, controlPointIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawIndexedPrimitives, (nuint)primitiveType, indexCount, (nuint)indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);
    }

    public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawMeshThreadgroups, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawMeshThreads, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
    }

    public void DrawPatches(nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, MTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance, MTLBuffer buffer, nuint offset, nuint instanceStride)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawPatches, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer.NativePtr, patchIndexBufferOffset, instanceCount, baseInstance, buffer.NativePtr, offset, instanceStride);
    }

    public void DrawPrimitives(MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.DrawPrimitives, (nuint)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.Reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetBarrier);
    }

    public void SetDepthBias(float depthBias, float slopeScale, float clamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetDepthBias, depthBias, slopeScale, clamp);
    }

    public void SetFragmentBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetFragmentBuffer, buffer.NativePtr, offset, index);
    }

    public void SetMeshBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetMeshBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetObjectBuffer, buffer.NativePtr, offset, index);
    }

    public void SetObjectThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetObjectThreadgroupMemoryLength, length, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetVertexBuffer, buffer.NativePtr, offset, index);
    }

    public void SetVertexBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectRenderCommandBindings.SetVertexBuffer, buffer.NativePtr, offset, stride, index);
    }
}

file static class MTLIndirectRenderCommandBindings
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");

    public static readonly Selector DrawIndexedPatches = Selector.Register("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:");

    public static readonly Selector DrawIndexedPrimitives = Selector.Register("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:");

    public static readonly Selector DrawMeshThreadgroups = Selector.Register("drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawMeshThreads = Selector.Register("drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:");

    public static readonly Selector DrawPatches = Selector.Register("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:");

    public static readonly Selector DrawPrimitives = Selector.Register("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetBarrier = Selector.Register("setBarrier");

    public static readonly Selector SetDepthBias = Selector.Register("setDepthBias:slopeScale:clamp:");

    public static readonly Selector SetFragmentBuffer = Selector.Register("setFragmentBuffer:offset:atIndex:");

    public static readonly Selector SetMeshBuffer = Selector.Register("setMeshBuffer:offset:atIndex:");

    public static readonly Selector SetObjectBuffer = Selector.Register("setObjectBuffer:offset:atIndex:");

    public static readonly Selector SetObjectThreadgroupMemoryLength = Selector.Register("setObjectThreadgroupMemoryLength:atIndex:");

    public static readonly Selector SetVertexBuffer = Selector.Register("setVertexBuffer:offset:atIndex:");
}
