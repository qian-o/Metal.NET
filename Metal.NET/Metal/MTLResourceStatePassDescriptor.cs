namespace Metal.NET;

public class MTLResourceStatePassDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLResourceStatePassDescriptor>
{
    public static MTLResourceStatePassDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLResourceStatePassDescriptor Null => Create(0, false);
    public static MTLResourceStatePassDescriptor Empty => Null;

    public MTLResourceStatePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassDescriptorBindings.Class), true)
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLResourceStatePassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLResourceStatePassDescriptorBindings.Class, MTLResourceStatePassDescriptorBindings.ResourceStatePassDescriptor);

        return new(nativePtr, false);
    }
}

file static class MTLResourceStatePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static readonly Selector ResourceStatePassDescriptor = "resourceStatePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
