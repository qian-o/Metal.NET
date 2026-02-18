namespace Metal.NET;

public partial class MTLArgumentEncoder : NativeObject
{
    public MTLArgumentEncoder(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint Alignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderSelector.Alignment);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint EncodedLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderSelector.EncodedLength);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nint ConstantData(nuint index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.ConstantData, index);
    }

    public MTLArgumentEncoder? NewArgumentEncoder(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.NewArgumentEncoder, index);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetAccelerationStructure, accelerationStructure.NativePtr, index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBuffer, argumentBuffer.NativePtr, offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBuffer, argumentBuffer.NativePtr, startOffset, arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetBuffer, buffer.NativePtr, offset, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetComputePipelineState, pipeline.NativePtr, index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetDepthStencilState, depthStencilState.NativePtr, index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetIndirectCommandBuffer, indirectCommandBuffer.NativePtr, index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetIntersectionFunctionTable, intersectionFunctionTable.NativePtr, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetRenderPipelineState, pipeline.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetSamplerState, sampler.NativePtr, index);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetTexture, texture.NativePtr, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetVisibleFunctionTable, visibleFunctionTable.NativePtr, index);
    }
}

file static class MTLArgumentEncoderSelector
{
    public static readonly Selector Alignment = Selector.Register("alignment");

    public static readonly Selector ConstantData = Selector.Register("constantDataAtIndex:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EncodedLength = Selector.Register("encodedLength");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector NewArgumentEncoder = Selector.Register("newArgumentEncoderForBufferAtIndex:");

    public static readonly Selector SetAccelerationStructure = Selector.Register("setAccelerationStructure:atIndex:");

    public static readonly Selector SetArgumentBuffer = Selector.Register("setArgumentBuffer:offset:");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:offset:atIndex:");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:atIndex:");

    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:atIndex:");

    public static readonly Selector SetIndirectCommandBuffer = Selector.Register("setIndirectCommandBuffer:atIndex:");

    public static readonly Selector SetIntersectionFunctionTable = Selector.Register("setIntersectionFunctionTable:atIndex:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:atIndex:");

    public static readonly Selector SetSamplerState = Selector.Register("setSamplerState:atIndex:");

    public static readonly Selector SetTexture = Selector.Register("setTexture:atIndex:");

    public static readonly Selector SetVisibleFunctionTable = Selector.Register("setVisibleFunctionTable:atIndex:");
}
