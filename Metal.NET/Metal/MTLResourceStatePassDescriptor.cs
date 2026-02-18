namespace Metal.NET;

public partial class MTLResourceStatePassDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public MTLResourceStatePassDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassDescriptorSelector.SampleBufferAttachments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public static MTLResourceStatePassDescriptor? ResourceStatePassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLResourceStatePassDescriptorSelector.ResourceStatePassDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLResourceStatePassDescriptorSelector
{
    public static readonly Selector ResourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
