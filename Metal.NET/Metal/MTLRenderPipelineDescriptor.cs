namespace Metal.NET;

public class MTLRenderPipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineDescriptorBindings.Class))
    {
    }

    public bool AlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.AlphaToCoverageEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToCoverageEnabled, (Bool8)value);
    }

    public bool AlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.AlphaToOneEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetAlphaToOneEnabled, (Bool8)value);
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.BinaryArchives);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetBinaryArchives, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray? ColorAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.ColorAttachments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLRenderPipelineColorAttachmentDescriptorArray(ptr);
            }

            return field;
        }
    }

    public MTLPixelFormat DepthAttachmentPixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.DepthAttachmentPixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetDepthAttachmentPixelFormat, (nuint)value);
    }

    public MTLPipelineBufferDescriptorArray? FragmentBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.FragmentBuffers);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLPipelineBufferDescriptorArray(ptr);
            }

            return field;
        }
    }

    public MTLFunction? FragmentFunction
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.FragmentFunction);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLFunction(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetFragmentFunction, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLLinkedFunctions? FragmentLinkedFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.FragmentLinkedFunctions);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLLinkedFunctions(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetFragmentLinkedFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? FragmentPreloadedLibraries
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.FragmentPreloadedLibraries);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetFragmentPreloadedLibraries, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLPrimitiveTopologyClass InputPrimitiveTopology
    {
        get => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPipelineDescriptorBindings.InputPrimitiveTopology);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetInputPrimitiveTopology, (nuint)value);
    }

    public bool IsAlphaToCoverageEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsAlphaToCoverageEnabled);
    }

    public bool IsAlphaToOneEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsAlphaToOneEnabled);
    }

    public bool IsRasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsRasterizationEnabled);
    }

    public bool IsTessellationFactorScaleEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.IsTessellationFactorScaleEnabled);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
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

    public bool RasterizationEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.RasterizationEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetRasterizationEnabled, (Bool8)value);
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

    public bool SupportAddingFragmentBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportAddingFragmentBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportAddingFragmentBinaryFunctions, (Bool8)value);
    }

    public bool SupportAddingVertexBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportAddingVertexBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportAddingVertexBinaryFunctions, (Bool8)value);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (Bool8)value);
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

    public bool TessellationFactorScaleEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLRenderPipelineDescriptorBindings.TessellationFactorScaleEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetTessellationFactorScaleEnabled, (Bool8)value);
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

    public MTLPipelineBufferDescriptorArray? VertexBuffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.VertexBuffers);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLPipelineBufferDescriptorArray(ptr);
            }

            return field;
        }
    }

    public MTLVertexDescriptor? VertexDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.VertexDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLVertexDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetVertexDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLFunction? VertexFunction
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.VertexFunction);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLFunction(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetVertexFunction, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLLinkedFunctions? VertexLinkedFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.VertexLinkedFunctions);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLLinkedFunctions(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetVertexLinkedFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? VertexPreloadedLibraries
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineDescriptorBindings.VertexPreloadedLibraries);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.SetVertexPreloadedLibraries, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineDescriptorBindings.Reset);
    }
}

file static class MTLRenderPipelineDescriptorBindings
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
