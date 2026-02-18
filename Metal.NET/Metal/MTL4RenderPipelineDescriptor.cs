namespace Metal.NET;

public partial class MTL4RenderPipelineDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDescriptor");

    public MTL4RenderPipelineDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.AlphaToCoverageState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetAlphaToCoverageState, (nint)value);
    }

    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.AlphaToOneState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetAlphaToOneState, (nint)value);
    }

    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.ColorAttachmentMappingState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetColorAttachmentMappingState, (nint)value);
    }

    public MTL4RenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.ColorAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTL4FunctionDescriptor? FragmentFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.FragmentFunctionDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetFragmentFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4StaticLinkingDescriptor? FragmentStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.FragmentStaticLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetFragmentStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.InputPrimitiveTopology);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetInputPrimitiveTopology, (nuint)value);
    }

    public bool IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorSelector.IsRasterizationEnabled);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetRasterSampleCount, value);
    }

    public bool RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorSelector.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetRasterizationEnabled, (Bool8)value);
    }

    public bool SupportFragmentBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorSelector.SupportFragmentBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportFragmentBinaryLinking, (Bool8)value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public bool SupportVertexBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorSelector.SupportVertexBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportVertexBinaryLinking, (Bool8)value);
    }

    public MTLVertexDescriptor? VertexDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.VertexDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4FunctionDescriptor? VertexFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.VertexFunctionDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4StaticLinkingDescriptor? VertexStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.VertexStaticLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.Reset);
    }
}

file static class MTL4RenderPipelineDescriptorSelector
{
    public static readonly Selector AlphaToCoverageState = Selector.Register("alphaToCoverageState");

    public static readonly Selector AlphaToOneState = Selector.Register("alphaToOneState");

    public static readonly Selector ColorAttachmentMappingState = Selector.Register("colorAttachmentMappingState");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector FragmentFunctionDescriptor = Selector.Register("fragmentFunctionDescriptor");

    public static readonly Selector FragmentStaticLinkingDescriptor = Selector.Register("fragmentStaticLinkingDescriptor");

    public static readonly Selector InputPrimitiveTopology = Selector.Register("inputPrimitiveTopology");

    public static readonly Selector IsRasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector MaxVertexAmplificationCount = Selector.Register("maxVertexAmplificationCount");

    public static readonly Selector RasterizationEnabled = Selector.Register("rasterizationEnabled");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetAlphaToCoverageState = Selector.Register("setAlphaToCoverageState:");

    public static readonly Selector SetAlphaToOneState = Selector.Register("setAlphaToOneState:");

    public static readonly Selector SetColorAttachmentMappingState = Selector.Register("setColorAttachmentMappingState:");

    public static readonly Selector SetFragmentFunctionDescriptor = Selector.Register("setFragmentFunctionDescriptor:");

    public static readonly Selector SetFragmentStaticLinkingDescriptor = Selector.Register("setFragmentStaticLinkingDescriptor:");

    public static readonly Selector SetInputPrimitiveTopology = Selector.Register("setInputPrimitiveTopology:");

    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");

    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetSupportFragmentBinaryLinking = Selector.Register("setSupportFragmentBinaryLinking:");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SetSupportVertexBinaryLinking = Selector.Register("setSupportVertexBinaryLinking:");

    public static readonly Selector SetVertexDescriptor = Selector.Register("setVertexDescriptor:");

    public static readonly Selector SetVertexFunctionDescriptor = Selector.Register("setVertexFunctionDescriptor:");

    public static readonly Selector SetVertexStaticLinkingDescriptor = Selector.Register("setVertexStaticLinkingDescriptor:");

    public static readonly Selector SupportFragmentBinaryLinking = Selector.Register("supportFragmentBinaryLinking");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector SupportVertexBinaryLinking = Selector.Register("supportVertexBinaryLinking");

    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");

    public static readonly Selector VertexFunctionDescriptor = Selector.Register("vertexFunctionDescriptor");

    public static readonly Selector VertexStaticLinkingDescriptor = Selector.Register("vertexStaticLinkingDescriptor");
}
