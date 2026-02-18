namespace Metal.NET;

public partial class MTLRenderPassDepthAttachmentDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public MTLRenderPassDepthAttachmentDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public double ClearDepth
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.ClearDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.SetClearDepth, value);
    }

    public MTLMultisampleDepthResolveFilter DepthResolveFilter
    {
        get => (MTLMultisampleDepthResolveFilter)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.DepthResolveFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.SetDepthResolveFilter, (nuint)value);
    }
}

file static class MTLRenderPassDepthAttachmentDescriptorSelector
{
    public static readonly Selector ClearDepth = Selector.Register("clearDepth");

    public static readonly Selector DepthResolveFilter = Selector.Register("depthResolveFilter");

    public static readonly Selector SetClearDepth = Selector.Register("setClearDepth:");

    public static readonly Selector SetDepthResolveFilter = Selector.Register("setDepthResolveFilter:");
}
