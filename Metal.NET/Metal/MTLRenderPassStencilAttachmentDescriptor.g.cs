namespace Metal.NET;

file class MTLRenderPassStencilAttachmentDescriptorSelector
{
    public static readonly Selector SetClearStencil_ = Selector.Register("setClearStencil:");
    public static readonly Selector SetStencilResolveFilter_ = Selector.Register("setStencilResolveFilter:");
}

public class MTLRenderPassStencilAttachmentDescriptor : IDisposable
{
    public MTLRenderPassStencilAttachmentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLRenderPassStencilAttachmentDescriptor(ptr);
    }

    public void SetClearStencil(uint clearStencil)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetClearStencil_, (nint)clearStencil);
    }

    public void SetStencilResolveFilter(MTLMultisampleStencilResolveFilter stencilResolveFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorSelector.SetStencilResolveFilter_, (nint)(uint)stencilResolveFilter);
    }

}
