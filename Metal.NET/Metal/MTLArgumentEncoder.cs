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

    public void SetArgumentBufferOffset(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBuffer, argumentBuffer.NativePtr, offset);
    }

    public void SetArgumentBufferStartOffsetArrayElement(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBufferstartOffsetarrayElement, argumentBuffer.NativePtr, startOffset, arrayElement);
    }

    public void SetBufferOffsetAtIndex(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetBuffer, buffer.NativePtr, offset, index);
    }

    public void SetTextureAtIndex(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTexture, texture.NativePtr, index);
    }

    public void SetSamplerStateAtIndex(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerState, sampler.NativePtr, index);
    }

    public nint ConstantDataAtIndex(nuint index)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.ConstantDataAtIndex, index);
    }

    public void SetRenderPipelineStateAtIndex(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineState, pipeline.NativePtr, index);
    }

    public void SetComputePipelineStateAtIndex(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineState, pipeline.NativePtr, index);
    }

    public void SetIndirectCommandBufferAtIndex(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffer, indirectCommandBuffer.NativePtr, index);
    }

    public void SetAccelerationStructureAtIndex(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetAccelerationStructure, accelerationStructure.NativePtr, index);
    }

    public MTLArgumentEncoder NewArgumentEncoderForBufferAtIndex(nuint index)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.NewArgumentEncoderForBufferAtIndex, index);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void SetVisibleFunctionTableAtIndex(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTable, visibleFunctionTable.NativePtr, index);
    }

    public void SetIntersectionFunctionTableAtIndex(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTable, intersectionFunctionTable.NativePtr, index);
    }

    public void SetDepthStencilStateAtIndex(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr, index);
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

    public static readonly Selector SetAccelerationStructure = "setAccelerationStructure:atIndex:";

    public static readonly Selector SetArgumentBuffer = "setArgumentBuffer:offset:";

    public static readonly Selector SetArgumentBufferstartOffsetarrayElement = "setArgumentBuffer:startOffset:arrayElement:";

    public static readonly Selector SetBuffer = "setBuffer:offset:atIndex:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:atIndex:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:atIndex:";

    public static readonly Selector SetIndirectCommandBuffer = "setIndirectCommandBuffer:atIndex:";

    public static readonly Selector SetIntersectionFunctionTable = "setIntersectionFunctionTable:atIndex:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:atIndex:";

    public static readonly Selector SetSamplerState = "setSamplerState:atIndex:";

    public static readonly Selector SetTexture = "setTexture:atIndex:";

    public static readonly Selector SetVisibleFunctionTable = "setVisibleFunctionTable:atIndex:";
}
