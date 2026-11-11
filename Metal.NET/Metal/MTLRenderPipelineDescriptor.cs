namespace Metal.NET;

public readonly struct MTLRenderPipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLRenderPipelineDescriptor value) => new(value.NativePtr);

    public MTLRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPipelineDescriptorBindings.Class))
    {
    }

    public MTLRenderPipelineDescriptor Retain()
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLFunction VertexFunction
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.VertexFunction));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetVertexFunction, value.NativePtr);
    }

    public MTLFunction FragmentFunction
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.FragmentFunction));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetFragmentFunction, value.NativePtr);
    }

    public MTLVertexDescriptor VertexDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.VertexDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetVertexDescriptor, value.NativePtr);
    }

    /// <summary>
    /// Deprecated: Use rasterSampleCount instead
    /// </summary>
    [Obsolete("Use rasterSampleCount instead")]
    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSampleCount, value);
    }

    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }

    public Bool8 IsAlphaToCoverageEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsAlphaToCoverageEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToCoverageEnabled, value);
    }

    public Bool8 IsAlphaToOneEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsAlphaToOneEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToOneEnabled, value);
    }

    public Bool8 IsRasterizationEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsRasterizationEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetRasterizationEnabled, value);
    }

    public nuint MaxVertexAmplificationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxVertexAmplificationCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxVertexAmplificationCount, value);
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.ColorAttachments));
    }

    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.DepthAttachmentPixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetDepthAttachmentPixelFormat, (nuint)value);
    }

    public MTLPixelFormat StencilAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.StencilAttachmentPixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetStencilAttachmentPixelFormat, (nuint)value);
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.InputPrimitiveTopology);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetInputPrimitiveTopology, (nuint)value);
    }

    public MTLTessellationPartitionMode TessellationPartitionMode
    {
        get => (MTLTessellationPartitionMode)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationPartitionMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationPartitionMode, (nuint)value);
    }

    public nuint MaxTessellationFactor
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxTessellationFactor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxTessellationFactor, value);
    }

    public Bool8 IsTessellationFactorScaleEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsTessellationFactorScaleEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorScaleEnabled, value);
    }

    public MTLTessellationFactorFormat TessellationFactorFormat
    {
        get => (MTLTessellationFactorFormat)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorFormat, (nuint)value);
    }

    public MTLTessellationControlPointIndexType TessellationControlPointIndexType
    {
        get => (MTLTessellationControlPointIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationControlPointIndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationControlPointIndexType, (nuint)value);
    }

    public MTLTessellationFactorStepFunction TessellationFactorStepFunction
    {
        get => (MTLTessellationFactorStepFunction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorStepFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorStepFunction, (nuint)value);
    }

    public MTLWinding TessellationOutputWindingOrder
    {
        get => (MTLWinding)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationOutputWindingOrder);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationOutputWindingOrder, (nuint)value);
    }

    public MTLPipelineBufferDescriptorArray VertexBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.VertexBuffers));
    }

    public MTLPipelineBufferDescriptorArray FragmentBuffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.FragmentBuffers));
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, value);
    }

    public NSArray<MTLBinaryArchive> BinaryArchives
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.BinaryArchives));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetBinaryArchives, value.NativePtr);
    }

    public NSArray<MTLDynamicLibrary> VertexPreloadedLibraries
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.VertexPreloadedLibraries));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetVertexPreloadedLibraries, value.NativePtr);
    }

    public NSArray<MTLDynamicLibrary> FragmentPreloadedLibraries
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.FragmentPreloadedLibraries));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetFragmentPreloadedLibraries, value.NativePtr);
    }

    public MTLLinkedFunctions VertexLinkedFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.VertexLinkedFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetVertexLinkedFunctions, value.NativePtr);
    }

    public MTLLinkedFunctions FragmentLinkedFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineDescriptorBindings.FragmentLinkedFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, value.NativePtr);
    }

    public Bool8 SupportAddingVertexBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportAddingVertexBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportAddingVertexBinaryFunctions, value);
    }

    public Bool8 SupportAddingFragmentBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportAddingFragmentBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportAddingFragmentBinaryFunctions, value);
    }

    public nuint MaxVertexCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxVertexCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxVertexCallStackDepth, value);
    }

    public nuint MaxFragmentCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.MaxFragmentCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetMaxFragmentCallStackDepth, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPipelineDescriptor");

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

    public static readonly Selector TessellationFactorStepFunction = "tessellationFactorStepFunction";

    public static readonly Selector TessellationOutputWindingOrder = "tessellationOutputWindingOrder";

    public static readonly Selector TessellationPartitionMode = "tessellationPartitionMode";

    public static readonly Selector VertexBuffers = "vertexBuffers";

    public static readonly Selector VertexDescriptor = "vertexDescriptor";

    public static readonly Selector VertexFunction = "vertexFunction";

    public static readonly Selector VertexLinkedFunctions = "vertexLinkedFunctions";

    public static readonly Selector VertexPreloadedLibraries = "vertexPreloadedLibraries";
}
