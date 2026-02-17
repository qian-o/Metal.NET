namespace Metal.NET;

file class MTLIndirectCommandBufferDescriptorSelector
{
    public static readonly Selector SetCommandTypes_ = Selector.Register("setCommandTypes:");
    public static readonly Selector SetInheritBuffers_ = Selector.Register("setInheritBuffers:");
    public static readonly Selector SetInheritCullMode_ = Selector.Register("setInheritCullMode:");
    public static readonly Selector SetInheritDepthBias_ = Selector.Register("setInheritDepthBias:");
    public static readonly Selector SetInheritDepthClipMode_ = Selector.Register("setInheritDepthClipMode:");
    public static readonly Selector SetInheritDepthStencilState_ = Selector.Register("setInheritDepthStencilState:");
    public static readonly Selector SetInheritFrontFacingWinding_ = Selector.Register("setInheritFrontFacingWinding:");
    public static readonly Selector SetInheritPipelineState_ = Selector.Register("setInheritPipelineState:");
    public static readonly Selector SetInheritTriangleFillMode_ = Selector.Register("setInheritTriangleFillMode:");
    public static readonly Selector SetMaxFragmentBufferBindCount_ = Selector.Register("setMaxFragmentBufferBindCount:");
    public static readonly Selector SetMaxKernelBufferBindCount_ = Selector.Register("setMaxKernelBufferBindCount:");
    public static readonly Selector SetMaxKernelThreadgroupMemoryBindCount_ = Selector.Register("setMaxKernelThreadgroupMemoryBindCount:");
    public static readonly Selector SetMaxMeshBufferBindCount_ = Selector.Register("setMaxMeshBufferBindCount:");
    public static readonly Selector SetMaxObjectBufferBindCount_ = Selector.Register("setMaxObjectBufferBindCount:");
    public static readonly Selector SetMaxObjectThreadgroupMemoryBindCount_ = Selector.Register("setMaxObjectThreadgroupMemoryBindCount:");
    public static readonly Selector SetMaxVertexBufferBindCount_ = Selector.Register("setMaxVertexBufferBindCount:");
    public static readonly Selector SetSupportColorAttachmentMapping_ = Selector.Register("setSupportColorAttachmentMapping:");
    public static readonly Selector SetSupportDynamicAttributeStride_ = Selector.Register("setSupportDynamicAttributeStride:");
    public static readonly Selector SetSupportRayTracing_ = Selector.Register("setSupportRayTracing:");
}

public class MTLIndirectCommandBufferDescriptor : IDisposable
{
    public MTLIndirectCommandBufferDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIndirectCommandBufferDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIndirectCommandBufferDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectCommandBufferDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLIndirectCommandBufferDescriptor");

    public static MTLIndirectCommandBufferDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLIndirectCommandBufferDescriptor(ptr);
    }

    public void SetCommandTypes(nuint commandTypes)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetCommandTypes_, (nint)commandTypes);
    }

    public void SetInheritBuffers(Bool8 inheritBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritBuffers_, (nint)inheritBuffers.Value);
    }

    public void SetInheritCullMode(Bool8 inheritCullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritCullMode_, (nint)inheritCullMode.Value);
    }

    public void SetInheritDepthBias(Bool8 inheritDepthBias)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthBias_, (nint)inheritDepthBias.Value);
    }

    public void SetInheritDepthClipMode(Bool8 inheritDepthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthClipMode_, (nint)inheritDepthClipMode.Value);
    }

    public void SetInheritDepthStencilState(Bool8 inheritDepthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthStencilState_, (nint)inheritDepthStencilState.Value);
    }

    public void SetInheritFrontFacingWinding(Bool8 inheritFrontFacingWinding)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritFrontFacingWinding_, (nint)inheritFrontFacingWinding.Value);
    }

    public void SetInheritPipelineState(Bool8 inheritPipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritPipelineState_, (nint)inheritPipelineState.Value);
    }

    public void SetInheritTriangleFillMode(Bool8 inheritTriangleFillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritTriangleFillMode_, (nint)inheritTriangleFillMode.Value);
    }

    public void SetMaxFragmentBufferBindCount(nuint maxFragmentBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxFragmentBufferBindCount_, (nint)maxFragmentBufferBindCount);
    }

    public void SetMaxKernelBufferBindCount(nuint maxKernelBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxKernelBufferBindCount_, (nint)maxKernelBufferBindCount);
    }

    public void SetMaxKernelThreadgroupMemoryBindCount(nuint maxKernelThreadgroupMemoryBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxKernelThreadgroupMemoryBindCount_, (nint)maxKernelThreadgroupMemoryBindCount);
    }

    public void SetMaxMeshBufferBindCount(nuint maxMeshBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxMeshBufferBindCount_, (nint)maxMeshBufferBindCount);
    }

    public void SetMaxObjectBufferBindCount(nuint maxObjectBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxObjectBufferBindCount_, (nint)maxObjectBufferBindCount);
    }

    public void SetMaxObjectThreadgroupMemoryBindCount(nuint maxObjectThreadgroupMemoryBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxObjectThreadgroupMemoryBindCount_, (nint)maxObjectThreadgroupMemoryBindCount);
    }

    public void SetMaxVertexBufferBindCount(nuint maxVertexBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxVertexBufferBindCount_, (nint)maxVertexBufferBindCount);
    }

    public void SetSupportColorAttachmentMapping(Bool8 supportColorAttachmentMapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportColorAttachmentMapping_, (nint)supportColorAttachmentMapping.Value);
    }

    public void SetSupportDynamicAttributeStride(Bool8 supportDynamicAttributeStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportDynamicAttributeStride_, (nint)supportDynamicAttributeStride.Value);
    }

    public void SetSupportRayTracing(Bool8 supportRayTracing)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportRayTracing_, (nint)supportRayTracing.Value);
    }

}
