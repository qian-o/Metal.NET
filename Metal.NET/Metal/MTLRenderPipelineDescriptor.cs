namespace Metal.NET;

public class MTLRenderPipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineDescriptorSelector.Class))
    {
    }

    public bool AlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.AlphaToCoverageEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetAlphaToCoverageEnabled, (Bool8)value);
    }

    public bool AlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.AlphaToOneEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetAlphaToOneEnabled, (Bool8)value);
    }

    public NSArray? BinaryArchives
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get => GetNullableObject<MTLRenderPipelineColorAttachmentDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.ColorAttachments));
    }

    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.DepthAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetDepthAttachmentPixelFormat, (nuint)value);
    }

    public MTLPipelineBufferDescriptorArray? FragmentBuffers
    {
        get => GetNullableObject<MTLPipelineBufferDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.FragmentBuffers));
    }

    public MTLFunction? FragmentFunction
    {
        get => GetNullableObject<MTLFunction>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.FragmentFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentFunction, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? FragmentLinkedFunctions
    {
        get => GetNullableObject<MTLLinkedFunctions>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.FragmentLinkedFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentLinkedFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? FragmentPreloadedLibraries
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.FragmentPreloadedLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetFragmentPreloadedLibraries, value?.NativePtr ?? 0);
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.InputPrimitiveTopology);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetInputPrimitiveTopology, (nuint)value);
    }

    public bool IsAlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.IsAlphaToCoverageEnabled);
    }

    public bool IsAlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.IsAlphaToOneEnabled);
    }

    public bool IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.IsRasterizationEnabled);
    }

    public bool IsTessellationFactorScaleEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.IsTessellationFactorScaleEnabled);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint MaxFragmentCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.MaxFragmentCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxFragmentCallStackDepth, value);
    }

    public nuint MaxTessellationFactor
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.MaxTessellationFactor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxTessellationFactor, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.MaxVertexAmplificationCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxVertexAmplificationCount, value);
    }

    public nuint MaxVertexCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.MaxVertexCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetMaxVertexCallStackDepth, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.RasterSampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetRasterSampleCount, value);
    }

    public bool RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetRasterizationEnabled, (Bool8)value);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSampleCount, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetShaderValidation, (nint)value);
    }

    public MTLPixelFormat StencilAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.StencilAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetStencilAttachmentPixelFormat, (nuint)value);
    }

    public bool SupportAddingFragmentBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.SupportAddingFragmentBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportAddingFragmentBinaryFunctions, (Bool8)value);
    }

    public bool SupportAddingVertexBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.SupportAddingVertexBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportAddingVertexBinaryFunctions, (Bool8)value);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (Bool8)value);
    }

    public MTLTessellationControlPointIndexType TessellationControlPointIndexType
    {
        get => (MTLTessellationControlPointIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.TessellationControlPointIndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationControlPointIndexType, (nuint)value);
    }

    public MTLTessellationFactorFormat TessellationFactorFormat
    {
        get => (MTLTessellationFactorFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.TessellationFactorFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorFormat, (nuint)value);
    }

    public bool TessellationFactorScaleEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorSelector.TessellationFactorScaleEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorScaleEnabled, (Bool8)value);
    }

    public MTLTessellationFactorStepFunction TessellationFactorStepFunction
    {
        get => (MTLTessellationFactorStepFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.TessellationFactorStepFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationFactorStepFunction, (nuint)value);
    }

    public MTLWinding TessellationOutputWindingOrder
    {
        get => (MTLWinding)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.TessellationOutputWindingOrder);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationOutputWindingOrder, (nuint)value);
    }

    public MTLTessellationPartitionMode TessellationPartitionMode
    {
        get => (MTLTessellationPartitionMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorSelector.TessellationPartitionMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetTessellationPartitionMode, (nuint)value);
    }

    public MTLPipelineBufferDescriptorArray? VertexBuffers
    {
        get => GetNullableObject<MTLPipelineBufferDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.VertexBuffers));
    }

    public MTLVertexDescriptor? VertexDescriptor
    {
        get => GetNullableObject<MTLVertexDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.VertexDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexDescriptor, value?.NativePtr ?? 0);
    }

    public MTLFunction? VertexFunction
    {
        get => GetNullableObject<MTLFunction>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.VertexFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexFunction, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? VertexLinkedFunctions
    {
        get => GetNullableObject<MTLLinkedFunctions>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.VertexLinkedFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexLinkedFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? VertexPreloadedLibraries
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorSelector.VertexPreloadedLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.SetVertexPreloadedLibraries, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorSelector.Reset);
    }
}

file static class MTLRenderPipelineDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineDescriptor");

    public static readonly Selector AlphaToCoverageEnabled = Selector.Register("isAlphaToCoverageEnabled");

    public static readonly Selector AlphaToOneEnabled = Selector.Register("isAlphaToOneEnabled");

    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector ColorAttachments = Selector.Register("colorAttachments");

    public static readonly Selector DepthAttachmentPixelFormat = Selector.Register("depthAttachmentPixelFormat");

    public static readonly Selector FragmentBuffers = Selector.Register("fragmentBuffers");

    public static readonly Selector FragmentFunction = Selector.Register("fragmentFunction");

    public static readonly Selector FragmentLinkedFunctions = Selector.Register("fragmentLinkedFunctions");

    public static readonly Selector FragmentPreloadedLibraries = Selector.Register("fragmentPreloadedLibraries");

    public static readonly Selector InputPrimitiveTopology = Selector.Register("inputPrimitiveTopology");

    public static readonly Selector IsAlphaToCoverageEnabled = Selector.Register("isAlphaToCoverageEnabled");

    public static readonly Selector IsAlphaToOneEnabled = Selector.Register("isAlphaToOneEnabled");

    public static readonly Selector IsRasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector IsTessellationFactorScaleEnabled = Selector.Register("isTessellationFactorScaleEnabled");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MaxFragmentCallStackDepth = Selector.Register("maxFragmentCallStackDepth");

    public static readonly Selector MaxTessellationFactor = Selector.Register("maxTessellationFactor");

    public static readonly Selector MaxVertexAmplificationCount = Selector.Register("maxVertexAmplificationCount");

    public static readonly Selector MaxVertexCallStackDepth = Selector.Register("maxVertexCallStackDepth");

    public static readonly Selector RasterizationEnabled = Selector.Register("isRasterizationEnabled");

    public static readonly Selector RasterSampleCount = Selector.Register("rasterSampleCount");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetAlphaToCoverageEnabled = Selector.Register("setAlphaToCoverageEnabled:");

    public static readonly Selector SetAlphaToOneEnabled = Selector.Register("setAlphaToOneEnabled:");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetDepthAttachmentPixelFormat = Selector.Register("setDepthAttachmentPixelFormat:");

    public static readonly Selector SetFragmentFunction = Selector.Register("setFragmentFunction:");

    public static readonly Selector SetFragmentLinkedFunctions = Selector.Register("setFragmentLinkedFunctions:");

    public static readonly Selector SetFragmentPreloadedLibraries = Selector.Register("setFragmentPreloadedLibraries:");

    public static readonly Selector SetInputPrimitiveTopology = Selector.Register("setInputPrimitiveTopology:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetMaxFragmentCallStackDepth = Selector.Register("setMaxFragmentCallStackDepth:");

    public static readonly Selector SetMaxTessellationFactor = Selector.Register("setMaxTessellationFactor:");

    public static readonly Selector SetMaxVertexAmplificationCount = Selector.Register("setMaxVertexAmplificationCount:");

    public static readonly Selector SetMaxVertexCallStackDepth = Selector.Register("setMaxVertexCallStackDepth:");

    public static readonly Selector SetRasterizationEnabled = Selector.Register("setRasterizationEnabled:");

    public static readonly Selector SetRasterSampleCount = Selector.Register("setRasterSampleCount:");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector SetStencilAttachmentPixelFormat = Selector.Register("setStencilAttachmentPixelFormat:");

    public static readonly Selector SetSupportAddingFragmentBinaryFunctions = Selector.Register("setSupportAddingFragmentBinaryFunctions:");

    public static readonly Selector SetSupportAddingVertexBinaryFunctions = Selector.Register("setSupportAddingVertexBinaryFunctions:");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SetTessellationControlPointIndexType = Selector.Register("setTessellationControlPointIndexType:");

    public static readonly Selector SetTessellationFactorFormat = Selector.Register("setTessellationFactorFormat:");

    public static readonly Selector SetTessellationFactorScaleEnabled = Selector.Register("setTessellationFactorScaleEnabled:");

    public static readonly Selector SetTessellationFactorStepFunction = Selector.Register("setTessellationFactorStepFunction:");

    public static readonly Selector SetTessellationOutputWindingOrder = Selector.Register("setTessellationOutputWindingOrder:");

    public static readonly Selector SetTessellationPartitionMode = Selector.Register("setTessellationPartitionMode:");

    public static readonly Selector SetVertexDescriptor = Selector.Register("setVertexDescriptor:");

    public static readonly Selector SetVertexFunction = Selector.Register("setVertexFunction:");

    public static readonly Selector SetVertexLinkedFunctions = Selector.Register("setVertexLinkedFunctions:");

    public static readonly Selector SetVertexPreloadedLibraries = Selector.Register("setVertexPreloadedLibraries:");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector StencilAttachmentPixelFormat = Selector.Register("stencilAttachmentPixelFormat");

    public static readonly Selector SupportAddingFragmentBinaryFunctions = Selector.Register("supportAddingFragmentBinaryFunctions");

    public static readonly Selector SupportAddingVertexBinaryFunctions = Selector.Register("supportAddingVertexBinaryFunctions");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector TessellationControlPointIndexType = Selector.Register("tessellationControlPointIndexType");

    public static readonly Selector TessellationFactorFormat = Selector.Register("tessellationFactorFormat");

    public static readonly Selector TessellationFactorScaleEnabled = Selector.Register("isTessellationFactorScaleEnabled");

    public static readonly Selector TessellationFactorStepFunction = Selector.Register("tessellationFactorStepFunction");

    public static readonly Selector TessellationOutputWindingOrder = Selector.Register("tessellationOutputWindingOrder");

    public static readonly Selector TessellationPartitionMode = Selector.Register("tessellationPartitionMode");

    public static readonly Selector VertexBuffers = Selector.Register("vertexBuffers");

    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");

    public static readonly Selector VertexFunction = Selector.Register("vertexFunction");

    public static readonly Selector VertexLinkedFunctions = Selector.Register("vertexLinkedFunctions");

    public static readonly Selector VertexPreloadedLibraries = Selector.Register("vertexPreloadedLibraries");
}
