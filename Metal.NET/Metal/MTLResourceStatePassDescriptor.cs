namespace Metal.NET;

public class MTLResourceStatePassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResourceStatePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassDescriptorBindings.Class))
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassDescriptorBindings.SampleBufferAttachments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLResourceStatePassSampleBufferAttachmentDescriptorArray(ptr);
            }

            return field;
        }
    }

    public static MTLResourceStatePassDescriptor? ResourceStatePassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLResourceStatePassDescriptorBindings.Class, MTLResourceStatePassDescriptorBindings.ResourceStatePassDescriptor);
        return ptr is not 0 ? new MTLResourceStatePassDescriptor(ptr) : null;
    }
}

file static class MTLResourceStatePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static readonly Selector ResourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
