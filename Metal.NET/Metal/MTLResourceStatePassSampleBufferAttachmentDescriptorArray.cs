namespace Metal.NET;

public class MTLResourceStatePassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResourceStatePassSampleBufferAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResourceStatePassSampleBufferAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint value)
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

    public MTLResourceStatePassSampleBufferAttachmentDescriptor Object(uint attachmentIndex)
    {
        MTLResourceStatePassSampleBufferAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector.Object, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLResourceStatePassSampleBufferAttachmentDescriptor attachment, uint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector.SetObjectAttachmentIndex, attachment.NativePtr, (nint)attachmentIndex);
    }

}

file class MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectAttachmentIndex = Selector.Register("setObject:attachmentIndex:");
}
