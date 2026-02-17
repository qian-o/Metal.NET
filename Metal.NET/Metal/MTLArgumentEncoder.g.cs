using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLArgumentEncoder_Selectors
{
    internal static readonly Selector constantData_ = Selector.Register("constantData:");
    internal static readonly Selector newArgumentEncoder_ = Selector.Register("newArgumentEncoder:");
    internal static readonly Selector setAccelerationStructure_index_ = Selector.Register("setAccelerationStructure:index:");
    internal static readonly Selector setArgumentBuffer_offset_ = Selector.Register("setArgumentBuffer:offset:");
    internal static readonly Selector setArgumentBuffer_startOffset_arrayElement_ = Selector.Register("setArgumentBuffer:startOffset:arrayElement:");
    internal static readonly Selector setBuffer_offset_index_ = Selector.Register("setBuffer:offset:index:");
    internal static readonly Selector setComputePipelineState_index_ = Selector.Register("setComputePipelineState:index:");
    internal static readonly Selector setDepthStencilState_index_ = Selector.Register("setDepthStencilState:index:");
    internal static readonly Selector setIndirectCommandBuffer_index_ = Selector.Register("setIndirectCommandBuffer:index:");
    internal static readonly Selector setIntersectionFunctionTable_index_ = Selector.Register("setIntersectionFunctionTable:index:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setRenderPipelineState_index_ = Selector.Register("setRenderPipelineState:index:");
    internal static readonly Selector setSamplerState_index_ = Selector.Register("setSamplerState:index:");
    internal static readonly Selector setTexture_index_ = Selector.Register("setTexture:index:");
    internal static readonly Selector setVisibleFunctionTable_index_ = Selector.Register("setVisibleFunctionTable:index:");
}

public class MTLArgumentEncoder : IDisposable
{
    public nint NativePtr { get; }

    public MTLArgumentEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLArgumentEncoder o) => o.NativePtr;
    public static implicit operator MTLArgumentEncoder(nint ptr) => new MTLArgumentEncoder(ptr);

    ~MTLArgumentEncoder() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public nint ConstantData(nuint index)
    {
        var __r = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.constantData_, (nint)index);
        return __r;
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint index)
    {
        var __r = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.newArgumentEncoder_, (nint)index));
        return __r;
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setAccelerationStructure_index_, accelerationStructure.NativePtr, (nint)index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setArgumentBuffer_offset_, argumentBuffer.NativePtr, (nint)offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setArgumentBuffer_startOffset_arrayElement_, argumentBuffer.NativePtr, (nint)startOffset, (nint)arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setComputePipelineState_index_, pipeline.NativePtr, (nint)index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setDepthStencilState_index_, depthStencilState.NativePtr, (nint)index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setIndirectCommandBuffer_index_, indirectCommandBuffer.NativePtr, (nint)index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setIntersectionFunctionTable_index_, intersectionFunctionTable.NativePtr, (nint)index);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setLabel_, label.NativePtr);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setRenderPipelineState_index_, pipeline.NativePtr, (nint)index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentEncoder_Selectors.setVisibleFunctionTable_index_, visibleFunctionTable.NativePtr, (nint)index);
    }

}
