namespace Metal.NET;

public class MTLRenderPassStencilAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLRenderPassAttachmentDescriptor(nativePtr, ownership), INativeObject<MTLRenderPassStencilAttachmentDescriptor>
{
    public static new MTLRenderPassStencilAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPassStencilAttachmentDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLRenderPassStencilAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassStencilAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
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

    public static readonly Selector ClearStencil = "clearStencil";

    public static readonly Selector SetClearStencil = "setClearStencil:";

    public static readonly Selector SetStencilResolveFilter = "setStencilResolveFilter:";

    public static readonly Selector StencilResolveFilter = "stencilResolveFilter";
}
