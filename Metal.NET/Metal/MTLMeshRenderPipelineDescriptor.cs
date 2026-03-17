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

    public NSString Label
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetLabel, value);
    }

    public MTLFunction ObjectFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetObjectFunction, value);
    }

    public MTLFunction MeshFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetMeshFunction, value);
    }

    public MTLFunction FragmentFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetFragmentFunction, value);
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
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectBuffers);
    }

    public MTLPipelineBufferDescriptorArray MeshBuffers
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshBuffers);
    }

    public MTLPipelineBufferDescriptorArray FragmentBuffers
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentBuffers);
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
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ColorAttachments);
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

    public MTLLinkedFunctions ObjectLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetObjectLinkedFunctions, value);
    }

    public MTLLinkedFunctions MeshLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetMeshLinkedFunctions, value);
    }

    public MTLLinkedFunctions FragmentLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, value);
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

    public NSString Label
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetLabel, value);
    }

    public MTLFunction ObjectFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetObjectFunction, value);
    }

    public MTLFunction MeshFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetMeshFunction, value);
    }

    public MTLFunction FragmentFunction
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentFunction);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetFragmentFunction, value);
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
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectBuffers);
    }

    public MTLPipelineBufferDescriptorArray MeshBuffers
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshBuffers);
    }

    public MTLPipelineBufferDescriptorArray FragmentBuffers
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentBuffers);
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
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ColorAttachments);
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

    public MTLLinkedFunctions ObjectLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.ObjectLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetObjectLinkedFunctions, value);
    }

    public MTLLinkedFunctions MeshLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.MeshLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetMeshLinkedFunctions, value);
    }

    public MTLLinkedFunctions FragmentLinkedFunctions
    {
        get => GetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.FragmentLinkedFunctions);
        set => SetProperty(ref field, MTLMeshRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, value);
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

    public void SetLabel(NSString label)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetLabel, label.NativePtr);
    }

    public void SetObjectFunction(MTLFunction objectFunction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetObjectFunction, objectFunction.NativePtr);
    }

    public void SetMeshFunction(MTLFunction meshFunction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMeshFunction, meshFunction.NativePtr);
    }

    public void SetFragmentFunction(MTLFunction fragmentFunction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetFragmentFunction, fragmentFunction.NativePtr);
    }

    public void SetMaxTotalThreadsPerObjectThreadgroup(nuint maxTotalThreadsPerObjectThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerObjectThreadgroup, maxTotalThreadsPerObjectThreadgroup);
    }

    public void SetMaxTotalThreadsPerMeshThreadgroup(nuint maxTotalThreadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerMeshThreadgroup, maxTotalThreadsPerMeshThreadgroup);
    }

    public void SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth(bool objectThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, objectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
    }

    public void SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth(bool meshThreadgroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, meshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
    }

    public void SetPayloadMemoryLength(nuint payloadMemoryLength)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetPayloadMemoryLength, payloadMemoryLength);
    }

    public void SetMaxTotalThreadgroupsPerMeshGrid(nuint maxTotalThreadgroupsPerMeshGrid)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxTotalThreadgroupsPerMeshGrid, maxTotalThreadgroupsPerMeshGrid);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRasterSampleCount, rasterSampleCount);
    }

    public void SetIsAlphaToCoverageEnabled(bool isAlphaToCoverageEnabled)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetIsAlphaToCoverageEnabled, isAlphaToCoverageEnabled);
    }

    public void SetIsAlphaToOneEnabled(bool isAlphaToOneEnabled)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetIsAlphaToOneEnabled, isAlphaToOneEnabled);
    }

    public void SetIsRasterizationEnabled(bool isRasterizationEnabled)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetIsRasterizationEnabled, isRasterizationEnabled);
    }

    public void SetMaxVertexAmplificationCount(nuint maxVertexAmplificationCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, maxVertexAmplificationCount);
    }

    public void SetDepthAttachmentPixelFormat(MTLPixelFormat depthAttachmentPixelFormat)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetDepthAttachmentPixelFormat, (nuint)depthAttachmentPixelFormat);
    }

    public void SetStencilAttachmentPixelFormat(MTLPixelFormat stencilAttachmentPixelFormat)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetStencilAttachmentPixelFormat, (nuint)stencilAttachmentPixelFormat);
    }

    public void SetSupportIndirectCommandBuffers(bool supportIndirectCommandBuffers)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, supportIndirectCommandBuffers);
    }

    public void SetObjectLinkedFunctions(MTLLinkedFunctions objectLinkedFunctions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetObjectLinkedFunctions, objectLinkedFunctions.NativePtr);
    }

    public void SetMeshLinkedFunctions(MTLLinkedFunctions meshLinkedFunctions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetMeshLinkedFunctions, meshLinkedFunctions.NativePtr);
    }

    public void SetFragmentLinkedFunctions(MTLLinkedFunctions fragmentLinkedFunctions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, fragmentLinkedFunctions.NativePtr);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetShaderValidation, (nint)shaderValidation);
    }

    public void SetRequiredThreadsPerObjectThreadgroup(MTLSize requiredThreadsPerObjectThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerObjectThreadgroup, requiredThreadsPerObjectThreadgroup);
    }

    public void SetRequiredThreadsPerMeshThreadgroup(MTLSize requiredThreadsPerMeshThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.SetRequiredThreadsPerMeshThreadgroup, requiredThreadsPerMeshThreadgroup);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLMeshRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLMeshRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLMeshRenderPipelineDescriptor");

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

    public static readonly Selector SetDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";

    public static readonly Selector SetFragmentFunction = "setFragmentFunction:";

    public static readonly Selector SetFragmentLinkedFunctions = "setFragmentLinkedFunctions:";

    public static readonly Selector SetIsAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";

    public static readonly Selector SetIsAlphaToOneEnabled = "setAlphaToOneEnabled:";

    public static readonly Selector SetIsRasterizationEnabled = "setRasterizationEnabled:";

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
