namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");

    public MTLRenderPassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLRenderPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLRenderPassSampleBufferAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassSampleBufferAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassSampleBufferAttachmentDescriptorArray(nint value)
    {
        return new(value);
    }

    public MTLRenderPassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        MTLRenderPassSampleBufferAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArraySelector.ObjectAtIndexedSubscript, attachmentIndex));

        return result;
    }

    public void SetObject(MTLRenderPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorArraySelector.SetObjectAtIndexedSubscript, attachment.NativePtr, attachmentIndex);
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
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
