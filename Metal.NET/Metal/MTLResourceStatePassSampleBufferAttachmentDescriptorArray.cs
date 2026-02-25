namespace Metal.NET;

public class MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLResourceStatePassSampleBufferAttachmentDescriptorArray>
{
    public static MTLResourceStatePassSampleBufferAttachmentDescriptorArray Create(nint nativePtr) => new(nativePtr);

    public static MTLResourceStatePassSampleBufferAttachmentDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return new(nativePtr);
    }

    public void SetObject(MTLResourceStatePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
