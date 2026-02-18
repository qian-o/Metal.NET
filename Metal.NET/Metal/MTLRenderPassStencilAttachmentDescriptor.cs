namespace Metal.NET;

public partial class MTLRenderPassStencilAttachmentDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassStencilAttachmentDescriptor");

    public MTLRenderPassStencilAttachmentDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public uint ClearStencil
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.ClearStencil);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetClearStencil, value);
    }

    public MTLMultisampleStencilResolveFilter StencilResolveFilter
    {
        get => (MTLMultisampleStencilResolveFilter)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.StencilResolveFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetStencilResolveFilter, (nuint)value);
    }
}

file static class MTLRenderPassStencilAttachmentDescriptorSelector
{
    public static readonly Selector ClearStencil = Selector.Register("clearStencil");

    public static readonly Selector SetClearStencil = Selector.Register("setClearStencil:");

    public static readonly Selector SetStencilResolveFilter = Selector.Register("setStencilResolveFilter:");

    public static readonly Selector StencilResolveFilter = Selector.Register("stencilResolveFilter");
}
