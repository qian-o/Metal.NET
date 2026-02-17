using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIndirectCommandBufferDescriptor_Selectors
{
    internal static readonly Selector setCommandTypes_ = Selector.Register("setCommandTypes:");
    internal static readonly Selector setInheritBuffers_ = Selector.Register("setInheritBuffers:");
    internal static readonly Selector setInheritCullMode_ = Selector.Register("setInheritCullMode:");
    internal static readonly Selector setInheritDepthBias_ = Selector.Register("setInheritDepthBias:");
    internal static readonly Selector setInheritDepthClipMode_ = Selector.Register("setInheritDepthClipMode:");
    internal static readonly Selector setInheritDepthStencilState_ = Selector.Register("setInheritDepthStencilState:");
    internal static readonly Selector setInheritFrontFacingWinding_ = Selector.Register("setInheritFrontFacingWinding:");
    internal static readonly Selector setInheritPipelineState_ = Selector.Register("setInheritPipelineState:");
    internal static readonly Selector setInheritTriangleFillMode_ = Selector.Register("setInheritTriangleFillMode:");
    internal static readonly Selector setMaxFragmentBufferBindCount_ = Selector.Register("setMaxFragmentBufferBindCount:");
    internal static readonly Selector setMaxKernelBufferBindCount_ = Selector.Register("setMaxKernelBufferBindCount:");
    internal static readonly Selector setMaxKernelThreadgroupMemoryBindCount_ = Selector.Register("setMaxKernelThreadgroupMemoryBindCount:");
    internal static readonly Selector setMaxMeshBufferBindCount_ = Selector.Register("setMaxMeshBufferBindCount:");
    internal static readonly Selector setMaxObjectBufferBindCount_ = Selector.Register("setMaxObjectBufferBindCount:");
    internal static readonly Selector setMaxObjectThreadgroupMemoryBindCount_ = Selector.Register("setMaxObjectThreadgroupMemoryBindCount:");
    internal static readonly Selector setMaxVertexBufferBindCount_ = Selector.Register("setMaxVertexBufferBindCount:");
    internal static readonly Selector setSupportColorAttachmentMapping_ = Selector.Register("setSupportColorAttachmentMapping:");
    internal static readonly Selector setSupportDynamicAttributeStride_ = Selector.Register("setSupportDynamicAttributeStride:");
    internal static readonly Selector setSupportRayTracing_ = Selector.Register("setSupportRayTracing:");
}

public class MTLIndirectCommandBufferDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLIndirectCommandBufferDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIndirectCommandBufferDescriptor o) => o.NativePtr;
    public static implicit operator MTLIndirectCommandBufferDescriptor(nint ptr) => new MTLIndirectCommandBufferDescriptor(ptr);

    ~MTLIndirectCommandBufferDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLIndirectCommandBufferDescriptor");

    public static MTLIndirectCommandBufferDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLIndirectCommandBufferDescriptor(ptr);
    }

    public void SetCommandTypes(nuint commandTypes)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setCommandTypes_, (nint)commandTypes);
    }

    public void SetInheritBuffers(Bool8 inheritBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setInheritBuffers_, (nint)inheritBuffers.Value);
    }

    public void SetInheritCullMode(Bool8 inheritCullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setInheritCullMode_, (nint)inheritCullMode.Value);
    }

    public void SetInheritDepthBias(Bool8 inheritDepthBias)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setInheritDepthBias_, (nint)inheritDepthBias.Value);
    }

    public void SetInheritDepthClipMode(Bool8 inheritDepthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setInheritDepthClipMode_, (nint)inheritDepthClipMode.Value);
    }

    public void SetInheritDepthStencilState(Bool8 inheritDepthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setInheritDepthStencilState_, (nint)inheritDepthStencilState.Value);
    }

    public void SetInheritFrontFacingWinding(Bool8 inheritFrontFacingWinding)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setInheritFrontFacingWinding_, (nint)inheritFrontFacingWinding.Value);
    }

    public void SetInheritPipelineState(Bool8 inheritPipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setInheritPipelineState_, (nint)inheritPipelineState.Value);
    }

    public void SetInheritTriangleFillMode(Bool8 inheritTriangleFillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setInheritTriangleFillMode_, (nint)inheritTriangleFillMode.Value);
    }

    public void SetMaxFragmentBufferBindCount(nuint maxFragmentBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setMaxFragmentBufferBindCount_, (nint)maxFragmentBufferBindCount);
    }

    public void SetMaxKernelBufferBindCount(nuint maxKernelBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setMaxKernelBufferBindCount_, (nint)maxKernelBufferBindCount);
    }

    public void SetMaxKernelThreadgroupMemoryBindCount(nuint maxKernelThreadgroupMemoryBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setMaxKernelThreadgroupMemoryBindCount_, (nint)maxKernelThreadgroupMemoryBindCount);
    }

    public void SetMaxMeshBufferBindCount(nuint maxMeshBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setMaxMeshBufferBindCount_, (nint)maxMeshBufferBindCount);
    }

    public void SetMaxObjectBufferBindCount(nuint maxObjectBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setMaxObjectBufferBindCount_, (nint)maxObjectBufferBindCount);
    }

    public void SetMaxObjectThreadgroupMemoryBindCount(nuint maxObjectThreadgroupMemoryBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setMaxObjectThreadgroupMemoryBindCount_, (nint)maxObjectThreadgroupMemoryBindCount);
    }

    public void SetMaxVertexBufferBindCount(nuint maxVertexBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setMaxVertexBufferBindCount_, (nint)maxVertexBufferBindCount);
    }

    public void SetSupportColorAttachmentMapping(Bool8 supportColorAttachmentMapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setSupportColorAttachmentMapping_, (nint)supportColorAttachmentMapping.Value);
    }

    public void SetSupportDynamicAttributeStride(Bool8 supportDynamicAttributeStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setSupportDynamicAttributeStride_, (nint)supportDynamicAttributeStride.Value);
    }

    public void SetSupportRayTracing(Bool8 supportRayTracing)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptor_Selectors.setSupportRayTracing_, (nint)supportRayTracing.Value);
    }

}
