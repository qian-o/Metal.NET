namespace Metal.NET;

file class MTLRenderPassColorAttachmentDescriptorSelector
{
    public static readonly Selector SetClearColor_ = Selector.Register("setClearColor:");
}

public class MTLRenderPassColorAttachmentDescriptor : IDisposable
{
    public MTLRenderPassColorAttachmentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLRenderPassColorAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassColorAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassColorAttachmentDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public static MTLRenderPassColorAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLRenderPassColorAttachmentDescriptor(ptr);
    }

    public void SetClearColor(MTLClearColor clearColor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorSelector.SetClearColor_, clearColor);
    }

}
