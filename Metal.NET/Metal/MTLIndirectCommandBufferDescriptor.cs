namespace Metal.NET;

public class MTLIndirectCommandBufferDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLIndirectCommandBufferDescriptor>
{
    public static MTLIndirectCommandBufferDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLIndirectCommandBufferDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLIndirectCommandBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIndirectCommandBufferDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLIndirectCommandType CommandTypes
    {
        get => (MTLIndirectCommandType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.CommandTypes);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetCommandTypes, (nuint)value);
    }

    public Bool8 InheritBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritBuffers, value);
    }

    public Bool8 InheritCullMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritCullMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritCullMode, value);
    }

    public Bool8 InheritDepthBias
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthBias);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthBias, value);
    }

    public Bool8 InheritDepthClipMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthClipMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthClipMode, value);
    }

    public Bool8 InheritDepthStencilState
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthStencilState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthStencilState, value);
    }

    public Bool8 InheritFrontFacingWinding
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritFrontFacingWinding);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritFrontFacingWinding, value);
    }

    public Bool8 InheritPipelineState
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritPipelineState);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritPipelineState, value);
    }

    public Bool8 InheritTriangleFillMode
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritTriangleFillMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritTriangleFillMode, value);
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

    public Bool8 SupportColorAttachmentMapping
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportColorAttachmentMapping, value);
    }

    public Bool8 SupportDynamicAttributeStride
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportDynamicAttributeStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportDynamicAttributeStride, value);
    }

    public Bool8 SupportRayTracing
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportRayTracing);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportRayTracing, value);
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
