namespace Metal.NET;

public class MTL4RenderPipelineDescriptor(nint nativePtr, bool ownsReference) : MTL4PipelineDescriptor(nativePtr, ownsReference), INativeObject<MTL4RenderPipelineDescriptor>
{
    public static new MTL4RenderPipelineDescriptor Null => Create(0, false);
    public static new MTL4RenderPipelineDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4RenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineDescriptorBindings.Class), true)
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

    public MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.ColorAttachments);
    }

    public MTL4FunctionDescriptor FragmentFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.FragmentFunctionDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetFragmentFunctionDescriptor, value);
    }

    public MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.FragmentStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetFragmentStaticLinkingDescriptor, value);
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorBindings.InputPrimitiveTopology);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetInputPrimitiveTopology, (nuint)value);
    }

    public Bool8 IsRasterizationEnabled
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

    public Bool8 RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    public Bool8 SupportFragmentBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportFragmentBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportFragmentBinaryLinking, value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public Bool8 SupportVertexBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportVertexBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportVertexBinaryLinking, value);
    }

    public MTLVertexDescriptor VertexDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.VertexDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetVertexDescriptor, value);
    }

    public MTL4FunctionDescriptor VertexFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.VertexFunctionDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetVertexFunctionDescriptor, value);
    }

    public MTL4StaticLinkingDescriptor VertexStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.VertexStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetVertexStaticLinkingDescriptor, value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTL4RenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDescriptor");

    public static readonly Selector AlphaToCoverageState = "alphaToCoverageState";

    public static readonly Selector AlphaToOneState = "alphaToOneState";

    public static readonly Selector ColorAttachmentMappingState = "colorAttachmentMappingState";

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector FragmentFunctionDescriptor = "fragmentFunctionDescriptor";

    public static readonly Selector FragmentStaticLinkingDescriptor = "fragmentStaticLinkingDescriptor";

    public static readonly Selector InputPrimitiveTopology = "inputPrimitiveTopology";

    public static readonly Selector IsRasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector MaxVertexAmplificationCount = "maxVertexAmplificationCount";

    public static readonly Selector RasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetAlphaToCoverageState = "setAlphaToCoverageState:";

    public static readonly Selector SetAlphaToOneState = "setAlphaToOneState:";

    public static readonly Selector SetColorAttachmentMappingState = "setColorAttachmentMappingState:";

    public static readonly Selector SetFragmentFunctionDescriptor = "setFragmentFunctionDescriptor:";

    public static readonly Selector SetFragmentStaticLinkingDescriptor = "setFragmentStaticLinkingDescriptor:";

    public static readonly Selector SetInputPrimitiveTopology = "setInputPrimitiveTopology:";

    public static readonly Selector SetMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";

    public static readonly Selector SetRasterizationEnabled = "setRasterizationEnabled:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetSupportFragmentBinaryLinking = "setSupportFragmentBinaryLinking:";

    public static readonly Selector SetSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";

    public static readonly Selector SetSupportVertexBinaryLinking = "setSupportVertexBinaryLinking:";

    public static readonly Selector SetVertexDescriptor = "setVertexDescriptor:";

    public static readonly Selector SetVertexFunctionDescriptor = "setVertexFunctionDescriptor:";

    public static readonly Selector SetVertexStaticLinkingDescriptor = "setVertexStaticLinkingDescriptor:";

    public static readonly Selector SupportFragmentBinaryLinking = "supportFragmentBinaryLinking";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector SupportVertexBinaryLinking = "supportVertexBinaryLinking";

    public static readonly Selector VertexDescriptor = "vertexDescriptor";

    public static readonly Selector VertexFunctionDescriptor = "vertexFunctionDescriptor";

    public static readonly Selector VertexStaticLinkingDescriptor = "vertexStaticLinkingDescriptor";
}
