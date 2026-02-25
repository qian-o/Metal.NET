namespace Metal.NET;

public class MTL4MeshRenderPipelineDescriptor(nint nativePtr, bool ownsReference) : MTL4PipelineDescriptor(nativePtr, ownsReference), INativeObject<MTL4MeshRenderPipelineDescriptor>
{
    public static new MTL4MeshRenderPipelineDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static new MTL4MeshRenderPipelineDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4MeshRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4MeshRenderPipelineDescriptorBindings.Class), true)
    {
    }

    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.AlphaToCoverageState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetAlphaToCoverageState, (nint)value);
    }

    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.AlphaToOneState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetAlphaToOneState, (nint)value);
    }

    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.ColorAttachmentMappingState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetColorAttachmentMappingState, (nint)value);
    }

    public MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.ColorAttachments);
    }

    public MTL4FunctionDescriptor FragmentFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.FragmentFunctionDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetFragmentFunctionDescriptor, value);
    }

    public MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.FragmentStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetFragmentStaticLinkingDescriptor, value);
    }

    public bool IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.IsRasterizationEnabled);
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MaxTotalThreadgroupsPerMeshGrid);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMaxTotalThreadgroupsPerMeshGrid, value);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerMeshThreadgroup, value);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerObjectThreadgroup, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    public MTL4FunctionDescriptor MeshFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.MeshFunctionDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetMeshFunctionDescriptor, value);
    }

    public MTL4StaticLinkingDescriptor MeshStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.MeshStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetMeshStaticLinkingDescriptor, value);
    }

    public bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public MTL4FunctionDescriptor ObjectFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.ObjectFunctionDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetObjectFunctionDescriptor, value);
    }

    public MTL4StaticLinkingDescriptor ObjectStaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.ObjectStaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4MeshRenderPipelineDescriptorBindings.SetObjectStaticLinkingDescriptor, value);
    }

    public bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public nuint PayloadMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.PayloadMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetPayloadMemoryLength, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public bool RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRasterizationEnabled, (Bool8)value);
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.RequiredThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerMeshThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.RequiredThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerObjectThreadgroup, value);
    }

    public bool SupportFragmentBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SupportFragmentBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetSupportFragmentBinaryLinking, (Bool8)value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public bool SupportMeshBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SupportMeshBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetSupportMeshBinaryLinking, (Bool8)value);
    }

    public bool SupportObjectBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SupportObjectBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetSupportObjectBinaryLinking, (Bool8)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTL4MeshRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MeshRenderPipelineDescriptor");

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
