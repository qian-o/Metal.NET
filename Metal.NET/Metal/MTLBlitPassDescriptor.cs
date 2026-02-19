namespace Metal.NET;

public class MTLBlitPassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassDescriptorBindings.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetProperty<MTLBlitPassSampleBufferAttachmentDescriptorArray>(ref field, MTLBlitPassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLBlitPassDescriptor? BlitPassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLBlitPassDescriptorBindings.Class, MTLBlitPassDescriptorBindings.BlitPassDescriptor);
        return ptr is not 0 ? new MTLBlitPassDescriptor(ptr) : null;
    }
}

file static class MTLBlitPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public static readonly Selector BlitPassDescriptor = "blitPassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
