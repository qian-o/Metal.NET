namespace Metal.NET;

public class MTLResourceStatePassDescriptor : IDisposable
{
    public MTLResourceStatePassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResourceStatePassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassDescriptorSelector.SampleBufferAttachments));

    public static implicit operator nint(MTLResourceStatePassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceStatePassDescriptor(nint value)
    {
        return new(value);
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

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        MTLResourceStatePassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLResourceStatePassDescriptorSelector.ResourceStatePassDescriptor));

        return result;
    }
}

file class MTLResourceStatePassDescriptorSelector
{
    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");

    public static readonly Selector ResourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");
}
