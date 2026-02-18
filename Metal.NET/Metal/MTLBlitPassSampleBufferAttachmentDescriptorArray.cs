namespace Metal.NET;

public class MTLBlitPassSampleBufferAttachmentDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBlitPassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        return GetNullableObject<MTLBlitPassSampleBufferAttachmentDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.Object, attachmentIndex));
    }

    public void SetObject(MTLBlitPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLBlitPassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
