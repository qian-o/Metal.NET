namespace Metal.NET;

public class MTLBlitPassSampleBufferAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBlitPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return nativePtr is not 0 ? new(nativePtr) : null;
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
