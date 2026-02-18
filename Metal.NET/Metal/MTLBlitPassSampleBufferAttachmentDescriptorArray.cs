namespace Metal.NET;

public class MTLBlitPassSampleBufferAttachmentDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassSampleBufferAttachmentDescriptorArray");

    public MTLBlitPassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
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

    public MTLBlitPassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        MTLBlitPassSampleBufferAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.ObjectAtIndexedSubscript, attachmentIndex));

        return result;
    }

    public void SetObject(MTLBlitPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.SetObjectAtIndexedSubscript, attachment.NativePtr, attachmentIndex);
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

file class MTLBlitPassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
