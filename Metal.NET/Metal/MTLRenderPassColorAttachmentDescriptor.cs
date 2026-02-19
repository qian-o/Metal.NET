namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptor(nint nativePtr, bool owned) : MTLRenderPassAttachmentDescriptor(nativePtr, owned)
{
    public MTLRenderPassColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassColorAttachmentDescriptorBindings.Class), true)
    {
    }

    public MTLClearColor ClearColor
    {
        get => ObjectiveCRuntime.MsgSendMTLClearColor(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.ClearColor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetClearColor, value);
    }
}

file static class MTLRenderPassColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public static readonly Selector ClearColor = "clearColor";

    public static readonly Selector SetClearColor = "setClearColor:";
}
