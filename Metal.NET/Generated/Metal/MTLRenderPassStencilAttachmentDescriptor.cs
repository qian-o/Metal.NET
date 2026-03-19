namespace Metal.NET;

public partial class MTLRenderPassStencilAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLRenderPassAttachmentDescriptor(nativePtr, ownership), INativeObject<MTLRenderPassStencilAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLRenderPassStencilAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPassStencilAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPassStencilAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassStencilAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public uint ClearStencil
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.ClearStencil);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetClearStencil, value);
    }

    public MTLMultisampleStencilResolveFilter StencilResolveFilter
    {
        get => (MTLMultisampleStencilResolveFilter)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.StencilResolveFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetStencilResolveFilter, (nuint)value);
    }
}

file static class MTLRenderPassStencilAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassStencilAttachmentDescriptor");

    public static readonly Selector ClearStencil = "clearStencil";

    public static readonly Selector SetClearStencil = "setClearStencil:";

    public static readonly Selector SetStencilResolveFilter = "setStencilResolveFilter:";

    public static readonly Selector StencilResolveFilter = "stencilResolveFilter";
}
