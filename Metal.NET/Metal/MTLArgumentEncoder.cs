namespace Metal.NET;

public readonly struct MTLArgumentEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLArgumentEncoder value) => new(value.NativePtr);

    public MTLArgumentEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetLabel, value.NativePtr);
    }

    public nuint EncodedLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentEncoderBindings.EncodedLength);
    }

    public nuint Alignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentEncoderBindings.Alignment);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBuffer_Offset, argumentBuffer.NativePtr, offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBuffer_StartOffset_ArrayElement, argumentBuffer.NativePtr, startOffset, arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public unsafe void SetBuffers(ReadOnlySpan<MTLBuffer> buffers, ReadOnlySpan<nuint> offsets, NSRange range)
    {
        fixed (MTLBuffer* pBuffers = buffers)
        {
            fixed (nuint* pOffsets = offsets)
            {
                ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
            }
        }
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTexture_AtIndex, texture.NativePtr, index);
    }

    public unsafe void SetTextures(ReadOnlySpan<MTLTexture> textures, NSRange range)
    {
        fixed (MTLTexture* pTextures = textures)
        {
            ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTextures_WithRange, (nint)pTextures, range);
        }
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public unsafe void SetSamplerStates(ReadOnlySpan<MTLSamplerState> samplers, NSRange range)
    {
        fixed (MTLSamplerState* pSamplers = samplers)
        {
            ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerStates_WithRange, (nint)pSamplers, range);
        }
    }

    public nint ConstantData(nuint index)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.ConstantDataAtIndex, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineState_AtIndex, pipeline.NativePtr, index);
    }

    public unsafe void SetRenderPipelineStates(ReadOnlySpan<MTLRenderPipelineState> pipelines, NSRange range)
    {
        fixed (MTLRenderPipelineState* pPipelines = pipelines)
        {
            ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineStates_WithRange, (nint)pPipelines, range);
        }
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineState_AtIndex, pipeline.NativePtr, index);
    }

    public unsafe void SetComputePipelineStates(ReadOnlySpan<MTLComputePipelineState> pipelines, NSRange range)
    {
        fixed (MTLComputePipelineState* pPipelines = pipelines)
        {
            ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineStates_WithRange, (nint)pPipelines, range);
        }
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffer_AtIndex, indirectCommandBuffer.NativePtr, index);
    }

    public unsafe void SetIndirectCommandBuffers(ReadOnlySpan<MTLIndirectCommandBuffer> buffers, NSRange range)
    {
        fixed (MTLIndirectCommandBuffer* pBuffers = buffers)
        {
            ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffers_WithRange, (nint)pBuffers, range);
        }
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetAccelerationStructure_AtIndex, accelerationStructure.NativePtr, index);
    }

    public MTLArgumentEncoder MakeArgumentEncoderForBuffer(nuint index)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.NewArgumentEncoderForBufferAtIndex, index);

        return new(nativePtr);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTable_AtIndex, visibleFunctionTable.NativePtr, index);
    }

    public unsafe void SetVisibleFunctionTables(ReadOnlySpan<MTLVisibleFunctionTable> visibleFunctionTables, NSRange range)
    {
        fixed (MTLVisibleFunctionTable* pVisibleFunctionTables = visibleFunctionTables)
        {
            ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTables_WithRange, (nint)pVisibleFunctionTables, range);
        }
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTable_AtIndex, intersectionFunctionTable.NativePtr, index);
    }

    public unsafe void SetIntersectionFunctionTables(ReadOnlySpan<MTLIntersectionFunctionTable> intersectionFunctionTables, NSRange range)
    {
        fixed (MTLIntersectionFunctionTable* pIntersectionFunctionTables = intersectionFunctionTables)
        {
            ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTables_WithRange, (nint)pIntersectionFunctionTables, range);
        }
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilState_AtIndex, depthStencilState.NativePtr, index);
    }

    public unsafe void SetDepthStencilStates(ReadOnlySpan<MTLDepthStencilState> depthStencilStates, NSRange range)
    {
        fixed (MTLDepthStencilState* pDepthStencilStates = depthStencilStates)
        {
            ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilStates_WithRange, (nint)pDepthStencilStates, range);
        }
    }
}

file static class MTLArgumentEncoderBindings
{
    public static readonly Selector Alignment = "alignment";

    public static readonly Selector ConstantDataAtIndex = "constantDataAtIndex:";

    public static readonly Selector Device = "device";

    public static readonly Selector EncodedLength = "encodedLength";

    public static readonly Selector Label = "label";

    public static readonly Selector NewArgumentEncoderForBufferAtIndex = "newArgumentEncoderForBufferAtIndex:";

    public static readonly Selector SetAccelerationStructure_AtIndex = "setAccelerationStructure:atIndex:";

    public static readonly Selector SetArgumentBuffer_Offset = "setArgumentBuffer:offset:";

    public static readonly Selector SetArgumentBuffer_StartOffset_ArrayElement = "setArgumentBuffer:startOffset:arrayElement:";

    public static readonly Selector SetBuffer_Offset_AtIndex = "setBuffer:offset:atIndex:";

    public static readonly Selector SetBuffers_Offsets_WithRange = "setBuffers:offsets:withRange:";

    public static readonly Selector SetComputePipelineState_AtIndex = "setComputePipelineState:atIndex:";

    public static readonly Selector SetComputePipelineStates_WithRange = "setComputePipelineStates:withRange:";

    public static readonly Selector SetDepthStencilState_AtIndex = "setDepthStencilState:atIndex:";

    public static readonly Selector SetDepthStencilStates_WithRange = "setDepthStencilStates:withRange:";

    public static readonly Selector SetIndirectCommandBuffer_AtIndex = "setIndirectCommandBuffer:atIndex:";

    public static readonly Selector SetIndirectCommandBuffers_WithRange = "setIndirectCommandBuffers:withRange:";

    public static readonly Selector SetIntersectionFunctionTable_AtIndex = "setIntersectionFunctionTable:atIndex:";

    public static readonly Selector SetIntersectionFunctionTables_WithRange = "setIntersectionFunctionTables:withRange:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetRenderPipelineState_AtIndex = "setRenderPipelineState:atIndex:";

    public static readonly Selector SetRenderPipelineStates_WithRange = "setRenderPipelineStates:withRange:";

    public static readonly Selector SetSamplerState_AtIndex = "setSamplerState:atIndex:";

    public static readonly Selector SetSamplerStates_WithRange = "setSamplerStates:withRange:";

    public static readonly Selector SetTexture_AtIndex = "setTexture:atIndex:";

    public static readonly Selector SetTextures_WithRange = "setTextures:withRange:";

    public static readonly Selector SetVisibleFunctionTable_AtIndex = "setVisibleFunctionTable:atIndex:";

    public static readonly Selector SetVisibleFunctionTables_WithRange = "setVisibleFunctionTables:withRange:";
}
