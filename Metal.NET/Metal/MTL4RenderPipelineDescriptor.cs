namespace Metal.NET;

public class MTL4RenderPipelineDescriptor : IDisposable
{
    public MTL4RenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTL4RenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.Reset);
    }

    public void SetAlphaToCoverageState(MTL4AlphaToCoverageState alphaToCoverageState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetAlphaToCoverageState, (nint)(uint)alphaToCoverageState);
    }

    public void SetAlphaToOneState(MTL4AlphaToOneState alphaToOneState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetAlphaToOneState, (nint)(uint)alphaToOneState);
    }

    public void SetColorAttachmentMappingState(MTL4LogicalToPhysicalColorAttachmentMappingState colorAttachmentMappingState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetColorAttachmentMappingState, (nint)(uint)colorAttachmentMappingState);
    }

    public void SetFragmentFunctionDescriptor(MTL4FunctionDescriptor fragmentFunctionDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetFragmentFunctionDescriptor, fragmentFunctionDescriptor.NativePtr);
    }

    public void SetFragmentStaticLinkingDescriptor(MTL4StaticLinkingDescriptor fragmentStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetFragmentStaticLinkingDescriptor, fragmentStaticLinkingDescriptor.NativePtr);
    }

    public void SetInputPrimitiveTopology(MTLPrimitiveTopologyClass inputPrimitiveTopology)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetInputPrimitiveTopology, (nint)(uint)inputPrimitiveTopology);
    }

    public void SetMaxVertexAmplificationCount(uint maxVertexAmplificationCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, (nint)maxVertexAmplificationCount);
    }

    public void SetRasterSampleCount(uint rasterSampleCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetRasterSampleCount, (nint)rasterSampleCount);
    }

    public void SetRasterizationEnabled(Bool8 rasterizationEnabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetRasterizationEnabled, (nint)rasterizationEnabled.Value);
    }

    public void SetSupportFragmentBinaryLinking(Bool8 supportFragmentBinaryLinking)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportFragmentBinaryLinking, (nint)supportFragmentBinaryLinking.Value);
    }

    public void SetSupportIndirectCommandBuffers(MTL4IndirectCommandBufferSupportState supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)(uint)supportIndirectCommandBuffers);
    }

    public void SetSupportVertexBinaryLinking(Bool8 supportVertexBinaryLinking)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportVertexBinaryLinking, (nint)supportVertexBinaryLinking.Value);
    }

    public void SetVertexDescriptor(MTLVertexDescriptor vertexDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexDescriptor, vertexDescriptor.NativePtr);
    }

    public void SetVertexFunctionDescriptor(MTL4FunctionDescriptor vertexFunctionDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexFunctionDescriptor, vertexFunctionDescriptor.NativePtr);
    }

    public void SetVertexStaticLinkingDescriptor(MTL4StaticLinkingDescriptor vertexStaticLinkingDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexStaticLinkingDescriptor, vertexStaticLinkingDescriptor.NativePtr);
    }

}

file class MTL4RenderPipelineDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetAlphaToCoverageState = Selector.Register("setAlphaToCoverageState:");

    public static readonly Selector SetAlphaToOneState = Selector.Register("setAlphaToOneState:");

    public static readonly Selector SetColorAttachmentMappingState = Selector.Register("setColorAttachmentMappingState:");

    public static readonly Selector SetFragmentFunctionDescriptor = Selector.Register("setFragmentFunctionDescriptor:");

    public static readonly Selector SetFragmentStaticLinkingDescriptor = Selector.Register("setFragmentStaticLinkingDescriptor:");

    public static readonly Selector SetInputPrimitiveTopology = Selector.Register("setInputPrimitiveTopology:");

    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");

    public static readonly Selector SetSupportFragmentBinaryLinking = Selector.Register("setSupportFragmentBinaryLinking:");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SetSupportVertexBinaryLinking = Selector.Register("setSupportVertexBinaryLinking:");

    public static readonly Selector SetVertexDescriptor = Selector.Register("setVertexDescriptor:");

    public static readonly Selector SetVertexFunctionDescriptor = Selector.Register("setVertexFunctionDescriptor:");

    public static readonly Selector SetVertexStaticLinkingDescriptor = Selector.Register("setVertexStaticLinkingDescriptor:");
}
