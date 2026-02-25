namespace Metal.NET;

public class MTLRenderPassDepthAttachmentDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLRenderPassAttachmentDescriptor(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLRenderPassDepthAttachmentDescriptor>
{
    public static new MTLRenderPassDepthAttachmentDescriptor Null { get; } = new(0, false, false);

    public static new MTLRenderPassDepthAttachmentDescriptor Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTLRenderPassDepthAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassDepthAttachmentDescriptorBindings.Class), true, true)
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

    public static readonly Selector ClearDepth = "clearDepth";

    public static readonly Selector DepthResolveFilter = "depthResolveFilter";

    public static readonly Selector SetClearDepth = "setClearDepth:";

    public static readonly Selector SetDepthResolveFilter = "setDepthResolveFilter:";
}
