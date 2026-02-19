namespace Metal.NET;

public readonly struct MTLComputePassSampleBufferAttachmentDescriptorArray(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLComputePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLComputePassSampleBufferAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLComputePassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);
        return ptr is not 0 ? new MTLComputePassSampleBufferAttachmentDescriptor(ptr) : default;
    }

    public void SetObject(MTLComputePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLComputePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
