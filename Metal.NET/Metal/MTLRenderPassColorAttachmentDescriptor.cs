namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : MTLRenderPassAttachmentDescriptor(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLRenderPassColorAttachmentDescriptor>
{
    public static new MTLRenderPassColorAttachmentDescriptor Null { get; } = new(0, false);

    public static new MTLRenderPassColorAttachmentDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLRenderPassColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassColorAttachmentDescriptorBindings.Class), true, true)
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
