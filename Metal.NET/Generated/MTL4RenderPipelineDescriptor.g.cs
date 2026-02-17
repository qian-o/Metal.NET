using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4RenderPipelineDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setAlphaToCoverageState_ = Selector.Register("setAlphaToCoverageState:");
    internal static readonly Selector setAlphaToOneState_ = Selector.Register("setAlphaToOneState:");
    internal static readonly Selector setColorAttachmentMappingState_ = Selector.Register("setColorAttachmentMappingState:");
    internal static readonly Selector setFragmentFunctionDescriptor_ = Selector.Register("setFragmentFunctionDescriptor:");
    internal static readonly Selector setFragmentStaticLinkingDescriptor_ = Selector.Register("setFragmentStaticLinkingDescriptor:");
    internal static readonly Selector setInputPrimitiveTopology_ = Selector.Register("setInputPrimitiveTopology:");
    internal static readonly Selector setMaxVertexAmplificationCount_ = Selector.Register("setMaxVertexAmplificationCount:");
    internal static readonly Selector setRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    internal static readonly Selector setRasterizationEnabled_ = Selector.Register("setRasterizationEnabled:");
    internal static readonly Selector setSupportFragmentBinaryLinking_ = Selector.Register("setSupportFragmentBinaryLinking:");
    internal static readonly Selector setSupportIndirectCommandBuffers_ = Selector.Register("setSupportIndirectCommandBuffers:");
    internal static readonly Selector setSupportVertexBinaryLinking_ = Selector.Register("setSupportVertexBinaryLinking:");
    internal static readonly Selector setVertexDescriptor_ = Selector.Register("setVertexDescriptor:");
    internal static readonly Selector setVertexFunctionDescriptor_ = Selector.Register("setVertexFunctionDescriptor:");
    internal static readonly Selector setVertexStaticLinkingDescriptor_ = Selector.Register("setVertexStaticLinkingDescriptor:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4RenderPipelineDescriptor
{
    public readonly nint NativePtr;

    public MTL4RenderPipelineDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4RenderPipelineDescriptor o) => o.NativePtr;
    public static implicit operator MTL4RenderPipelineDescriptor(nint ptr) => new MTL4RenderPipelineDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDescriptor");

    public static MTL4RenderPipelineDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTL4RenderPipelineDescriptor(ptr);
    }

    public MTL4RenderPipelineDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTL4RenderPipelineDescriptor(ptr);
    }

    public static MTL4RenderPipelineDescriptor New()
    {
        return Alloc().Init();
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.reset);
    }

    public void SetAlphaToCoverageState(MTL4AlphaToCoverageState alphaToCoverageState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setAlphaToCoverageState_, (nint)(uint)alphaToCoverageState);
    }

    public void SetAlphaToOneState(MTL4AlphaToOneState alphaToOneState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setAlphaToOneState_, (nint)(uint)alphaToOneState);
    }

    public void SetColorAttachmentMappingState(MTL4LogicalToPhysicalColorAttachmentMappingState colorAttachmentMappingState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setColorAttachmentMappingState_, (nint)(uint)colorAttachmentMappingState);
    }

    public void SetFragmentFunctionDescriptor(MTL4FunctionDescriptor fragmentFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setFragmentFunctionDescriptor_, fragmentFunctionDescriptor.NativePtr);
    }

    public void SetFragmentStaticLinkingDescriptor(MTL4StaticLinkingDescriptor fragmentStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setFragmentStaticLinkingDescriptor_, fragmentStaticLinkingDescriptor.NativePtr);
    }

    public void SetInputPrimitiveTopology(MTLPrimitiveTopologyClass inputPrimitiveTopology)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setInputPrimitiveTopology_, (nint)(uint)inputPrimitiveTopology);
    }

    public void SetMaxVertexAmplificationCount(nuint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setMaxVertexAmplificationCount_, (nint)maxVertexAmplificationCount);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setRasterizationEnabled_, (nint)rasterizationEnabled.Value);
    }

    public void SetSupportFragmentBinaryLinking(Bool8 supportFragmentBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setSupportFragmentBinaryLinking_, (nint)supportFragmentBinaryLinking.Value);
    }

    public void SetSupportIndirectCommandBuffers(MTL4IndirectCommandBufferSupportState supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setSupportIndirectCommandBuffers_, (nint)(uint)supportIndirectCommandBuffers);
    }

    public void SetSupportVertexBinaryLinking(Bool8 supportVertexBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setSupportVertexBinaryLinking_, (nint)supportVertexBinaryLinking.Value);
    }

    public void SetVertexDescriptor(MTLVertexDescriptor vertexDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setVertexDescriptor_, vertexDescriptor.NativePtr);
    }

    public void SetVertexFunctionDescriptor(MTL4FunctionDescriptor vertexFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setVertexFunctionDescriptor_, vertexFunctionDescriptor.NativePtr);
    }

    public void SetVertexStaticLinkingDescriptor(MTL4StaticLinkingDescriptor vertexStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptor_Selectors.setVertexStaticLinkingDescriptor_, vertexStaticLinkingDescriptor.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
