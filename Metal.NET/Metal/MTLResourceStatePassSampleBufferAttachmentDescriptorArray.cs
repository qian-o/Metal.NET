namespace Metal.NET;

public class MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector.Class))
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        return GetNullableObject<MTLResourceStatePassSampleBufferAttachmentDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector.Object, attachmentIndex));
    }

    public void SetObject(MTLResourceStatePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLResourceStatePassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
