namespace Metal.NET;

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray>
{
    public static MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.Class), true)
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
