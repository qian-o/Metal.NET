namespace Metal.NET;

public partial class MTLMeshRenderPipelineDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLMeshRenderPipelineDescriptor");

    public MTLMeshRenderPipelineDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public bool AlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.AlphaToCoverageEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetAlphaToCoverageEnabled, (Bool8)value);
    }

    public bool AlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.AlphaToOneEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetAlphaToOneEnabled, (Bool8)value);
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.BinaryArchives);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.ColorAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorSelector.DepthAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetDepthAttachmentPixelFormat, (nuint)value);
    }

    public MTLPipelineBufferDescriptorArray? FragmentBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.FragmentBuffers);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLFunction? FragmentFunction
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.FragmentFunction);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetFragmentFunction, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? FragmentLinkedFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.FragmentLinkedFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetFragmentLinkedFunctions, value?.NativePtr ?? 0);
    }

    public bool IsAlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.IsAlphaToCoverageEnabled);
    }

    public bool IsAlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.IsAlphaToOneEnabled);
    }

    public bool IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.IsRasterizationEnabled);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorSelector.MaxTotalThreadgroupsPerMeshGrid);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadgroupsPerMeshGrid, value);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorSelector.MaxTotalThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerMeshThreadgroup, value);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorSelector.MaxTotalThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxTotalThreadsPerObjectThreadgroup, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorSelector.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, value);
    }

    public MTLPipelineBufferDescriptorArray? MeshBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.MeshBuffers);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLFunction? MeshFunction
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.MeshFunction);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshFunction, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? MeshLinkedFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.MeshLinkedFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshLinkedFunctions, value?.NativePtr ?? 0);
    }

    public bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public MTLPipelineBufferDescriptorArray? ObjectBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.ObjectBuffers);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLFunction? ObjectFunction
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.ObjectFunction);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectFunction, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? ObjectLinkedFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.ObjectLinkedFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectLinkedFunctions, value?.NativePtr ?? 0);
    }

    public bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public nuint PayloadMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorSelector.PayloadMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetPayloadMemoryLength, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRasterSampleCount, value);
    }

    public bool RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRasterizationEnabled, (Bool8)value);
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLMeshRenderPipelineDescriptorSelector.RequiredThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerMeshThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLMeshRenderPipelineDescriptorSelector.RequiredThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetRequiredThreadsPerObjectThreadgroup, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorSelector.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetShaderValidation, (nint)value);
    }

    public MTLPixelFormat StencilAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorSelector.StencilAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetStencilAttachmentPixelFormat, (nuint)value);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (Bool8)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorSelector.Reset);
    }
}

file static class MTLMeshRenderPipelineDescriptorSelector
{
    public static readonly Selector AlphaToCoverageEnabled = Selector.Register("alphaToCoverageEnabled");

    public static readonly Selector AlphaToOneEnabled = Selector.Register("alphaToOneEnabled");

    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector DepthAttachmentPixelFormat = Selector.Register("depthAttachmentPixelFormat");

    public static readonly Selector FragmentBuffers = Selector.Register("fragmentBuffers");

    public static readonly Selector FragmentFunction = Selector.Register("fragmentFunction");

    public static readonly Selector FragmentLinkedFunctions = Selector.Register("fragmentLinkedFunctions");

    public static readonly Selector IsAlphaToCoverageEnabled = Selector.Register("isAlphaToCoverageEnabled");

    public static readonly Selector IsAlphaToOneEnabled = Selector.Register("isAlphaToOneEnabled");

    public static readonly Selector IsRasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = Selector.Register("maxTotalThreadgroupsPerMeshGrid");

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = Selector.Register("maxTotalThreadsPerMeshThreadgroup");

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = Selector.Register("maxTotalThreadsPerObjectThreadgroup");

    public static readonly Selector MaxVertexAmplificationCount = Selector.Register("maxVertexAmplificationCount");

    public static readonly Selector MeshBuffers = Selector.Register("meshBuffers");

    public static readonly Selector MeshFunction = Selector.Register("meshFunction");

    public static readonly Selector MeshLinkedFunctions = Selector.Register("meshLinkedFunctions");

    public static readonly Selector MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("meshThreadgroupSizeIsMultipleOfThreadExecutionWidth");

    public static readonly Selector ObjectBuffers = Selector.Register("objectBuffers");

    public static readonly Selector ObjectFunction = Selector.Register("objectFunction");

    public static readonly Selector ObjectLinkedFunctions = Selector.Register("objectLinkedFunctions");

    public static readonly Selector ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("objectThreadgroupSizeIsMultipleOfThreadExecutionWidth");

    public static readonly Selector PayloadMemoryLength = Selector.Register("payloadMemoryLength");

    public static readonly Selector RasterizationEnabled = Selector.Register("rasterizationEnabled");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = Selector.Register("requiredThreadsPerMeshThreadgroup");

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = Selector.Register("requiredThreadsPerObjectThreadgroup");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetAlphaToCoverageEnabled = Selector.Register("setAlphaToCoverageEnabled:");

    public static readonly Selector SetAlphaToOneEnabled = Selector.Register("setAlphaToOneEnabled:");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetDepthAttachmentPixelFormat = Selector.Register("setDepthAttachmentPixelFormat:");

    public static readonly Selector SetFragmentFunction = Selector.Register("setFragmentFunction:");

    public static readonly Selector SetFragmentLinkedFunctions = Selector.Register("setFragmentLinkedFunctions:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid = Selector.Register("setMaxTotalThreadgroupsPerMeshGrid:");

    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup = Selector.Register("setMaxTotalThreadsPerMeshThreadgroup:");

    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup = Selector.Register("setMaxTotalThreadsPerObjectThreadgroup:");

    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");

    public static readonly Selector SetMeshFunction = Selector.Register("setMeshFunction:");

    public static readonly Selector SetMeshLinkedFunctions = Selector.Register("setMeshLinkedFunctions:");

    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector SetObjectFunction = Selector.Register("setObjectFunction:");

    public static readonly Selector SetObjectLinkedFunctions = Selector.Register("setObjectLinkedFunctions:");

    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector SetPayloadMemoryLength = Selector.Register("setPayloadMemoryLength:");

    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup = Selector.Register("setRequiredThreadsPerMeshThreadgroup:");

    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup = Selector.Register("setRequiredThreadsPerObjectThreadgroup:");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector SetStencilAttachmentPixelFormat = Selector.Register("setStencilAttachmentPixelFormat:");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector StencilAttachmentPixelFormat = Selector.Register("stencilAttachmentPixelFormat");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");
}
