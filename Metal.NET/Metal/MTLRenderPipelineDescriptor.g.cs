namespace Metal.NET;

file class MTLRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetAlphaToCoverageEnabled_ = Selector.Register("setAlphaToCoverageEnabled:");
    public static readonly Selector SetAlphaToOneEnabled_ = Selector.Register("setAlphaToOneEnabled:");
    public static readonly Selector SetBinaryArchives_ = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetDepthAttachmentPixelFormat_ = Selector.Register("setDepthAttachmentPixelFormat:");
    public static readonly Selector SetFragmentFunction_ = Selector.Register("setFragmentFunction:");
    public static readonly Selector SetFragmentLinkedFunctions_ = Selector.Register("setFragmentLinkedFunctions:");
    public static readonly Selector SetFragmentPreloadedLibraries_ = Selector.Register("setFragmentPreloadedLibraries:");
    public static readonly Selector SetInputPrimitiveTopology_ = Selector.Register("setInputPrimitiveTopology:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetMaxFragmentCallStackDepth_ = Selector.Register("setMaxFragmentCallStackDepth:");
    public static readonly Selector SetMaxTessellationFactor_ = Selector.Register("setMaxTessellationFactor:");
    public static readonly Selector SetMaxVertexAmplificationCount_ = Selector.Register("setMaxVertexAmplificationCount:");
    public static readonly Selector SetMaxVertexCallStackDepth_ = Selector.Register("setMaxVertexCallStackDepth:");
    public static readonly Selector SetRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    public static readonly Selector SetRasterizationEnabled_ = Selector.Register("setRasterizationEnabled:");
    public static readonly Selector SetSampleCount_ = Selector.Register("setSampleCount:");
    public static readonly Selector SetShaderValidation_ = Selector.Register("setShaderValidation:");
    public static readonly Selector SetStencilAttachmentPixelFormat_ = Selector.Register("setStencilAttachmentPixelFormat:");
    public static readonly Selector SetSupportAddingFragmentBinaryFunctions_ = Selector.Register("setSupportAddingFragmentBinaryFunctions:");
    public static readonly Selector SetSupportAddingVertexBinaryFunctions_ = Selector.Register("setSupportAddingVertexBinaryFunctions:");
    public static readonly Selector SetSupportIndirectCommandBuffers_ = Selector.Register("setSupportIndirectCommandBuffers:");
    public static readonly Selector SetTessellationControlPointIndexType_ = Selector.Register("setTessellationControlPointIndexType:");
    public static readonly Selector SetTessellationFactorFormat_ = Selector.Register("setTessellationFactorFormat:");
    public static readonly Selector SetTessellationFactorScaleEnabled_ = Selector.Register("setTessellationFactorScaleEnabled:");
    public static readonly Selector SetTessellationFactorStepFunction_ = Selector.Register("setTessellationFactorStepFunction:");
    public static readonly Selector SetTessellationOutputWindingOrder_ = Selector.Register("setTessellationOutputWindingOrder:");
    public static readonly Selector SetTessellationPartitionMode_ = Selector.Register("setTessellationPartitionMode:");
    public static readonly Selector SetVertexDescriptor_ = Selector.Register("setVertexDescriptor:");
    public static readonly Selector SetVertexFunction_ = Selector.Register("setVertexFunction:");
    public static readonly Selector SetVertexLinkedFunctions_ = Selector.Register("setVertexLinkedFunctions:");
    public static readonly Selector SetVertexPreloadedLibraries_ = Selector.Register("setVertexPreloadedLibraries:");
}

public class MTLRenderPipelineDescriptor : IDisposable
{
    public MTLRenderPipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLRenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPipelineDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPipelineDescriptor");

    public static MTLRenderPipelineDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLRenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.Reset);
    }

    public void SetAlphaToCoverageEnabled(Bool8 alphaToCoverageEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetAlphaToCoverageEnabled_, (nint)alphaToCoverageEnabled.Value);
    }

    public void SetAlphaToOneEnabled(Bool8 alphaToOneEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetAlphaToOneEnabled_, (nint)alphaToOneEnabled.Value);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetDepthAttachmentPixelFormat(MTLPixelFormat depthAttachmentPixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetDepthAttachmentPixelFormat_, (nint)(uint)depthAttachmentPixelFormat);
    }

    public void SetFragmentFunction(MTLFunction fragmentFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentFunction_, fragmentFunction.NativePtr);
    }

    public void SetFragmentLinkedFunctions(MTLLinkedFunctions fragmentLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentLinkedFunctions_, fragmentLinkedFunctions.NativePtr);
    }

    public void SetFragmentPreloadedLibraries(NSArray fragmentPreloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentPreloadedLibraries_, fragmentPreloadedLibraries.NativePtr);
    }

    public void SetInputPrimitiveTopology(MTLPrimitiveTopologyClass inputPrimitiveTopology)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetInputPrimitiveTopology_, (nint)(uint)inputPrimitiveTopology);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetMaxFragmentCallStackDepth(nuint maxFragmentCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxFragmentCallStackDepth_, (nint)maxFragmentCallStackDepth);
    }

    public void SetMaxTessellationFactor(nuint maxTessellationFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxTessellationFactor_, (nint)maxTessellationFactor);
    }

    public void SetMaxVertexAmplificationCount(nuint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount_, (nint)maxVertexAmplificationCount);
    }

    public void SetMaxVertexCallStackDepth(nuint maxVertexCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxVertexCallStackDepth_, (nint)maxVertexCallStackDepth);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetRasterizationEnabled_, (nint)rasterizationEnabled.Value);
    }

    public void SetSampleCount(nuint sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSampleCount_, (nint)sampleCount);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetShaderValidation_, (nint)(uint)shaderValidation);
    }

    public void SetStencilAttachmentPixelFormat(MTLPixelFormat stencilAttachmentPixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetStencilAttachmentPixelFormat_, (nint)(uint)stencilAttachmentPixelFormat);
    }

    public void SetSupportAddingFragmentBinaryFunctions(Bool8 supportAddingFragmentBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportAddingFragmentBinaryFunctions_, (nint)supportAddingFragmentBinaryFunctions.Value);
    }

    public void SetSupportAddingVertexBinaryFunctions(Bool8 supportAddingVertexBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportAddingVertexBinaryFunctions_, (nint)supportAddingVertexBinaryFunctions.Value);
    }

    public void SetSupportIndirectCommandBuffers(Bool8 supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers_, (nint)supportIndirectCommandBuffers.Value);
    }

    public void SetTessellationControlPointIndexType(MTLTessellationControlPointIndexType tessellationControlPointIndexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationControlPointIndexType_, (nint)(uint)tessellationControlPointIndexType);
    }

    public void SetTessellationFactorFormat(MTLTessellationFactorFormat tessellationFactorFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorFormat_, (nint)(uint)tessellationFactorFormat);
    }

    public void SetTessellationFactorScaleEnabled(Bool8 tessellationFactorScaleEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorScaleEnabled_, (nint)tessellationFactorScaleEnabled.Value);
    }

    public void SetTessellationFactorStepFunction(MTLTessellationFactorStepFunction tessellationFactorStepFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorStepFunction_, (nint)(uint)tessellationFactorStepFunction);
    }

    public void SetTessellationOutputWindingOrder(MTLWinding tessellationOutputWindingOrder)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationOutputWindingOrder_, (nint)(uint)tessellationOutputWindingOrder);
    }

    public void SetTessellationPartitionMode(MTLTessellationPartitionMode tessellationPartitionMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationPartitionMode_, (nint)(uint)tessellationPartitionMode);
    }

    public void SetVertexDescriptor(MTLVertexDescriptor vertexDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexDescriptor_, vertexDescriptor.NativePtr);
    }

    public void SetVertexFunction(MTLFunction vertexFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexFunction_, vertexFunction.NativePtr);
    }

    public void SetVertexLinkedFunctions(MTLLinkedFunctions vertexLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexLinkedFunctions_, vertexLinkedFunctions.NativePtr);
    }

    public void SetVertexPreloadedLibraries(NSArray vertexPreloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexPreloadedLibraries_, vertexPreloadedLibraries.NativePtr);
    }

}
