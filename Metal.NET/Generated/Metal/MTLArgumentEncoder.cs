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

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTexture_AtIndex, texture.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public nint ConstantData(nuint index)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.ConstantDataAtIndex, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineState_AtIndex, pipeline.NativePtr, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineState_AtIndex, pipeline.NativePtr, index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffer_AtIndex, indirectCommandBuffer.NativePtr, index);
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

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTable_AtIndex, intersectionFunctionTable.NativePtr, index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilState_AtIndex, depthStencilState.NativePtr, index);
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

    public static readonly Selector SetComputePipelineState_AtIndex = "setComputePipelineState:atIndex:";

    public static readonly Selector SetDepthStencilState_AtIndex = "setDepthStencilState:atIndex:";

    public static readonly Selector SetIndirectCommandBuffer_AtIndex = "setIndirectCommandBuffer:atIndex:";

    public static readonly Selector SetIntersectionFunctionTable_AtIndex = "setIntersectionFunctionTable:atIndex:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetRenderPipelineState_AtIndex = "setRenderPipelineState:atIndex:";

    public static readonly Selector SetSamplerState_AtIndex = "setSamplerState:atIndex:";

    public static readonly Selector SetTexture_AtIndex = "setTexture:atIndex:";

    public static readonly Selector SetVisibleFunctionTable_AtIndex = "setVisibleFunctionTable:atIndex:";
}
