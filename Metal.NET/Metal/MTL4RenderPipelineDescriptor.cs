namespace Metal.NET;

public readonly struct MTL4RenderPipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4PipelineDescriptor(MTL4RenderPipelineDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4RenderPipelineDescriptor value) => new(value.NativePtr);

    public MTL4RenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPipelineDescriptorBindings.Class))
    {
    }

    public MTL4RenderPipelineDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTL4FunctionDescriptor VertexFunctionDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDescriptorBindings.VertexFunctionDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetVertexFunctionDescriptor, value.NativePtr);
    }

    public MTL4FunctionDescriptor FragmentFunctionDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDescriptorBindings.FragmentFunctionDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetFragmentFunctionDescriptor, value.NativePtr);
    }

    public MTLVertexDescriptor VertexDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDescriptorBindings.VertexDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetVertexDescriptor, value.NativePtr);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineDescriptorBindings.AlphaToCoverageState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetAlphaToCoverageState, (nint)value);
    }

    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineDescriptorBindings.AlphaToOneState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetAlphaToOneState, (nint)value);
    }

    public Bool8 IsRasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.IsRasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    public MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDescriptorBindings.ColorAttachments));
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineDescriptorBindings.InputPrimitiveTopology);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetInputPrimitiveTopology, (nuint)value);
    }

    public MTL4StaticLinkingDescriptor VertexStaticLinkingDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDescriptorBindings.VertexStaticLinkingDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetVertexStaticLinkingDescriptor, value.NativePtr);
    }

    public MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDescriptorBindings.FragmentStaticLinkingDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetFragmentStaticLinkingDescriptor, value.NativePtr);
    }

    public Bool8 SupportVertexBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportVertexBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportVertexBinaryLinking, value);
    }

    public Bool8 SupportFragmentBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportFragmentBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportFragmentBinaryLinking, value);
    }

    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineDescriptorBindings.ColorAttachmentMappingState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetColorAttachmentMappingState, (nint)value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4PipelineOptions Options
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDescriptorBindings.Options));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetOptions, value.NativePtr);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTL4RenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4RenderPipelineDescriptor");

    public static readonly Selector AlphaToCoverageState = "alphaToCoverageState";

    public static readonly Selector AlphaToOneState = "alphaToOneState";

    public static readonly Selector ColorAttachmentMappingState = "colorAttachmentMappingState";

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector FragmentFunctionDescriptor = "fragmentFunctionDescriptor";

    public static readonly Selector FragmentStaticLinkingDescriptor = "fragmentStaticLinkingDescriptor";

    public static readonly Selector InputPrimitiveTopology = "inputPrimitiveTopology";

    public static readonly Selector IsRasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxVertexAmplificationCount = "maxVertexAmplificationCount";

    public static readonly Selector Options = "options";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetAlphaToCoverageState = "setAlphaToCoverageState:";

    public static readonly Selector SetAlphaToOneState = "setAlphaToOneState:";

    public static readonly Selector SetColorAttachmentMappingState = "setColorAttachmentMappingState:";

    public static readonly Selector SetFragmentFunctionDescriptor = "setFragmentFunctionDescriptor:";

    public static readonly Selector SetFragmentStaticLinkingDescriptor = "setFragmentStaticLinkingDescriptor:";

    public static readonly Selector SetInputPrimitiveTopology = "setInputPrimitiveTopology:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";

    public static readonly Selector SetOptions = "setOptions:";

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
