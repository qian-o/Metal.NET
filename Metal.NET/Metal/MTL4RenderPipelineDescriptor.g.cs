namespace Metal.NET;

file class MTL4RenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetAlphaToCoverageState_ = Selector.Register("setAlphaToCoverageState:");
    public static readonly Selector SetAlphaToOneState_ = Selector.Register("setAlphaToOneState:");
    public static readonly Selector SetColorAttachmentMappingState_ = Selector.Register("setColorAttachmentMappingState:");
    public static readonly Selector SetFragmentFunctionDescriptor_ = Selector.Register("setFragmentFunctionDescriptor:");
    public static readonly Selector SetFragmentStaticLinkingDescriptor_ = Selector.Register("setFragmentStaticLinkingDescriptor:");
    public static readonly Selector SetInputPrimitiveTopology_ = Selector.Register("setInputPrimitiveTopology:");
    public static readonly Selector SetMaxVertexAmplificationCount_ = Selector.Register("setMaxVertexAmplificationCount:");
    public static readonly Selector SetRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    public static readonly Selector SetRasterizationEnabled_ = Selector.Register("setRasterizationEnabled:");
    public static readonly Selector SetSupportFragmentBinaryLinking_ = Selector.Register("setSupportFragmentBinaryLinking:");
    public static readonly Selector SetSupportIndirectCommandBuffers_ = Selector.Register("setSupportIndirectCommandBuffers:");
    public static readonly Selector SetSupportVertexBinaryLinking_ = Selector.Register("setSupportVertexBinaryLinking:");
    public static readonly Selector SetVertexDescriptor_ = Selector.Register("setVertexDescriptor:");
    public static readonly Selector SetVertexFunctionDescriptor_ = Selector.Register("setVertexFunctionDescriptor:");
    public static readonly Selector SetVertexStaticLinkingDescriptor_ = Selector.Register("setVertexStaticLinkingDescriptor:");
}

public class MTL4RenderPipelineDescriptor : IDisposable
{
    public MTL4RenderPipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4RenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4RenderPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4RenderPipelineDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDescriptor");

    public static MTL4RenderPipelineDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTL4RenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.Reset);
    }

    public void SetAlphaToCoverageState(MTL4AlphaToCoverageState alphaToCoverageState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetAlphaToCoverageState_, (nint)(uint)alphaToCoverageState);
    }

    public void SetAlphaToOneState(MTL4AlphaToOneState alphaToOneState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetAlphaToOneState_, (nint)(uint)alphaToOneState);
    }

    public void SetColorAttachmentMappingState(MTL4LogicalToPhysicalColorAttachmentMappingState colorAttachmentMappingState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetColorAttachmentMappingState_, (nint)(uint)colorAttachmentMappingState);
    }

    public void SetFragmentFunctionDescriptor(MTL4FunctionDescriptor fragmentFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetFragmentFunctionDescriptor_, fragmentFunctionDescriptor.NativePtr);
    }

    public void SetFragmentStaticLinkingDescriptor(MTL4StaticLinkingDescriptor fragmentStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetFragmentStaticLinkingDescriptor_, fragmentStaticLinkingDescriptor.NativePtr);
    }

    public void SetInputPrimitiveTopology(MTLPrimitiveTopologyClass inputPrimitiveTopology)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetInputPrimitiveTopology_, (nint)(uint)inputPrimitiveTopology);
    }

    public void SetMaxVertexAmplificationCount(nuint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount_, (nint)maxVertexAmplificationCount);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetRasterizationEnabled_, (nint)rasterizationEnabled.Value);
    }

    public void SetSupportFragmentBinaryLinking(Bool8 supportFragmentBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportFragmentBinaryLinking_, (nint)supportFragmentBinaryLinking.Value);
    }

    public void SetSupportIndirectCommandBuffers(MTL4IndirectCommandBufferSupportState supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers_, (nint)(uint)supportIndirectCommandBuffers);
    }

    public void SetSupportVertexBinaryLinking(Bool8 supportVertexBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportVertexBinaryLinking_, (nint)supportVertexBinaryLinking.Value);
    }

    public void SetVertexDescriptor(MTLVertexDescriptor vertexDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexDescriptor_, vertexDescriptor.NativePtr);
    }

    public void SetVertexFunctionDescriptor(MTL4FunctionDescriptor vertexFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexFunctionDescriptor_, vertexFunctionDescriptor.NativePtr);
    }

    public void SetVertexStaticLinkingDescriptor(MTL4StaticLinkingDescriptor vertexStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexStaticLinkingDescriptor_, vertexStaticLinkingDescriptor.NativePtr);
    }

}
