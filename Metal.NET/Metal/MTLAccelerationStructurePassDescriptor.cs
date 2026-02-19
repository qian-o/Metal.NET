namespace Metal.NET;

public class MTLAccelerationStructurePassDescriptor(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLAccelerationStructurePassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructurePassDescriptorBindings.Class), true)
    {
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLAccelerationStructurePassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLAccelerationStructurePassDescriptor? AccelerationStructurePassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLAccelerationStructurePassDescriptorBindings.Class, MTLAccelerationStructurePassDescriptorBindings.AccelerationStructurePassDescriptor);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }
}

file static class MTLAccelerationStructurePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static readonly Selector AccelerationStructurePassDescriptor = "accelerationStructurePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
