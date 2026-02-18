namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptor(nint nativePtr) : MTLRenderPassAttachmentDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public MTLRenderPassColorAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    public MTLClearColor ClearColor
    {
        get => ObjectiveCRuntime.MsgSendMTLClearColor(NativePtr, MTLRenderPassColorAttachmentDescriptorSelector.ClearColor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorSelector.SetClearColor, value);
    }

    public static implicit operator nint(MTLRenderPassColorAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassColorAttachmentDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTLRenderPassColorAttachmentDescriptorSelector
{
    public static readonly Selector ClearColor = Selector.Register("clearColor");

    public static readonly Selector SetClearColor = Selector.Register("setClearColor:");
}
