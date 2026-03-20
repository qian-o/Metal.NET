namespace Metal.NET;

public partial class MTLArgumentEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLArgumentEncoder>
{
    #region INativeObject
    public static new MTLArgumentEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLArgumentEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLArgumentEncoderBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLArgumentEncoderBindings.Label);
        set => SetProperty(ref field, MTLArgumentEncoderBindings.SetLabel, value);
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

    public unsafe void SetBuffers(MTLBuffer[] buffers, nuint[] offsets, NSRange range)
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

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTexture_AtIndex, texture.NativePtr, index);
    }

    public unsafe void SetTextures(MTLTexture[] textures, NSRange range)
    {
        nint* pTextures = stackalloc nint[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            pTextures[i] = textures[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTextures_WithRange, (nint)pTextures, range);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public unsafe void SetSamplerStates(MTLSamplerState[] samplers, NSRange range)
    {
        nint* pSamplers = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            pSamplers[i] = samplers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerStates_WithRange, (nint)pSamplers, range);
    }

    public nint ConstantData(nuint index)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.ConstantDataAtIndex, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineState_AtIndex, pipeline.NativePtr, index);
    }

    public unsafe void SetRenderPipelineStates(MTLRenderPipelineState[] pipelines, NSRange range)
    {
        nint* pPipelines = stackalloc nint[pipelines.Length];
        for (int i = 0; i < pipelines.Length; i++)
        {
            pPipelines[i] = pipelines[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineStates_WithRange, (nint)pPipelines, range);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineState_AtIndex, pipeline.NativePtr, index);
    }

    public unsafe void SetComputePipelineStates(MTLComputePipelineState[] pipelines, NSRange range)
    {
        nint* pPipelines = stackalloc nint[pipelines.Length];
        for (int i = 0; i < pipelines.Length; i++)
        {
            pPipelines[i] = pipelines[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineStates_WithRange, (nint)pPipelines, range);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffer_AtIndex, indirectCommandBuffer.NativePtr, index);
    }

    public unsafe void SetIndirectCommandBuffers(MTLIndirectCommandBuffer[] buffers, NSRange range)
    {
        nint* pBuffers = stackalloc nint[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            pBuffers[i] = buffers[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffers_WithRange, (nint)pBuffers, range);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetAccelerationStructure_AtIndex, accelerationStructure.NativePtr, index);
    }

    public MTLArgumentEncoder MakeArgumentEncoderForBuffer(nuint index)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.NewArgumentEncoderForBufferAtIndex, index);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTable_AtIndex, visibleFunctionTable.NativePtr, index);
    }

    public unsafe void SetVisibleFunctionTables(MTLVisibleFunctionTable[] visibleFunctionTables, NSRange range)
    {
        nint* pVisibleFunctionTables = stackalloc nint[visibleFunctionTables.Length];
        for (int i = 0; i < visibleFunctionTables.Length; i++)
        {
            pVisibleFunctionTables[i] = visibleFunctionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTables_WithRange, (nint)pVisibleFunctionTables, range);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTable_AtIndex, intersectionFunctionTable.NativePtr, index);
    }

    public unsafe void SetIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
    {
        nint* pIntersectionFunctionTables = stackalloc nint[intersectionFunctionTables.Length];
        for (int i = 0; i < intersectionFunctionTables.Length; i++)
        {
            pIntersectionFunctionTables[i] = intersectionFunctionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTables_WithRange, (nint)pIntersectionFunctionTables, range);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilState_AtIndex, depthStencilState.NativePtr, index);
    }

    public unsafe void SetDepthStencilStates(MTLDepthStencilState[] depthStencilStates, NSRange range)
    {
        nint* pDepthStencilStates = stackalloc nint[depthStencilStates.Length];
        for (int i = 0; i < depthStencilStates.Length; i++)
        {
            pDepthStencilStates[i] = depthStencilStates[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilStates_WithRange, (nint)pDepthStencilStates, range);
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
