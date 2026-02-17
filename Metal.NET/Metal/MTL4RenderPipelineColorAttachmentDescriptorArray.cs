namespace Metal.NET;

public class MTL4RenderPipelineColorAttachmentDescriptorArray : IDisposable
{
    public MTL4RenderPipelineColorAttachmentDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4RenderPipelineColorAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTL4RenderPipelineColorAttachmentDescriptor Object(uint attachmentIndex)
    {
        MTL4RenderPipelineColorAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArraySelector.Object, (nuint)attachmentIndex));

        return result;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArraySelector.Reset);
    }

    public void SetObject(MTL4RenderPipelineColorAttachmentDescriptor attachment, uint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineColorAttachmentDescriptorArraySelector.SetObjectAttachmentIndex, attachment.NativePtr, (nuint)attachmentIndex);
    }

    public static implicit operator nint(MTL4RenderPipelineColorAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4RenderPipelineColorAttachmentDescriptorArray(nint value)
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

file class MTL4RenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetObjectAttachmentIndex = Selector.Register("setObject:attachmentIndex:");
}
