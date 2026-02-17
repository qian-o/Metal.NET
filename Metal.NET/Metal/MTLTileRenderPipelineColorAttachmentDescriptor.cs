namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptor : IDisposable
{
    public MTLTileRenderPipelineColorAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTileRenderPipelineColorAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTileRenderPipelineColorAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTileRenderPipelineColorAttachmentDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineColorAttachmentDescriptor");

    public static MTLTileRenderPipelineColorAttachmentDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLTileRenderPipelineColorAttachmentDescriptor(ptr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorSelector.SetPixelFormat, (nint)(uint)pixelFormat);
    }

}

file class MTLTileRenderPipelineColorAttachmentDescriptorSelector
{
    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");
}
