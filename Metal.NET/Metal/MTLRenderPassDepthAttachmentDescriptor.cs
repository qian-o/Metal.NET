namespace Metal.NET;

public class MTLRenderPassDepthAttachmentDescriptor : IDisposable
{
    public MTLRenderPassDepthAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPassDepthAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassDepthAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassDepthAttachmentDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public static MTLRenderPassDepthAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLRenderPassDepthAttachmentDescriptor(ptr);
    }

    public void SetClearDepth(double clearDepth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.SetClearDepth, clearDepth);
    }

    public void SetDepthResolveFilter(MTLMultisampleDepthResolveFilter depthResolveFilter)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorSelector.SetDepthResolveFilter, (nint)(uint)depthResolveFilter);
    }

}

file class MTLRenderPassDepthAttachmentDescriptorSelector
{
    public static readonly Selector SetClearDepth = Selector.Register("setClearDepth:");

    public static readonly Selector SetDepthResolveFilter = Selector.Register("setDepthResolveFilter:");
}
