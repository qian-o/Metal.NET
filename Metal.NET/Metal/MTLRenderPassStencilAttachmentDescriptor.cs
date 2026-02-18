namespace Metal.NET;

public class MTLRenderPassStencilAttachmentDescriptor(nint nativePtr) : MTLRenderPassAttachmentDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassStencilAttachmentDescriptor");

    public MTLRenderPassStencilAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    public uint ClearStencil
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.ClearStencil);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetClearStencil, value);
    }

    public MTLMultisampleStencilResolveFilter StencilResolveFilter
    {
        get => (MTLMultisampleStencilResolveFilter)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.StencilResolveFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetStencilResolveFilter, (ulong)value);
    }

    public static implicit operator nint(MTLRenderPassStencilAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassStencilAttachmentDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTLRenderPassStencilAttachmentDescriptorSelector
{
    public static readonly Selector ClearStencil = Selector.Register("clearStencil");

    public static readonly Selector SetClearStencil = Selector.Register("setClearStencil:");

    public static readonly Selector StencilResolveFilter = Selector.Register("stencilResolveFilter");

    public static readonly Selector SetStencilResolveFilter = Selector.Register("setStencilResolveFilter:");
}
