namespace Metal.NET;

public class MTLRenderPassColorAttachmentDescriptorArray : IDisposable
{
    public MTLRenderPassColorAttachmentDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPassColorAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassColorAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassColorAttachmentDescriptorArray(nint value)
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

    public MTLRenderPassColorAttachmentDescriptor Object(uint attachmentIndex)
    {
        MTLRenderPassColorAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassColorAttachmentDescriptorArraySelector.Object, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLRenderPassColorAttachmentDescriptor attachment, uint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorArraySelector.SetObjectAttachmentIndex, attachment.NativePtr, (nint)attachmentIndex);
    }

}

file class MTLRenderPassColorAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectAttachmentIndex = Selector.Register("setObject:attachmentIndex:");
}
