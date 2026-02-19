namespace Metal.NET;

public class MTL4MeshRenderPipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4MeshRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4MeshRenderPipelineDescriptorBindings.Class))
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

    public MTL4RenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.ColorAttachments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4RenderPipelineColorAttachmentDescriptorArray(ptr);
            }

            return field;
        }
    }

    public MTL4FunctionDescriptor? FragmentFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.FragmentFunctionDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4FunctionDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetFragmentFunctionDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTL4StaticLinkingDescriptor? FragmentStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.FragmentStaticLinkingDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4StaticLinkingDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetFragmentStaticLinkingDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
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

    public MTL4FunctionDescriptor? MeshFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MeshFunctionDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4FunctionDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMeshFunctionDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTL4StaticLinkingDescriptor? MeshStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MeshStaticLinkingDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4StaticLinkingDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMeshStaticLinkingDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public MTL4FunctionDescriptor? ObjectFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.ObjectFunctionDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4FunctionDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetObjectFunctionDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTL4StaticLinkingDescriptor? ObjectStaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.ObjectStaticLinkingDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4StaticLinkingDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4MeshRenderPipelineDescriptorBindings.SetObjectStaticLinkingDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
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
