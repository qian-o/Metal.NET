namespace Metal.NET;

public partial class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray");

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor? @object(nuint attachmentIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArraySelector.Object, attachmentIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetObject(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArraySelector.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
