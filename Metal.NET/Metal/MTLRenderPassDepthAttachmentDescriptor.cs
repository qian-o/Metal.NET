namespace Metal.NET;

public class MTLRenderPassDepthAttachmentDescriptor(nint nativePtr) : MTLRenderPassAttachmentDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public double ClearDepth
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.ClearDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.SetClearDepth, value);
    }

    public MTLMultisampleDepthResolveFilter DepthResolveFilter
    {
        get => (MTLMultisampleDepthResolveFilter)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.DepthResolveFilter));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.SetDepthResolveFilter, (ulong)value);
    }

    public static implicit operator nint(MTLRenderPassDepthAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassDepthAttachmentDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTLRenderPassDepthAttachmentDescriptorSelector
{
    public static readonly Selector ClearDepth = Selector.Register("clearDepth");

    public static readonly Selector SetClearDepth = Selector.Register("setClearDepth:");

    public static readonly Selector DepthResolveFilter = Selector.Register("depthResolveFilter");

    public static readonly Selector SetDepthResolveFilter = Selector.Register("setDepthResolveFilter:");
}
