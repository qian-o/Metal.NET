namespace Metal.NET;

public class MTLResourceStatePassDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLResourceStatePassDescriptor>
{
    public static MTLResourceStatePassDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLResourceStatePassDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLResourceStatePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLResourceStatePassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLResourceStatePassDescriptorBindings.Class, MTLResourceStatePassDescriptorBindings.ResourceStatePassDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLResourceStatePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static readonly Selector ResourceStatePassDescriptor = "resourceStatePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
