namespace Metal.NET;

public class MTL4MeshRenderPipelineDescriptor : IDisposable
{
    public MTL4MeshRenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.Reset);
    }

    public void SetAlphaToCoverageState(MTL4AlphaToCoverageState alphaToCoverageState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetAlphaToCoverageState, (nint)(uint)alphaToCoverageState);
    }

    public void SetAlphaToOneState(MTL4AlphaToOneState alphaToOneState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetAlphaToOneState, (nint)(uint)alphaToOneState);
    }

    public void SetColorAttachmentMappingState(MTL4LogicalToPhysicalColorAttachmentMappingState colorAttachmentMappingState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetColorAttachmentMappingState, (nint)(uint)colorAttachmentMappingState);
    }

    public void SetFragmentFunctionDescriptor(MTL4FunctionDescriptor fragmentFunctionDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetFragmentFunctionDescriptor, fragmentFunctionDescriptor.NativePtr);
    }

    public void SetFragmentStaticLinkingDescriptor(MTL4StaticLinkingDescriptor fragmentStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetFragmentStaticLinkingDescriptor, fragmentStaticLinkingDescriptor.NativePtr);
    }

    public void SetMaxTotalThreadgroupsPerMeshGrid(uint maxTotalThreadgroupsPerMeshGrid)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadgroupsPerMeshGrid, (nint)maxTotalThreadgroupsPerMeshGrid);
    }

    public void SetMaxTotalThreadsPerMeshThreadgroup(uint maxTotalThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerMeshThreadgroup, (nint)maxTotalThreadsPerMeshThreadgroup);
    }

    public void SetMaxTotalThreadsPerObjectThreadgroup(uint maxTotalThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerObjectThreadgroup, (nint)maxTotalThreadsPerObjectThreadgroup);
    }

    public void SetMaxVertexAmplificationCount(uint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, (nint)maxVertexAmplificationCount);
    }

    public void SetMeshFunctionDescriptor(MTL4FunctionDescriptor meshFunctionDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshFunctionDescriptor, meshFunctionDescriptor.NativePtr);
    }

    public void SetMeshStaticLinkingDescriptor(MTL4StaticLinkingDescriptor meshStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshStaticLinkingDescriptor, meshStaticLinkingDescriptor.NativePtr);
    }

    public void SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 meshThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, (nint)meshThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetObjectFunctionDescriptor(MTL4FunctionDescriptor objectFunctionDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectFunctionDescriptor, objectFunctionDescriptor.NativePtr);
    }

    public void SetObjectStaticLinkingDescriptor(MTL4StaticLinkingDescriptor objectStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectStaticLinkingDescriptor, objectStaticLinkingDescriptor.NativePtr);
    }

    public void SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 objectThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, (nint)objectThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetPayloadMemoryLength(uint payloadMemoryLength)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetPayloadMemoryLength, (nint)payloadMemoryLength);
    }

    public void SetRasterSampleCount(uint rasterSampleCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRasterSampleCount, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRasterizationEnabled, (nint)rasterizationEnabled.Value);
    }

    public void SetRequiredThreadsPerMeshThreadgroup(MTLSize requiredThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerMeshThreadgroup, requiredThreadsPerMeshThreadgroup);
    }

    public void SetRequiredThreadsPerObjectThreadgroup(MTLSize requiredThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerObjectThreadgroup, requiredThreadsPerObjectThreadgroup);
    }

    public void SetSupportFragmentBinaryLinking(Bool8 supportFragmentBinaryLinking)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportFragmentBinaryLinking, (nint)supportFragmentBinaryLinking.Value);
    }

    public void SetSupportIndirectCommandBuffers(MTL4IndirectCommandBufferSupportState supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)(uint)supportIndirectCommandBuffers);
    }

    public void SetSupportMeshBinaryLinking(Bool8 supportMeshBinaryLinking)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportMeshBinaryLinking, (nint)supportMeshBinaryLinking.Value);
    }

    public void SetSupportObjectBinaryLinking(Bool8 supportObjectBinaryLinking)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportObjectBinaryLinking, (nint)supportObjectBinaryLinking.Value);
    }

}

file class MTL4MeshRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetAlphaToCoverageState = Selector.Register("setAlphaToCoverageState:");

    public static readonly Selector SetAlphaToOneState = Selector.Register("setAlphaToOneState:");

    public static readonly Selector SetColorAttachmentMappingState = Selector.Register("setColorAttachmentMappingState:");

    public static readonly Selector SetFragmentFunctionDescriptor = Selector.Register("setFragmentFunctionDescriptor:");

    public static readonly Selector SetFragmentStaticLinkingDescriptor = Selector.Register("setFragmentStaticLinkingDescriptor:");

    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid = Selector.Register("setMaxTotalThreadgroupsPerMeshGrid:");

    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup = Selector.Register("setMaxTotalThreadsPerMeshThreadgroup:");

    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup = Selector.Register("setMaxTotalThreadsPerObjectThreadgroup:");

    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");

    public static readonly Selector SetMeshFunctionDescriptor = Selector.Register("setMeshFunctionDescriptor:");

    public static readonly Selector SetMeshStaticLinkingDescriptor = Selector.Register("setMeshStaticLinkingDescriptor:");

    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector SetObjectFunctionDescriptor = Selector.Register("setObjectFunctionDescriptor:");

    public static readonly Selector SetObjectStaticLinkingDescriptor = Selector.Register("setObjectStaticLinkingDescriptor:");

    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector SetPayloadMemoryLength = Selector.Register("setPayloadMemoryLength:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");

    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup = Selector.Register("setRequiredThreadsPerMeshThreadgroup:");

    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup = Selector.Register("setRequiredThreadsPerObjectThreadgroup:");

    public static readonly Selector SetSupportFragmentBinaryLinking = Selector.Register("setSupportFragmentBinaryLinking:");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SetSupportMeshBinaryLinking = Selector.Register("setSupportMeshBinaryLinking:");

    public static readonly Selector SetSupportObjectBinaryLinking = Selector.Register("setSupportObjectBinaryLinking:");
}
