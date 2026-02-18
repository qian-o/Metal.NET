namespace Metal.NET;

public partial class MTLBlitPassSampleBufferAttachmentDescriptorArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassSampleBufferAttachmentDescriptorArray");

    public MTLBlitPassSampleBufferAttachmentDescriptorArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptor? @object(nuint attachmentIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.Object, attachmentIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetObject(MTLBlitPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLBlitPassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
