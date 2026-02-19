namespace Metal.NET;

public readonly struct MTLRenderPassStencilAttachmentDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderPassStencilAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassStencilAttachmentDescriptorBindings.Class))
    {
    }

    public uint ClearStencil
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.ClearStencil);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetClearStencil, value);
    }

    public MTLMultisampleStencilResolveFilter StencilResolveFilter
    {
        get => (MTLMultisampleStencilResolveFilter)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.StencilResolveFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetStencilResolveFilter, (nuint)value);
    }
}

file static class MTLRenderPassStencilAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassStencilAttachmentDescriptor");

    public static readonly Selector ClearStencil = Selector.Register("clearStencil");

    public static readonly Selector SetClearStencil = Selector.Register("setClearStencil:");

    public static readonly Selector SetStencilResolveFilter = Selector.Register("setStencilResolveFilter:");

    public static readonly Selector StencilResolveFilter = Selector.Register("stencilResolveFilter");
}
