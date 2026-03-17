namespace Metal.NET;

/// <summary>
/// Groups together properties you use to create a mesh render pipeline state object.
/// </summary>
public class MTL4MeshRenderPipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4PipelineDescriptor(nativePtr, ownership), INativeObject<MTL4MeshRenderPipelineDescriptor>
{
    #region INativeObject
    public static new MTL4MeshRenderPipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4MeshRenderPipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4MeshRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4MeshRenderPipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Indicates whether to read and use the alpha channel fragment output of color attachments to compute a sample coverage mask.
    /// </summary>
    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)ObjectiveC.MsgSendLong(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.AlphaToCoverageState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetAlphaToCoverageState, (nint)value);
    }

    /// <summary>
    /// Indicates whether the pipeline forces alpha channel values of color attachments to the largest representable value.
    /// </summary>
    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)ObjectiveC.MsgSendLong(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.AlphaToOneState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetAlphaToOneState, (nint)value);
    }

    /// <summary>
    /// Sets the logical-to-physical rendering remap state.
    /// </summary>
    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)ObjectiveC.MsgSendLong(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.ColorAttachmentMappingState);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetColorAttachmentMappingState, (nint)value);
    }

    /// <summary>
    /// Accesses an array containing descriptions of the color attachments this pipeline writes to.
    /// </summary>
    public MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.ColorAttachments);
    }

    /// <summary>
    /// Assigns a function descriptor representing the function this pipeline executes for each fragment.
    /// </summary>
    public MTL4FunctionDescriptor FragmentFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.FragmentFunctionDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetFragmentFunctionDescriptor, value);
    }

    /// <summary>
    /// Provides static linking information for the fragment stage of the render pipeline.
    /// </summary>
    public MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.FragmentStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetFragmentStaticLinkingDescriptor, value);
    }

    /// <summary>
    /// Determines whether the pipeline rasterizes primitives.
    /// </summary>
    public Bool8 IsRasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.IsRasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    /// <summary>
    /// Controls the largest number of threads the pipeline state can execute when the object stage of a mesh render pipeline you create from this descriptor dispatches its mesh stage.
    /// </summary>
    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MaxTotalThreadgroupsPerMeshGrid);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMaxTotalThreadgroupsPerMeshGrid, value);
    }

    /// <summary>
    /// Controls the largest number of threads the pipeline state can execute in a single mesh shader threadgroup dispatch.
    /// </summary>
    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerMeshThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerMeshThreadgroup, value);
    }

    /// <summary>
    /// Controls the largest number of threads the pipeline state can execute in a single object shader threadgroup dispatch.
    /// </summary>
    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerObjectThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerObjectThreadgroup, value);
    }

    /// <summary>
    /// Determines the maximum value that can you can pass as the pipeline’s amplification count.
    /// </summary>
    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    /// <summary>
    /// Assigns a function descriptor representing the function this pipeline executes for each primitive in the mesh shader stage.
    /// </summary>
    public MTL4FunctionDescriptor MeshFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.MeshFunctionDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetMeshFunctionDescriptor, value);
    }

    /// <summary>
    /// Provides static linking information for the mesh stage of the render pipeline.
    /// </summary>
    public MTL4StaticLinkingDescriptor MeshStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.MeshStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetMeshStaticLinkingDescriptor, value);
    }

    /// <summary>
    /// Provides a guarantee to Metal regarding the number of threadgroup threads for the mesh stage of a pipeline you create from this descriptor.
    /// </summary>
    public Bool8 MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    /// <summary>
    /// Assigns a function descriptor representing the function this pipeline executes for each object in the object shader stage.
    /// </summary>
    public MTL4FunctionDescriptor ObjectFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.ObjectFunctionDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetObjectFunctionDescriptor, value);
    }

    /// <summary>
    /// Provides static linking information for the object stage of the render pipeline.
    /// </summary>
    public MTL4StaticLinkingDescriptor ObjectStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.ObjectStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetObjectStaticLinkingDescriptor, value);
    }

    /// <summary>
    /// Provides a guarantee to Metal regarding the number of threadgroup threads for the object stage of a pipeline you create from this descriptor.
    /// </summary>
    public Bool8 ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    /// <summary>
    /// Reserves storage for the object-to-mesh stage payload.
    /// </summary>
    public nuint PayloadMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.PayloadMemoryLength);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetPayloadMemoryLength, value);
    }

    /// <summary>
    /// Sets number of samples this pipeline applies for each fragment.
    /// </summary>
    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    /// <summary>
    /// Controls the required number of mesh threads-per-threadgroup when drawing with a mesh shader pipeline you create from this descriptor.
    /// </summary>
    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.RequiredThreadsPerMeshThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerMeshThreadgroup, value);
    }

    /// <summary>
    /// Controls the required number of object threads-per-threadgroup when drawing with a mesh shader pipeline you create from this descriptor.
    /// </summary>
    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.RequiredThreadsPerObjectThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerObjectThreadgroup, value);
    }

    /// <summary>
    /// Indicates whether you can use the render pipeline to create new pipelines by adding binary functions to the fragment shader function’s callable functions list.
    /// </summary>
    public Bool8 SupportFragmentBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SupportFragmentBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetSupportFragmentBinaryLinking, value);
    }

    /// <summary>
    /// Indicates whether the pipeline supports indirect command buffers.
    /// </summary>
    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveC.MsgSendLong(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    /// <summary>
    /// Indicates whether you can use the render pipeline to create new pipelines by adding binary functions to the mesh shader function’s callable functions list.
    /// </summary>
    public Bool8 SupportMeshBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SupportMeshBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetSupportMeshBinaryLinking, value);
    }

    /// <summary>
    /// Indicates whether you can use the render pipeline to create new pipelines by adding binary functions to the object shader function’s callable functions list.
    /// </summary>
    public Bool8 SupportObjectBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SupportObjectBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetSupportObjectBinaryLinking, value);
    }
    #endregion

    /// <summary>
    /// Deprecated: please use isRasterizationEnabled instead
    /// </summary>
    [Obsolete("please use isRasterizationEnabled instead")]
    public Bool8 RasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    #region Instance Methods - Methods

    /// <summary>
    /// Resets this descriptor to its default state.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.Reset);
    }
    #endregion
}

file static class MTL4MeshRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4MeshRenderPipelineDescriptor");

    public static readonly Selector AlphaToCoverageState = "alphaToCoverageState";

    public static readonly Selector AlphaToOneState = "alphaToOneState";

    public static readonly Selector ColorAttachmentMappingState = "colorAttachmentMappingState";

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector FragmentFunctionDescriptor = "fragmentFunctionDescriptor";

    public static readonly Selector FragmentStaticLinkingDescriptor = "fragmentStaticLinkingDescriptor";

    public static readonly Selector IsRasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";

    public static readonly Selector MaxVertexAmplificationCount = "maxVertexAmplificationCount";

    public static readonly Selector MeshFunctionDescriptor = "meshFunctionDescriptor";

    public static readonly Selector MeshStaticLinkingDescriptor = "meshStaticLinkingDescriptor";

    public static readonly Selector MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = "meshThreadgroupSizeIsMultipleOfThreadExecutionWidth";

    public static readonly Selector ObjectFunctionDescriptor = "objectFunctionDescriptor";

    public static readonly Selector ObjectStaticLinkingDescriptor = "objectStaticLinkingDescriptor";

    public static readonly Selector ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = "objectThreadgroupSizeIsMultipleOfThreadExecutionWidth";

    public static readonly Selector PayloadMemoryLength = "payloadMemoryLength";

    public static readonly Selector RasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = "requiredThreadsPerMeshThreadgroup";

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = "requiredThreadsPerObjectThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetAlphaToCoverageState = "setAlphaToCoverageState:";

    public static readonly Selector SetAlphaToOneState = "setAlphaToOneState:";

    public static readonly Selector SetColorAttachmentMappingState = "setColorAttachmentMappingState:";

    public static readonly Selector SetFragmentFunctionDescriptor = "setFragmentFunctionDescriptor:";

    public static readonly Selector SetFragmentStaticLinkingDescriptor = "setFragmentStaticLinkingDescriptor:";

    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid = "setMaxTotalThreadgroupsPerMeshGrid:";

    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup = "setMaxTotalThreadsPerMeshThreadgroup:";

    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup = "setMaxTotalThreadsPerObjectThreadgroup:";

    public static readonly Selector SetMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";

    public static readonly Selector SetMeshFunctionDescriptor = "setMeshFunctionDescriptor:";

    public static readonly Selector SetMeshStaticLinkingDescriptor = "setMeshStaticLinkingDescriptor:";

    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = "setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:";

    public static readonly Selector SetObjectFunctionDescriptor = "setObjectFunctionDescriptor:";

    public static readonly Selector SetObjectStaticLinkingDescriptor = "setObjectStaticLinkingDescriptor:";

    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = "setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:";

    public static readonly Selector SetPayloadMemoryLength = "setPayloadMemoryLength:";

    public static readonly Selector SetRasterizationEnabled = "setRasterizationEnabled:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup = "setRequiredThreadsPerMeshThreadgroup:";

    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup = "setRequiredThreadsPerObjectThreadgroup:";

    public static readonly Selector SetSupportFragmentBinaryLinking = "setSupportFragmentBinaryLinking:";

    public static readonly Selector SetSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";

    public static readonly Selector SetSupportMeshBinaryLinking = "setSupportMeshBinaryLinking:";

    public static readonly Selector SetSupportObjectBinaryLinking = "setSupportObjectBinaryLinking:";

    public static readonly Selector SupportFragmentBinaryLinking = "supportFragmentBinaryLinking";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector SupportMeshBinaryLinking = "supportMeshBinaryLinking";

    public static readonly Selector SupportObjectBinaryLinking = "supportObjectBinaryLinking";
}
