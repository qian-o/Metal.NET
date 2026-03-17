namespace Metal.NET;

/// <summary>
/// An argument of options you pass to a GPU device to get a render pipeline state.
/// </summary>
public class MTLRenderPipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineDescriptor>
{
    #region INativeObject
    public static new MTLRenderPipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Identifying the render pipeline state object - Properties

    /// <summary>
    /// A string that identifies the render pipeline descriptor.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetLabel, value);
    }
    #endregion

    #region Specifying graphics functions and associated data - Properties

    /// <summary>
    /// The vertex function the pipeline calls to process vertices.
    /// </summary>
    public MTLFunction VertexFunction
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.VertexFunction);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetVertexFunction, value);
    }

    /// <summary>
    /// The fragment function the pipeline calls to process fragments.
    /// </summary>
    public MTLFunction FragmentFunction
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.FragmentFunction);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetFragmentFunction, value);
    }

    /// <summary>
    /// The maximum function call depth from the top-most vertex shader function.
    /// </summary>
    public nuint MaxVertexCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxVertexCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxVertexCallStackDepth, value);
    }

    /// <summary>
    /// The maximum function call depth from the top-most fragment shader function.
    /// </summary>
    public nuint MaxFragmentCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxFragmentCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxFragmentCallStackDepth, value);
    }
    #endregion

    #region Specifying buffer layouts and fetch behavior - Properties

    /// <summary>
    /// The organization of vertex data in an attribute’s argument table.
    /// </summary>
    public MTLVertexDescriptor VertexDescriptor
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.VertexDescriptor);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetVertexDescriptor, value);
    }
    #endregion

    #region Specifying buffer mutability - Properties

    /// <summary>
    /// An array that contains the buffer mutability options for a render pipeline’s vertex function.
    /// </summary>
    public MTLPipelineBufferDescriptorArray VertexBuffers
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.VertexBuffers);
    }

    /// <summary>
    /// An array that contains the buffer mutability options for a render pipeline’s fragment function.
    /// </summary>
    public MTLPipelineBufferDescriptorArray FragmentBuffers
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.FragmentBuffers);
    }
    #endregion

    #region Specifying rendering pipeline state - Properties

    /// <summary>
    /// An array of attachments that store color data.
    /// </summary>
    public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.ColorAttachments);
    }

    /// <summary>
    /// The pixel format of the attachment that stores depth data.
    /// </summary>
    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.DepthAttachmentPixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetDepthAttachmentPixelFormat, (nuint)value);
    }

    /// <summary>
    /// The pixel format of the attachment that stores stencil data.
    /// </summary>
    public MTLPixelFormat StencilAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.StencilAttachmentPixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetStencilAttachmentPixelFormat, (nuint)value);
    }
    #endregion

    #region Specifying rasterization and visibility state - Properties

    /// <summary>
    /// A Boolean value that indicates whether to read and use the alpha channel fragment output for color attachments to compute a sample coverage mask.
    /// </summary>
    public Bool8 IsAlphaToCoverageEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsAlphaToCoverageEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToCoverageEnabled, value);
    }

    /// <summary>
    /// A Boolean value that indicates whether to force alpha channel values for color attachments to the largest representable value.
    /// </summary>
    public Bool8 IsAlphaToOneEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsAlphaToOneEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToOneEnabled, value);
    }

    /// <summary>
    /// A Boolean value that determines whether the pipeline rasterizes primitives.
    /// </summary>
    public Bool8 IsRasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsRasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    /// <summary>
    /// The type of primitive topology the pipeline renders.
    /// </summary>
    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.InputPrimitiveTopology);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetInputPrimitiveTopology, (nuint)value);
    }

    /// <summary>
    /// The number of samples the pipeline applies for each fragment.
    /// </summary>
    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    /// <summary>
    /// The number of samples the pipeline applies for each fragment.
    /// </summary>
    [Obsolete("Use rasterSampleCount instead.")]
    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSampleCount, value);
    }
    #endregion

    #region Specifying tessellation state - Properties

    /// <summary>
    /// The maximum tessellation factor that the tessellator uses when tessellating patches.
    /// </summary>
    public nuint MaxTessellationFactor
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxTessellationFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxTessellationFactor, value);
    }

    /// <summary>
    /// A Boolean value that determines whether the pipeline scales the tessellation factor.
    /// </summary>
    public Bool8 IsTessellationFactorScaleEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsTessellationFactorScaleEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorScaleEnabled, value);
    }

    /// <summary>
    /// The format of the tessellation factors in the tessellation factor buffer.
    /// </summary>
    public MTLTessellationFactorFormat TessellationFactorFormat
    {
        get => (MTLTessellationFactorFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorFormat, (nuint)value);
    }

    /// <summary>
    /// The size of the control point indices in a control point index buffer.
    /// </summary>
    public MTLTessellationControlPointIndexType TessellationControlPointIndexType
    {
        get => (MTLTessellationControlPointIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationControlPointIndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationControlPointIndexType, (nuint)value);
    }

    /// <summary>
    /// The step function for determining the tessellation factors for a patch from the tessellation factor buffer.
    /// </summary>
    public MTLTessellationFactorStepFunction TessellationFactorStepFunction
    {
        get => (MTLTessellationFactorStepFunction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorStepFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorStepFunction, (nuint)value);
    }

    /// <summary>
    /// The winding order of triangles from the tessellator.
    /// </summary>
    public MTLWinding TessellationOutputWindingOrder
    {
        get => (MTLWinding)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationOutputWindingOrder);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationOutputWindingOrder, (nuint)value);
    }

    /// <summary>
    /// The partitioning mode that the tessellator uses to derive the number and spacing of segments for subdividing a corresponding edge.
    /// </summary>
    public MTLTessellationPartitionMode TessellationPartitionMode
    {
        get => (MTLTessellationPartitionMode)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationPartitionMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationPartitionMode, (nuint)value);
    }
    #endregion

    #region Specifying indirect command buffers usage - Properties

    /// <summary>
    /// A Boolean value that determines whether you can encode commands into an indirect command buffer using the render pipeline.
    /// </summary>
    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, value);
    }
    #endregion

    #region Specifying the maximum vertex amplification count - Properties

    /// <summary>
    /// The maximum vertex amplification count you can set when encoding render commands.
    /// </summary>
    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }
    #endregion

    #region Specifying precompiled shader binaries - Properties

    /// <summary>
    /// A Boolean value that indicates whether you can use the pipeline to create new pipelines by adding binary functions to the vertex shader’s callable functions list.
    /// </summary>
    public Bool8 SupportAddingVertexBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportAddingVertexBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportAddingVertexBinaryFunctions, value);
    }

    /// <summary>
    /// A Boolean value that indicates whether you can use the pipeline to create new pipelines by adding binary functions to the fragment shader’s callable functions list.
    /// </summary>
    public Bool8 SupportAddingFragmentBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportAddingFragmentBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportAddingFragmentBinaryFunctions, value);
    }

    /// <summary>
    /// An array of binary archives to search for precompiled versions of the shader.
    /// </summary>
    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLRenderPipelineDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLRenderPipelineDescriptorBindings.SetBinaryArchives, value);
    }
    #endregion

    #region Specifying callable functions for the pipeline - Properties

    /// <summary>
    /// Functions that you can specify as function arguments for the vertex shader when encoding commands that use the pipeline.
    /// </summary>
    public MTLLinkedFunctions VertexLinkedFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.VertexLinkedFunctions);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetVertexLinkedFunctions, value);
    }

    /// <summary>
    /// Functions that you can specify as function arguments for the fragment shader when encoding commands that use the pipeline.
    /// </summary>
    public MTLLinkedFunctions FragmentLinkedFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.FragmentLinkedFunctions);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, value);
    }
    #endregion

    #region Specifying shader validation - Properties

    /// <summary>
    /// A value that enables or disables shader validation for the pipeline.
    /// </summary>
    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLDynamicLibrary[] FragmentPreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLRenderPipelineDescriptorBindings.FragmentPreloadedLibraries);
        set => SetArrayProperty(MTLRenderPipelineDescriptorBindings.SetFragmentPreloadedLibraries, value);
    }

    public MTLDynamicLibrary[] VertexPreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLRenderPipelineDescriptorBindings.VertexPreloadedLibraries);
        set => SetArrayProperty(MTLRenderPipelineDescriptorBindings.SetVertexPreloadedLibraries, value);
    }
    #endregion

    /// <summary>
    /// Deprecated: please use isAlphaToCoverageEnabled instead
    /// </summary>
    [Obsolete("please use isAlphaToCoverageEnabled instead")]
    public Bool8 AlphaToCoverageEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.AlphaToCoverageEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToCoverageEnabled, value);
    }

    /// <summary>
    /// Deprecated: please use isAlphaToOneEnabled instead
    /// </summary>
    [Obsolete("please use isAlphaToOneEnabled instead")]
    public Bool8 AlphaToOneEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.AlphaToOneEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToOneEnabled, value);
    }

    /// <summary>
    /// Deprecated: please use isRasterizationEnabled instead
    /// </summary>
    [Obsolete("please use isRasterizationEnabled instead")]
    public Bool8 RasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    /// <summary>
    /// Deprecated: please use isTessellationFactorScaleEnabled instead
    /// </summary>
    [Obsolete("please use isTessellationFactorScaleEnabled instead")]
    public Bool8 TessellationFactorScaleEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorScaleEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorScaleEnabled, value);
    }

    #region Specifying rendering pipeline state - Methods

    /// <summary>
    /// Specifies the default rendering pipeline state values for the descriptor.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.Reset);
    }
    #endregion
}

file static class MTLRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPipelineDescriptor");

    public static readonly Selector AlphaToCoverageEnabled = "isAlphaToCoverageEnabled";

    public static readonly Selector AlphaToOneEnabled = "isAlphaToOneEnabled";

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector DepthAttachmentPixelFormat = "depthAttachmentPixelFormat";

    public static readonly Selector FragmentBuffers = "fragmentBuffers";

    public static readonly Selector FragmentFunction = "fragmentFunction";

    public static readonly Selector FragmentLinkedFunctions = "fragmentLinkedFunctions";

    public static readonly Selector FragmentPreloadedLibraries = "fragmentPreloadedLibraries";

    public static readonly Selector InputPrimitiveTopology = "inputPrimitiveTopology";

    public static readonly Selector IsAlphaToCoverageEnabled = "isAlphaToCoverageEnabled";

    public static readonly Selector IsAlphaToOneEnabled = "isAlphaToOneEnabled";

    public static readonly Selector IsRasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector IsTessellationFactorScaleEnabled = "isTessellationFactorScaleEnabled";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxFragmentCallStackDepth = "maxFragmentCallStackDepth";

    public static readonly Selector MaxTessellationFactor = "maxTessellationFactor";

    public static readonly Selector MaxVertexAmplificationCount = "maxVertexAmplificationCount";

    public static readonly Selector MaxVertexCallStackDepth = "maxVertexCallStackDepth";

    public static readonly Selector RasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";

    public static readonly Selector SetAlphaToOneEnabled = "setAlphaToOneEnabled:";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";

    public static readonly Selector SetFragmentFunction = "setFragmentFunction:";

    public static readonly Selector SetFragmentLinkedFunctions = "setFragmentLinkedFunctions:";

    public static readonly Selector SetFragmentPreloadedLibraries = "setFragmentPreloadedLibraries:";

    public static readonly Selector SetInputPrimitiveTopology = "setInputPrimitiveTopology:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMaxFragmentCallStackDepth = "setMaxFragmentCallStackDepth:";

    public static readonly Selector SetMaxTessellationFactor = "setMaxTessellationFactor:";

    public static readonly Selector SetMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";

    public static readonly Selector SetMaxVertexCallStackDepth = "setMaxVertexCallStackDepth:";

    public static readonly Selector SetRasterizationEnabled = "setRasterizationEnabled:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector SetStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";

    public static readonly Selector SetSupportAddingFragmentBinaryFunctions = "setSupportAddingFragmentBinaryFunctions:";

    public static readonly Selector SetSupportAddingVertexBinaryFunctions = "setSupportAddingVertexBinaryFunctions:";

    public static readonly Selector SetSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";

    public static readonly Selector SetTessellationControlPointIndexType = "setTessellationControlPointIndexType:";

    public static readonly Selector SetTessellationFactorFormat = "setTessellationFactorFormat:";

    public static readonly Selector SetTessellationFactorScaleEnabled = "setTessellationFactorScaleEnabled:";

    public static readonly Selector SetTessellationFactorStepFunction = "setTessellationFactorStepFunction:";

    public static readonly Selector SetTessellationOutputWindingOrder = "setTessellationOutputWindingOrder:";

    public static readonly Selector SetTessellationPartitionMode = "setTessellationPartitionMode:";

    public static readonly Selector SetVertexDescriptor = "setVertexDescriptor:";

    public static readonly Selector SetVertexFunction = "setVertexFunction:";

    public static readonly Selector SetVertexLinkedFunctions = "setVertexLinkedFunctions:";

    public static readonly Selector SetVertexPreloadedLibraries = "setVertexPreloadedLibraries:";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector StencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";

    public static readonly Selector SupportAddingFragmentBinaryFunctions = "supportAddingFragmentBinaryFunctions";

    public static readonly Selector SupportAddingVertexBinaryFunctions = "supportAddingVertexBinaryFunctions";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector TessellationControlPointIndexType = "tessellationControlPointIndexType";

    public static readonly Selector TessellationFactorFormat = "tessellationFactorFormat";

    public static readonly Selector TessellationFactorScaleEnabled = "isTessellationFactorScaleEnabled";

    public static readonly Selector TessellationFactorStepFunction = "tessellationFactorStepFunction";

    public static readonly Selector TessellationOutputWindingOrder = "tessellationOutputWindingOrder";

    public static readonly Selector TessellationPartitionMode = "tessellationPartitionMode";

    public static readonly Selector VertexBuffers = "vertexBuffers";

    public static readonly Selector VertexDescriptor = "vertexDescriptor";

    public static readonly Selector VertexFunction = "vertexFunction";

    public static readonly Selector VertexLinkedFunctions = "vertexLinkedFunctions";

    public static readonly Selector VertexPreloadedLibraries = "vertexPreloadedLibraries";
}
