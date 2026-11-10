namespace Metal.NET;

public readonly struct MTLResourceStatePassDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLResourceStatePassDescriptor value) => new(value.NativePtr);

    public MTLResourceStatePassDescriptor() : this(ObjectiveC.AllocInit(MTLResourceStatePassDescriptorBindings.Class))
    {
    }

    public MTLResourceStatePassDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceStatePassDescriptorBindings.SampleBufferAttachments));
    }

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLResourceStatePassDescriptorBindings.Class, MTLResourceStatePassDescriptorBindings.ResourceStatePassDescriptor);

        return new(nativePtr);
    }
}

file static class MTLResourceStatePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLResourceStatePassDescriptor");

    public static readonly Selector ResourceStatePassDescriptor = "resourceStatePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
