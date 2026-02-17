namespace Metal.NET;

public class MTLRenderPipelineDescriptor : IDisposable
{
    public MTLRenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetAlphaToCoverageEnabled, (nint)alphaToCoverageEnabled.Value);
    }

    public void SetAlphaToOneEnabled(Bool8 alphaToOneEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetAlphaToOneEnabled, (nint)alphaToOneEnabled.Value);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetBinaryArchives, binaryArchives.NativePtr);
    }

    public void SetDepthAttachmentPixelFormat(MTLPixelFormat depthAttachmentPixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetDepthAttachmentPixelFormat, (nint)(uint)depthAttachmentPixelFormat);
    }

    public void SetFragmentFunction(MTLFunction fragmentFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentFunction, fragmentFunction.NativePtr);
    }

    public void SetFragmentLinkedFunctions(MTLLinkedFunctions fragmentLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentLinkedFunctions, fragmentLinkedFunctions.NativePtr);
    }

    public void SetFragmentPreloadedLibraries(NSArray fragmentPreloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentPreloadedLibraries, fragmentPreloadedLibraries.NativePtr);
    }

    public void SetInputPrimitiveTopology(MTLPrimitiveTopologyClass inputPrimitiveTopology)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetInputPrimitiveTopology, (nint)(uint)inputPrimitiveTopology);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetMaxFragmentCallStackDepth(uint maxFragmentCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxFragmentCallStackDepth, (nint)maxFragmentCallStackDepth);
    }

    public void SetMaxTessellationFactor(uint maxTessellationFactor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxTessellationFactor, (nint)maxTessellationFactor);
    }

    public void SetMaxVertexAmplificationCount(uint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, (nint)maxVertexAmplificationCount);
    }

    public void SetMaxVertexCallStackDepth(uint maxVertexCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxVertexCallStackDepth, (nint)maxVertexCallStackDepth);
    }

    public void SetRasterSampleCount(uint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetRasterSampleCount, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetRasterizationEnabled, (nint)rasterizationEnabled.Value);
    }

    public void SetSampleCount(uint sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSampleCount, (nint)sampleCount);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetShaderValidation, (nint)(uint)shaderValidation);
    }

    public void SetStencilAttachmentPixelFormat(MTLPixelFormat stencilAttachmentPixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetStencilAttachmentPixelFormat, (nint)(uint)stencilAttachmentPixelFormat);
    }

    public void SetSupportAddingFragmentBinaryFunctions(Bool8 supportAddingFragmentBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportAddingFragmentBinaryFunctions, (nint)supportAddingFragmentBinaryFunctions.Value);
    }

    public void SetSupportAddingVertexBinaryFunctions(Bool8 supportAddingVertexBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportAddingVertexBinaryFunctions, (nint)supportAddingVertexBinaryFunctions.Value);
    }

    public void SetSupportIndirectCommandBuffers(Bool8 supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)supportIndirectCommandBuffers.Value);
    }

    public void SetTessellationControlPointIndexType(MTLTessellationControlPointIndexType tessellationControlPointIndexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationControlPointIndexType, (nint)(uint)tessellationControlPointIndexType);
    }

    public void SetTessellationFactorFormat(MTLTessellationFactorFormat tessellationFactorFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorFormat, (nint)(uint)tessellationFactorFormat);
    }

    public void SetTessellationFactorScaleEnabled(Bool8 tessellationFactorScaleEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorScaleEnabled, (nint)tessellationFactorScaleEnabled.Value);
    }

    public void SetTessellationFactorStepFunction(MTLTessellationFactorStepFunction tessellationFactorStepFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorStepFunction, (nint)(uint)tessellationFactorStepFunction);
    }

    public void SetTessellationOutputWindingOrder(MTLWinding tessellationOutputWindingOrder)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationOutputWindingOrder, (nint)(uint)tessellationOutputWindingOrder);
    }

    public void SetTessellationPartitionMode(MTLTessellationPartitionMode tessellationPartitionMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationPartitionMode, (nint)(uint)tessellationPartitionMode);
    }

    public void SetVertexDescriptor(MTLVertexDescriptor vertexDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexDescriptor, vertexDescriptor.NativePtr);
    }

    public void SetVertexFunction(MTLFunction vertexFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexFunction, vertexFunction.NativePtr);
    }

    public void SetVertexLinkedFunctions(MTLLinkedFunctions vertexLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexLinkedFunctions, vertexLinkedFunctions.NativePtr);
    }

    public void SetVertexPreloadedLibraries(NSArray vertexPreloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexPreloadedLibraries, vertexPreloadedLibraries.NativePtr);
    }

}

file class MTLRenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetAlphaToCoverageEnabled = Selector.Register("setAlphaToCoverageEnabled:");
    public static readonly Selector SetAlphaToOneEnabled = Selector.Register("setAlphaToOneEnabled:");
    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetDepthAttachmentPixelFormat = Selector.Register("setDepthAttachmentPixelFormat:");
    public static readonly Selector SetFragmentFunction = Selector.Register("setFragmentFunction:");
    public static readonly Selector SetFragmentLinkedFunctions = Selector.Register("setFragmentLinkedFunctions:");
    public static readonly Selector SetFragmentPreloadedLibraries = Selector.Register("setFragmentPreloadedLibraries:");
    public static readonly Selector SetInputPrimitiveTopology = Selector.Register("setInputPrimitiveTopology:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector SetMaxFragmentCallStackDepth = Selector.Register("setMaxFragmentCallStackDepth:");
    public static readonly Selector SetMaxTessellationFactor = Selector.Register("setMaxTessellationFactor:");
    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");
    public static readonly Selector SetMaxVertexCallStackDepth = Selector.Register("setMaxVertexCallStackDepth:");
    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");
    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");
    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");
    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");
    public static readonly Selector SetStencilAttachmentPixelFormat = Selector.Register("setStencilAttachmentPixelFormat:");
    public static readonly Selector SetSupportAddingFragmentBinaryFunctions = Selector.Register("setSupportAddingFragmentBinaryFunctions:");
    public static readonly Selector SetSupportAddingVertexBinaryFunctions = Selector.Register("setSupportAddingVertexBinaryFunctions:");
    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");
    public static readonly Selector SetTessellationControlPointIndexType = Selector.Register("setTessellationControlPointIndexType:");
    public static readonly Selector SetTessellationFactorFormat = Selector.Register("setTessellationFactorFormat:");
    public static readonly Selector SetTessellationFactorScaleEnabled = Selector.Register("setTessellationFactorScaleEnabled:");
    public static readonly Selector SetTessellationFactorStepFunction = Selector.Register("setTessellationFactorStepFunction:");
    public static readonly Selector SetTessellationOutputWindingOrder = Selector.Register("setTessellationOutputWindingOrder:");
    public static readonly Selector SetTessellationPartitionMode = Selector.Register("setTessellationPartitionMode:");
    public static readonly Selector SetVertexDescriptor = Selector.Register("setVertexDescriptor:");
    public static readonly Selector SetVertexFunction = Selector.Register("setVertexFunction:");
    public static readonly Selector SetVertexLinkedFunctions = Selector.Register("setVertexLinkedFunctions:");
    public static readonly Selector SetVertexPreloadedLibraries = Selector.Register("setVertexPreloadedLibraries:");
}
