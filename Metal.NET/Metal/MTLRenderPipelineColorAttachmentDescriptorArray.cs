namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptorArray : IDisposable
{
    public MTLRenderPipelineColorAttachmentDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPipelineColorAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPipelineColorAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPipelineColorAttachmentDescriptorArray(nint value)
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

    public MTLRenderPipelineColorAttachmentDescriptor Object(uint attachmentIndex)
    {
        MTLRenderPipelineColorAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArraySelector.Object, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLRenderPipelineColorAttachmentDescriptor attachment, uint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArraySelector.SetObjectAttachmentIndex, attachment.NativePtr, (nint)attachmentIndex);
    }

}

file class MTLRenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectAttachmentIndex = Selector.Register("setObject:attachmentIndex:");
}
