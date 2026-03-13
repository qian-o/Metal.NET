namespace Metal.NET;

public class MTLResourceStatePassSampleBufferAttachmentDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResourceStatePassSampleBufferAttachmentDescriptorArray>
{
    #region INativeObject
    public static new MTLResourceStatePassSampleBufferAttachmentDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceStatePassSampleBufferAttachmentDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveC.AllocInit(MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLResourceStatePassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLResourceStatePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLResourceStatePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
