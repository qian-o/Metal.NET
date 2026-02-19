namespace Metal.NET;

public class MTLAccelerationStructurePassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAccelerationStructurePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassDescriptorBindings.SampleBufferAttachments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(ptr);
            }

            return field;
        }
    }

    public static MTLAccelerationStructurePassDescriptor? AccelerationStructurePassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructurePassDescriptorBindings.Class, MTLAccelerationStructurePassDescriptorBindings.AccelerationStructurePassDescriptor);
        return ptr is not 0 ? new MTLAccelerationStructurePassDescriptor(ptr) : null;
    }
}

file static class MTLAccelerationStructurePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static readonly Selector AccelerationStructurePassDescriptor = Selector.Register("accelerationStructurePassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
