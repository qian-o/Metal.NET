namespace Metal.NET;

public readonly struct MTLAccelerationStructurePassDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLAccelerationStructurePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructurePassDescriptorBindings.SampleBufferAttachments);
            return ptr is not 0 ? new MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(ptr) : default;
        }
    }

    public static MTLAccelerationStructurePassDescriptor? AccelerationStructurePassDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructurePassDescriptorBindings.Class, MTLAccelerationStructurePassDescriptorBindings.AccelerationStructurePassDescriptor);
        return ptr is not 0 ? new MTLAccelerationStructurePassDescriptor(ptr) : default;
    }
}

file static class MTLAccelerationStructurePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static readonly Selector AccelerationStructurePassDescriptor = Selector.Register("accelerationStructurePassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
