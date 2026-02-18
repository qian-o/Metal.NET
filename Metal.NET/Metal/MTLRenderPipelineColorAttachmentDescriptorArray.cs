namespace Metal.NET;

public class MTLRenderPipelineColorAttachmentDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineColorAttachmentDescriptorArray");

    public MTLRenderPipelineColorAttachmentDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLRenderPipelineColorAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
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

    public MTLRenderPipelineColorAttachmentDescriptor Object(nuint attachmentIndex)
    {
        MTLRenderPipelineColorAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArraySelector.ObjectAtIndexedSubscript, attachmentIndex));

        return result;
    }

    public void SetObject(MTLRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineColorAttachmentDescriptorArraySelector.SetObjectAtIndexedSubscript, attachment.NativePtr, attachmentIndex);
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

file class MTLRenderPipelineColorAttachmentDescriptorArraySelector
{
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
