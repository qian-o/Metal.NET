namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptor : IDisposable
{
    public MTLRenderPassColorAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLRenderPassColorAttachmentDescriptor(ptr);
    }

    public void SetClearColor(MTLClearColor clearColor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorSelector.SetClearColor, clearColor);
    }

}

file class MTLRenderPassColorAttachmentDescriptorSelector
{
    public static readonly Selector SetClearColor = Selector.Register("setClearColor:");
}
