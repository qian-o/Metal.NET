namespace Metal.NET;

public class MTLMeshRenderPipelineDescriptor : IDisposable
{
    public MTLMeshRenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLMeshRenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLMeshRenderPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLMeshRenderPipelineDescriptor(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.Reset);
    }

    public void SetAlphaToCoverageEnabled(Bool8 alphaToCoverageEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetAlphaToCoverageEnabled, (nint)alphaToCoverageEnabled.Value);
    }

    public void SetAlphaToOneEnabled(Bool8 alphaToOneEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetAlphaToOneEnabled, (nint)alphaToOneEnabled.Value);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetBinaryArchives, binaryArchives.NativePtr);
    }

    public void SetDepthAttachmentPixelFormat(MTLPixelFormat depthAttachmentPixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetDepthAttachmentPixelFormat, (nint)(uint)depthAttachmentPixelFormat);
    }

    public void SetFragmentFunction(MTLFunction fragmentFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetFragmentFunction, fragmentFunction.NativePtr);
    }

    public void SetFragmentLinkedFunctions(MTLLinkedFunctions fragmentLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetFragmentLinkedFunctions, fragmentLinkedFunctions.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetMaxTotalThreadgroupsPerMeshGrid(uint maxTotalThreadgroupsPerMeshGrid)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadgroupsPerMeshGrid, (nint)maxTotalThreadgroupsPerMeshGrid);
    }

    public void SetMaxTotalThreadsPerMeshThreadgroup(uint maxTotalThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerMeshThreadgroup, (nint)maxTotalThreadsPerMeshThreadgroup);
    }

    public void SetMaxTotalThreadsPerObjectThreadgroup(uint maxTotalThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerObjectThreadgroup, (nint)maxTotalThreadsPerObjectThreadgroup);
    }

    public void SetMaxVertexAmplificationCount(uint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, (nint)maxVertexAmplificationCount);
    }

    public void SetMeshFunction(MTLFunction meshFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshFunction, meshFunction.NativePtr);
    }

    public void SetMeshLinkedFunctions(MTLLinkedFunctions meshLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshLinkedFunctions, meshLinkedFunctions.NativePtr);
    }

    public void SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 meshThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, (nint)meshThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetObjectFunction(MTLFunction objectFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectFunction, objectFunction.NativePtr);
    }

    public void SetObjectLinkedFunctions(MTLLinkedFunctions objectLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectLinkedFunctions, objectLinkedFunctions.NativePtr);
    }

    public void SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 objectThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, (nint)objectThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetPayloadMemoryLength(uint payloadMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetPayloadMemoryLength, (nint)payloadMemoryLength);
    }

    public void SetRasterSampleCount(uint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRasterSampleCount, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRasterizationEnabled, (nint)rasterizationEnabled.Value);
    }

    public void SetRequiredThreadsPerMeshThreadgroup(MTLSize requiredThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerMeshThreadgroup, requiredThreadsPerMeshThreadgroup);
    }

    public void SetRequiredThreadsPerObjectThreadgroup(MTLSize requiredThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerObjectThreadgroup, requiredThreadsPerObjectThreadgroup);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetShaderValidation, (nint)(uint)shaderValidation);
    }

    public void SetStencilAttachmentPixelFormat(MTLPixelFormat stencilAttachmentPixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetStencilAttachmentPixelFormat, (nint)(uint)stencilAttachmentPixelFormat);
    }

    public void SetSupportIndirectCommandBuffers(Bool8 supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)supportIndirectCommandBuffers.Value);
    }

}

file class MTLMeshRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetAlphaToCoverageEnabled = Selector.Register("setAlphaToCoverageEnabled:");
    public static readonly Selector SetAlphaToOneEnabled = Selector.Register("setAlphaToOneEnabled:");
    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetDepthAttachmentPixelFormat = Selector.Register("setDepthAttachmentPixelFormat:");
    public static readonly Selector SetFragmentFunction = Selector.Register("setFragmentFunction:");
    public static readonly Selector SetFragmentLinkedFunctions = Selector.Register("setFragmentLinkedFunctions:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid = Selector.Register("setMaxTotalThreadgroupsPerMeshGrid:");
    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup = Selector.Register("setMaxTotalThreadsPerMeshThreadgroup:");
    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup = Selector.Register("setMaxTotalThreadsPerObjectThreadgroup:");
    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");
    public static readonly Selector SetMeshFunction = Selector.Register("setMeshFunction:");
    public static readonly Selector SetMeshLinkedFunctions = Selector.Register("setMeshLinkedFunctions:");
    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:");
    public static readonly Selector SetObjectFunction = Selector.Register("setObjectFunction:");
    public static readonly Selector SetObjectLinkedFunctions = Selector.Register("setObjectLinkedFunctions:");
    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:");
    public static readonly Selector SetPayloadMemoryLength = Selector.Register("setPayloadMemoryLength:");
    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");
    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");
    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup = Selector.Register("setRequiredThreadsPerMeshThreadgroup:");
    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup = Selector.Register("setRequiredThreadsPerObjectThreadgroup:");
    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");
    public static readonly Selector SetStencilAttachmentPixelFormat = Selector.Register("setStencilAttachmentPixelFormat:");
    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");
}
