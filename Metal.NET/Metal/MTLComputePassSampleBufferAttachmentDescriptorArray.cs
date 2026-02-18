namespace Metal.NET;

public class MTLComputePassSampleBufferAttachmentDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassSampleBufferAttachmentDescriptorArray");

    public MTLComputePassSampleBufferAttachmentDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLComputePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLComputePassSampleBufferAttachmentDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputePassSampleBufferAttachmentDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePassSampleBufferAttachmentDescriptorArray(nint value)
    {
        return new(value);
    }

    public MTLComputePassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        MTLComputePassSampleBufferAttachmentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArraySelector.ObjectAtIndexedSubscript, attachmentIndex));

        return result;
    }

    public void SetObject(MTLComputePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArraySelector.SetObjectAtIndexedSubscript, attachment.NativePtr, attachmentIndex);
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

file class MTLComputePassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
