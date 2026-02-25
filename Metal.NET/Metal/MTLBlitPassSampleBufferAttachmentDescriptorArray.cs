namespace Metal.NET;

public class MTLBlitPassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBlitPassSampleBufferAttachmentDescriptorArray>
{
    public static MTLBlitPassSampleBufferAttachmentDescriptorArray Create(nint nativePtr) => new(nativePtr);

    public static MTLBlitPassSampleBufferAttachmentDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLBlitPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return new(nativePtr);
    }

    public void SetObject(MTLBlitPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
