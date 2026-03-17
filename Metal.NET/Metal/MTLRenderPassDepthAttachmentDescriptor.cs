namespace Metal.NET;

public class MTLRenderPassDepthAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLRenderPassAttachmentDescriptor(nativePtr, ownership), INativeObject<MTLRenderPassDepthAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLRenderPassDepthAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPassDepthAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPassDepthAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassDepthAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public double ClearDepth
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.ClearDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetClearDepth, value);
    }

    public MTLMultisampleDepthResolveFilter DepthResolveFilter
    {
        get => (MTLMultisampleDepthResolveFilter)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.DepthResolveFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetDepthResolveFilter, (nuint)value);
    }

    public double ClearDepth
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.ClearDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetClearDepth, value);
    }

    public MTLMultisampleDepthResolveFilter DepthResolveFilter
    {
        get => (MTLMultisampleDepthResolveFilter)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.DepthResolveFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetDepthResolveFilter, (nuint)value);
    }

    public void SetClearDepth(double clearDepth)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetClearDepth, clearDepth);
    }

    public void SetDepthResolveFilter(MTLMultisampleDepthResolveFilter depthResolveFilter)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetDepthResolveFilter, (nuint)depthResolveFilter);
    }
}

file static class MTLRenderPassDepthAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public static readonly Selector ClearDepth = "clearDepth";

    public static readonly Selector DepthResolveFilter = "depthResolveFilter";

    public static readonly Selector SetClearDepth = "setClearDepth:";

    public static readonly Selector SetDepthResolveFilter = "setDepthResolveFilter:";
}
