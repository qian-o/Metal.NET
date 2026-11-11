namespace Metal.NET;

public readonly struct MTLMeshRenderPipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLMeshRenderPipelineDescriptor value) => new(value.NativePtr);

    public MTLMeshRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTLMeshRenderPipelineDescriptorBindings.Class))
    {
    }

    public MTLMeshRenderPipelineDescriptor Retain()
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

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLFunction ObjectFunction
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ObjectFunction));
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetObjectFunction, value.NativePtr);
    }

    public MTLFunction MeshFunction
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MeshFunction));
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMeshFunction, value.NativePtr);
    }

    public MTLFunction FragmentFunction
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.FragmentFunction));
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetFragmentFunction, value.NativePtr);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerObjectThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerObjectThreadgroup, value);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerMeshThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerMeshThreadgroup, value);
    }

    public Bool8 ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public Bool8 MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public nuint PayloadMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.PayloadMemoryLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetPayloadMemoryLength, value);
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadgroupsPerMeshGrid);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadgroupsPerMeshGrid, value);
    }

    public MTLPipelineBufferDescriptorArray ObjectBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ObjectBuffers));
    }

    public MTLPipelineBufferDescriptorArray MeshBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MeshBuffers));
    }

    public MTLPipelineBufferDescriptorArray FragmentBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.FragmentBuffers));
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public Bool8 IsAlphaToCoverageEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsAlphaToCoverageEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetAlphaToCoverageEnabled, value);
    }

    public Bool8 IsAlphaToOneEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsAlphaToOneEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetAlphaToOneEnabled, value);
    }

    public Bool8 IsRasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsRasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ColorAttachments));
    }

    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLMeshRenderPipelineDescriptorBindings.DepthAttachmentPixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetDepthAttachmentPixelFormat, (nuint)value);
    }

    public MTLPixelFormat StencilAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLMeshRenderPipelineDescriptorBindings.StencilAttachmentPixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetStencilAttachmentPixelFormat, (nuint)value);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, value);
    }

    public NSArray<MTLBinaryArchive> BinaryArchives
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.BinaryArchives));
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetBinaryArchives, value.NativePtr);
    }

    public MTLLinkedFunctions ObjectLinkedFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ObjectLinkedFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetObjectLinkedFunctions, value.NativePtr);
    }

    public MTLLinkedFunctions MeshLinkedFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MeshLinkedFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMeshLinkedFunctions, value.NativePtr);
    }

    public MTLLinkedFunctions FragmentLinkedFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.FragmentLinkedFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, value.NativePtr);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RequiredThreadsPerObjectThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerObjectThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RequiredThreadsPerMeshThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerMeshThreadgroup, value);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLMeshRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLMeshRenderPipelineDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector DepthAttachmentPixelFormat = "depthAttachmentPixelFormat";

    public static readonly Selector FragmentBuffers = "fragmentBuffers";

    public static readonly Selector FragmentFunction = "fragmentFunction";

    public static readonly Selector FragmentLinkedFunctions = "fragmentLinkedFunctions";

    public static readonly Selector IsAlphaToCoverageEnabled = "isAlphaToCoverageEnabled";

    public static readonly Selector IsAlphaToOneEnabled = "isAlphaToOneEnabled";

    public static readonly Selector IsRasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";

    public static readonly Selector MaxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";

    public static readonly Selector MaxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";

    public static readonly Selector MaxVertexAmplificationCount = "maxVertexAmplificationCount";

    public static readonly Selector MeshBuffers = "meshBuffers";

    public static readonly Selector MeshFunction = "meshFunction";

    public static readonly Selector MeshLinkedFunctions = "meshLinkedFunctions";

    public static readonly Selector MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = "meshThreadgroupSizeIsMultipleOfThreadExecutionWidth";

    public static readonly Selector ObjectBuffers = "objectBuffers";

    public static readonly Selector ObjectFunction = "objectFunction";

    public static readonly Selector ObjectLinkedFunctions = "objectLinkedFunctions";

    public static readonly Selector ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = "objectThreadgroupSizeIsMultipleOfThreadExecutionWidth";

    public static readonly Selector PayloadMemoryLength = "payloadMemoryLength";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector RequiredThreadsPerMeshThreadgroup = "requiredThreadsPerMeshThreadgroup";

    public static readonly Selector RequiredThreadsPerObjectThreadgroup = "requiredThreadsPerObjectThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";

    public static readonly Selector SetAlphaToOneEnabled = "setAlphaToOneEnabled:";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";

    public static readonly Selector SetFragmentFunction = "setFragmentFunction:";

    public static readonly Selector SetFragmentLinkedFunctions = "setFragmentLinkedFunctions:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMaxTotalThreadgroupsPerMeshGrid = "setMaxTotalThreadgroupsPerMeshGrid:";

    public static readonly Selector SetMaxTotalThreadsPerMeshThreadgroup = "setMaxTotalThreadsPerMeshThreadgroup:";

    public static readonly Selector SetMaxTotalThreadsPerObjectThreadgroup = "setMaxTotalThreadsPerObjectThreadgroup:";

    public static readonly Selector SetMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";

    public static readonly Selector SetMeshFunction = "setMeshFunction:";

    public static readonly Selector SetMeshLinkedFunctions = "setMeshLinkedFunctions:";

    public static readonly Selector SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = "setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:";

    public static readonly Selector SetObjectFunction = "setObjectFunction:";

    public static readonly Selector SetObjectLinkedFunctions = "setObjectLinkedFunctions:";

    public static readonly Selector SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = "setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:";

    public static readonly Selector SetPayloadMemoryLength = "setPayloadMemoryLength:";

    public static readonly Selector SetRasterizationEnabled = "setRasterizationEnabled:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetRequiredThreadsPerMeshThreadgroup = "setRequiredThreadsPerMeshThreadgroup:";

    public static readonly Selector SetRequiredThreadsPerObjectThreadgroup = "setRequiredThreadsPerObjectThreadgroup:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector SetStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";

    public static readonly Selector SetSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector StencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";
}
