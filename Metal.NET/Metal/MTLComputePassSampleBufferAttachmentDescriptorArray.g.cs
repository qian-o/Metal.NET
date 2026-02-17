namespace Metal.NET;

file class MTLComputePassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLComputePassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public MTLComputePassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLComputePassSampleBufferAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputePassSampleBufferAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePassSampleBufferAttachmentDescriptorArray(nint value)
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

    public MTLComputePassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var result = new MTLComputePassSampleBufferAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArraySelector.Object_, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLComputePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArraySelector.SetObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
