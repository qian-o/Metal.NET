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

    public nint ConstantData(uint index)
    {
        var result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLArgumentEncoderSelector.ConstantData, (nint)index);

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(uint index)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLArgumentEncoderSelector.NewArgumentEncoder, (nint)index));

        return result;
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetAccelerationStructureIndex, accelerationStructure.NativePtr, (nint)index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, uint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBufferOffset, argumentBuffer.NativePtr, (nint)offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, uint startOffset, uint arrayElement)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetArgumentBufferStartOffsetArrayElement, argumentBuffer.NativePtr, (nint)startOffset, (nint)arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetComputePipelineStateIndex, pipeline.NativePtr, (nint)index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetDepthStencilStateIndex, depthStencilState.NativePtr, (nint)index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetIndirectCommandBufferIndex, indirectCommandBuffer.NativePtr, (nint)index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetIntersectionFunctionTableIndex, intersectionFunctionTable.NativePtr, (nint)index);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetLabel, label.NativePtr);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetRenderPipelineStateIndex, pipeline.NativePtr, (nint)index);
    }

    public void SetSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetSamplerStateIndex, sampler.NativePtr, (nint)index);
    }

    public void SetTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetTextureIndex, texture.NativePtr, (nint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoderSelector.SetVisibleFunctionTableIndex, visibleFunctionTable.NativePtr, (nint)index);
    }

}

file class MTLArgumentEncoderSelector
{
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
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector SetRenderPipelineStateIndex = Selector.Register("setRenderPipelineState:index:");
    public static readonly Selector SetSamplerStateIndex = Selector.Register("setSamplerState:index:");
    public static readonly Selector SetTextureIndex = Selector.Register("setTexture:index:");
    public static readonly Selector SetVisibleFunctionTableIndex = Selector.Register("setVisibleFunctionTable:index:");
}
