namespace Metal.NET;

public class MTLArgumentEncoder(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLArgumentEncoder>
{
    public static MTLArgumentEncoder Null => Create(0, false);
    public static MTLArgumentEncoder Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public nuint Alignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderBindings.Alignment);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLArgumentEncoderBindings.Device);
    }

    public nuint EncodedLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderBindings.EncodedLength);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLArgumentEncoderBindings.Label);
        set => SetProperty(ref field, MTLArgumentEncoderBindings.SetLabel, value);
    }

    public nint ConstantData(nuint index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderBindings.ConstantData, index);
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint index)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderBindings.NewArgumentEncoder, index);

        return new(nativePtr, true);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetAccelerationStructure, accelerationStructure.NativePtr, index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBuffer, argumentBuffer.NativePtr, offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBufferstartOffsetarrayElement, argumentBuffer.NativePtr, startOffset, arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetBuffer, buffer.NativePtr, offset, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineState, pipeline.NativePtr, index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr, index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffer, indirectCommandBuffer.NativePtr, index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTable, intersectionFunctionTable.NativePtr, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineState, pipeline.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerState, sampler.NativePtr, index);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTexture, texture.NativePtr, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTable, visibleFunctionTable.NativePtr, index);
    }
}

file static class MTLArgumentEncoderBindings
{
    public static readonly Selector Alignment = "alignment";

    public static readonly Selector ConstantData = "constantDataAtIndex:";

    public static readonly Selector Device = "device";

    public static readonly Selector EncodedLength = "encodedLength";

    public static readonly Selector Label = "label";

    public static readonly Selector NewArgumentEncoder = "newArgumentEncoderForBufferAtIndex:";

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
