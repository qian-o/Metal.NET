namespace Metal.NET;

public class MTLResourceStatePassDescriptor(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLResourceStatePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassDescriptorBindings.Class), true)
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLResourceStatePassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLResourceStatePassDescriptor? ResourceStatePassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLResourceStatePassDescriptorBindings.Class, MTLResourceStatePassDescriptorBindings.ResourceStatePassDescriptor);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }
}

file static class MTLResourceStatePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static readonly Selector ResourceStatePassDescriptor = "resourceStatePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
