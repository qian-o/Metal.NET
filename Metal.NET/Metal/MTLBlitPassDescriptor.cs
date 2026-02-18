namespace Metal.NET;

public partial class MTLBlitPassDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public MTLBlitPassDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassDescriptorSelector.SampleBufferAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public static MTLBlitPassDescriptor? BlitPassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLBlitPassDescriptorSelector.BlitPassDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLBlitPassDescriptorSelector
{
    public static readonly Selector BlitPassDescriptor = Selector.Register("blitPassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
