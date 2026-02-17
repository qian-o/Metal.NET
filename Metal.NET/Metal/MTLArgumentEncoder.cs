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

    public nuint Alignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderSelector.Alignment);
    }

    public MTLDevice Device
    {
        get => new MTLDevice(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.Device));
    }

    public nuint EncodedLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderSelector.EncodedLength);
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetLabel, value.NativePtr);
    }

    public nint ConstantData(uint index)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.ConstantData, (nuint)index);

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(uint index)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.NewArgumentEncoder, (nuint)index));

        return result;
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetAccelerationStructureIndex, accelerationStructure.NativePtr, (nuint)index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, uint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBufferOffset, argumentBuffer.NativePtr, (nuint)offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, uint startOffset, uint arrayElement)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBufferStartOffsetArrayElement, argumentBuffer.NativePtr, (nuint)startOffset, (nuint)arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetComputePipelineStateIndex, pipeline.NativePtr, (nuint)index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetDepthStencilStateIndex, depthStencilState.NativePtr, (nuint)index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetIndirectCommandBufferIndex, indirectCommandBuffer.NativePtr, (nuint)index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetIntersectionFunctionTableIndex, intersectionFunctionTable.NativePtr, (nuint)index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetRenderPipelineStateIndex, pipeline.NativePtr, (nuint)index);
    }

    public void SetSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetSamplerStateIndex, sampler.NativePtr, (nuint)index);
    }

    public void SetTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetTextureIndex, texture.NativePtr, (nuint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetVisibleFunctionTableIndex, visibleFunctionTable.NativePtr, (nuint)index);
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
