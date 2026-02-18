namespace Metal.NET;

public partial class MTL4MeshRenderPipelineDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MeshRenderPipelineDescriptor");

    public MTL4MeshRenderPipelineDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.AlphaToCoverageState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetAlphaToCoverageState, (nint)value);
    }

    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.AlphaToOneState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetAlphaToOneState, (nint)value);
    }

    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ColorAttachmentMappingState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetColorAttachmentMappingState, (nint)value);
    }

    public MTL4RenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ColorAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTL4FunctionDescriptor? FragmentFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.FragmentFunctionDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetFragmentFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4StaticLinkingDescriptor? FragmentStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.FragmentStaticLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetFragmentStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public bool IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.IsRasterizationEnabled);
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MaxTotalThreadgroupsPerMeshGrid);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadgroupsPerMeshGrid, value);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MaxTotalThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerMeshThreadgroup, value);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MaxTotalThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerObjectThreadgroup, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, value);
    }

    public MTL4FunctionDescriptor? MeshFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MeshFunctionDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4StaticLinkingDescriptor? MeshStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MeshStaticLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public MTL4FunctionDescriptor? ObjectFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ObjectFunctionDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTL4StaticLinkingDescriptor? ObjectStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ObjectStaticLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public nuint PayloadMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.PayloadMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetPayloadMemoryLength, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRasterSampleCount, value);
    }

    public bool RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRasterizationEnabled, (Bool8)value);
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.RequiredThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerMeshThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.RequiredThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerObjectThreadgroup, value);
    }

    public bool SupportFragmentBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SupportFragmentBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportFragmentBinaryLinking, (Bool8)value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public bool SupportMeshBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SupportMeshBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportMeshBinaryLinking, (Bool8)value);
    }

    public bool SupportObjectBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SupportObjectBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportObjectBinaryLinking, (Bool8)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.Reset);
    }
}

file static class MTL4MeshRenderPipelineDescriptorSelector
{
    public static readonly Selector AlphaToCoverageState = Selector.Register("alphaToCoverageState");

    public static readonly Selector AlphaToOneState = Selector.Register("alphaToOneState");

    public static readonly Selector ColorAttachmentMappingState = Selector.Register("colorAttachmentMappingState");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector FragmentFunctionDescriptor = Selector.Register("fragmentFunctionDescriptor");

    public static readonly Selector FragmentStaticLinkingDescriptor = Selector.Register("fragmentStaticLinkingDescriptor");

    public static readonly Selector IsRasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = Selector.Register("maxTotalThreadgroupsPerMeshGrid");

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = Selector.Register("maxTotalThreadsPerMeshThreadgroup");

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = Selector.Register("maxTotalThreadsPerObjectThreadgroup");

    public static readonly Selector MaxVertexAmplificationCount = Selector.Register("maxVertexAmplificationCount");

    public static readonly Selector MeshFunctionDescriptor = Selector.Register("meshFunctionDescriptor");

    public static readonly Selector MeshStaticLinkingDescriptor = Selector.Register("meshStaticLinkingDescriptor");

    public static readonly Selector MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("meshThreadgroupSizeIsMultipleOfThreadExecutionWidth");

    public static readonly Selector ObjectFunctionDescriptor = Selector.Register("objectFunctionDescriptor");

    public static readonly Selector ObjectStaticLinkingDescriptor = Selector.Register("objectStaticLinkingDescriptor");

    public static readonly Selector ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("objectThreadgroupSizeIsMultipleOfThreadExecutionWidth");

    public static readonly Selector PayloadMemoryLength = Selector.Register("payloadMemoryLength");

    public static readonly Selector RasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = Selector.Register("requiredThreadsPerMeshThreadgroup");

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = Selector.Register("requiredThreadsPerObjectThreadgroup");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetAlphaToCoverageState = Selector.Register("setAlphaToCoverageState:");

    public static readonly Selector SetAlphaToOneState = Selector.Register("setAlphaToOneState:");

    public static readonly Selector SetColorAttachmentMappingState = Selector.Register("setColorAttachmentMappingState:");

    public static readonly Selector SetFragmentFunctionDescriptor = Selector.Register("setFragmentFunctionDescriptor:");

    public static readonly Selector SetFragmentStaticLinkingDescriptor = Selector.Register("setFragmentStaticLinkingDescriptor:");

    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid = Selector.Register("setMaxTotalThreadgroupsPerMeshGrid:");

    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup = Selector.Register("setMaxTotalThreadsPerMeshThreadgroup:");

    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup = Selector.Register("setMaxTotalThreadsPerObjectThreadgroup:");

    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");

    public static readonly Selector SetMeshFunctionDescriptor = Selector.Register("setMeshFunctionDescriptor:");

    public static readonly Selector SetMeshStaticLinkingDescriptor = Selector.Register("setMeshStaticLinkingDescriptor:");

    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector SetObjectFunctionDescriptor = Selector.Register("setObjectFunctionDescriptor:");

    public static readonly Selector SetObjectStaticLinkingDescriptor = Selector.Register("setObjectStaticLinkingDescriptor:");

    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector SetPayloadMemoryLength = Selector.Register("setPayloadMemoryLength:");

    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup = Selector.Register("setRequiredThreadsPerMeshThreadgroup:");

    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup = Selector.Register("setRequiredThreadsPerObjectThreadgroup:");

    public static readonly Selector SetSupportFragmentBinaryLinking = Selector.Register("setSupportFragmentBinaryLinking:");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SetSupportMeshBinaryLinking = Selector.Register("setSupportMeshBinaryLinking:");

    public static readonly Selector SetSupportObjectBinaryLinking = Selector.Register("setSupportObjectBinaryLinking:");

    public static readonly Selector SupportFragmentBinaryLinking = Selector.Register("supportFragmentBinaryLinking");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector SupportMeshBinaryLinking = Selector.Register("supportMeshBinaryLinking");

    public static readonly Selector SupportObjectBinaryLinking = Selector.Register("supportObjectBinaryLinking");
}
