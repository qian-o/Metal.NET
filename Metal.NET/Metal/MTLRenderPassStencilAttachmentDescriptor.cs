namespace Metal.NET;

public class MTLRenderPassStencilAttachmentDescriptor : IDisposable
{
    public MTLRenderPassStencilAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPassStencilAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassStencilAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassStencilAttachmentDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassStencilAttachmentDescriptor");

    public MTLRenderPassStencilAttachmentDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public uint ClearStencil
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.ClearStencil);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetClearStencil, value);
    }

    public MTLMultisampleStencilResolveFilter StencilResolveFilter
    {
        get => (MTLMultisampleStencilResolveFilter)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.StencilResolveFilter));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetStencilResolveFilter, (uint)value);
    }

}

file class MTLRenderPassStencilAttachmentDescriptorSelector
{
    public static readonly Selector ClearStencil = Selector.Register("clearStencil");

    public static readonly Selector SetClearStencil = Selector.Register("setClearStencil:");

    public static readonly Selector StencilResolveFilter = Selector.Register("stencilResolveFilter");

    public static readonly Selector SetStencilResolveFilter = Selector.Register("setStencilResolveFilter:");
}
