namespace Metal.NET;

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor? Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public void SetObject(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, attachment.NativePtr, attachmentIndex);
    }
}

file static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
