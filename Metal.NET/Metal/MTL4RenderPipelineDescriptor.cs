namespace Metal.NET;

/// <summary>Groups together properties to create a render pipeline state object.</summary>
public class MTL4RenderPipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4PipelineDescriptor(nativePtr, ownership), INativeObject<MTL4RenderPipelineDescriptor>
{
    #region INativeObject
    public static new MTL4RenderPipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderPipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4RenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>Indicates whether to read and use the alpha channel fragment output of color attachments to compute a sample coverage mask.</summary>
    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineDescriptorBindings.AlphaToCoverageState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetAlphaToCoverageState, (nint)value);
    }

    /// <summary>Indicates whether the pipeline forces alpha channel values of color attachments to the largest representable value.</summary>
    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineDescriptorBindings.AlphaToOneState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetAlphaToOneState, (nint)value);
    }

    /// <summary>Configures a logical-to-physical rendering remap state.</summary>
    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineDescriptorBindings.ColorAttachmentMappingState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetColorAttachmentMappingState, (nint)value);
    }

    /// <summary>Accesses an array containing descriptions of the color attachments this pipeline writes to.</summary>
    public MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.ColorAttachments);
    }

    /// <summary>Assigns the shader function that this pipeline executes for each fragment.</summary>
    public MTL4FunctionDescriptor FragmentFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.FragmentFunctionDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetFragmentFunctionDescriptor, value);
    }

    /// <summary>Provides static linking information for the fragment stage of the render pipeline.</summary>
    public MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.FragmentStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetFragmentStaticLinkingDescriptor, value);
    }

    /// <summary>Assigns type of primitive topology this pipeline renders.</summary>
    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveC.MsgSendULong(NativePtr, MTL4RenderPipelineDescriptorBindings.InputPrimitiveTopology);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetInputPrimitiveTopology, (nuint)value);
    }

    /// <summary>Determines whether the pipeline rasterizes primitives.</summary>
    public Bool8 IsRasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.IsRasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    /// <summary>Determines the maximum value that can you can pass as the pipeline’s amplification count.</summary>
    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    /// <summary>Controls the number of samples this pipeline applies for each fragment.</summary>
    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4RenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    /// <summary>Indicates whether you can use the pipeline to create new pipelines by adding binary functions to the fragment shader function’s callable functions list.</summary>
    public Bool8 SupportFragmentBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportFragmentBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportFragmentBinaryLinking, value);
    }

    /// <summary>Indicates whether the pipeline supports indirect command buffers.</summary>
    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveC.MsgSendLong(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    /// <summary>Indicates whether you can use the render pipeline to create new pipelines by adding binary functions to the vertex shader function’s callable functions list.</summary>
    public Bool8 SupportVertexBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.SupportVertexBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetSupportVertexBinaryLinking, value);
    }

    /// <summary>Configures an optional vertex descriptor for the vertex input.</summary>
    public MTLVertexDescriptor VertexDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.VertexDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetVertexDescriptor, value);
    }

    /// <summary>Assigns the shader function that this pipeline executes for each vertex.</summary>
    public MTL4FunctionDescriptor VertexFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.VertexFunctionDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetVertexFunctionDescriptor, value);
    }

    /// <summary>Provides static linking information for the vertex stage of the render pipeline.</summary>
    public MTL4StaticLinkingDescriptor VertexStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDescriptorBindings.VertexStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4RenderPipelineDescriptorBindings.SetVertexStaticLinkingDescriptor, value);
    }
    #endregion

    /// <summary>Deprecated: please use isRasterizationEnabled instead</summary>
    [Obsolete("please use isRasterizationEnabled instead")]
    public Bool8 RasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4RenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    #region Instance Methods - Methods

    /// <summary>Resets this descriptor to its default state.</summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineDescriptorBindings.Reset);
    }
    #endregion
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
