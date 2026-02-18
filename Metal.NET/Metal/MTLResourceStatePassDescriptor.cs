namespace Metal.NET;

public class MTLResourceStatePassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResourceStatePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassDescriptorSelector.Class))
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetNullableObject<MTLResourceStatePassSampleBufferAttachmentDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassDescriptorSelector.SampleBufferAttachments));
    }

    public static MTLResourceStatePassDescriptor? ResourceStatePassDescriptor()
    {
        return GetNullableObject<MTLResourceStatePassDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLResourceStatePassDescriptorSelector.Class, MTLResourceStatePassDescriptorSelector.ResourceStatePassDescriptor));
    }
}

file static class MTLResourceStatePassDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static readonly Selector ResourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
