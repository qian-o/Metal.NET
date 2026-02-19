namespace Metal.NET;

public class MTLBlitPassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassDescriptorBindings.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassDescriptorBindings.SampleBufferAttachments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBlitPassSampleBufferAttachmentDescriptorArray(ptr);
            }

            return field;
        }
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

    public static readonly Selector BlitPassDescriptor = Selector.Register("blitPassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
