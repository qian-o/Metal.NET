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

    public static MTLRenderPassStencilAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLRenderPassStencilAttachmentDescriptor(ptr);
    }

    public void SetClearStencil(uint clearStencil)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetClearStencil, (nint)clearStencil);
    }

    public void SetStencilResolveFilter(MTLMultisampleStencilResolveFilter stencilResolveFilter)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetStencilResolveFilter, (nint)(uint)stencilResolveFilter);
    }

}

file class MTLRenderPassStencilAttachmentDescriptorSelector
{
    public static readonly Selector SetClearStencil = Selector.Register("setClearStencil:");

    public static readonly Selector SetStencilResolveFilter = Selector.Register("setStencilResolveFilter:");
}
