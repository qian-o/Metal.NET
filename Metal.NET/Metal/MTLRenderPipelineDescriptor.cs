namespace Metal.NET;

public class MTLRenderPipelineDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLRenderPipelineDescriptor>
{
    public static MTLRenderPipelineDescriptor Null { get; } = new(0, false, false);

    public static MTLRenderPipelineDescriptor Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTLRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineDescriptorBindings.Class), true, true)
    {
    }

    public Bool8 AlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.AlphaToCoverageEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToCoverageEnabled, value);
    }

    public Bool8 AlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.AlphaToOneEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToOneEnabled, value);
    }

    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLRenderPipelineDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLRenderPipelineDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.ColorAttachments);
    }

    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.DepthAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetDepthAttachmentPixelFormat, (nuint)value);
    }

    public MTLPipelineBufferDescriptorArray FragmentBuffers
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.FragmentBuffers);
    }

    public MTLFunction FragmentFunction
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.FragmentFunction);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetFragmentFunction, value);
    }

    public MTLLinkedFunctions FragmentLinkedFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.FragmentLinkedFunctions);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, value);
    }

    public MTLDynamicLibrary[] FragmentPreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLRenderPipelineDescriptorBindings.FragmentPreloadedLibraries);
        set => SetArrayProperty(MTLRenderPipelineDescriptorBindings.SetFragmentPreloadedLibraries, value);
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.InputPrimitiveTopology);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetInputPrimitiveTopology, (nuint)value);
    }

    public Bool8 IsAlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsAlphaToCoverageEnabled);
    }

    public Bool8 IsAlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsAlphaToOneEnabled);
    }

    public Bool8 IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsRasterizationEnabled);
    }

    public Bool8 IsTessellationFactorScaleEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsTessellationFactorScaleEnabled);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetLabel, value);
    }

    public nuint MaxFragmentCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxFragmentCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxFragmentCallStackDepth, value);
    }

    public nuint MaxTessellationFactor
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxTessellationFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxTessellationFactor, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    public nuint MaxVertexCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxVertexCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxVertexCallStackDepth, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public Bool8 RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSampleCount, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public MTLPixelFormat StencilAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.StencilAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetStencilAttachmentPixelFormat, (nuint)value);
    }

    public Bool8 SupportAddingFragmentBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportAddingFragmentBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportAddingFragmentBinaryFunctions, value);
    }

    public Bool8 SupportAddingVertexBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportAddingVertexBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportAddingVertexBinaryFunctions, value);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, value);
    }

    public MTLTessellationControlPointIndexType TessellationControlPointIndexType
    {
        get => (MTLTessellationControlPointIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationControlPointIndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationControlPointIndexType, (nuint)value);
    }

    public MTLTessellationFactorFormat TessellationFactorFormat
    {
        get => (MTLTessellationFactorFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorFormat, (nuint)value);
    }

    public Bool8 TessellationFactorScaleEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorScaleEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorScaleEnabled, value);
    }

    public MTLTessellationFactorStepFunction TessellationFactorStepFunction
    {
        get => (MTLTessellationFactorStepFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorStepFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorStepFunction, (nuint)value);
    }

    public MTLWinding TessellationOutputWindingOrder
    {
        get => (MTLWinding)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationOutputWindingOrder);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationOutputWindingOrder, (nuint)value);
    }

    public MTLTessellationPartitionMode TessellationPartitionMode
    {
        get => (MTLTessellationPartitionMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationPartitionMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationPartitionMode, (nuint)value);
    }

    public MTLPipelineBufferDescriptorArray VertexBuffers
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.VertexBuffers);
    }

    public MTLVertexDescriptor VertexDescriptor
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.VertexDescriptor);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetVertexDescriptor, value);
    }

    public MTLFunction VertexFunction
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.VertexFunction);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetVertexFunction, value);
    }

    public MTLLinkedFunctions VertexLinkedFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineDescriptorBindings.VertexLinkedFunctions);
        set => SetProperty(ref field, MTLRenderPipelineDescriptorBindings.SetVertexLinkedFunctions, value);
    }

    public MTLDynamicLibrary[] VertexPreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLRenderPipelineDescriptorBindings.VertexPreloadedLibraries);
        set => SetArrayProperty(MTLRenderPipelineDescriptorBindings.SetVertexPreloadedLibraries, value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineDescriptor");

    public static readonly Selector AlphaToCoverageEnabled = "isAlphaToCoverageEnabled";

    public static readonly Selector AlphaToOneEnabled = "isAlphaToOneEnabled";

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector DepthAttachmentPixelFormat = "depthAttachmentPixelFormat";

    public static readonly Selector FragmentBuffers = "fragmentBuffers";

    public static readonly Selector FragmentFunction = "fragmentFunction";

    public static readonly Selector FragmentLinkedFunctions = "fragmentLinkedFunctions";

    public static readonly Selector FragmentPreloadedLibraries = "fragmentPreloadedLibraries";

    public static readonly Selector InputPrimitiveTopology = "inputPrimitiveTopology";

    public static readonly Selector IsAlphaToCoverageEnabled = "isAlphaToCoverageEnabled";

    public static readonly Selector IsAlphaToOneEnabled = "isAlphaToOneEnabled";

    public static readonly Selector IsRasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector IsTessellationFactorScaleEnabled = "isTessellationFactorScaleEnabled";

    public static readonly Selector Label = "label";

    public static readonly Selector MaxFragmentCallStackDepth = "maxFragmentCallStackDepth";

    public static readonly Selector MaxTessellationFactor = "maxTessellationFactor";

    public static readonly Selector MaxVertexAmplificationCount = "maxVertexAmplificationCount";

    public static readonly Selector MaxVertexCallStackDepth = "maxVertexCallStackDepth";

    public static readonly Selector RasterizationEnabled = "isRasterizationEnabled";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";

    public static readonly Selector SetAlphaToOneEnabled = "setAlphaToOneEnabled:";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";

    public static readonly Selector SetFragmentFunction = "setFragmentFunction:";

    public static readonly Selector SetFragmentLinkedFunctions = "setFragmentLinkedFunctions:";

    public static readonly Selector SetFragmentPreloadedLibraries = "setFragmentPreloadedLibraries:";

    public static readonly Selector SetInputPrimitiveTopology = "setInputPrimitiveTopology:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMaxFragmentCallStackDepth = "setMaxFragmentCallStackDepth:";

    public static readonly Selector SetMaxTessellationFactor = "setMaxTessellationFactor:";

    public static readonly Selector SetMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";

    public static readonly Selector SetMaxVertexCallStackDepth = "setMaxVertexCallStackDepth:";

    public static readonly Selector SetRasterizationEnabled = "setRasterizationEnabled:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector SetStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";

    public static readonly Selector SetSupportAddingFragmentBinaryFunctions = "setSupportAddingFragmentBinaryFunctions:";

    public static readonly Selector SetSupportAddingVertexBinaryFunctions = "setSupportAddingVertexBinaryFunctions:";

    public static readonly Selector SetSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";

    public static readonly Selector SetTessellationControlPointIndexType = "setTessellationControlPointIndexType:";

    public static readonly Selector SetTessellationFactorFormat = "setTessellationFactorFormat:";

    public static readonly Selector SetTessellationFactorScaleEnabled = "setTessellationFactorScaleEnabled:";

    public static readonly Selector SetTessellationFactorStepFunction = "setTessellationFactorStepFunction:";

    public static readonly Selector SetTessellationOutputWindingOrder = "setTessellationOutputWindingOrder:";

    public static readonly Selector SetTessellationPartitionMode = "setTessellationPartitionMode:";

    public static readonly Selector SetVertexDescriptor = "setVertexDescriptor:";

    public static readonly Selector SetVertexFunction = "setVertexFunction:";

    public static readonly Selector SetVertexLinkedFunctions = "setVertexLinkedFunctions:";

    public static readonly Selector SetVertexPreloadedLibraries = "setVertexPreloadedLibraries:";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector StencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";

    public static readonly Selector SupportAddingFragmentBinaryFunctions = "supportAddingFragmentBinaryFunctions";

    public static readonly Selector SupportAddingVertexBinaryFunctions = "supportAddingVertexBinaryFunctions";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector TessellationControlPointIndexType = "tessellationControlPointIndexType";

    public static readonly Selector TessellationFactorFormat = "tessellationFactorFormat";

    public static readonly Selector TessellationFactorScaleEnabled = "isTessellationFactorScaleEnabled";

    public static readonly Selector TessellationFactorStepFunction = "tessellationFactorStepFunction";

    public static readonly Selector TessellationOutputWindingOrder = "tessellationOutputWindingOrder";

    public static readonly Selector TessellationPartitionMode = "tessellationPartitionMode";

    public static readonly Selector VertexBuffers = "vertexBuffers";

    public static readonly Selector VertexDescriptor = "vertexDescriptor";

    public static readonly Selector VertexFunction = "vertexFunction";

    public static readonly Selector VertexLinkedFunctions = "vertexLinkedFunctions";

    public static readonly Selector VertexPreloadedLibraries = "vertexPreloadedLibraries";
}
