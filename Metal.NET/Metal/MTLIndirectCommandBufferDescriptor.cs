namespace Metal.NET;

public readonly struct MTLIndirectCommandBufferDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLIndirectCommandBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIndirectCommandBufferDescriptorBindings.Class))
    {
    }

    public MTLIndirectCommandType CommandTypes
    {
        get => (MTLIndirectCommandType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.CommandTypes);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetCommandTypes, (nuint)value);
    }

    public bool InheritBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritBuffers, (Bool8)value);
    }

    public bool InheritCullMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritCullMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritCullMode, (Bool8)value);
    }

    public bool InheritDepthBias
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthBias);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthBias, (Bool8)value);
    }

    public bool InheritDepthClipMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthClipMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthClipMode, (Bool8)value);
    }

    public bool InheritDepthStencilState
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthStencilState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthStencilState, (Bool8)value);
    }

    public bool InheritFrontFacingWinding
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritFrontFacingWinding);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritFrontFacingWinding, (Bool8)value);
    }

    public bool InheritPipelineState
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritPipelineState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritPipelineState, (Bool8)value);
    }

    public bool InheritTriangleFillMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritTriangleFillMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritTriangleFillMode, (Bool8)value);
    }

    public nuint MaxFragmentBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxFragmentBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxFragmentBufferBindCount, value);
    }

    public nuint MaxKernelBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxKernelBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxKernelBufferBindCount, value);
    }

    public nuint MaxKernelThreadgroupMemoryBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxKernelThreadgroupMemoryBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxKernelThreadgroupMemoryBindCount, value);
    }

    public nuint MaxMeshBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxMeshBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxMeshBufferBindCount, value);
    }

    public nuint MaxObjectBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxObjectBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxObjectBufferBindCount, value);
    }

    public nuint MaxObjectThreadgroupMemoryBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxObjectThreadgroupMemoryBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxObjectThreadgroupMemoryBindCount, value);
    }

    public nuint MaxVertexBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxVertexBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxVertexBufferBindCount, value);
    }

    public bool SupportColorAttachmentMapping
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportColorAttachmentMapping, (Bool8)value);
    }

    public bool SupportDynamicAttributeStride
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportDynamicAttributeStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportDynamicAttributeStride, (Bool8)value);
    }

    public bool SupportRayTracing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportRayTracing);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportRayTracing, (Bool8)value);
    }
}

file static class MTLIndirectCommandBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIndirectCommandBufferDescriptor");

    public static readonly Selector CommandTypes = Selector.Register("commandTypes");

    public static readonly Selector InheritBuffers = Selector.Register("inheritBuffers");

    public static readonly Selector InheritCullMode = Selector.Register("inheritCullMode");

    public static readonly Selector InheritDepthBias = Selector.Register("inheritDepthBias");

    public static readonly Selector InheritDepthClipMode = Selector.Register("inheritDepthClipMode");

    public static readonly Selector InheritDepthStencilState = Selector.Register("inheritDepthStencilState");

    public static readonly Selector InheritFrontFacingWinding = Selector.Register("inheritFrontFacingWinding");

    public static readonly Selector InheritPipelineState = Selector.Register("inheritPipelineState");

    public static readonly Selector InheritTriangleFillMode = Selector.Register("inheritTriangleFillMode");

    public static readonly Selector MaxFragmentBufferBindCount = Selector.Register("maxFragmentBufferBindCount");

    public static readonly Selector MaxKernelBufferBindCount = Selector.Register("maxKernelBufferBindCount");

    public static readonly Selector MaxKernelThreadgroupMemoryBindCount = Selector.Register("maxKernelThreadgroupMemoryBindCount");

    public static readonly Selector MaxMeshBufferBindCount = Selector.Register("maxMeshBufferBindCount");

    public static readonly Selector MaxObjectBufferBindCount = Selector.Register("maxObjectBufferBindCount");

    public static readonly Selector MaxObjectThreadgroupMemoryBindCount = Selector.Register("maxObjectThreadgroupMemoryBindCount");

    public static readonly Selector MaxVertexBufferBindCount = Selector.Register("maxVertexBufferBindCount");

    public static readonly Selector SetCommandTypes = Selector.Register("setCommandTypes:");

    public static readonly Selector SetInheritBuffers = Selector.Register("setInheritBuffers:");

    public static readonly Selector SetInheritCullMode = Selector.Register("setInheritCullMode:");

    public static readonly Selector SetInheritDepthBias = Selector.Register("setInheritDepthBias:");

    public static readonly Selector SetInheritDepthClipMode = Selector.Register("setInheritDepthClipMode:");

    public static readonly Selector SetInheritDepthStencilState = Selector.Register("setInheritDepthStencilState:");

    public static readonly Selector SetInheritFrontFacingWinding = Selector.Register("setInheritFrontFacingWinding:");

    public static readonly Selector SetInheritPipelineState = Selector.Register("setInheritPipelineState:");

    public static readonly Selector SetInheritTriangleFillMode = Selector.Register("setInheritTriangleFillMode:");

    public static readonly Selector SetMaxFragmentBufferBindCount = Selector.Register("setMaxFragmentBufferBindCount:");

    public static readonly Selector SetMaxKernelBufferBindCount = Selector.Register("setMaxKernelBufferBindCount:");

    public static readonly Selector SetMaxKernelThreadgroupMemoryBindCount = Selector.Register("setMaxKernelThreadgroupMemoryBindCount:");

    public static readonly Selector SetMaxMeshBufferBindCount = Selector.Register("setMaxMeshBufferBindCount:");

    public static readonly Selector SetMaxObjectBufferBindCount = Selector.Register("setMaxObjectBufferBindCount:");

    public static readonly Selector SetMaxObjectThreadgroupMemoryBindCount = Selector.Register("setMaxObjectThreadgroupMemoryBindCount:");

    public static readonly Selector SetMaxVertexBufferBindCount = Selector.Register("setMaxVertexBufferBindCount:");

    public static readonly Selector SetSupportColorAttachmentMapping = Selector.Register("setSupportColorAttachmentMapping:");

    public static readonly Selector SetSupportDynamicAttributeStride = Selector.Register("setSupportDynamicAttributeStride:");

    public static readonly Selector SetSupportRayTracing = Selector.Register("setSupportRayTracing:");

    public static readonly Selector SupportColorAttachmentMapping = Selector.Register("supportColorAttachmentMapping");

    public static readonly Selector SupportDynamicAttributeStride = Selector.Register("supportDynamicAttributeStride");

    public static readonly Selector SupportRayTracing = Selector.Register("supportRayTracing");
}
