namespace Metal.NET;

public class MTLIndirectCommandBufferDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLIndirectCommandBufferDescriptor>
{
    public static MTLIndirectCommandBufferDescriptor Create(nint nativePtr) => new(nativePtr);

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

    public static readonly Selector CommandTypes = "commandTypes";

    public static readonly Selector InheritBuffers = "inheritBuffers";

    public static readonly Selector InheritCullMode = "inheritCullMode";

    public static readonly Selector InheritDepthBias = "inheritDepthBias";

    public static readonly Selector InheritDepthClipMode = "inheritDepthClipMode";

    public static readonly Selector InheritDepthStencilState = "inheritDepthStencilState";

    public static readonly Selector InheritFrontFacingWinding = "inheritFrontFacingWinding";

    public static readonly Selector InheritPipelineState = "inheritPipelineState";

    public static readonly Selector InheritTriangleFillMode = "inheritTriangleFillMode";

    public static readonly Selector MaxFragmentBufferBindCount = "maxFragmentBufferBindCount";

    public static readonly Selector MaxKernelBufferBindCount = "maxKernelBufferBindCount";

    public static readonly Selector MaxKernelThreadgroupMemoryBindCount = "maxKernelThreadgroupMemoryBindCount";

    public static readonly Selector MaxMeshBufferBindCount = "maxMeshBufferBindCount";

    public static readonly Selector MaxObjectBufferBindCount = "maxObjectBufferBindCount";

    public static readonly Selector MaxObjectThreadgroupMemoryBindCount = "maxObjectThreadgroupMemoryBindCount";

    public static readonly Selector MaxVertexBufferBindCount = "maxVertexBufferBindCount";

    public static readonly Selector SetCommandTypes = "setCommandTypes:";

    public static readonly Selector SetInheritBuffers = "setInheritBuffers:";

    public static readonly Selector SetInheritCullMode = "setInheritCullMode:";

    public static readonly Selector SetInheritDepthBias = "setInheritDepthBias:";

    public static readonly Selector SetInheritDepthClipMode = "setInheritDepthClipMode:";

    public static readonly Selector SetInheritDepthStencilState = "setInheritDepthStencilState:";

    public static readonly Selector SetInheritFrontFacingWinding = "setInheritFrontFacingWinding:";

    public static readonly Selector SetInheritPipelineState = "setInheritPipelineState:";

    public static readonly Selector SetInheritTriangleFillMode = "setInheritTriangleFillMode:";

    public static readonly Selector SetMaxFragmentBufferBindCount = "setMaxFragmentBufferBindCount:";

    public static readonly Selector SetMaxKernelBufferBindCount = "setMaxKernelBufferBindCount:";

    public static readonly Selector SetMaxKernelThreadgroupMemoryBindCount = "setMaxKernelThreadgroupMemoryBindCount:";

    public static readonly Selector SetMaxMeshBufferBindCount = "setMaxMeshBufferBindCount:";

    public static readonly Selector SetMaxObjectBufferBindCount = "setMaxObjectBufferBindCount:";

    public static readonly Selector SetMaxObjectThreadgroupMemoryBindCount = "setMaxObjectThreadgroupMemoryBindCount:";

    public static readonly Selector SetMaxVertexBufferBindCount = "setMaxVertexBufferBindCount:";

    public static readonly Selector SetSupportColorAttachmentMapping = "setSupportColorAttachmentMapping:";

    public static readonly Selector SetSupportDynamicAttributeStride = "setSupportDynamicAttributeStride:";

    public static readonly Selector SetSupportRayTracing = "setSupportRayTracing:";

    public static readonly Selector SupportColorAttachmentMapping = "supportColorAttachmentMapping";

    public static readonly Selector SupportDynamicAttributeStride = "supportDynamicAttributeStride";

    public static readonly Selector SupportRayTracing = "supportRayTracing";
}
