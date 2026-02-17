namespace Metal.NET;

file class MTLArgumentEncoderSelector
{
    public static readonly Selector ConstantData_ = Selector.Register("constantData:");
    public static readonly Selector NewArgumentEncoder_ = Selector.Register("newArgumentEncoder:");
    public static readonly Selector SetAccelerationStructure_index_ = Selector.Register("setAccelerationStructure:index:");
    public static readonly Selector SetArgumentBuffer_offset_ = Selector.Register("setArgumentBuffer:offset:");
    public static readonly Selector SetArgumentBuffer_startOffset_arrayElement_ = Selector.Register("setArgumentBuffer:startOffset:arrayElement:");
    public static readonly Selector SetBuffer_offset_index_ = Selector.Register("setBuffer:offset:index:");
    public static readonly Selector SetComputePipelineState_index_ = Selector.Register("setComputePipelineState:index:");
    public static readonly Selector SetDepthStencilState_index_ = Selector.Register("setDepthStencilState:index:");
    public static readonly Selector SetIndirectCommandBuffer_index_ = Selector.Register("setIndirectCommandBuffer:index:");
    public static readonly Selector SetIntersectionFunctionTable_index_ = Selector.Register("setIntersectionFunctionTable:index:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetRenderPipelineState_index_ = Selector.Register("setRenderPipelineState:index:");
    public static readonly Selector SetSamplerState_index_ = Selector.Register("setSamplerState:index:");
    public static readonly Selector SetTexture_index_ = Selector.Register("setTexture:index:");
    public static readonly Selector SetVisibleFunctionTable_index_ = Selector.Register("setVisibleFunctionTable:index:");
}

public class MTLArgumentEncoder : IDisposable
{
    public MTLArgumentEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public nint ConstantData(nuint index)
    {
        var result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLArgumentEncoderSelector.ConstantData_, (nint)index);

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint index)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLArgumentEncoderSelector.NewArgumentEncoder_, (nint)index));

        return result;
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetAccelerationStructure_index_, accelerationStructure.NativePtr, (nint)index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBuffer_offset_, argumentBuffer.NativePtr, (nint)offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBuffer_startOffset_arrayElement_, argumentBuffer.NativePtr, (nint)startOffset, (nint)arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetComputePipelineState_index_, pipeline.NativePtr, (nint)index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetDepthStencilState_index_, depthStencilState.NativePtr, (nint)index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetIndirectCommandBuffer_index_, indirectCommandBuffer.NativePtr, (nint)index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetIntersectionFunctionTable_index_, intersectionFunctionTable.NativePtr, (nint)index);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetLabel_, label.NativePtr);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetRenderPipelineState_index_, pipeline.NativePtr, (nint)index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetVisibleFunctionTable_index_, visibleFunctionTable.NativePtr, (nint)index);
    }

}
