namespace Metal.NET;

public class MTLArgumentEncoder : IDisposable
{
    public MTLArgumentEncoder(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLArgumentEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Alignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderSelector.Alignment);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.Device));
    }

    public nuint EncodedLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderSelector.EncodedLength);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetLabel, value.NativePtr);
    }

    public nint ConstantData(nuint index)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.ConstantDataAtIndex, index);

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint index)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderSelector.NewArgumentEncoderForBufferAtIndex, index));

        return result;
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetAccelerationStructureAtIndex, accelerationStructure.NativePtr, index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBufferStartOffsetArrayElement, argumentBuffer.NativePtr, offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBufferStartOffsetArrayElement, argumentBuffer.NativePtr, startOffset, arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetComputePipelineStateAtIndex, pipeline.NativePtr, index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetDepthStencilStateAtIndex, depthStencilState.NativePtr, index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetIndirectCommandBufferAtIndex, indirectCommandBuffer.NativePtr, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetRenderPipelineStateAtIndex, pipeline.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetSamplerStateAtIndex, sampler.NativePtr, index);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderSelector.SetTextureAtIndex, texture.NativePtr, index);
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

    public static readonly Selector ConstantDataAtIndex = Selector.Register("constantDataAtIndex:");

    public static readonly Selector NewArgumentEncoderForBufferAtIndex = Selector.Register("newArgumentEncoderForBufferAtIndex:");

    public static readonly Selector SetAccelerationStructureAtIndex = Selector.Register("setAccelerationStructure:atIndex:");

    public static readonly Selector SetArgumentBufferStartOffsetArrayElement = Selector.Register("setArgumentBuffer:startOffset:arrayElement:");

    public static readonly Selector SetBufferOffsetAtIndex = Selector.Register("setBuffer:offset:atIndex:");

    public static readonly Selector SetComputePipelineStateAtIndex = Selector.Register("setComputePipelineState:atIndex:");

    public static readonly Selector SetDepthStencilStateAtIndex = Selector.Register("setDepthStencilState:atIndex:");

    public static readonly Selector SetIndirectCommandBufferAtIndex = Selector.Register("setIndirectCommandBuffer:atIndex:");

    public static readonly Selector SetRenderPipelineStateAtIndex = Selector.Register("setRenderPipelineState:atIndex:");

    public static readonly Selector SetSamplerStateAtIndex = Selector.Register("setSamplerState:atIndex:");

    public static readonly Selector SetTextureAtIndex = Selector.Register("setTexture:atIndex:");
}
