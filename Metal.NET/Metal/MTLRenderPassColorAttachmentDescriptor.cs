namespace Metal.NET;

public partial class MTLRenderPassColorAttachmentDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public MTLRenderPassColorAttachmentDescriptor(nint nativePtr) : base(nativePtr)
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
    public static readonly Selector ClearColor = Selector.Register("clearColor");

    public static readonly Selector SetClearColor = Selector.Register("setClearColor:");
}
