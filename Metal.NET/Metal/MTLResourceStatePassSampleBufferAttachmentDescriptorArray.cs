namespace Metal.NET;

public readonly struct MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);
        return ptr is not 0 ? new MTLResourceStatePassSampleBufferAttachmentDescriptor(ptr) : default;
    }

    public void SetObject(MTLResourceStatePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
