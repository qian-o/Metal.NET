namespace Metal.NET;

public class MTLTileRenderPipelineColorAttachmentDescriptorArray : IDisposable
{
    public MTLTileRenderPipelineColorAttachmentDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTileRenderPipelineColorAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTileRenderPipelineColorAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTileRenderPipelineColorAttachmentDescriptorArray(nint value)
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

    public MTLTileRenderPipelineColorAttachmentDescriptor Object(uint attachmentIndex)
    {
        var result = new MTLTileRenderPipelineColorAttachmentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArraySelector.Object, (nint)attachmentIndex));

        return result;
    }

    public void SetObject(MTLTileRenderPipelineColorAttachmentDescriptor attachment, uint attachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineColorAttachmentDescriptorArraySelector.SetObjectAttachmentIndex, attachment.NativePtr, (nint)attachmentIndex);
    }

}

file class MTLTileRenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");
    public static readonly Selector SetObjectAttachmentIndex = Selector.Register("setObject:attachmentIndex:");
}
