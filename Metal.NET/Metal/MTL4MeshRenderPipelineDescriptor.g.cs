namespace Metal.NET;

file class MTL4MeshRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetAlphaToCoverageState_ = Selector.Register("setAlphaToCoverageState:");
    public static readonly Selector SetAlphaToOneState_ = Selector.Register("setAlphaToOneState:");
    public static readonly Selector SetColorAttachmentMappingState_ = Selector.Register("setColorAttachmentMappingState:");
    public static readonly Selector SetFragmentFunctionDescriptor_ = Selector.Register("setFragmentFunctionDescriptor:");
    public static readonly Selector SetFragmentStaticLinkingDescriptor_ = Selector.Register("setFragmentStaticLinkingDescriptor:");
    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid_ = Selector.Register("setMaxTotalThreadgroupsPerMeshGrid:");
    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup_ = Selector.Register("setMaxTotalThreadsPerMeshThreadgroup:");
    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup_ = Selector.Register("setMaxTotalThreadsPerObjectThreadgroup:");
    public static readonly Selector SetMaxVertexAmplificationCount_ = Selector.Register("setMaxVertexAmplificationCount:");
    public static readonly Selector SetMeshFunctionDescriptor_ = Selector.Register("setMeshFunctionDescriptor:");
    public static readonly Selector SetMeshStaticLinkingDescriptor_ = Selector.Register("setMeshStaticLinkingDescriptor:");
    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth_ = Selector.Register("setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:");
    public static readonly Selector SetObjectFunctionDescriptor_ = Selector.Register("setObjectFunctionDescriptor:");
    public static readonly Selector SetObjectStaticLinkingDescriptor_ = Selector.Register("setObjectStaticLinkingDescriptor:");
    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth_ = Selector.Register("setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:");
    public static readonly Selector SetPayloadMemoryLength_ = Selector.Register("setPayloadMemoryLength:");
    public static readonly Selector SetRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    public static readonly Selector SetRasterizationEnabled_ = Selector.Register("setRasterizationEnabled:");
    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup_ = Selector.Register("setRequiredThreadsPerMeshThreadgroup:");
    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup_ = Selector.Register("setRequiredThreadsPerObjectThreadgroup:");
    public static readonly Selector SetSupportFragmentBinaryLinking_ = Selector.Register("setSupportFragmentBinaryLinking:");
    public static readonly Selector SetSupportIndirectCommandBuffers_ = Selector.Register("setSupportIndirectCommandBuffers:");
    public static readonly Selector SetSupportMeshBinaryLinking_ = Selector.Register("setSupportMeshBinaryLinking:");
    public static readonly Selector SetSupportObjectBinaryLinking_ = Selector.Register("setSupportObjectBinaryLinking:");
}

public class MTL4MeshRenderPipelineDescriptor : IDisposable
{
    public MTL4MeshRenderPipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4MeshRenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4MeshRenderPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MeshRenderPipelineDescriptor(nint value)
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

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.Reset);
    }

    public void SetAlphaToCoverageState(MTL4AlphaToCoverageState alphaToCoverageState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetAlphaToCoverageState_, (nint)(uint)alphaToCoverageState);
    }

    public void SetAlphaToOneState(MTL4AlphaToOneState alphaToOneState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetAlphaToOneState_, (nint)(uint)alphaToOneState);
    }

    public void SetColorAttachmentMappingState(MTL4LogicalToPhysicalColorAttachmentMappingState colorAttachmentMappingState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetColorAttachmentMappingState_, (nint)(uint)colorAttachmentMappingState);
    }

    public void SetFragmentFunctionDescriptor(MTL4FunctionDescriptor fragmentFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetFragmentFunctionDescriptor_, fragmentFunctionDescriptor.NativePtr);
    }

    public void SetFragmentStaticLinkingDescriptor(MTL4StaticLinkingDescriptor fragmentStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetFragmentStaticLinkingDescriptor_, fragmentStaticLinkingDescriptor.NativePtr);
    }

    public void SetMaxTotalThreadgroupsPerMeshGrid(nuint maxTotalThreadgroupsPerMeshGrid)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadgroupsPerMeshGrid_, (nint)maxTotalThreadgroupsPerMeshGrid);
    }

    public void SetMaxTotalThreadsPerMeshThreadgroup(nuint maxTotalThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerMeshThreadgroup_, (nint)maxTotalThreadsPerMeshThreadgroup);
    }

    public void SetMaxTotalThreadsPerObjectThreadgroup(nuint maxTotalThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerObjectThreadgroup_, (nint)maxTotalThreadsPerObjectThreadgroup);
    }

    public void SetMaxVertexAmplificationCount(nuint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount_, (nint)maxVertexAmplificationCount);
    }

    public void SetMeshFunctionDescriptor(MTL4FunctionDescriptor meshFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshFunctionDescriptor_, meshFunctionDescriptor.NativePtr);
    }

    public void SetMeshStaticLinkingDescriptor(MTL4StaticLinkingDescriptor meshStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshStaticLinkingDescriptor_, meshStaticLinkingDescriptor.NativePtr);
    }

    public void SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 meshThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth_, (nint)meshThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetObjectFunctionDescriptor(MTL4FunctionDescriptor objectFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectFunctionDescriptor_, objectFunctionDescriptor.NativePtr);
    }

    public void SetObjectStaticLinkingDescriptor(MTL4StaticLinkingDescriptor objectStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectStaticLinkingDescriptor_, objectStaticLinkingDescriptor.NativePtr);
    }

    public void SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 objectThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth_, (nint)objectThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetPayloadMemoryLength(nuint payloadMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetPayloadMemoryLength_, (nint)payloadMemoryLength);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRasterizationEnabled_, (nint)rasterizationEnabled.Value);
    }

    public void SetRequiredThreadsPerMeshThreadgroup(MTLSize requiredThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerMeshThreadgroup_, requiredThreadsPerMeshThreadgroup);
    }

    public void SetRequiredThreadsPerObjectThreadgroup(MTLSize requiredThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerObjectThreadgroup_, requiredThreadsPerObjectThreadgroup);
    }

    public void SetSupportFragmentBinaryLinking(Bool8 supportFragmentBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportFragmentBinaryLinking_, (nint)supportFragmentBinaryLinking.Value);
    }

    public void SetSupportIndirectCommandBuffers(MTL4IndirectCommandBufferSupportState supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers_, (nint)(uint)supportIndirectCommandBuffers);
    }

    public void SetSupportMeshBinaryLinking(Bool8 supportMeshBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportMeshBinaryLinking_, (nint)supportMeshBinaryLinking.Value);
    }

    public void SetSupportObjectBinaryLinking(Bool8 supportObjectBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportObjectBinaryLinking_, (nint)supportObjectBinaryLinking.Value);
    }

}
