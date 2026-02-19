namespace Metal.NET;

public class MTLBlitPassDescriptor(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassDescriptorBindings.Class), true)
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLBlitPassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLBlitPassDescriptor? BlitPassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLBlitPassDescriptorBindings.Class, MTLBlitPassDescriptorBindings.BlitPassDescriptor);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }
}

file static class MTLBlitPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public static readonly Selector BlitPassDescriptor = "blitPassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
