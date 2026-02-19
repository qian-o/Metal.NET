namespace Metal.NET;

public class MTLResourceStatePassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResourceStatePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassDescriptorBindings.Class))
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLResourceStatePassDescriptorBindings.SampleBufferAttachments);
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

    public static readonly Selector ResourceStatePassDescriptor = "resourceStatePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
