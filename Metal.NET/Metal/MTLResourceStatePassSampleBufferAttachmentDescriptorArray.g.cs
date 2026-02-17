namespace Metal.NET;

file class MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLResourceStatePassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLResourceStatePassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var result = new MTLResourceStatePassSampleBufferAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector.Object_, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLResourceStatePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector.SetObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
