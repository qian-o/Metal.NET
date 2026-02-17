namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptorArray : IDisposable
{
    public MTLRenderPassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPassSampleBufferAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLRenderPassSampleBufferAttachmentDescriptor Object(uint attachmentIndex)
    {
        MTLRenderPassSampleBufferAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArraySelector.Object, (nuint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLRenderPassSampleBufferAttachmentDescriptor attachment, uint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArraySelector.SetObjectAttachmentIndex, attachment.NativePtr, (nuint)attachmentIndex);
    }

    public static implicit operator nint(MTLRenderPassSampleBufferAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassSampleBufferAttachmentDescriptorArray(nint value)
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

}

file class MTLRenderPassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectAttachmentIndex = Selector.Register("setObject:attachmentIndex:");
}
