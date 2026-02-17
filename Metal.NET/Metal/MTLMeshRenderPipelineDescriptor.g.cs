namespace Metal.NET;

file class MTLMeshRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetAlphaToCoverageEnabled_ = Selector.Register("setAlphaToCoverageEnabled:");
    public static readonly Selector SetAlphaToOneEnabled_ = Selector.Register("setAlphaToOneEnabled:");
    public static readonly Selector SetBinaryArchives_ = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetDepthAttachmentPixelFormat_ = Selector.Register("setDepthAttachmentPixelFormat:");
    public static readonly Selector SetFragmentFunction_ = Selector.Register("setFragmentFunction:");
    public static readonly Selector SetFragmentLinkedFunctions_ = Selector.Register("setFragmentLinkedFunctions:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid_ = Selector.Register("setMaxTotalThreadgroupsPerMeshGrid:");
    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup_ = Selector.Register("setMaxTotalThreadsPerMeshThreadgroup:");
    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup_ = Selector.Register("setMaxTotalThreadsPerObjectThreadgroup:");
    public static readonly Selector SetMaxVertexAmplificationCount_ = Selector.Register("setMaxVertexAmplificationCount:");
    public static readonly Selector SetMeshFunction_ = Selector.Register("setMeshFunction:");
    public static readonly Selector SetMeshLinkedFunctions_ = Selector.Register("setMeshLinkedFunctions:");
    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth_ = Selector.Register("setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:");
    public static readonly Selector SetObjectFunction_ = Selector.Register("setObjectFunction:");
    public static readonly Selector SetObjectLinkedFunctions_ = Selector.Register("setObjectLinkedFunctions:");
    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth_ = Selector.Register("setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:");
    public static readonly Selector SetPayloadMemoryLength_ = Selector.Register("setPayloadMemoryLength:");
    public static readonly Selector SetRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    public static readonly Selector SetRasterizationEnabled_ = Selector.Register("setRasterizationEnabled:");
    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup_ = Selector.Register("setRequiredThreadsPerMeshThreadgroup:");
    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup_ = Selector.Register("setRequiredThreadsPerObjectThreadgroup:");
    public static readonly Selector SetShaderValidation_ = Selector.Register("setShaderValidation:");
    public static readonly Selector SetStencilAttachmentPixelFormat_ = Selector.Register("setStencilAttachmentPixelFormat:");
    public static readonly Selector SetSupportIndirectCommandBuffers_ = Selector.Register("setSupportIndirectCommandBuffers:");
}

public class MTLMeshRenderPipelineDescriptor : IDisposable
{
    public MTLMeshRenderPipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetAlphaToCoverageEnabled_, (nint)alphaToCoverageEnabled.Value);
    }

    public void SetAlphaToOneEnabled(Bool8 alphaToOneEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetAlphaToOneEnabled_, (nint)alphaToOneEnabled.Value);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetDepthAttachmentPixelFormat(MTLPixelFormat depthAttachmentPixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetDepthAttachmentPixelFormat_, (nint)(uint)depthAttachmentPixelFormat);
    }

    public void SetFragmentFunction(MTLFunction fragmentFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetFragmentFunction_, fragmentFunction.NativePtr);
    }

    public void SetFragmentLinkedFunctions(MTLLinkedFunctions fragmentLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetFragmentLinkedFunctions_, fragmentLinkedFunctions.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetMaxTotalThreadgroupsPerMeshGrid(nuint maxTotalThreadgroupsPerMeshGrid)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadgroupsPerMeshGrid_, (nint)maxTotalThreadgroupsPerMeshGrid);
    }

    public void SetMaxTotalThreadsPerMeshThreadgroup(nuint maxTotalThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerMeshThreadgroup_, (nint)maxTotalThreadsPerMeshThreadgroup);
    }

    public void SetMaxTotalThreadsPerObjectThreadgroup(nuint maxTotalThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerObjectThreadgroup_, (nint)maxTotalThreadsPerObjectThreadgroup);
    }

    public void SetMaxVertexAmplificationCount(nuint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount_, (nint)maxVertexAmplificationCount);
    }

    public void SetMeshFunction(MTLFunction meshFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshFunction_, meshFunction.NativePtr);
    }

    public void SetMeshLinkedFunctions(MTLLinkedFunctions meshLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshLinkedFunctions_, meshLinkedFunctions.NativePtr);
    }

    public void SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 meshThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth_, (nint)meshThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetObjectFunction(MTLFunction objectFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectFunction_, objectFunction.NativePtr);
    }

    public void SetObjectLinkedFunctions(MTLLinkedFunctions objectLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectLinkedFunctions_, objectLinkedFunctions.NativePtr);
    }

    public void SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth(Bool8 objectThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth_, (nint)objectThreadgroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

    public void SetPayloadMemoryLength(nuint payloadMemoryLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetPayloadMemoryLength_, (nint)payloadMemoryLength);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRasterizationEnabled_, (nint)rasterizationEnabled.Value);
    }

    public void SetRequiredThreadsPerMeshThreadgroup(MTLSize requiredThreadsPerMeshThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerMeshThreadgroup_, requiredThreadsPerMeshThreadgroup);
    }

    public void SetRequiredThreadsPerObjectThreadgroup(MTLSize requiredThreadsPerObjectThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerObjectThreadgroup_, requiredThreadsPerObjectThreadgroup);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetShaderValidation_, (nint)(uint)shaderValidation);
    }

    public void SetStencilAttachmentPixelFormat(MTLPixelFormat stencilAttachmentPixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetStencilAttachmentPixelFormat_, (nint)(uint)stencilAttachmentPixelFormat);
    }

    public void SetSupportIndirectCommandBuffers(Bool8 supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers_, (nint)supportIndirectCommandBuffers.Value);
    }

}
