namespace Metal.NET;

public partial class MTLIndirectCommandBufferDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIndirectCommandBufferDescriptor");

    public MTLIndirectCommandBufferDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint CommandTypes
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorSelector.CommandTypes);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetCommandTypes, value);
    }

    public bool InheritBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.InheritBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritBuffers, (Bool8)value);
    }

    public bool InheritCullMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.InheritCullMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritCullMode, (Bool8)value);
    }

    public bool InheritDepthBias
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.InheritDepthBias);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthBias, (Bool8)value);
    }

    public bool InheritDepthClipMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.InheritDepthClipMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthClipMode, (Bool8)value);
    }

    public bool InheritDepthStencilState
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.InheritDepthStencilState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritDepthStencilState, (Bool8)value);
    }

    public bool InheritFrontFacingWinding
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.InheritFrontFacingWinding);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritFrontFacingWinding, (Bool8)value);
    }

    public bool InheritPipelineState
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.InheritPipelineState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritPipelineState, (Bool8)value);
    }

    public bool InheritTriangleFillMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.InheritTriangleFillMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetInheritTriangleFillMode, (Bool8)value);
    }

    public nuint MaxFragmentBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorSelector.MaxFragmentBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxFragmentBufferBindCount, value);
    }

    public nuint MaxKernelBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorSelector.MaxKernelBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxKernelBufferBindCount, value);
    }

    public nuint MaxKernelThreadgroupMemoryBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorSelector.MaxKernelThreadgroupMemoryBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxKernelThreadgroupMemoryBindCount, value);
    }

    public nuint MaxMeshBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorSelector.MaxMeshBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxMeshBufferBindCount, value);
    }

    public nuint MaxObjectBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorSelector.MaxObjectBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxObjectBufferBindCount, value);
    }

    public nuint MaxObjectThreadgroupMemoryBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorSelector.MaxObjectThreadgroupMemoryBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxObjectThreadgroupMemoryBindCount, value);
    }

    public nuint MaxVertexBufferBindCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorSelector.MaxVertexBufferBindCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetMaxVertexBufferBindCount, value);
    }

    public bool SupportColorAttachmentMapping
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SupportColorAttachmentMapping);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportColorAttachmentMapping, (Bool8)value);
    }

    public bool SupportDynamicAttributeStride
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SupportDynamicAttributeStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportDynamicAttributeStride, (Bool8)value);
    }

    public bool SupportRayTracing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SupportRayTracing);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorSelector.SetSupportRayTracing, (Bool8)value);
    }
}

file static class MTLIndirectCommandBufferDescriptorSelector
{
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
