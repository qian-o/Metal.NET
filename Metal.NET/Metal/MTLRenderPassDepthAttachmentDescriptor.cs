namespace Metal.NET;

public readonly struct MTLRenderPassDepthAttachmentDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderPassDepthAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassDepthAttachmentDescriptorBindings.Class))
    {
    }

    public double ClearDepth
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.ClearDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetClearDepth, value);
    }

    public MTLMultisampleDepthResolveFilter DepthResolveFilter
    {
        get => (MTLMultisampleDepthResolveFilter)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.DepthResolveFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetDepthResolveFilter, (nuint)value);
    }
}

file static class MTLRenderPassDepthAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public static readonly Selector ClearDepth = Selector.Register("clearDepth");

    public static readonly Selector DepthResolveFilter = Selector.Register("depthResolveFilter");

    public static readonly Selector SetClearDepth = Selector.Register("setClearDepth:");

    public static readonly Selector SetDepthResolveFilter = Selector.Register("setDepthResolveFilter:");
}
