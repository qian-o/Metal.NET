namespace Metal.NET;

public class MTLIndirectCommandBufferDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIndirectCommandBufferDescriptor>
{
    #region INativeObject
    public static new MTLIndirectCommandBufferDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectCommandBufferDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIndirectCommandBufferDescriptor() : this(ObjectiveC.AllocInit(MTLIndirectCommandBufferDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLIndirectCommandType CommandTypes
    {
        get => (MTLIndirectCommandType)ObjectiveC.MsgSendULong(NativePtr, MTLIndirectCommandBufferDescriptorBindings.CommandTypes);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetCommandTypes, (nuint)value);
    }

    public Bool8 InheritPipelineState
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritPipelineState);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritPipelineState, value);
    }

    public Bool8 InheritBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritBuffers, value);
    }

    public Bool8 InheritDepthStencilState
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthStencilState);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthStencilState, value);
    }

    public Bool8 InheritDepthBias
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthBias);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthBias, value);
    }

    public Bool8 InheritDepthClipMode
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritDepthClipMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritDepthClipMode, value);
    }

    public Bool8 InheritCullMode
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritCullMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritCullMode, value);
    }

    public Bool8 InheritFrontFacingWinding
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritFrontFacingWinding);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritFrontFacingWinding, value);
    }

    public Bool8 InheritTriangleFillMode
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.InheritTriangleFillMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetInheritTriangleFillMode, value);
    }

    public nuint MaxVertexBufferBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxVertexBufferBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxVertexBufferBindCount, value);
    }

    public nuint MaxFragmentBufferBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxFragmentBufferBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxFragmentBufferBindCount, value);
    }

    public nuint MaxKernelBufferBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxKernelBufferBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxKernelBufferBindCount, value);
    }

    public nuint MaxKernelThreadgroupMemoryBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxKernelThreadgroupMemoryBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxKernelThreadgroupMemoryBindCount, value);
    }

    public nuint MaxObjectBufferBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxObjectBufferBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxObjectBufferBindCount, value);
    }

    public nuint MaxMeshBufferBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxMeshBufferBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxMeshBufferBindCount, value);
    }

    public nuint MaxObjectThreadgroupMemoryBindCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferDescriptorBindings.MaxObjectThreadgroupMemoryBindCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetMaxObjectThreadgroupMemoryBindCount, value);
    }

    public Bool8 SupportRayTracing
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportRayTracing);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportRayTracing, value);
    }

    public Bool8 SupportDynamicAttributeStride
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportDynamicAttributeStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportDynamicAttributeStride, value);
    }

    public Bool8 SupportColorAttachmentMapping
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SupportColorAttachmentMapping);
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferDescriptorBindings.SetSupportColorAttachmentMapping, value);
    }
}

file static class MTLIndirectCommandBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLIndirectCommandBufferDescriptor");

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
