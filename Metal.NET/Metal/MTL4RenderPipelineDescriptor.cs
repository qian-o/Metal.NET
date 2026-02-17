namespace Metal.NET;

public class MTL4RenderPipelineDescriptor : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDescriptor");

    public MTL4RenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTL4RenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(s_class))
    {
    }

    ~MTL4RenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.AlphaToCoverageState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetAlphaToCoverageState, (uint)value);
    }

    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.AlphaToOneState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetAlphaToOneState, (uint)value);
    }

    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.ColorAttachmentMappingState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetColorAttachmentMappingState, (uint)value);
    }

    public MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.ColorAttachments));

    public MTL4FunctionDescriptor FragmentFunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.FragmentFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetFragmentFunctionDescriptor, value.NativePtr);
    }

    public MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.FragmentStaticLinkingDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetFragmentStaticLinkingDescriptor, value.NativePtr);
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.InputPrimitiveTopology));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetInputPrimitiveTopology, (uint)value);
    }

    public Bool8 IsRasterizationEnabled => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorSelector.IsRasterizationEnabled);

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, (nuint)value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetRasterSampleCount, (nuint)value);
    }

    public Bool8 RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorSelector.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetRasterizationEnabled, value);
    }

    public Bool8 SupportFragmentBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorSelector.SupportFragmentBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportFragmentBinaryLinking, value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4RenderPipelineDescriptorSelector.SupportIndirectCommandBuffers));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (uint)value);
    }

    public Bool8 SupportVertexBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorSelector.SupportVertexBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetSupportVertexBinaryLinking, value);
    }

    public MTLVertexDescriptor VertexDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.VertexDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexDescriptor, value.NativePtr);
    }

    public MTL4FunctionDescriptor VertexFunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.VertexFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexFunctionDescriptor, value.NativePtr);
    }

    public MTL4StaticLinkingDescriptor VertexStaticLinkingDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorSelector.VertexStaticLinkingDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.SetVertexStaticLinkingDescriptor, value.NativePtr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorSelector.Reset);
    }

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

}

file class MTL4RenderPipelineDescriptorSelector
{
    public static readonly Selector AlphaToCoverageState = Selector.Register("alphaToCoverageState");

    public static readonly Selector SetAlphaToCoverageState = Selector.Register("setAlphaToCoverageState:");

    public static readonly Selector AlphaToOneState = Selector.Register("alphaToOneState");

    public static readonly Selector SetAlphaToOneState = Selector.Register("setAlphaToOneState:");

    public static readonly Selector ColorAttachmentMappingState = Selector.Register("colorAttachmentMappingState");

    public static readonly Selector SetColorAttachmentMappingState = Selector.Register("setColorAttachmentMappingState:");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector FragmentFunctionDescriptor = Selector.Register("fragmentFunctionDescriptor");

    public static readonly Selector SetFragmentFunctionDescriptor = Selector.Register("setFragmentFunctionDescriptor:");

    public static readonly Selector FragmentStaticLinkingDescriptor = Selector.Register("fragmentStaticLinkingDescriptor");

    public static readonly Selector SetFragmentStaticLinkingDescriptor = Selector.Register("setFragmentStaticLinkingDescriptor:");

    public static readonly Selector InputPrimitiveTopology = Selector.Register("inputPrimitiveTopology");

    public static readonly Selector SetInputPrimitiveTopology = Selector.Register("setInputPrimitiveTopology:");

    public static readonly Selector IsRasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector MaxVertexAmplificationCount = Selector.Register("maxVertexAmplificationCount");

    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector RasterizationEnabled = Selector.Register("rasterizationEnabled");

    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");

    public static readonly Selector SupportFragmentBinaryLinking = Selector.Register("supportFragmentBinaryLinking");

    public static readonly Selector SetSupportFragmentBinaryLinking = Selector.Register("setSupportFragmentBinaryLinking:");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SupportVertexBinaryLinking = Selector.Register("supportVertexBinaryLinking");

    public static readonly Selector SetSupportVertexBinaryLinking = Selector.Register("setSupportVertexBinaryLinking:");

    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");

    public static readonly Selector SetVertexDescriptor = Selector.Register("setVertexDescriptor:");

    public static readonly Selector VertexFunctionDescriptor = Selector.Register("vertexFunctionDescriptor");

    public static readonly Selector SetVertexFunctionDescriptor = Selector.Register("setVertexFunctionDescriptor:");

    public static readonly Selector VertexStaticLinkingDescriptor = Selector.Register("vertexStaticLinkingDescriptor");

    public static readonly Selector SetVertexStaticLinkingDescriptor = Selector.Register("setVertexStaticLinkingDescriptor:");

    public static readonly Selector Reset = Selector.Register("reset");
}
