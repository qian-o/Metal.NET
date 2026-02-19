namespace Metal.NET;

public readonly struct MTL4RenderPipelineDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4RenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineDescriptorBindings.Class))
    {
    }

    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.AlphaToCoverageState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetAlphaToCoverageState, (nint)value);
    }

    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.AlphaToOneState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetAlphaToOneState, (nint)value);
    }

    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.ColorAttachmentMappingState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetColorAttachmentMappingState, (nint)value);
    }

    public MTL4RenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.ColorAttachments);
            return ptr is not 0 ? new MTL4RenderPipelineColorAttachmentDescriptorArray(ptr) : default;
        }
    }

    public MTL4FunctionDescriptor? FragmentFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.FragmentFunctionDescriptor);
            return ptr is not 0 ? new MTL4FunctionDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetFragmentFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4StaticLinkingDescriptor? FragmentStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.FragmentStaticLinkingDescriptor);
            return ptr is not 0 ? new MTL4StaticLinkingDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetFragmentStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorBindings.InputPrimitiveTopology);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetInputPrimitiveTopology, (nuint)value);
    }

    public bool IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.IsRasterizationEnabled);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public bool RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetRasterizationEnabled, (Bool8)value);
    }

    public bool SupportFragmentBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportFragmentBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportFragmentBinaryLinking, (Bool8)value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public bool SupportVertexBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportVertexBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportVertexBinaryLinking, (Bool8)value);
    }

    public MTLVertexDescriptor? VertexDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.VertexDescriptor);
            return ptr is not 0 ? new MTLVertexDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetVertexDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4FunctionDescriptor? VertexFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.VertexFunctionDescriptor);
            return ptr is not 0 ? new MTL4FunctionDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetVertexFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4StaticLinkingDescriptor? VertexStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.VertexStaticLinkingDescriptor);
            return ptr is not 0 ? new MTL4StaticLinkingDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetVertexStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTL4RenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDescriptor");

    public static readonly Selector AlphaToCoverageState = Selector.Register("alphaToCoverageState");

    public static readonly Selector AlphaToOneState = Selector.Register("alphaToOneState");

    public static readonly Selector ColorAttachmentMappingState = Selector.Register("colorAttachmentMappingState");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector FragmentFunctionDescriptor = Selector.Register("fragmentFunctionDescriptor");

    public static readonly Selector FragmentStaticLinkingDescriptor = Selector.Register("fragmentStaticLinkingDescriptor");

    public static readonly Selector InputPrimitiveTopology = Selector.Register("inputPrimitiveTopology");

    public static readonly Selector IsRasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector MaxVertexAmplificationCount = Selector.Register("maxVertexAmplificationCount");

    public static readonly Selector RasterizationEnabled = Selector.Register("isRasterizationEnabled");

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
