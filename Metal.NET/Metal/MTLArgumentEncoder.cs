namespace Metal.NET;

public class MTLArgumentEncoder : IDisposable
{
    public MTLArgumentEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLArgumentEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Alignment => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderSelector.Alignment);

    public MTLDevice Device => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.Device));

    public nuint EncodedLength => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderSelector.EncodedLength);

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetLabel, value.NativePtr);
    }

    public nint ConstantData(nuint index)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.ConstantData, index);

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint index)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.NewArgumentEncoder, index));

        return result;
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetAccelerationStructureIndex, accelerationStructure.NativePtr, index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBufferOffset, argumentBuffer.NativePtr, offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBufferStartOffsetArrayElement, argumentBuffer.NativePtr, startOffset, arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetBufferOffsetIndex, buffer.NativePtr, offset, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetComputePipelineStateIndex, pipeline.NativePtr, index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetDepthStencilStateIndex, depthStencilState.NativePtr, index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetIndirectCommandBufferIndex, indirectCommandBuffer.NativePtr, index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetIntersectionFunctionTableIndex, intersectionFunctionTable.NativePtr, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetRenderPipelineStateIndex, pipeline.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetSamplerStateIndex, sampler.NativePtr, index);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetTextureIndex, texture.NativePtr, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetVisibleFunctionTableIndex, visibleFunctionTable.NativePtr, index);
    }

    public static implicit operator nint(MTLArgumentEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArgumentEncoder(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLArgumentEncoderSelector
{
    public static readonly Selector Alignment = Selector.Register("alignment");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EncodedLength = Selector.Register("encodedLength");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector ConstantData = Selector.Register("constantData:");

    public static readonly Selector NewArgumentEncoder = Selector.Register("newArgumentEncoder:");

    public static readonly Selector SetAccelerationStructureIndex = Selector.Register("setAccelerationStructure:index:");

    public static readonly Selector SetArgumentBufferOffset = Selector.Register("setArgumentBuffer:offset:");

    public static readonly Selector SetArgumentBufferStartOffsetArrayElement = Selector.Register("setArgumentBuffer:startOffset:arrayElement:");

    public static readonly Selector SetBufferOffsetIndex = Selector.Register("setBuffer:offset:index:");

    public static readonly Selector SetComputePipelineStateIndex = Selector.Register("setComputePipelineState:index:");

    public static readonly Selector SetDepthStencilStateIndex = Selector.Register("setDepthStencilState:index:");

    public static readonly Selector SetIndirectCommandBufferIndex = Selector.Register("setIndirectCommandBuffer:index:");

    public static readonly Selector SetIntersectionFunctionTableIndex = Selector.Register("setIntersectionFunctionTable:index:");

    public static readonly Selector SetRenderPipelineStateIndex = Selector.Register("setRenderPipelineState:index:");

    public static readonly Selector SetSamplerStateIndex = Selector.Register("setSamplerState:index:");

    public static readonly Selector SetTextureIndex = Selector.Register("setTexture:index:");

    public static readonly Selector SetVisibleFunctionTableIndex = Selector.Register("setVisibleFunctionTable:index:");
}
