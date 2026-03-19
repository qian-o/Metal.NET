namespace Metal.NET;

public class MTLArgumentEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLArgumentEncoder>
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
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBufferOffset, argumentBuffer.NativePtr, offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBufferStartOffsetArrayElement, argumentBuffer.NativePtr, startOffset, arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTextureAtIndex, texture.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerStateAtIndex, sampler.NativePtr, index);
    }

    public nint ConstantData(nuint index)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.ConstantDataAtIndex, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineStateAtIndex, pipeline.NativePtr, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineStateAtIndex, pipeline.NativePtr, index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBufferAtIndex, indirectCommandBuffer.NativePtr, index);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetAccelerationStructureAtIndex, accelerationStructure.NativePtr, index);
    }

    public MTLArgumentEncoder MakeArgumentEncoderForBuffer(nuint index)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.NewArgumentEncoderForBufferAtIndex, index);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTableAtIndex, visibleFunctionTable.NativePtr, index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTableAtIndex, intersectionFunctionTable.NativePtr, index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilStateAtIndex, depthStencilState.NativePtr, index);
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

    public static readonly Selector SetAccelerationStructureAtIndex = "setAccelerationStructure:atIndex:";

    public static readonly Selector SetArgumentBufferOffset = "setArgumentBuffer:offset:";

    public static readonly Selector SetArgumentBufferStartOffsetArrayElement = "setArgumentBuffer:startOffset:arrayElement:";

    public static readonly Selector SetBufferOffsetAtIndex = "setBuffer:offset:atIndex:";

    public static readonly Selector SetComputePipelineStateAtIndex = "setComputePipelineState:atIndex:";

    public static readonly Selector SetDepthStencilStateAtIndex = "setDepthStencilState:atIndex:";

    public static readonly Selector SetIndirectCommandBufferAtIndex = "setIndirectCommandBuffer:atIndex:";

    public static readonly Selector SetIntersectionFunctionTableAtIndex = "setIntersectionFunctionTable:atIndex:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetRenderPipelineStateAtIndex = "setRenderPipelineState:atIndex:";

    public static readonly Selector SetSamplerStateAtIndex = "setSamplerState:atIndex:";

    public static readonly Selector SetTextureAtIndex = "setTexture:atIndex:";

    public static readonly Selector SetVisibleFunctionTableAtIndex = "setVisibleFunctionTable:atIndex:";
}
