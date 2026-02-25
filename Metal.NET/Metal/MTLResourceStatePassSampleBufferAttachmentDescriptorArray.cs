namespace Metal.NET;

public class MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLResourceStatePassSampleBufferAttachmentDescriptorArray>
{
    public static MTLResourceStatePassSampleBufferAttachmentDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceStatePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
