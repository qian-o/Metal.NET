namespace Metal.NET;

public class MTLResourceStatePassDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public MTLResourceStatePassDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLResourceStatePassDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLResourceStatePassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassDescriptorSelector.SampleBufferAttachments));
    }

    public static implicit operator nint(MTLResourceStatePassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceStatePassDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        MTLResourceStatePassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLResourceStatePassDescriptorSelector.ResourceStatePassDescriptor));

        return result;
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLResourceStatePassDescriptorSelector
{
    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector ResourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");
}
