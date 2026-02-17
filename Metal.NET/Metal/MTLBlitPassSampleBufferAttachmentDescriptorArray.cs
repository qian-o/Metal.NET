namespace Metal.NET;

public class MTLBlitPassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public MTLBlitPassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public MTLBlitPassSampleBufferAttachmentDescriptor Object(uint attachmentIndex)
    {
        MTLBlitPassSampleBufferAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.Object, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLBlitPassSampleBufferAttachmentDescriptor attachment, uint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.SetObjectAttachmentIndex, attachment.NativePtr, (nint)attachmentIndex);
    }

}

file class MTLBlitPassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectAttachmentIndex = Selector.Register("setObject:attachmentIndex:");
}
