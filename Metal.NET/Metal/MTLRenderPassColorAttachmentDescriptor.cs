namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLRenderPassAttachmentDescriptor(nativePtr, ownership), INativeObject<MTLRenderPassColorAttachmentDescriptor>
{
    public static new MTLRenderPassColorAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPassColorAttachmentDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLRenderPassColorAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassColorAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLClearColor ClearColor
    {
        get => ObjectiveC.MsgSendMTLClearColor(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.ClearColor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetClearColor, value);
    }
}

file static class MTLRenderPassColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public static readonly Selector ClearColor = "clearColor";

    public static readonly Selector SetClearColor = "setClearColor:";
}
