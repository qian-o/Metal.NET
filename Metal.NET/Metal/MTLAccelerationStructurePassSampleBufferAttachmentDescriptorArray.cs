namespace Metal.NET;

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray>
{
    public static MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray Create(nint nativePtr) => new(nativePtr);

    public static MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.Class))
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor Object(nuint attachmentIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

        return new(nativePtr);
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
