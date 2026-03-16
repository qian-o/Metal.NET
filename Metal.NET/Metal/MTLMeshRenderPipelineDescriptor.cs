namespace Metal.NET;

public class MTLMeshRenderPipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLMeshRenderPipelineDescriptor>
{
    #region INativeObject
    public static new MTLMeshRenderPipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLMeshRenderPipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLMeshRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTLMeshRenderPipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    /// <summary>Deprecated: please use isAlphaToCoverageEnabled instead</summary>
    [Obsolete("please use isAlphaToCoverageEnabled instead")]
    public Bool8 AlphaToCoverageEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.AlphaToCoverageEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetAlphaToCoverageEnabled, value);
    }

    /// <summary>Deprecated: please use isAlphaToOneEnabled instead</summary>
    [Obsolete("please use isAlphaToOneEnabled instead")]
    public Bool8 AlphaToOneEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.AlphaToOneEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetAlphaToOneEnabled, value);
    }

    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLMeshRenderPipelineDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLMeshRenderPipelineDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ColorAttachments);
    }

    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLMeshRenderPipelineDescriptorBindings.DepthAttachmentPixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetDepthAttachmentPixelFormat, (nuint)value);
    }

    public MTLPipelineBufferDescriptorArray FragmentBuffers
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentBuffers);
    }

    public MTLFunction FragmentFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetFragmentFunction, value);
    }

    public MTLLinkedFunctions FragmentLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, value);
    }

    public Bool8 IsAlphaToCoverageEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsAlphaToCoverageEnabled);
    }

    public Bool8 IsAlphaToOneEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsAlphaToOneEnabled);
    }

    public Bool8 IsRasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsRasterizationEnabled);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetLabel, value);
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadgroupsPerMeshGrid);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadgroupsPerMeshGrid, value);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerMeshThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerMeshThreadgroup, value);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerObjectThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerObjectThreadgroup, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    public MTLPipelineBufferDescriptorArray MeshBuffers
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshBuffers);
    }

    public MTLFunction MeshFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetMeshFunction, value);
    }

    public MTLLinkedFunctions MeshLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetMeshLinkedFunctions, value);
    }

    public Bool8 MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public MTLPipelineBufferDescriptorArray ObjectBuffers
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectBuffers);
    }

    public MTLFunction ObjectFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetObjectFunction, value);
    }

    public MTLLinkedFunctions ObjectLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetObjectLinkedFunctions, value);
    }

    public Bool8 ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public nuint PayloadMemoryLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.PayloadMemoryLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetPayloadMemoryLength, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    /// <summary>Deprecated: please use isRasterizationEnabled instead</summary>
    [Obsolete("please use isRasterizationEnabled instead")]
    public Bool8 RasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RequiredThreadsPerMeshThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerMeshThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RequiredThreadsPerObjectThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerObjectThreadgroup, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
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

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLMeshRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLMeshRenderPipelineDescriptor");

    public static readonly Selector AlphaToCoverageEnabled = "isAlphaToCoverageEnabled";

    public static readonly Selector AlphaToOneEnabled = "isAlphaToOneEnabled";

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

    public static readonly Selector RasterizationEnabled = "isRasterizationEnabled";

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
