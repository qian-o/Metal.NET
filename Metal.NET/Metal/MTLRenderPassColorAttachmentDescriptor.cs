namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptor(nint nativePtr) : MTLRenderPassAttachmentDescriptor(nativePtr)
{
    public MTLRenderPassColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassColorAttachmentDescriptorSelector.Class))
    {
    }

    public MTLClearColor ClearColor
    {
        get => ObjectiveCRuntime.MsgSendMTLClearColor(NativePtr, MTLRenderPassColorAttachmentDescriptorSelector.ClearColor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorSelector.SetClearColor, value);
    }
}

file static class MTLRenderPassColorAttachmentDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public static readonly Selector ClearColor = Selector.Register("clearColor");

    public static readonly Selector SetClearColor = Selector.Register("setClearColor:");
}
