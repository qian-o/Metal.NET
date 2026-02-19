namespace Metal.NET;

public readonly struct MTLBlitPassDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassDescriptorBindings.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassDescriptorBindings.SampleBufferAttachments);
            return ptr is not 0 ? new MTLBlitPassSampleBufferAttachmentDescriptorArray(ptr) : default;
        }
    }

    public static MTLBlitPassDescriptor? BlitPassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLBlitPassDescriptorBindings.Class, MTLBlitPassDescriptorBindings.BlitPassDescriptor);
        return ptr is not 0 ? new MTLBlitPassDescriptor(ptr) : default;
    }
}

file static class MTLBlitPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public static readonly Selector BlitPassDescriptor = Selector.Register("blitPassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
