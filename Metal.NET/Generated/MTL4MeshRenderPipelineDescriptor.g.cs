using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4MeshRenderPipelineDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setAlphaToCoverageState_ = Selector.Register("setAlphaToCoverageState:");
    internal static readonly Selector setAlphaToOneState_ = Selector.Register("setAlphaToOneState:");
    internal static readonly Selector setColorAttachmentMappingState_ = Selector.Register("setColorAttachmentMappingState:");
    internal static readonly Selector setFragmentFunctionDescriptor_ = Selector.Register("setFragmentFunctionDescriptor:");
    internal static readonly Selector setFragmentStaticLinkingDescriptor_ = Selector.Register("setFragmentStaticLinkingDescriptor:");
    internal static readonly Selector setMaxTotalThreadgroupsPerMeshGrid_ = Selector.Register("setMaxTotalThreadgroupsPerMeshGrid:");
    internal static readonly Selector setMaxTotalThreadsPerMeshThreadgroup_ = Selector.Register("setMaxTotalThreadsPerMeshThreadgroup:");
    internal static readonly Selector setMaxTotalThreadsPerObjectThreadgroup_ = Selector.Register("setMaxTotalThreadsPerObjectThreadgroup:");
    internal static readonly Selector setMaxVertexAmplificationCount_ = Selector.Register("setMaxVertexAmplificationCount:");
    internal static readonly Selector setMeshFunctionDescriptor_ = Selector.Register("setMeshFunctionDescriptor:");
    internal static readonly Selector setMeshStaticLinkingDescriptor_ = Selector.Register("setMeshStaticLinkingDescriptor:");
    internal static readonly Selector setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth_ = Selector.Register("setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:");
    internal static readonly Selector setObjectFunctionDescriptor_ = Selector.Register("setObjectFunctionDescriptor:");
    internal static readonly Selector setObjectStaticLinkingDescriptor_ = Selector.Register("setObjectStaticLinkingDescriptor:");
    internal static readonly Selector setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth_ = Selector.Register("setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:");
    internal static readonly Selector setPayloadMemoryLength_ = Selector.Register("setPayloadMemoryLength:");
    internal static readonly Selector setRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    internal static readonly Selector setRasterizationEnabled_ = Selector.Register("setRasterizationEnabled:");
    internal static readonly Selector setRequiredThreadsPerMeshThreadgroup_ = Selector.Register("setRequiredThreadsPerMeshThreadgroup:");
    internal static readonly Selector setRequiredThreadsPerObjectThreadgroup_ = Selector.Register("setRequiredThreadsPerObjectThreadgroup:");
    internal static readonly Selector setSupportFragmentBinaryLinking_ = Selector.Register("setSupportFragmentBinaryLinking:");
    internal static readonly Selector setSupportIndirectCommandBuffers_ = Selector.Register("setSupportIndirectCommandBuffers:");
    internal static readonly Selector setSupportMeshBinaryLinking_ = Selector.Register("setSupportMeshBinaryLinking:");
    internal static readonly Selector setSupportObjectBinaryLinking_ = Selector.Register("setSupportObjectBinaryLinking:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4MeshRenderPipelineDescriptor
{
    public readonly nint NativePtr;

    public MTL4MeshRenderPipelineDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4MeshRenderPipelineDescriptor o) => o.NativePtr;
    public static implicit operator MTL4MeshRenderPipelineDescriptor(nint ptr) => new MTL4MeshRenderPipelineDescriptor(ptr);

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.reset);
    }

    public void SetAlphaToCoverageState(MTL4AlphaToCoverageState alphaToCoverageState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setAlphaToCoverageState_, (nint)(uint)alphaToCoverageState);
    }

    public void SetAlphaToOneState(MTL4AlphaToOneState alphaToOneState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setAlphaToOneState_, (nint)(uint)alphaToOneState);
    }

    public void SetColorAttachmentMappingState(MTL4LogicalToPhysicalColorAttachmentMappingState colorAttachmentMappingState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setColorAttachmentMappingState_, (nint)(uint)colorAttachmentMappingState);
    }

    public void SetFragmentFunctionDescriptor(MTL4FunctionDescriptor fragmentFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setFragmentFunctionDescriptor_, fragmentFunctionDescriptor.NativePtr);
    }

    public void SetFragmentStaticLinkingDescriptor(MTL4StaticLinkingDescriptor fragmentStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setFragmentStaticLinkingDescriptor_, fragmentStaticLinkingDescriptor.NativePtr);
    }

    public void SetMaxTotalThreadgroupsPerMeshGrid(nuint maxTotalThreadgroupsPerMeshGrid)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setMaxTotalThreadgroupsPerMeshGrid_, (nint)maxTotalThreadgroupsPerMeshGrid);
    }

    public void SetMaxTotalThreadsPerMeshThreadgroup(nuint maxTotalThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setMaxTotalThreadsPerMeshThreadgroup_, (nint)maxTotalThreadsPerMeshThreadgroup);
    }

    public void SetMaxTotalThreadsPerObjectThreadgroup(nuint maxTotalThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setMaxTotalThreadsPerObjectThreadgroup_, (nint)maxTotalThreadsPerObjectThreadgroup);
    }

    public void SetMaxVertexAmplificationCount(nuint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setMaxVertexAmplificationCount_, (nint)maxVertexAmplificationCount);
    }

    public void SetMeshFunctionDescriptor(MTL4FunctionDescriptor meshFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setMeshFunctionDescriptor_, meshFunctionDescriptor.NativePtr);
    }

    public void SetMeshStaticLinkingDescriptor(MTL4StaticLinkingDescriptor meshStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setMeshStaticLinkingDescriptor_, meshStaticLinkingDescriptor.NativePtr);
    }

    public void SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 meshThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth_, (nint)meshThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetObjectFunctionDescriptor(MTL4FunctionDescriptor objectFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setObjectFunctionDescriptor_, objectFunctionDescriptor.NativePtr);
    }

    public void SetObjectStaticLinkingDescriptor(MTL4StaticLinkingDescriptor objectStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setObjectStaticLinkingDescriptor_, objectStaticLinkingDescriptor.NativePtr);
    }

    public void SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 objectThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth_, (nint)objectThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetPayloadMemoryLength(nuint payloadMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setPayloadMemoryLength_, (nint)payloadMemoryLength);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setRasterizationEnabled_, (nint)rasterizationEnabled.Value);
    }

    public void SetRequiredThreadsPerMeshThreadgroup(MTLSize requiredThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setRequiredThreadsPerMeshThreadgroup_, requiredThreadsPerMeshThreadgroup);
    }

    public void SetRequiredThreadsPerObjectThreadgroup(MTLSize requiredThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setRequiredThreadsPerObjectThreadgroup_, requiredThreadsPerObjectThreadgroup);
    }

    public void SetSupportFragmentBinaryLinking(Bool8 supportFragmentBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setSupportFragmentBinaryLinking_, (nint)supportFragmentBinaryLinking.Value);
    }

    public void SetSupportIndirectCommandBuffers(MTL4IndirectCommandBufferSupportState supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setSupportIndirectCommandBuffers_, (nint)(uint)supportIndirectCommandBuffers);
    }

    public void SetSupportMeshBinaryLinking(Bool8 supportMeshBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setSupportMeshBinaryLinking_, (nint)supportMeshBinaryLinking.Value);
    }

    public void SetSupportObjectBinaryLinking(Bool8 supportObjectBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptor_Selectors.setSupportObjectBinaryLinking_, (nint)supportObjectBinaryLinking.Value);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
