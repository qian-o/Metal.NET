namespace Metal.NET;

public class MTL4MeshRenderPipelineDescriptor : IDisposable
{
    public MTL4MeshRenderPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4MeshRenderPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTL4AlphaToCoverageState AlphaToCoverageState
    {
        get => (MTL4AlphaToCoverageState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.AlphaToCoverageState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetAlphaToCoverageState, (uint)value);
    }

    public MTL4AlphaToOneState AlphaToOneState
    {
        get => (MTL4AlphaToOneState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.AlphaToOneState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetAlphaToOneState, (uint)value);
    }

    public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
    {
        get => (MTL4LogicalToPhysicalColorAttachmentMappingState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ColorAttachmentMappingState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetColorAttachmentMappingState, (uint)value);
    }

    public MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ColorAttachments));

    public MTL4FunctionDescriptor FragmentFunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.FragmentFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetFragmentFunctionDescriptor, value.NativePtr);
    }

    public MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.FragmentStaticLinkingDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetFragmentStaticLinkingDescriptor, value.NativePtr);
    }

    public Bool8 IsRasterizationEnabled => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.IsRasterizationEnabled);

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MaxTotalThreadgroupsPerMeshGrid);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadgroupsPerMeshGrid, (nuint)value);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MaxTotalThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerMeshThreadgroup, (nuint)value);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MaxTotalThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerObjectThreadgroup, (nuint)value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, (nuint)value);
    }

    public MTL4FunctionDescriptor MeshFunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MeshFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshFunctionDescriptor, value.NativePtr);
    }

    public MTL4StaticLinkingDescriptor MeshStaticLinkingDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MeshStaticLinkingDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshStaticLinkingDescriptor, value.NativePtr);
    }

    public Bool8 MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public MTL4FunctionDescriptor ObjectFunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ObjectFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectFunctionDescriptor, value.NativePtr);
    }

    public MTL4StaticLinkingDescriptor ObjectStaticLinkingDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ObjectStaticLinkingDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectStaticLinkingDescriptor, value.NativePtr);
    }

    public Bool8 ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public nuint PayloadMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.PayloadMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetPayloadMemoryLength, (nuint)value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRasterSampleCount, (nuint)value);
    }

    public Bool8 RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetRasterizationEnabled, value);
    }

    public Bool8 SupportFragmentBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SupportFragmentBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportFragmentBinaryLinking, value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SupportIndirectCommandBuffers));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (uint)value);
    }

    public Bool8 SupportMeshBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SupportMeshBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportMeshBinaryLinking, value);
    }

    public Bool8 SupportObjectBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SupportObjectBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.SetSupportObjectBinaryLinking, value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorSelector.Reset);
    }

    public static implicit operator nint(MTL4MeshRenderPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MeshRenderPipelineDescriptor(nint value)
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

file class MTL4MeshRenderPipelineDescriptorSelector
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

    public static readonly Selector IsRasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = Selector.Register("maxTotalThreadgroupsPerMeshGrid");

    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid = Selector.Register("setMaxTotalThreadgroupsPerMeshGrid:");

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = Selector.Register("maxTotalThreadsPerMeshThreadgroup");

    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup = Selector.Register("setMaxTotalThreadsPerMeshThreadgroup:");

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = Selector.Register("maxTotalThreadsPerObjectThreadgroup");

    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup = Selector.Register("setMaxTotalThreadsPerObjectThreadgroup:");

    public static readonly Selector MaxVertexAmplificationCount = Selector.Register("maxVertexAmplificationCount");

    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");

    public static readonly Selector MeshFunctionDescriptor = Selector.Register("meshFunctionDescriptor");

    public static readonly Selector SetMeshFunctionDescriptor = Selector.Register("setMeshFunctionDescriptor:");

    public static readonly Selector MeshStaticLinkingDescriptor = Selector.Register("meshStaticLinkingDescriptor");

    public static readonly Selector SetMeshStaticLinkingDescriptor = Selector.Register("setMeshStaticLinkingDescriptor:");

    public static readonly Selector MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("meshThreadgroupSizeIsMultipleOfThreadExecutionWidth");

    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector ObjectFunctionDescriptor = Selector.Register("objectFunctionDescriptor");

    public static readonly Selector SetObjectFunctionDescriptor = Selector.Register("setObjectFunctionDescriptor:");

    public static readonly Selector ObjectStaticLinkingDescriptor = Selector.Register("objectStaticLinkingDescriptor");

    public static readonly Selector SetObjectStaticLinkingDescriptor = Selector.Register("setObjectStaticLinkingDescriptor:");

    public static readonly Selector ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("objectThreadgroupSizeIsMultipleOfThreadExecutionWidth");

    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector PayloadMemoryLength = Selector.Register("payloadMemoryLength");

    public static readonly Selector SetPayloadMemoryLength = Selector.Register("setPayloadMemoryLength:");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector RasterizationEnabled = Selector.Register("rasterizationEnabled");

    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = Selector.Register("requiredThreadsPerMeshThreadgroup");

    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup = Selector.Register("setRequiredThreadsPerMeshThreadgroup:");

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = Selector.Register("requiredThreadsPerObjectThreadgroup");

    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup = Selector.Register("setRequiredThreadsPerObjectThreadgroup:");

    public static readonly Selector SupportFragmentBinaryLinking = Selector.Register("supportFragmentBinaryLinking");

    public static readonly Selector SetSupportFragmentBinaryLinking = Selector.Register("setSupportFragmentBinaryLinking:");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SupportMeshBinaryLinking = Selector.Register("supportMeshBinaryLinking");

    public static readonly Selector SetSupportMeshBinaryLinking = Selector.Register("setSupportMeshBinaryLinking:");

    public static readonly Selector SupportObjectBinaryLinking = Selector.Register("supportObjectBinaryLinking");

    public static readonly Selector SetSupportObjectBinaryLinking = Selector.Register("setSupportObjectBinaryLinking:");

    public static readonly Selector Reset = Selector.Register("reset");
}
