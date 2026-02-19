namespace Metal.NET;

public readonly struct MTLResourceStatePassDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLResourceStatePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassDescriptorBindings.Class))
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassDescriptorBindings.SampleBufferAttachments);
            return ptr is not 0 ? new MTLResourceStatePassSampleBufferAttachmentDescriptorArray(ptr) : default;
        }
    }

    public static MTLResourceStatePassDescriptor? ResourceStatePassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLResourceStatePassDescriptorBindings.Class, MTLResourceStatePassDescriptorBindings.ResourceStatePassDescriptor);
        return ptr is not 0 ? new MTLResourceStatePassDescriptor(ptr) : default;
    }
}

file static class MTLResourceStatePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static readonly Selector ResourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
