namespace Metal.NET;

public class MTLMeshRenderPipelineDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLMeshRenderPipelineDescriptor>
{
    public static MTLMeshRenderPipelineDescriptor Create(nint nativePtr) => new(nativePtr);

    public MTLMeshRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLMeshRenderPipelineDescriptorBindings.Class))
    {
    }

    public bool AlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.AlphaToCoverageEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetAlphaToCoverageEnabled, (Bool8)value);
    }

    public bool AlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.AlphaToOneEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetAlphaToOneEnabled, (Bool8)value);
    }

    public NSArray BinaryArchives
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.BinaryArchives);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ColorAttachments);
    }

    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.DepthAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetDepthAttachmentPixelFormat, (nuint)value);
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

    public bool IsAlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsAlphaToCoverageEnabled);
    }

    public bool IsAlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsAlphaToOneEnabled);
    }

    public bool IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.IsRasterizationEnabled);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetLabel, value);
    }

    public nuint MaxTotalThreadgroupsPerMeshGrid
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadgroupsPerMeshGrid);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadgroupsPerMeshGrid, value);
    }

    public nuint MaxTotalThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerMeshThreadgroup, value);
    }

    public nuint MaxTotalThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxTotalThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerObjectThreadgroup, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
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

    public bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
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

    public bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public nuint PayloadMemoryLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.PayloadMemoryLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetPayloadMemoryLength, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public bool RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRasterizationEnabled, (Bool8)value);
    }

    public MTLSize RequiredThreadsPerMeshThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RequiredThreadsPerMeshThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerMeshThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerObjectThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLMeshRenderPipelineDescriptorBindings.RequiredThreadsPerObjectThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerObjectThreadgroup, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLMeshRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public MTLPixelFormat StencilAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLMeshRenderPipelineDescriptorBindings.StencilAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetStencilAttachmentPixelFormat, (nuint)value);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (Bool8)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLMeshRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLMeshRenderPipelineDescriptor");

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
