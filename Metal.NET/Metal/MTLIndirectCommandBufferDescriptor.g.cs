namespace Metal.NET;

public class MTLIndirectCommandBufferDescriptor : IDisposable
{
    public MTLIndirectCommandBufferDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetCommandTypes(uint commandTypes)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetCommandTypes, (nint)commandTypes);
    }

    public void SetInheritBuffers(Bool8 inheritBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritBuffers, (nint)inheritBuffers.Value);
    }

    public void SetInheritCullMode(Bool8 inheritCullMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritCullMode, (nint)inheritCullMode.Value);
    }

    public void SetInheritDepthBias(Bool8 inheritDepthBias)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthBias, (nint)inheritDepthBias.Value);
    }

    public void SetInheritDepthClipMode(Bool8 inheritDepthClipMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthClipMode, (nint)inheritDepthClipMode.Value);
    }

    public void SetInheritDepthStencilState(Bool8 inheritDepthStencilState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthStencilState, (nint)inheritDepthStencilState.Value);
    }

    public void SetInheritFrontFacingWinding(Bool8 inheritFrontFacingWinding)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritFrontFacingWinding, (nint)inheritFrontFacingWinding.Value);
    }

    public void SetInheritPipelineState(Bool8 inheritPipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritPipelineState, (nint)inheritPipelineState.Value);
    }

    public void SetInheritTriangleFillMode(Bool8 inheritTriangleFillMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritTriangleFillMode, (nint)inheritTriangleFillMode.Value);
    }

    public void SetMaxFragmentBufferBindCount(uint maxFragmentBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxFragmentBufferBindCount, (nint)maxFragmentBufferBindCount);
    }

    public void SetMaxKernelBufferBindCount(uint maxKernelBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxKernelBufferBindCount, (nint)maxKernelBufferBindCount);
    }

    public void SetMaxKernelThreadgroupMemoryBindCount(uint maxKernelThreadgroupMemoryBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxKernelThreadgroupMemoryBindCount, (nint)maxKernelThreadgroupMemoryBindCount);
    }

    public void SetMaxMeshBufferBindCount(uint maxMeshBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxMeshBufferBindCount, (nint)maxMeshBufferBindCount);
    }

    public void SetMaxObjectBufferBindCount(uint maxObjectBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxObjectBufferBindCount, (nint)maxObjectBufferBindCount);
    }

    public void SetMaxObjectThreadgroupMemoryBindCount(uint maxObjectThreadgroupMemoryBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxObjectThreadgroupMemoryBindCount, (nint)maxObjectThreadgroupMemoryBindCount);
    }

    public void SetMaxVertexBufferBindCount(uint maxVertexBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxVertexBufferBindCount, (nint)maxVertexBufferBindCount);
    }

    public void SetSupportColorAttachmentMapping(Bool8 supportColorAttachmentMapping)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportColorAttachmentMapping, (nint)supportColorAttachmentMapping.Value);
    }

    public void SetSupportDynamicAttributeStride(Bool8 supportDynamicAttributeStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportDynamicAttributeStride, (nint)supportDynamicAttributeStride.Value);
    }

    public void SetSupportRayTracing(Bool8 supportRayTracing)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportRayTracing, (nint)supportRayTracing.Value);
    }

}

file class MTLIndirectCommandBufferDescriptorSelector
{
    public static readonly Selector SetCommandTypes = Selector.Register("setCommandTypes:");
    public static readonly Selector SetInheritBuffers = Selector.Register("setInheritBuffers:");
    public static readonly Selector SetInheritCullMode = Selector.Register("setInheritCullMode:");
    public static readonly Selector SetInheritDepthBias = Selector.Register("setInheritDepthBias:");
    public static readonly Selector SetInheritDepthClipMode = Selector.Register("setInheritDepthClipMode:");
    public static readonly Selector SetInheritDepthStencilState = Selector.Register("setInheritDepthStencilState:");
    public static readonly Selector SetInheritFrontFacingWinding = Selector.Register("setInheritFrontFacingWinding:");
    public static readonly Selector SetInheritPipelineState = Selector.Register("setInheritPipelineState:");
    public static readonly Selector SetInheritTriangleFillMode = Selector.Register("setInheritTriangleFillMode:");
    public static readonly Selector SetMaxFragmentBufferBindCount = Selector.Register("setMaxFragmentBufferBindCount:");
    public static readonly Selector SetMaxKernelBufferBindCount = Selector.Register("setMaxKernelBufferBindCount:");
    public static readonly Selector SetMaxKernelThreadgroupMemoryBindCount = Selector.Register("setMaxKernelThreadgroupMemoryBindCount:");
    public static readonly Selector SetMaxMeshBufferBindCount = Selector.Register("setMaxMeshBufferBindCount:");
    public static readonly Selector SetMaxObjectBufferBindCount = Selector.Register("setMaxObjectBufferBindCount:");
    public static readonly Selector SetMaxObjectThreadgroupMemoryBindCount = Selector.Register("setMaxObjectThreadgroupMemoryBindCount:");
    public static readonly Selector SetMaxVertexBufferBindCount = Selector.Register("setMaxVertexBufferBindCount:");
    public static readonly Selector SetSupportColorAttachmentMapping = Selector.Register("setSupportColorAttachmentMapping:");
    public static readonly Selector SetSupportDynamicAttributeStride = Selector.Register("setSupportDynamicAttributeStride:");
    public static readonly Selector SetSupportRayTracing = Selector.Register("setSupportRayTracing:");
}
