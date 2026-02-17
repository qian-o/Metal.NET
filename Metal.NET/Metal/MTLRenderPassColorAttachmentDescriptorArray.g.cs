namespace Metal.NET;

file class MTLRenderPassColorAttachmentDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_attachmentIndex_ = Selector.Register("setObject:attachmentIndex:");
}

public class MTLRenderPassColorAttachmentDescriptorArray : IDisposable
{
    public MTLRenderPassColorAttachmentDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLRenderPassColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        var result = new MTLRenderPassColorAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorArraySelector.Object_, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLRenderPassColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorArraySelector.SetObject_attachmentIndex_, attachment.NativePtr, (nint)attachmentIndex);
    }

}
