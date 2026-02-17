namespace Metal.NET;

file class MTLBlitPassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLBlitPassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public MTLBlitPassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLBlitPassSampleBufferAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBlitPassSampleBufferAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBlitPassSampleBufferAttachmentDescriptorArray(nint value)
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

    public MTLBlitPassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var result = new MTLBlitPassSampleBufferAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.Object_, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLBlitPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.SetObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
